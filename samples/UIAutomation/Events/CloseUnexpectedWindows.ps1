# run powershell as Administrator

services.msc
ipmo [path]\UIAutomation.dll
Get-UIAWindow -Name Services | Register-UIAWindowOpenedEvent -EventAction { param($src, $e) try {Get-UIAWindow -Name Services | Get-UIAChildWindow -Name $src.Current.Name | Get-UIAButton -Name * | Invoke-UIAButtonClick; } catch {} }


