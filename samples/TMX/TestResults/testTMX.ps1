#[string]$TMXmodule = 'C:\tests\TMX.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\TMX.dll';
#[string]$UIAmodule = 'C:\tests\UIAutomation.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\UIAutomation.dll';
[string]$TMXmodule = 'C:\Projects\PS\STUPS\TMX\bin\Release35\TMX.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\TMX.dll';
[string]$UIAmodule = 'C:\Projects\PS\STUPS\UIAutomation\bin\Release35\UIAutomation.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\UIAutomation.dll';
[string]$importFile = 'C:\Projects\PS\STUPS\samples\samples\TMX\testdata.txt'; #'E:\G\Projects\PS\UIAutomation\samples\samples\TMX\testdata.txt' #'C:\tests\testdata.txt'; #'E:\G\Projects\PS\UIAutomation\samples\testdata.txt';

ipmo -Name $TMXmodule;
ipmo -Name $UIAmodule;
$VerbosePreference = [System.Management.Automation.ActionPreference]::Continue;
[TMX.TestData]::ResetData();

#region Creating suites
Write-Host "`r`n===========================================================================================";
Write-Host "Creating the suite1 test suite";
New-TMXTestSuite -Name suite1; # sprint story #1

# 20121018
New-TMXTestSuite -Name suite1000; # the empty suite

Write-Host "`r`nCreating the suite2 test suite";
New-TMXTestSuite -Name suite2 -Id 2 -Description 'suite #2'; # sprint story #2

Write-Host "`r`nShow suite1 and suite2";
[tmx.testdata]::TestSuites
#endregion Creating suites


#region Adding scenarios
# add scenarios to the suite suite1 (sprint story #1)
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "Adding test scenario sc1 to the suite1 test suite";
Add-TMXTestScenario -Name sc1 -Id 1 -TestSuiteName suite1 # sprint: story #1 scenario #1

Write-Host "`r`nAdding test scenario sc2 to the suite1 test suite";
Add-TMXTestScenario -Name sc2 -TestSuiteName suite1 # sprint story #2 scenarion custom

Write-Host "`r`nAdding test scenario sc3 to the suite2 test suite";
Add-TMXTestScenario -Name sc3 -TestSuiteName suite2

Write-Host "`r`nAdding test scenario sc4 to the suite2 test suite";
Add-TMXTestScenario -Name sc4 -Description 'scenario 4'


Write-Host "`r`nShow scenarios";
[tmx.testdata]::TestSuites
#endregion Adding scenarios


#region Opening scenarios
# select our current test scenario
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "Opening test scenario sc1";
Open-TMXTestScenario -Name sc1 -TestSuiteName suite1

# select suite1
Write-Host "`r`nOpening test suite suite1";
Open-TMXTestSuite -Name suite1

Write-Host "`r`nAdding test scenario sc001 to the suite1 test suite";
Add-TMXTestScenario -Name sc001

Write-Host "`r`nShow suites and scenarios";
[tmx.testdata]::TestSuites
#endregion Opening scenarios


#region Adding test details 1
# test case (test result) tracking
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "Adding test result details to the active test result/test scenario sc001 /test suite suite1";
Add-TMXTestResultDetail -TestResultDetail "test in progress, not failed yet 1"
# ... code
Add-TMXTestResultDetail -TestResultDetail "test in progress, not failed yet 2"
# ... code
Write-Host "test passed. Writing results";
Write-Host "-Echo parameter";
Close-TMXTestResult -Name "checking the control 1" -Id "1.2.3" -TestPassed -Echo -TestLog:$true

Write-Host "`r`n`r`nout test results";
[tmx.testdata]::CurrentTestScenario.Name
[tmx.testdata]::CurrentTestScenario.TestResults.Count
[tmx.testdata]::CurrentTestScenario.TestResults
#endregion Adding test details 1


#region Adding test details 2
# one more test case (test result)
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "Adding test result details to the active test result/test scenario/test suite";
Add-TMXTestResultDetail -TestResultDetail "test in progress, not failed yet 3"
# ... code
Write-Host "`r`ntest failed. Writing results";
if (-not $false){  # check a test condition
	Close-TMXTestResult -Name "checking the control 2" -Id "1.2.4" -TestLog:$true
}

Write-Host "`r`n`r`nout test results";
[tmx.testdata]::CurrentTestScenario.Name
[tmx.testdata]::CurrentTestScenario.TestResults
#endregion Adding test details 2


#region Adding test details 3
# the third test case (test result)
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "Adding test result details to the active test result/test scenario/test suite";
Write-Host "-Echo parameter";
Add-TMXTestResultDetail -TestResultDetail "test in progress, not failed yet 4" -Echo
# ... code
Write-Host "-Echo parameter";
Add-TMXTestResultDetail -TestResultDetail "enabling a control: passed1 " -Echo
# ... code

Write-Host "`r`ntaking a screenshot";
Save-UIAScreenShot -Description "control_failed"  # every screenshot saving is being written into the active test result

Write-Host "`r`nperforming the action that should fail";
Get-UIAWindow -ProcessName "no such process" -Seconds 2 -TestResultName "checking the window [no such process]" -TestResultId "1.2.5" -Verbose:$false -TestLog:$true;
# every error is being written into the active test result
# test case failed, what is marked by not setting the -TestPassed parameter (which is $false by default)
#endregion Adding test details 3


#region Adding test details 4
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "Adding test result details to the active test result/test scenario/test suite";
Add-TMXTestResultDetail -TestResultDetail "test in progress, not failed yet 5" -Echo
# ... code
Add-TMXTestResultDetail -TestResultDetail "enabling a control: passed 2" -Echo
#endregion Adding test details 4


WRite-Host "`r`nShow suites and scenarios";
[tmx.testdata]::TestSuites


Write-Host "`r`n`r`n===========================================================================================";
Write-Host "out test results";
#[tmx.testdata]::CurrentTestScenario.TestResults
foreach ($testResult in [tmx.testdata]::CurrentTestScenario.TestResults){
	$testResult;
	foreach ($testResultDetail in $testResult.Details){
		$testResultDetail.TextDetail; $testResultDetail.ScreenshotDetail; $testResultDetail.ErrorDetail;
	}
}


#region import test structure
Write-Host "`r`n`r`n===========================================================================================";
Write-Host "importing test structure";
[PSObject]$global:testSuites = New-Object PSObject;
[PSObject]$global:testScenarios = New-Object PSObject;
Get-Content -Path $importFile | ConvertFrom-Csv | `
%{if ($_.type -eq 'suite')
{New-TMXTestSuite -Name $_.name -Id $_.id -Description $_.description;
Add-Member -InputObject $global:testSuites -Name $_.name -MemberType NoteProperty -Value $_.name;} `
if ($_.type -eq 'scenario')
{Add-TMXTestScenario -Name $_.name -Id $_.id -Description $_.description;
Add-Member -InputObject $global:testScenarios -Name $_.name -MemberType NoteProperty -Value $_.name;} `
}
#endregion import test structure

Open-TMXTestSuite -Name $global:testsuites.'Coexistance for AD to O365 migration'

[TMX.TestData]::TestSuites #| FT name,id,status -Force

if (-not (Test-Path 'C:\1')) {
	New-Item -ItemType directory -Name 1 -Path C:\
}
Export-TMXTestResults -As html -Path 'c:\1\test_result.htm' -Verbose
Export-TMXTestSummary -As html -Path 'c:\1\test_summary.htm' -Verbose
Export-TMXTestResults -As XML -Path C:\1\export_xml.xml