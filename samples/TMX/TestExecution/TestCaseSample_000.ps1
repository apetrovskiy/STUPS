ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
cls

[TMX.TestData]::ResetData();
$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '3'; };
$null = Add-TMXTestScenario 'sc001' -Id 0001;
Invoke-TMXTestSuite -Id 001;

[TMX.TestData]::ResetData();
$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { Write-Host '1'; },{ Write-Host '1'; };
$null = Add-TMXTestScenario 'sc001' -Id 0001;
Invoke-TMXTestSuite -Id 001;

[TMX.TestData]::ResetData();
$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '3' | Out-Host; };
$null = Add-TMXTestScenario 'sc001' -Id 0001;
Invoke-TMXTestSuite -Id 001;


