ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\TMX.dll
Set-TMXCurrentTestResult -Id 01
Add-TMXTestResultDetail "1"
Add-TMXTestResultDetail "2"
Close-TMXTestResult -Id 111
Search-TMXTestResult

Set-TMXCurrentTestResult -Id 02
Add-TMXTestResultDetail "1"
Add-TMXTestResultDetail "2"
Set-TMXCurrentTestResult -Id 03
Add-TMXTestResultDetail "1" -TestResultStatus Failed
Add-TMXTestResultDetail "2"
Set-TMXCurrentTestResult -Id 04
Add-TMXTestResultDetail "1" -TestResultStatus Passed
Add-TMXTestResultDetail "2"
Set-TMXCurrentTestResult -Id 05
Add-TMXTestResultDetail "1" -TestResultStatus KnownIssue
Add-TMXTestResultDetail "2"
Set-TMXCurrentTestResult -Id 06
Search-TMXTestResult
Get-UIAWindow -n "no such window"
Set-TMXCurrentTestResult -Id 07

cls
Search-TMXTestResult
