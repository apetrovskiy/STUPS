Write-Host "pipelined from Get-Process"
Get-Process powershell,winlogon,explorer | Get-TamsMemorySnapshot;
Write-Host "taken by name"
Get-TamsMemorySnapshot powershell,winlogon,explorer;
Write-Host "taken by name"
Get-TamsMemorySnapshot -ProcessName powershell,winlogon,explorer;
Write-Host "taken by Id"
Get-TamsMemorySnapshot -ProcessId (Get-Process powershell,winlogon,explorer | %{ $_.Id; });
Write-Host "taken by Process"
Get-TamsMemorySnapshot -InputObject (Get-Process powershell,winlogon,explorer);