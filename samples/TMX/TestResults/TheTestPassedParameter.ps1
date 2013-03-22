ipmo C:\Projects\PS\STUPS\UIAutomation\bin\Release35\UIAutomation.dll
ipmo C:\Projects\PS\STUPS\TMX\bin\Release35\TMX.dll

# passed
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -n 1 -TestResultName "button 1" -TestPassed

# failed (cmdlet failed)
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -n 10 -TestResultName "button 10" -TestPassed -Sec 1

Search-TMXTestResult



