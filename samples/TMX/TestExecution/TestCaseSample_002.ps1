ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

$null = New-TMXTestSuite "suite01" -Id 001 -BeforeScenario { Write-Host "before scenario script 1"; },{ Write-Host "before scenario script 2"; } `
    -AfterScenario { Write-Host "after scenario script 1"; },{ Write-Host "after scenario script 2"; };

$null = Add-TMXTestScenario "sc001" -Id 0001 -BeforeTest { Write-Host "before test script 1"; },{ Write-Host "before test script 2"; } `
    -AfterTest { Write-Host "after test script 1"; },{ Write-Host "after test script 2"; };

Invoke-TMXTestSuite -Id 001;
