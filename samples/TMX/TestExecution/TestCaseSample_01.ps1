ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

$null = New-TMXTestSuite "suite01" -Id 001 -BeforeScenario { Write-Host "1111"; },{ Write-Host "before scenario script"; } -AfterScenario { Write-Host "2222"; },{ Write-Host "after scenario script"; }; # -Verbose;
$null = Add-TMXTestScenario "sc001" -Id 0001 -BeforeTest { Write-Host "before test script"; } -AfterTest { Write-Host "after test script"; } -Verbose;
$null = Add-TMXTestCase -TestCaseName "tc01" -Id 00001 -TestCode { "test 00001"; } ;
$null = Add-TMXTestCase -TestCaseName "tc01" -Id 00002 -TestCode { "test 00002"; } ;
$null = Add-TMXTestCase -TestCaseName "tc01" -Id 00003 -TestCode { "test 00003"; } ;

Invoke-TMXTestSuite -Id 001; # -Verbose;
[TMX.TestData]::CurrentTestSuite | FL dbid,id,name;
[TMX.TestData]::CurrentTestScenario | FL dbid,id,name;
[TMX.TestData]::CurrentTestResult | FL dbid,id,name;
