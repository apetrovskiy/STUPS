ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
Set-TMXCurrentTestResult "tr 1" -Id 1 -TestOrigin Technical
Add-TMXSimpleTestResult "tr 2" -Id 2 -TestResultStatus Passed -TestOrigin Technical
Add-TMXSimpleTestResult "tr 3" -Id 3 -TestResultStatus Passed -TestOrigin Logical
Add-TMXSimpleTestResult "tr 4" -Id 4 -TestResultStatus Passed
Add-TMXSimpleTestResult "tr 5" -Id 5 -TestResultStatus Failed
Add-TMXSimpleTestResult "tr 6" -Id 6 -TestResultStatus KnownIssue
Set-TMXCurrentTestResult "tr 7" -Id 7 -TestOrigin Technical
Close-TMXTestResult "tr 8" -Id 8 -TestPassed -TestOrigin Technical
Close-TMXTestResult "tr 9" -Id 9 -TestResultStatus Passed -TestOrigin Technical
Close-TMXTestResult "tr 10" -Id 10 -TestPassed -TestOrigin Technical
Search-TMXTestResult | fl id,name,status,origin

