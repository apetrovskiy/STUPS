cd C:\Projects\PS\STUPS\UIA\UIAutomationTest\bin\Release35
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
[void]([UIAutomation.Preferences]::OnSuccessDelay = 0);
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
Import-Module '.\TMX.dll' -Force; 
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
[void]([UIAutomation.Preferences]::OnSuccessDelay = 0);
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
[void]([TMX.TestData]::ResetData()); 
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
[UIAutomation.Preferences]::EveryCmdletAsTestResult = $false;
#..\..\..\UIAutomationTestForms\bin\Release35\UIAutomationTestForms.exe 1 0 Button 0 Button111 btn
calc
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
#$null = Get-UIAWindow -n 'WinFormsEmpty' | Get-UIAButton -n 'Button111' | Invoke-UIAButtonClick -TestResultName 'clicked' -KnownIssue; [TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;
$null = Get-UIAWindow -n '*calc*' | Get-UIAButton -n '1' | Invoke-UIAButtonClick -TestResultName 'clicked' -KnownIssue; [TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
#[void]([UIAutomation.CurrentData]::ResetData());



