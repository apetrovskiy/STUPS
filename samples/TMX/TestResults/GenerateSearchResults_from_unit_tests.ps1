ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\TMX.dll

$null = New-TMXTestSuite -Name abc1 -Id 1; 
$null = Add-TMXTestScenario -Name scenario1 -Id 1; 
$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; 
$null = New-TMXTestSuite -Name abc2 -Id 2; 
$null = Add-TMXTestScenario -Name scenario2 -Id 2; 
$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; 
$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; 
$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; 
$null = Add-TMXTestScenario -Name scenario3 -Id 3; 
$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; $null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; 
$null = New-TMXTestSuite -Name abc3 -Id 3; 
$null = New-TMXTestSuite -Name abc4 -Id 4; 
$null = Add-TMXTestScenario -Name scenario4 -Id 4; 
$null = Add-TMXTestScenario -Name scenario2 -Id 2; 
$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; 
$null = New-TMXTestSuite -Name abc5 -Id 5; 
$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; 
$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; 
$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; 
Search-TMXTestResult -OrderById | %{$_.Id;}

