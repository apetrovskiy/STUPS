ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\TMX.dll
ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\UIAutomation.dll
[UIAutomation.Preferences]::EveryCmdletAsTestResult=$true
[UIAutomation.Preferences]::OnSuccessDelay = 0;
Start-Process calc -PassThru | Get-UIAWindow -Verbose | Get-UIAButton -Name 1 -Verbose | Invoke-UIAButtonClick;
Search-TMXTestResult
