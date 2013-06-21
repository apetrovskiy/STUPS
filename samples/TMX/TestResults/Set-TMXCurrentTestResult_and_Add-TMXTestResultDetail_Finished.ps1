ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
Set-TMXCurrentTestResult "tr1" -Id 11
Add-TMXTestResultDetail "d1" -TestResultStatus Failed -Finished
Set-TMXCurrentTestResult "tr2" -Id 12
Add-TMXTestResultDetail "d2" -TestResultStatus Passed -Finished
Set-TMXCurrentTestResult "tr3" -Id 13
Add-TMXTestResultDetail "d2" -TestResultStatus KnownIssue -Finished
Set-TMXCurrentTestResult "tr4" -Id 14
Add-TMXTestResultDetail "d2" -TestResultStatus NotTested -Finished
Search-TMXTestResult
(Search-TMXTestResult).Count

