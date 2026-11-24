# 一键编译 + 校验清单 + 启动 WPF 客户端（Windows PowerShell 5.1 / 7 均可）
# 用法：在项目根目录或任意位置执行
#   powershell -ExecutionPolicy Bypass -File tools\run-client.ps1
#   powershell -ExecutionPolicy Bypass -File tools\run-client.ps1 -Configuration Debug
param(
    [string]$Configuration = "Release",
    [switch]$NoLaunch
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
Push-Location $root
try {
    Write-Host "[1/4] 检查 .NET 桌面运行时 ..." -ForegroundColor Cyan
    $runtimes = & dotnet --list-runtimes 2>$null
    if (-not ($runtimes | Where-Object { $_ -match "Microsoft.WindowsDesktop.App 8\." })) {
        Write-Warning "未检测到 Microsoft.WindowsDesktop.App 8.x（WPF 必需）。请安装 Windows Desktop Runtime 8 (x64)。"
    } else {
        $runtimes | Where-Object { $_ -match "Microsoft.WindowsDesktop.App 8\." } | ForEach-Object { Write-Host "    $_" }
    }

    Write-Host "[2/4] 编译 Corrugator.Client.Wpf ($Configuration) ..." -ForegroundColor Cyan
    & dotnet build "src/Corrugator.Client.Wpf/Corrugator.Client.Wpf.csproj" -c $Configuration
    if ($LASTEXITCODE -ne 0) { throw "编译失败，见上方输出。" }

    # 项目名是 Corrugator.Client.Wpf，但 csproj 里 AssemblyName=Corrugator.Client，产物名以此为准
    $exe = Join-Path $root "src/Corrugator.Client.Wpf/bin/$Configuration/net8.0-windows/Corrugator.Client.exe"
    if (-not (Test-Path $exe)) {
        throw "未找到产物：$exe（请确认 -c $Configuration 编译成功）"
    }

    Write-Host "[3/4] 校验内嵌清单（RT_MANIFEST）..." -ForegroundColor Cyan
    $bytes = [System.IO.File]::ReadAllBytes($exe)
    $ascii = [System.Text.Encoding]::ASCII.GetString($bytes)
    if ($ascii.Contains("urn:schemas-microsoft-com:asm.v1")) {
        Write-Host "    清单 OK：urn:schemas-microsoft-com:asm.v1" -ForegroundColor Green
    } else {
        throw "exe 内嵌清单不正确（应为 asm.v1 命名空间）。若刚改过 app.manifest，请先清理 bin/obj 再编译。"
    }
    if ($ascii.Contains("winfx/2006/xaml/presentation")) {
        Write-Warning "检测到 XAML 命名空间残留在 exe 中，清单可能仍是旧版本。"
    }

    Write-Host "[4/4] 启动客户端 ..." -ForegroundColor Cyan
    Write-Host "    exe = $exe"
    Write-Host "    提示：请先启动后端 API（dotnet run --project src/Corrugator.Api，默认 http://localhost:5099）" -ForegroundColor Yellow
    if (-not $NoLaunch) { Start-Process -FilePath $exe }
}
finally {
    Pop-Location
}
