ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
$null = Add-TMXTestScenario "tsc1" -Id 1 -BeforeTest { param($v1, $v2, $v3) "var1=$v1";"var2=$v2";"var3=$v3"; }
$null = Add-TMXTestCase "tc1" -Id 1 -TestCode {}
Invoke-TMXTestScenario -Id 1 -BeforeTestParameters @("aaaa","bbbb",$true)

# OK
$null = Add-TMXTestScenario "tsc2" -Id 2 -BeforeTest { param($v1, $v2, $v3) "var1=$v1" | Out-Host;"var2=$v2" | Out-Host;"var3=$v3" | Out-Host; }
$null = Add-TMXTestCase "tc2" -Id 2 -TestCode {}
Invoke-TMXTestScenario -Id 2 -BeforeTestParameters @("aaaa","bbbb",$true)           

# OK
$null = Add-TMXTestScenario "tsc3" -Id 3 -BeforeTest { param($v1, $v2, $v3) Write-Host "var1=$v1";Write-Host "var2=$v2";Write-Host "var3=$v3"; }                   
$null = Add-TMXTestCase "tc3" -Id 3 -TestCode {}
Invoke-TMXTestScenario -Id 3 -BeforeTestParameters @("aaaa","bbbb",$true)                                                                                  

$global:res = '';
$null = Add-TMXTestScenario "tsc4" -Id 4 -BeforeTest { param($v1, $v2, $v3) $global:res += "var1=$v1";$global:res += "var2=$v2";$global:res += "var3=$v3"; }                                                                       $null = Add-TMXTestCase "tc4" -Id 4 -TestCode {}
Invoke-TMXTestScenario -Id 4 -BeforeTestParameters @("aaaa","bbbb",$true)                                                                                                                                                                    $global:res                                                                                                                                                                                                                                  



