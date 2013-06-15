ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

$null = New-TMXTestSuite "suite01" -Id 001 -BeforeScenario { Write-Host "1111"; },{ Write-Host "before scenario script"; } -AfterScenario { Write-Host "2222"; },{ Write-Host "after scenario script"; }; # -Verbose;
$null = Add-TMXTestScenario "sc001" -Id 0001 -BeforeTest { Write-Host "before test script"; } -AfterTest { Write-Host "after test script"; } -Verbose;
Invoke-TMXTestSuite -Id 001; # -Verbose;
