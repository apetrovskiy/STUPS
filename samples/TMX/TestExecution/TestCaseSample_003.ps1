ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

# BeforeScenario scriptblocks are running before every test scenario
# AfterScenario scriptblocks are running after every test scenario
$null = New-TMXTestSuite "suite01" -Id 001 -BeforeScenario { 'before scenario script 1' | Out-Host; },{ "before scenario script 2" | Out-Host; } `
    -AfterScenario { 'after scenario script 1' | Out-Host; },{ "after scenario script 2" | Out-Host; };

# BeforeTest scriptblocks are running before every test in the test scenario
# AfterTest scriptblocks are running after every test in the test scenario
$null = Add-TMXTestScenario "sc001" -Id 0001 -BeforeTest { "before test script 1" | Out-Host; },{ "before test script 2" | Out-Host; } `
    -AfterTest { "after test script 1" | Out-Host; },{ "after test script 2" | Out-Host; };
$null = Add-TMXTestCase -TestCaseName "tc01" -Id 00001 -TestCode { "test 01" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc01" -Id 00002 -TestCode { "test 02" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc01" -Id 00003 -TestCode { "test 03" | Out-Host; } ;

# BeforeTest scriptblocks are running before every test in the test scenario
# AfterTest scriptblocks are running after every test in the test scenario
$null = Add-TMXTestScenario "sc002" -Id 0002 -BeforeTest { "before test script 3" | Out-Host; },{ "before test script 4" | Out-Host; } `
    -AfterTest { "after test script 3" | Out-Host; },{ "after test script 4" | Out-Host; };
$null = Add-TMXTestCase -TestCaseName "tc04" -Id 00004 -TestCode { "test 04" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc05" -Id 00005 -TestCode { "test 05" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc06" -Id 00006 -TestCode { "test 06" | Out-Host; } ;

Invoke-TMXTestSuite -Id 001; # -Verbose;
[TMX.TestData]::CurrentTestSuite | FL dbid,id,name;
[TMX.TestData]::CurrentTestScenario | FL dbid,id,name;
[TMX.TestData]::CurrentTestResult | FL dbid,id,name;
