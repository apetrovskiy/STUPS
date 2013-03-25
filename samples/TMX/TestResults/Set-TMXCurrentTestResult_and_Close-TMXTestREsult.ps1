ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
New-TMXTestSuite -Name ts1 -Description ts0001 -Id 1 | Add-TMXTestScenario -Description tsc0001 -Name tsc1 -Id 11
Add-TMXTestResultDetail "detail 01"
Set-TMXCurrentTestResult -Description tr0001 -TestResultName tr1 -Id 111
Add-TMXTestResultDetail "detail 02"
Close-TMXTestResult -TestPassed
Add-TMXTestResultDetail "detail 03"
Close-TMXTestResult -TestPassed -TestResultName tr2 -Id 222 -Verbose
Add-TMXTestResultDetail "detail 04"
Close-TMXTestResult -TestPassed -Verbose

