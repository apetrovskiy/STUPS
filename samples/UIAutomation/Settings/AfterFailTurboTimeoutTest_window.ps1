ipmo C:\Projects\PS\STUPS\UIAutomationSpy\bin\Release35\UIAutomation.dll
Start-Process calc -PassThru | Get-UIAWindow;
[UIAutomation.Preferences]::Timeout
[UIAutomation.Preferences]::AfterFailTurboTimeout
Get-UIAWindow -Name calc1
[UIAutomation.Preferences]::Timeout
[UIAutomation.Preferences]::AfterFailTurboTimeout
Get-UIAWindow -Name calc*
[UIAutomation.Preferences]::Timeout
[UIAutomation.Preferences]::AfterFailTurboTimeout

