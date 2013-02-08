ipmo C:\Projects\PS\STUPS\UIAutomationSpy\bin\Release35\UIAutomation.dll
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1
[UIAutomation.Preferences]::Timeout
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 10
[UIAutomation.Preferences]::Timeout
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 10 -IsCritical #-Verbose
[UIAutomation.Preferences]::Timeout
[UIAutomation.CurrentData]::LastResult
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1 #-Verbose
[UIAutomation.Preferences]::Timeout
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1 -IsCritical
[UIAutomation.Preferences]::Timeout

