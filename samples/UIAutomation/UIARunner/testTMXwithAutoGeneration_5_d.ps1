sleep -Seconds 10;

ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\TMX.dll
ipmo C:\Projects\PS\UIAutomation.Old\UIAutomationSpy\bin\Release35\UIAutomation.dll

[UIAutomation.Preferences]::EveryCmdletAsTestResult=$true
[UIAutomation.Preferences]::OnSuccessDelay = 0;

Start-Process calc
Get-UIAWindow -n calc* | `
	Get-UIAMenuItem -n Vi* | Invoke-UIAMenuItemExpand | `
	Get-UIAMenuItem -n Stand* | Invoke-UIAMenuItemClick;

"test started $([System.DateTime]::Now)" >> C:\1\UIARunner_test.txt;

for ($i = 1; $i -le 1000; $i++) {
	Get-UIAWindow -n calc* | Get-UIAButton -n 1 | Invoke-UIAButtonClick;
	Get-UIAButton -n add | Invoke-UIAButtonClick;
	Get-UIAButton -n 1 | Invoke-UIAButtonClick;
	Get-UIAButton -n Equals | Invoke-UIAButtonClick;
	#Get-UIAButton | Set-UIAFocus | Set-UIAControlKeys -Text "2{+}2{=}"
	try {
		Get-UIAButton -n 10 -Seconds 1;
	}
	catch {}
	Get-UIAButton -n 'Clear entry' | Invoke-UIAButtonClick;
	#"$($i) times done" >> C:\1\UIARunner_test.txt;
}

"test stopped $([System.DateTime]::Now)" >> C:\1\UIARunner_test.txt;

Stop-Process -Name calc

Search-TMXTestResult
Export-TMXTestResults -As HTML -Path c:\1\calc_test_results_generated.htm
c:\1\calc_test_results_generated.htm