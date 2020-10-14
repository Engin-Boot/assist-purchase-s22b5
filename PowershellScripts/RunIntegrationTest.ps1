function Kill-Tree {
    Param([int]$ppid)
    Get-CimInstance Win32_Process | Where-Object { $_.ParentProcessId -eq $ppid } | ForEach-Object { Kill-Tree $_.ProcessId }
    Stop-Process -Id $ppid
}

$serverProcess = Start-Process powershell -ArgumentList ".\PowershellScripts\RunServer.ps1" -PassThru;

Write-Host "Started sleeping"
Start-Sleep -Seconds 20
Write-Host "done sleeping"

dotnet test --filter "DisplayName~ProductControllerIntegrationTest|DisplayName~ChatAppControllerIntegrationTest" --no-restore --verbosity normal

Write-Host "test completed"
Start-Sleep -Seconds 5
Kill-Tree $serverProcess.Id