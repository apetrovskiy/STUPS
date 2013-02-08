# ipmo UIAutomation.dll
$global:annals = New-Object System.Collections.ArrayList;
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem | Register-UIAMenuOpenedEvent -EventAction { param($src, $e) $global:annals.Add("opened:"); $global:annals.Add($src.Current.Name); $global:annals.Add($e.EventId); };
Get-UIAMenuItem | Register-UIAMenuClosedEvent -EventAction { param($src, $e) $global:annals.Add("closed:"); $global:annals.Add($src.Current.Name); $global:annals.Add($src.Cached.Name); $global:annals.Add($e.EventId); };
Get-UIAMenuItem -Name view | Invoke-UIAMenuItemExpand;
Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand;
Get-UIAMenuItem -Name edit | Invoke-UIAMenuItemExpand;
sleep -Seconds 2;
$global:annals;


