ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
$null = New-TMXTestSuite -Name 'suite1' | Add-TMXTestScenario -Name 'sc1';
Set-TMXCurrentTestResult 'tr1' -Id 001;
Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;
[TMX.TestData]::TestSuites | %{ $_.TestScenarios | %{ $_.TestResults; } }
Get-TMXTestResultDetails
Get-TMXTestResultStatus
[TMX.TestData]::TestSuites | %{ $_.TestScenarios | %{ $_.TestResults; } }
$null = Add-TMXTestScenario -Name 'sc2'
[TMX.TestData]::TestSuites | %{ $_.TestScenarios | %{ $_.TestResults; } }
Get-TMXTestResultStatus
[TMX.TestData]::CurrentTestResult

[TMX.TestData]::TestSuites | %{ $_.TestScenarios | %{ $_.TestResults; } }





