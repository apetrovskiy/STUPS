ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
[TMX.TestData]::ResetData();
cls

$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; } -AfterScenario { '02' | Out-Host; };
$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; } -AfterTest { '12' | Out-Host; };
$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; };

Invoke-TMXTestSuite -Id 001;