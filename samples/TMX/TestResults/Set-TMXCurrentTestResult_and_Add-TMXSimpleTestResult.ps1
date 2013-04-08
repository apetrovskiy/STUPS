ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
Set-TMXCurrentTestResult -TestResultName "tr01" -id 0001
Add-TMXSimpleTestResult -TestResultName "tr02" -Id 0002 -TestResultStatus Failed
Add-TMXTestResultDetail "detail 01"
Add-TMXTestResultDetail "detail 02" -TestResultStatus Passed
Set-TMXCurrentTestResult -TestResultName "tr03" -Id 0003
Search-TMXTestResult
