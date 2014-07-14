ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
$null = New-TmxTestSuite -Name suite01 | Add-TmxTestScenario -Name sc01;
Set-TmxCurrentTestResult tr1 -Id 001
Add-TmxTestResultDetail 'det 01' -TestResultStatus Passed;
Add-TmxTestResultDetail 'det 02' -TestResultStatus Passed -Finished;
$null = New-TmxTestSuite -Name suite02 | Add-TmxTestScenario -Name sc02;
$null = Open-TmxTestSuite -Name suite01;
Get-TmxTestResultStatus -Id 001



