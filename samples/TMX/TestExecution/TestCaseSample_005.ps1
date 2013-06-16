ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
cls

# There were no scenarios to run, the AfterScenario scriptblock has not been run
[TMX.TestData]::ResetData();
$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '3'; };
$null = Add-TMXTestScenario 'sc001' -Id 0001;
Invoke-TMXTestSuite -Id 001;
Write-Host "===================================================";

[TMX.TestData]::ResetData();
$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { Write-Host '1'; },{ Write-Host '2'; };
$null = Add-TMXTestScenario 'sc001' -Id 0001;
Invoke-TMXTestSuite -Id 001;
Write-Host "===================================================";

[TMX.TestData]::ResetData();
$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '3' | Out-Host; };
$null = Add-TMXTestScenario 'sc001' -Id 0001;
Invoke-TMXTestSuite -Id 001;
Write-Host "===================================================";