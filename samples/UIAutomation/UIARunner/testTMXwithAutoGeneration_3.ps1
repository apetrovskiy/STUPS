ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\TMX.dll
ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\UIAutomation.dll
[UIAutomation.Preferences]::EveryCmdletAsTestResult=$true
[UIAutomation.Preferences]::OnSuccessDelay = 0;

Start-Process calc
Get-UIAWindow -n calc* | Get-UIAButton -n 1 | Invoke-UIAButtonClick;
(Get-UIAButton -n add | Invoke-UIAButtonClick).Current.AutomationId;
(Get-UIAButton -n 1 | Invoke-UIAButtonClick).Current | Out-String;
Get-UIAWindow -n calc* | Get-UIAButton | Set-UIAFocus | Set-UIAControlKeys -Text "1{+}1{=}"
'Get-UIAWindow -n calc* | Out-String; ->'
Get-UIAWindow -n calc* | Out-String;
'(Get-UIAWindow -n calc*).Current | Out-String;'
(Get-UIAWindow -n calc*).Current | Out-String;

#'Write-Host:'
#Write-Host 'Write-Host';
#$VerbosePreference = [System.Management.Automation.ActionPreference]::Continue;
#'Write-Verbose:'
#Write-Verbose 'Write-Verbose';
#'Out-Host:'
#'Out-Host' | Out-Host;


"now test should fail"
Get-UIAWindow -n "non-existing window" -Seconds 2
Get-UIAWindow -n calc* | Get-UIAButton -n 10 | Invoke-UIAButtonClick;

Stop-Process -Name calc

Search-TMXTestResult
Export-TMXTestResults -As HTML -Path c:\1\calc_test_results_generated.htm
c:\1\calc_test_results_generated.htm