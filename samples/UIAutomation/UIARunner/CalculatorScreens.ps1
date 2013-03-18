Set-StrictMode -Version Latest
ipmo C:\Projects\PS\STUPS\UIA\UIAutomationSpy\bin\Release35\UIAutomation.dll
[UIAutomation.Preferences]::OnSuccessDelay = 0;
[UIAutomation.WizardCollection]::Wizards.Clear();

[string]$wizardName = "CalcSteps";
[string]$stepScientific = "Scientific";
[string]$stepProgrammer = "Programmer";
[string]$stepStatistics = "Statistics";
[string]$windowName = "calc*";
#[string]$global:scientificResult = "";
#[string]$global:programmerResult = "";
#[string]$global:statisticsResult = "";

#[System.EventHandler]$printScientific = {$global:scientificResult;};


New-UIAWizard -Name $wizardName -StartAction {Start-Process calc -PassThru | Get-UIAWindow};

Add-UIAWizardStep -Name $stepScientific -SearchCriteria @{ControlType="RadioButton";Name="Degrees"} `
	-StepForwardAction {Get-UIAButton -n 1 | Set-UIAFocus | `
	Set-UIAControlKeys -Text "1{+}1{=}"; [UIAutomation.UserData]::UserDictionary.Add("scientificResult", (Get-UIAText -AutomationId 150 | Get-UIATextText));} `
	-InputObject (Get-UIAWizard -Name $wizardName) `
	-OnSuccessAction {[UIAutomation.UserData]::UserDictionary["scientificResult"];}

Add-UIAWizardStep -Name $stepProgrammer -SearchCriteria @{ControlType="RadioButton";Name="Hex"} `
	-StepForwardAction {Get-UIAButton -n 1 | Set-UIAFocus | `
	Set-UIAControlKeys -Text "2{+}2{=}"; {$global:programmerResult = Get-UIAText -AutomationId 150 | Get-UIATextText; $global:programmerResult;}.INvoke();} `
	-InputObject (Get-UIAWizard -Name $wizardName);

Add-UIAWizardStep -Name $stepStatistics -SearchCriteria @{ControlType="Button";Name="Average"} `
	-StepForwardAction {Get-UIAButton -n 1 | Set-UIAFocus | `
	Set-UIAControlKeys -Text "3{+}3{=}"; $global:statisticsResult = Get-UIAText -AutomationId 150 | Get-UIATextText; $global:statisticsResult;} `
	-InputObject (Get-UIAWizard -Name $wizardName);

Invoke-UIAWizard -Name $wizardName;

Get-UIAMenuItem -n Vi* | Invoke-UIAMenuItemExpand | `
	Get-UIAMenuItem -n Scien* | Invoke-UIAMenuItemClick;

Step-UIAWizard -Name $stepScientific -InputObject (Get-UIAWizard -Name $wizardName) -Forward;

Get-UIAMenuItem -n Vi* | Invoke-UIAMenuItemExpand | `
	Get-UIAMenuItem -n Prog* | Invoke-UIAMenuItemClick;

Step-UIAWizard -Name $stepProgrammer -InputObject (Get-UIAWizard -Name $wizardName) -Forward;

Get-UIAMenuItem -n Vi* | Invoke-UIAMenuItemExpand | `
	Get-UIAMenuItem -n Stat* | Invoke-UIAMenuItemClick;

Step-UIAWizard -Name $stepStatistics -InputObject (Get-UIAWizard -Name $wizardName) -Forward;

[object]$a = $null;
[uiautomation.userdata]::UserDictionary.TryGetValue("scientificResult", [ref]$a)
#$global:scientificResult;
$global:programmerResult;
$global:statisticsResult;