cls
ipmo C:\Projects\ps\STUPS\TMX\TMX\bin\Release35\TMX.dll
[TMX.TestData]::ResetData();

New-TmxTestSuite -Id 1 -Name "suite 01"
Add-TmxTestScenario -Id s01sc01 -Name "scenario 01 suite 01"
Add-TmxTestScenario -Id s01sc02 -Name "scenario 02 suite 01"

New-TmxTestSuite -Id 3 -Name "suite 03"
Add-TmxTestScenario -Id s03sc01 -Name "scenario 01 suite 03"
Add-TmxTestScenario -Id s03sc02 -Name "scenario 02 suite 03"

New-TmxTestSuite -Id 2 -Name "suite 02"
Add-TmxTestScenario -Id s02sc02 -Name "scenario 02 suite 02"
Add-TmxTestScenario -Id s02sc01 -Name "scenario 01 suite 02"

New-TmxTestSuite -Id 4 -Name "suite 04"
Add-TmxTestScenario -Id s04sc01 -Name "scenario 01 suite 04"
Add-TmxTestScenario -Id s04sc02 -Name "scenario 02 suite 04"

cls
"======================= suites - standard sorting ======================="
Search-TmxTestSuite | fl id,name,timestamp
"======================= suites - standard sorting ======================="
Search-TmxTestSuite | Sort-Object -Property timestamp | fl id,name,timestamp
"======================= suites - standard sorting ======================="
Search-TmxTestScenario | fl id,name,timestamp
"======================= suites - standard sorting ======================="
Search-TmxTestScenario | Sort-Object -Property timestamp | fl id,name,timestamp
