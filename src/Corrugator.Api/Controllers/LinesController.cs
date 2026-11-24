using Corrugator.Application.Abstractions;
using Corrugator.Infrastructure.MultiLine;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Lines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

/// <summary>瓦线配置：读取 BaseDB.TB_Line，支持热刷新（改完配置不用重启）</summary>
[ApiController]
[Route("api/lines")]
[Authorize]
public class LinesController : ControllerBase
{
    private readonly ILineRegistry _registry;
    private readonly LineDbProvider _provider;
    private readonly ILineContext _context;

    public LinesController(ILineRegistry registry, LineDbProvider provider, ILineContext context)
    {
        _registry = registry;
        _provider = provider;
        _context = context;
    }

    /// <summary>线路列表（不含连接串），供客户端下拉与当前线路提示</summary>
    [HttpGet]
    public async Task<ApiResult<List<LineDto>>> List()
    {
        var lines = (await _registry.GetLinesAsync()).ToList();
        var current = string.IsNullOrWhiteSpace(_context.LineCode) ? await _registry.GetDefaultCodeAsync() : _context.LineCode;
        foreach (var line in lines)
        {
            line.IsDefault = string.Equals(line.Code, current, StringComparison.OrdinalIgnoreCase);
        }

        return ApiResult<List<LineDto>>.Ok(lines);
    }

    /// <summary>重新读取 TB_Line 并重建多库路由（现场新增瓦线后调用）</summary>
    [HttpPost("reload")]
    public async Task<ApiResult<List<LineDto>>> Reload()
    {
        var isAdmin = User.IsInRole("admin");
        var hasPermission = User.HasClaim("perm", "lines:reload");
        if (!isAdmin && !hasPermission)
        {
            return ApiResult<List<LineDto>>.Fail("无权限刷新瓦线配置（需要 admin 角色或 lines:reload 权限）", 403);
        }

        await _provider.ReloadAsync();
        var lines = (await _registry.GetLinesAsync()).ToList();
        return ApiResult<List<LineDto>>.Ok(lines, "线路配置已刷新");
    }
}
