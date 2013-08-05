cd C:\Projects\PS\STUPS\UIA\UIAutomationTest\bin\Release35
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

#..\..\..\UIAutomationTestForms\bin\Release35\UIAutomationTestForms.exe 1 0 Button 0 Button111 btn
Start-Process C:\Projects\PS\STUPS\UIA\UIAutomationTestForms\bin\Release35\UIAutomationTestForms.exe -ArgumentList "1","0","Button","0"," Button111","btn"
#calc
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
$null = Get-UIAWindow -n 'WinFormsEmpty' | Get-UIAButton -n 'Button111' | Invoke-UIAButtonClick -TestResultName 'clicked' -KnownIssue; [TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;
#$null = Get-UIAWindow -n '*calc*' | Get-UIAButton -n '1' | Invoke-UIAButtonClick -TestResultName 'clicked' -KnownIssue; [TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;
# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =
#[void]([UIAutomation.CurrentData]::ResetData());
