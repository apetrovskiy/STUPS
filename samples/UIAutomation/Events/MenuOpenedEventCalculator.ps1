# ipmo UIAutomation
$global:annals = New-Object System.Collections.ArrayList;
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem | Register-UIAMenuOpenedEvent -EventAction { param($src, $e) $global:annals.Add($src.Current.Name); $global:annals.Add($e.EventId); }
Get-UIAMenuItem -Name view | Invoke-UIAMenuItemExpand;
Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand;
Get-UIAMenuItem -Name edit | Invoke-UIAMenuItemExpand;
sleep -Seconds 1;
$global:annals;


