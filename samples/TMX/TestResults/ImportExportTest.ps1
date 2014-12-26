ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
New-TmxTestPlatform -Name "p1" -Id 111
New-TmxTestSuite "s01" | Add-TmxTestScenario "sc01"
Close-TmxTestResult "tr01" -TestPassed
Close-TmxTestResult "tr02" -TestPassed

New-TmxTestPlatform -Name "p2" -Id 222
New-TmxTestSuite "s02" | Add-TmxTestScenario "sc02"
Close-TmxTestResult "tr01" -TestPassed
Close-TmxTestResult "tr02" -TestPassed

New-TmxTestSuite "s03" | Add-TmxTestScenario "sc03"
Close-TmxTestResult "tr01" -TestPassed
Close-TmxTestResult "tr02" -TestPassed
Add-TmxTestScenario "sc04"
Close-TmxTestResult "tr01" -TestPassed
Close-TmxTestResult "tr02" -TestPassed:$false

Export-TmxTestResults -As xml -Path E:\1111111111111111\1111\01.xml


ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
Import-TmxTestResults -As xml -Path E:\1111111111111111\1111\01.xml
Import-TmxTestResults -As xml -Path E:\1111111111111111\1111\02.xml
Import-TmxTestResults -As xml -Path E:\1111111111111111\1111\03.xml
Export-TmxTestResults -As xml -Path E:\1111111111111111\1111\04.xml





