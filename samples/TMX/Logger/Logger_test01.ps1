ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll

New-TMXTestSuite -Name "suite01" -Id 01
Add-TMXTestScenario -Name "scenario01" -Id 001
Add-TMXTestScenario -Name "scenario02" -Id 002
Close-TMXTestResult "test result 01" -TestPassed
dir $env:HOMEPATH\Documents\TMX.log

[TMX.Logger]::LogPath = "C:\1\new_tmx_log.txt"
New-TMXTestSuite -Name "suite02" -Id 02
Add-TMXTestScenario -Name "scenario03" -Id 003
Close-TMXTestResult "test result 03" -TestPassed
dir C:\1\new_tmx_log.txt

