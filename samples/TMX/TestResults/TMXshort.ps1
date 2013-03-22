ipmo C:\Projects\PS\UIAutomation.Old\UIAutomation\bin\Release35\TMX.dll; #C:\Projects\PS\UIAutomation\UIAutomationSpy\bin\Release\TMX.dll
ipmo C:\Projects\PS\UIAutomation.Old\UIAutomation\bin\Release35\UIAutomation.dll; #C:\Projects\PS\UIAutomation\UIAutomationSpy\bin\Release\UIAutomation.dll
[TMX.TestData]::ResetData();
New-TMXTestSuite -Description "description description description description description description description description description description" -Name suite1 -Id 111
Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1
Add-TMXTestResultDetail -TestResultDetail "1"
Add-TMXTestResultDetail -TestResultDetail "2"
Close-TMXTestResult -TestPassed -Name test1

Add-TMXTestResultDetail -TestResultDetail "3"
Add-TMXTestResultDetail -TestResultDetail "4"
Close-TMXTestResult -Name test2

Add-TMXTestResultDetail -TestResultDetail "5"
Get-UIAWindow -pn "no such window 01" -Seconds 1
Add-TMXTestResultDetail -TestResultDetail "6"
Get-UIAWindow -pn "no such window 02" -Seconds 1 -TestResultName "no window 02"-v

Add-TMXTestResultDetail -TestResultDetail "7"
Get-UIAWindow -pn "no such window 03" -Seconds 1 -TestResultName "no window 03" -TestPassed:$false -v

Add-TMXTestResultDetail -TestResultDetail "8"

Add-TMXTestScenario -Name sc2 -Id 1112 -TestSuiteName suite1
Add-TMXTestResultDetail -TestResultDetail "9a"
Add-TMXTestResultDetail -TestResultDetail "10a"
Close-TMXTestResult -TestPassed -Name test1a -Description "P"

Add-TMXTestResultDetail -TestResultDetail "9b"
Add-TMXTestResultDetail -TestResultDetail "10b"
Close-TMXTestResult -TestPassed -KnownIssue -Name test1b -Description "P"

Add-TMXTestResultDetail -TestResultDetail "9c"
Add-TMXTestResultDetail -TestResultDetail "10c"
Close-TMXTestResult -TestPassed -KnownIssue:$true -Name test1b -Description "P"

Add-TMXTestResultDetail -TestResultDetail "9d"
Add-TMXTestResultDetail -TestResultDetail "10d"
Close-TMXTestResult -TestPassed -KnownIssue:$false -Name test1d -Description "P"

Add-TMXTestResultDetail -TestResultDetail "9e"
Add-TMXTestResultDetail -TestResultDetail "10e"
Close-TMXTestResult -Name test1e -Description "F"

Add-TMXTestResultDetail -TestResultDetail "9f"
Add-TMXTestResultDetail -TestResultDetail "10f"
Close-TMXTestResult -KnownIssue -Name test1f -Description "K"

Add-TMXTestResultDetail -TestResultDetail "9g"
Add-TMXTestResultDetail -TestResultDetail "10cg"
Close-TMXTestResult -KnownIssue:$true -Name test1g -Description "K"

Add-TMXTestResultDetail -TestResultDetail "9h"
Add-TMXTestResultDetail -TestResultDetail "10h"
Close-TMXTestResult -KnownIssue:$false -Name test1h -Description "F"

Add-TMXTestResultDetail -TestResultDetail "9i"
Add-TMXTestResultDetail -TestResultDetail "10i"
Close-TMXTestResult -TestPassed:$false -Name test1i -Description "F"

Add-TMXTestResultDetail -TestResultDetail "9j"
Add-TMXTestResultDetail -TestResultDetail "10j"
Close-TMXTestResult -TestPassed:$false -KnownIssue -Name test1j -Description "K"

Add-TMXTestResultDetail -TestResultDetail "9k"
Add-TMXTestResultDetail -TestResultDetail "10k"
Close-TMXTestResult -TestPassed:$false -KnownIssue:$true -Name test1k -Description "K"

Add-TMXTestResultDetail -TestResultDetail "9l"
Add-TMXTestResultDetail -TestResultDetail "10l"
Close-TMXTestResult -TestPassed:$false -KnownIssue:$false -Name test1l -Description "F"

Add-TMXTestResultDetail -TestResultDetail "11"
Add-TMXTestResultDetail -TestResultDetail "12"
Save-UIAScreenshot -Description "1" -v
Close-TMXTestResult -TestPassed -Name test2

Add-TMXTestResultDetail -TestResultDetail "13"
Add-TMXTestResultDetail -TestResultDetail "14"
Save-UIAScreenshot -Description "2" -v
Open-TMXTestScenario -Name sc1 -TestSuiteName suite1 -v
#[TMX.TestData]::CurrentTestSuite
#[TMX.TestData]::CurrentTestScenario
#[TMX.TestData]::CurrentTestScenario.TestResults
#[TMX.TestData]::CurrentTestResult
#[TMX.TestData]::TestSuites
Close-TMXTestResult -TestPassed -Name test2.5 -Description 'fake result, with no real tests';
Add-TMXTestResultDetail -TestResultDetail "15"
Add-TMXTestResultDetail -TestResultDetail "16"
Save-UIAScreenshot -Description "3" -v

if (-not (Test-Path 'C:\1')) {
	New-Item -ItemType directory -Name 1 -Path C:\
}
Export-TMXTestResults -As HTML -Path C:\1\result1.htm
Export-TMXTestSummary -As HTML -Path C:\1\summary1.htm