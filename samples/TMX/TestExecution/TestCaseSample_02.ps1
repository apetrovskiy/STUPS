ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

$null = New-TMXTestSuite "suite02" -Id 002 -BeforeScenario { Write-Host "1111"; },{ param($b1, $b2, $b3) Write-Host "before scenario script 1. $($b1) 2. $($b2) 3. $($b3)"; } -AfterScenario { Write-Host "2222"; },{ param($a1, $a2, $a3) Write-Host "after scenario script 1. $($a1) 2. $($a2) 3. $($a3)"; };
$null = Add-TMXTestScenario "sc002" -Id 0002 -BeforeTest { Write-Host "3333"; },{ Write-Host "before test script"; } -AfterTest { Write-Host "4444"; },{ Write-Host "after test script"; } ;
$null = Add-TMXTestCase -TestCaseName "tc04" -Id 00004 -TestCode { "test 00004"; } ;
$null = Add-TMXTestCase -TestCaseName "tc05" -Id 00005 -TestCode { "test 00005"; } ;
$null = Add-TMXTestCase -TestCaseName "tc06" -Id 00006 -TestCode { "test 00006"; } ;

Invoke-TMXTestSuite -Id 002 -BeforeScenarioParameters @(1,2,3) -AfterScenarioParameters @(4,5,6);
[TMX.TestData]::CurrentTestSuite | FL dbid,id,name;
[TMX.TestData]::CurrentTestScenario | FL dbid,id,name;
[TMX.TestData]::CurrentTestResult | FL dbid,id,name;