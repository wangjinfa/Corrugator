using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace Corrugator.Client.Wpf.Services;

/// <summary>
/// 登录页本地偏好：记住账号、勾选「保存密码 / 自动登录」。
/// 密码用 Windows DPAPI（CryptProtectData）按当前用户加密后落盘，
/// 文件被拷到别的机器/别的用户下无法解密，不会变成明文密码文件。
/// 存放：%LOCALAPPDATA%\Corrugator\login.json
/// </summary>
public static class LoginPreferences
{
    public class Data
    {
        public string Account { get; set; } = string.Empty;
        public string PasswordCipher { get; set; } = string.Empty;
        public bool SavePassword { get; set; }
        public bool AutoLogin { get; set; }
    }

    private static string FilePath
    {
        get
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Corrugator");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, "login.json");
        }
    }

    public static Data Load()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                return new Data();
            }

            var json = File.ReadAllText(FilePath, Encoding.UTF8);
            var data = JsonSerializer.Deserialize<Data>(json) ?? new Data();
            return data;
        }
        catch
        {
            return new Data();
        }
    }

    public static void Save(Data data)
    {
        try
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(data), Encoding.UTF8);
        }
        catch
        {
            // 存偏好失败不影响登录
        }
    }

    /// <summary>把已保存的密码解出来；没有或不是本机加密的返回 null</summary>
    public static string? ReadPassword(Data data)
    {
        if (string.IsNullOrEmpty(data.PasswordCipher))
        {
            return null;
        }

        try
        {
            return Unprotect(data.PasswordCipher);
        }
        catch
        {
            return null;
        }
    }

    public static void WritePassword(Data data, string password)
    {
        data.PasswordCipher = string.IsNullOrEmpty(password) ? string.Empty : Protect(password);
    }

    // ---------- DPAPI（crypt32） ----------
    [StructLayout(LayoutKind.Sequential)]
    private struct DATA_BLOB
    {
        public int cbData;
        public IntPtr pbData;
    }

    [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool CryptProtectData(
        ref DATA_BLOB pDataIn, string? szDataDescr, IntPtr pOptionalEntropy,
        IntPtr pvReserved, IntPtr pPromptStruct, int dwFlags, ref DATA_BLOB pDataOut);

    [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool CryptUnprotectData(
        ref DATA_BLOB pDataIn, IntPtr ppszDataDescr, IntPtr pOptionalEntropy,
        IntPtr pvReserved, IntPtr pPromptStruct, int dwFlags, ref DATA_BLOB pDataOut);

    [DllImport("kernel32.dll")]
    private static extern IntPtr LocalFree(IntPtr hMem);

    private static string Protect(string plain)
    {
        var bytes = Encoding.UTF8.GetBytes(plain);
        var blob = ToBlob(bytes);
        var outBlob = new DATA_BLOB();
        try
        {
            if (!CryptProtectData(ref blob, "corrugator-login", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, ref outBlob))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            var outBytes = FromBlob(outBlob);
            return Convert.ToBase64String(outBytes);
        }
        finally
        {
            FreeBlob(blob);
            FreeBlob(outBlob);
        }
    }

    private static string Unprotect(string cipherBase64)
    {
        var bytes = Convert.FromBase64String(cipherBase64);
        var blob = ToBlob(bytes);
        var outBlob = new DATA_BLOB();
        try
        {
            if (!CryptUnprotectData(ref blob, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, ref outBlob))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return Encoding.UTF8.GetString(FromBlob(outBlob));
        }
        finally
        {
            FreeBlob(blob);
            FreeBlob(outBlob);
        }
    }

    private static DATA_BLOB ToBlob(byte[] data)
    {
        var blob = new DATA_BLOB { cbData = data.Length, pbData = Marshal.AllocHGlobal(data.Length) };
        Marshal.Copy(data, 0, blob.pbData, data.Length);
        return blob;
    }

    private static byte[] FromBlob(DATA_BLOB blob)
    {
        var bytes = new byte[blob.cbData];
        Marshal.Copy(blob.pbData, bytes, 0, blob.cbData);
        return bytes;
    }

    private static void FreeBlob(DATA_BLOB blob)
    {
        if (blob.pbData != IntPtr.Zero)
        {
            LocalFree(blob.pbData);
        }
    }
}
