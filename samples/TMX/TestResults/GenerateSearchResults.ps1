ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\TMX.dll
Set-TMXCurrentTestResult -Id 111
Add-TMXTestResultDetail "1"
Add-TMXTestResultDetail "2"
Close-TMXTestResult
Search-TMXTestResult

Set-TMXCurrentTestResult -Id 222
Add-TMXTestResultDetail "1"
Add-TMXTestResultDetail "2"
Set-TMXCurrentTestResult -Id 333
Search-TMXTestResult

Get-UIAWindow -n hjhl
Set-TMXCurrentTestResult -Id 444

