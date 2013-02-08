ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\TMX.dll
ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\UIAutomation.dll
[UIAutomation.Preferences]::EveryCmdletAsTestResult=$true
[UIAutomation.Preferences]::OnSuccessDelay = 0;
Start-Process calc
Get-UIAWindow -n calc* | Get-UIAButton -n 1 | Invoke-UIAButtonClick;
Get-UIAWindow -n calc* | Get-UIAButton -n add | Invoke-UIAButtonClick;
Get-UIAWindow -n calc* | Get-UIAButton -n 1 | Invoke-UIAButtonClick;
Get-UIAWindow -n calc* | Get-UIAButton | Set-UIAFocus | Set-UIAControlKeys -Text "1{+}1{=}"

Search-TMXTestResult
Export-TMXTestResults -As HTML -Path c:\1\calc_test_results_generated.htm
c:\1\calc_test_results_generated.htm