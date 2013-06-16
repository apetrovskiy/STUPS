ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

$null = New-TMXTestSuite "suite01" -Id 001 `
    -BeforeScenario { 'before scenario script (no parameters)' | Out-Host; },
        { param($bs1, $bs2, $bs3) "before scenario script 1. «$($bs1)» 2. «$($bs2)» 3. «$($bs3)»" | Out-Host; } `
    -AfterScenario { 'after scenario script (no parameters)' | Out-Host; },
        { param($as1, $as2, $as3) "after scenario script 1. «$($as1)» 2. «$($as2)» 3. «$($as3)»" | Out-Host; };

$null = Add-TMXTestScenario "sc001" -Id 0001 `
    -BeforeTest { 'before test script (no parameters)' | Out-Host; },
        { param($bt1, $bt2, $bt3) "before test script 1. «$($bt1)» 2. «$($bt2)» 3. «$($bt3)»" | Out-Host; } `
    -AfterTest { 'after test script (no parameters)' | Out-Host; },
        { param($at1, $at2, $at3) "after test script 1. «$($at1)» 2. «$($at2)» 3. «$($at3)»" | Out-Host; } ;

$null = Add-TMXTestCase -TestCaseName "tc04" -Id 00001 -TestCode { "test 01" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc05" -Id 00002 -TestCode { "test 02" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc06" -Id 00003 -TestCode { "test 03" | Out-Host; } ;

$null = Add-TMXTestScenario "sc002" -Id 0002 `
    -BeforeTest { 'before test script (no parameters)' | Out-Host; },
        { param($bt1, $bt2, $bt3) "before test script 1. «$($bt1)» 2. «$($bt2)» 3. «$($bt3)»" | Out-Host; } `
    -AfterTest { 'after test script (no parameters)' | Out-Host; },
        { param($at1, $at2, $at3) "after test script 1. «$($at1)» 2. «$($at2)» 3. «$($at3)»" | Out-Host; } ;

$null = Add-TMXTestCase -TestCaseName "tc04" -Id 00004 -TestCode { "test 04" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc05" -Id 00005 -TestCode { "test 05" | Out-Host; } ;
$null = Add-TMXTestCase -TestCaseName "tc06" -Id 00006 -TestCode { "test 06" | Out-Host; } ;

Write-Host "=========================================================================================================";
# There are only parameters to the test suite
Invoke-TMXTestSuite -Id 001 -BeforeScenarioParameters @(1,2,3) -AfterScenarioParameters @(4,5,6);
Write-Host "=========================================================================================================";
# There are, along with test sutie parameters, parameters to the test scenario
Invoke-TMXTestScenario -Id 0001 -BeforeTestParameters @(7,8,9) -AfterTestParameters @(10,11,12);
Write-Host "=========================================================================================================";
# There are, along with test sutie parameters, parameters to the test scenario
Invoke-TMXTestScenario -Id 0002 -BeforeTestParameters @(13,14,15) -AfterTestParameters @(16,17,18);
Write-Host "=========================================================================================================";
Invoke-TMXTestSuite -Id 001 -BeforeScenarioParameters @(1,2,3) -AfterScenarioParameters @(4,5,6);
Write-Host "=========================================================================================================";
[TMX.TestData]::CurrentTestSuite | FL dbid,id,name;
[TMX.TestData]::CurrentTestScenario | FL dbid,id,name;
[TMX.TestData]::CurrentTestResult | FL dbid,id,name;