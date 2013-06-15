ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;

New-TMXTestSuite "suite01" -Id 001 -BeforeScenario { "before scenario script"; } -AfterScenario { "after scenario script"; } -Verbose;
Add-TMXTestScenario "sc001" -Id 0001 -BeforeTest { "before test script"; } -AfterTest { "after test script"; } -Verbose;
#Add-TMXTestCase -TestCaseName "tc01" -Id 00001 -TestCode { "test 00001"; } ;
#Add-TMXTestCase -TestCaseName "tc01" -Id 00002 -TestCode { "test 00002"; } ;
#Add-TMXTestCase -TestCaseName "tc01" -Id 00003 -TestCode { "test 00003"; } ;

Invoke-TMXTestSuite -Id 001 -Verbose;
[TMX.TestData]::CurrentTestSuite | FL dbid,id,name;
[TMX.TestData]::CurrentTestScenario | FL dbid,id,name;
[TMX.TestData]::CurrentTestResult | FL dbid,id,name;
