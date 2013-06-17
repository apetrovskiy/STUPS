ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
$global:result = '';
New-TMXTestSuite "ts" | Add-TMXTestScenario "tsc"
Add-TMXTestCase "tc1" -Id 1111 -TestCode { $global:result  += "test case 1111"; }
Invoke-TMXTestCase -Id 1111

