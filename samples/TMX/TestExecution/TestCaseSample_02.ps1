New-TMXTestSuite "suite02" -Id 002 -BeforeScenario { param($b1, $b2, $b3) "before scenario script 1. $($b1) 2. $($b2) 3. $($b3)"; } -AfterScenario { param($a1, $a2, $a3) "after scenario script 1. $($a1) 2. $($a2) 3. $($a3)"; };
Add-TMXTestScenario "sc002" -Id 0002 -BeforeTest { "before test script"; } -AfterTest { "after test script"; } ;
Add-TMXTestCase -TestCaseName "tc04" -Id 00004 -TestCode { "test 00004"; } ;
Add-TMXTestCase -TestCaseName "tc05" -Id 00005 -TestCode { "test 00005"; } ;
Add-TMXTestCase -TestCaseName "tc06" -Id 00006 -TestCode { "test 00006"; } ;

Invoke-TMXTestSuite -Id 002 -BeforeScenarioParameters @(1,2,3) -AfterScenarioParameters @(4,5,6);
[TMX.TestData]::CurrentTestSuite | FL dbid,id,name;
[TMX.TestData]::CurrentTestScenario | FL dbid,id,name;
[TMX.TestData]::CurrentTestResult | FL dbid,id,name;