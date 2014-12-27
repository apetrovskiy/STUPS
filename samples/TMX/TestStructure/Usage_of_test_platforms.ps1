ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll

New-TmxTestPlatform -Name p1;
New-TmxTestSuite -Id p01 -Name "test suite p01" | Add-TmxTestScenario "scenario p01";
$null = Close-TmxTestResult "test p001" -TestPassed;
$null = Close-TmxTestResult "test p002" -TestPassed:$false;
$null = New-TmxTestPlatform -Name p2;
$null = New-TmxTestSuite -Id p01 -Name "test suite p01" | Add-TmxTestScenario "scenario p01";





ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
$null = New-TmxTestSuite -Id 10000 -Name "test suite 0100" | Add-TmxTestScenario "scenario 0100";
$null = Close-TmxTestResult "test 00100" -TestPassed;
$null = New-TmxTestSuite -Id p001 -Name "test suite p001" -TestPlatformId 3 | Add-TmxTestScenario "scenario p001";
$null = Close-TmxTestResult "test p0001" -TestPassed;
$null = Close-TmxTestResult "test p0002" -TestPassed:$false;
$null = New-TmxTestSuite -Id p001 -Name "test suite p001" -TestPlatformId 4 | Add-TmxTestScenario "scenario p001";
$null = Close-TmxTestResult "test p0001" -TestPassed;
$null = Close-TmxTestResult "test p0002" -TestPassed:$false;






