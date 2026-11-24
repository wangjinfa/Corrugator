using Corrugator.Shared.Api;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Corrugator.Client.Wpf.Services;

/// <summary>
/// 统一的 API 调用封装：自动带 Bearer Token、统一解析 ApiResult、把网络异常转成可提示的消息。
/// ViewModel 里只写 await _api.GetAsync&lt;OrderDto&gt;("api/orders/1") 即可。
/// </summary>
public class ApiClient
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _json = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = null,
    };

    private string? _token;
    private string? _lineCode;

    public ApiClient()
    {
        var handler = new HttpClientHandler
        {
            // 客户端同样只允许 TLS 1.2 / 1.3，避免在旧 Windows 上被协商降到 TLS 1.0
            SslProtocols = System.Security.Authentication.SslProtocols.Tls12
                           | System.Security.Authentication.SslProtocols.Tls13,
            AutomaticDecompression = System.Net.DecompressionMethods.GZip
                                     | System.Net.DecompressionMethods.Deflate,
        };

        _http = new HttpClient(handler)
        {
            BaseAddress = new Uri(AppConfig.BaseUrl),
            Timeout = TimeSpan.FromSeconds(30),
        };
    }

    public void SetToken(string? token) => _token = token;

    /// <summary>设置当前瓦线：之后所有请求自动带 X-Line-Code 头，后端据此路由到该线路的库</summary>
    public void SetLine(string? lineCode) => _lineCode = lineCode;

    public Task<ApiResult<T>> GetAsync<T>(string path) => SendAsync<T>(HttpMethod.Get, path, null, null);

    public Task<ApiResult<T>> GetAsync<T>(string path, IDictionary<string, string?> query)
        => SendAsync<T>(HttpMethod.Get, path, null, query);

    public Task<ApiResult<T>> PostAsync<T>(string path, object? body = null) => SendAsync<T>(HttpMethod.Post, path, body, null);

    public Task<ApiResult<T>> PutAsync<T>(string path, object? body = null) => SendAsync<T>(HttpMethod.Put, path, body, null);

    public Task<ApiResult<T>> DeleteAsync<T>(string path) => SendAsync<T>(HttpMethod.Delete, path, null, null);

    private async Task<ApiResult<T>> SendAsync<T>(
        HttpMethod method,
        string path,
        object? body,
        IDictionary<string, string?>? query)
    {
        var url = BuildUrl(path, query);
        var request = new HttpRequestMessage(method, url);

        if (body is not null)
        {
            request.Content = new StringContent(
                JsonSerializer.Serialize(body, _json), Encoding.UTF8, "application/json");
        }

        if (_token is not null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        if (!string.IsNullOrWhiteSpace(_lineCode))
        {
            request.Headers.Add("X-Line-Code", _lineCode);
        }

        try
        {
            using var response = await _http.SendAsync(request);
            var payload = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return ApiResult<T>.Unauthorized();
            }

            if (string.IsNullOrWhiteSpace(payload))
            {
                return ApiResult<T>.Fail($"接口无返回内容（HTTP {response.StatusCode}）");
            }

            var result = JsonSerializer.Deserialize<ApiResult<T>>(payload, _json);
            if (result is null)
            {
                return ApiResult<T>.Fail($"接口返回格式异常：{payload[..Math.Min(payload.Length, 200)]}");
            }

            if (!result.Success)
            {
                return ApiResult<T>.Fail(result.Message ?? "接口返回失败", result.Code == 0 ? -1 : result.Code);
            }

            return result;
        }
        catch (TaskCanceledException)
        {
            return ApiResult<T>.Fail("请求超时，请检查后端服务或网络");
        }
        catch (HttpRequestException ex)
        {
            return ApiResult<T>.Fail($"无法连接后端服务（{AppConfig.BaseUrl}）：{ex.Message}");
        }
        catch (JsonException ex)
        {
            return ApiResult<T>.Fail($"接口返回解析失败：{ex.Message}");
        }
    }

    private static string BuildUrl(string path, IDictionary<string, string?>? query)
    {
        if (query is null || query.Count == 0)
        {
            return path;
        }

        var builder = new StringBuilder(path);
        var first = !path.Contains('?');
        foreach (var item in query)
        {
            if (string.IsNullOrEmpty(item.Value))
            {
                continue;
            }

            builder.Append(first ? '?' : '&');
            first = false;
            builder.Append(Uri.EscapeDataString(item.Key));
            builder.Append('=');
            builder.Append(Uri.EscapeDataString(item.Value!));
        }

        return builder.ToString();
    }
}
