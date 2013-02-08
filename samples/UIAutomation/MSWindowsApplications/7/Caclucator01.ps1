####################################################################################################
# Script name: Caclucator01.ps1
# Description: demonstrates using of TMX module during the testing of an application
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;
ipmo $global:tmxModule;

# Let's create a new test suite
# to clean up the data that are posibly out of the current interest
[TMX.TestData]::ResetData();
[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation;
New-TMXTestSuite -Name 'Calculator testing' -Id calc;
Add-TMXTestScenario -Name 'Calculator menu' -Id calcmenu;
Add-TMXTestScenario	-Name 'Caclucator simple calculations' -Id maths;

# start the application under test (AUT)
Start-Process calc -PassThru | Get-UIAWindow; 
# now we've got the window in the
# [UIAutomation.CurrentData]::CurrentWindow variable

# set the initial state: Standard
Open-TMXTestScenario -Id calcmenu; 
# we are going to save our test result regarding how the menu works here

# the main menu here is expandable/collapsible
# what can be learnt by issuing the following line of code:
# (Get-UIAMenuItem -Name View).GetSupportedPatterns()
Get-UIAMenuItem -Name View | `
	Invoke-UIAMenuItemExpand | `
	Get-UIAMenuItem -Name Standard | `
	Invoke-UIAMenuItemClick -TestResultName 'The Standard menu item is available' `
		-TestPassed -TestLog;
# the TestLog parameters logs the last line of code
# the TestPassed parameter informs that we have gotten the result we expected
# the TestResultName parameter gives the name to our test result
# test result Id is generated as we don't need to set it manually, this is just result

function calculateExpression
{
	param(
		  [string]$modeName
		  )
	# produce the input
	Get-UIAButton -Name 2 | Invoke-UIAButtonClick;
	Get-UIAButton -Name Add | Invoke-UIAButtonClick -TestResultName "The Add button is clickable $($modeName)" -TestPassed;
	Get-UIAButton -Name 2 | Invoke-UIAButtonClick;
	Get-UIAButton -Name Divide | Invoke-UIAButtonClick;
	Get-UIAButton -Name 2 | Invoke-UIAButtonClick;
	Get-UIAButton -Name Equals | Invoke-UIAButtonClick -TestResultName "The Equals button is clickable $($modeName)" -TestPassed;

	# now we need to get the result
	# there is a difficulty: the name of a Text element (i.e., Label in .NET) is its value
	# okay, let's find all of them and our module highlight each
	#Get-UIAControlDescendants -ControlType Text | `
	#	%{Get-UIAText -AutomationId $_.Current.AutomationId; `
	#		sleep -Seconds 2; `
	#		Write-Host "this was " $_.Current.Name $_.Current.AutomationId;}
	# the last, with Id = 158, is ours
	[int]$result = (Get-UIAText -AutomationId 158).Current.Name;
	$result;
}

# we must determine where we are
# as testers, we never believe, we check
# you might, for example, investigate into the second level menu:
#Get-UIAMenuItem -Name View | `
#	Invoke-UIAMenuItemExpand | `
#	Get-UIAMenu | `
#	Get-UIAControlChildren | `
#	%{Write-Host $_.Current.ControlType.ProgrammaticName $_.Current.Name $_.Current.AutomationId;}

# the easy way is to simple calculate the buttons
# MS UI Automaiton never returns what it can't see (by design, as it is intended for screen readers)
# the Standard mode - 31
# the Statictics mode - 33
# the Programmer mode - 48
# the Scientific mode - 53
[string]$testResultName = 'The Standard mode is available';
# to ensure that after changing the mode
# we are working with the actual window
Get-UIAWindow -ProcessName calc;
if ((Get-UIAControlDescendants -ControlType Button).Count -eq 31) {
	Close-TMXTestResult -Name $testResultName -TestPassed;
} else {
	Close-TMXTestResult -Name $testResultName -TestPassed:$false;
	# do additional actions if needed
}

# now we are going to test calculations so that
# we are switching to appropriate scenario
Open-TMXTestScenario -Id maths;
[string]$modeName = 'in the Standard mode';

calculateExpression $modeName; # in the Standard mode

# test the same in the Scientific mode
Open-TMXTestScenario -Id calcmenu; 
Get-UIAMenuItem -Name View | `
	Invoke-UIAMenuItemExpand | `
	Get-UIAMenuItem -Name Scientific | `
	Invoke-UIAMenuItemClick -TestResultName 'The Scientific menu item is available' `
		-TestPassed -TestLog;

# check the mode we are in now
$testResultName = 'The Scientific mode is available';
# to ensure that after changing the mode
# we are working with the actual window
Get-UIAWindow -ProcessName calc;
if ((Get-UIAControlDescendants -ControlType Button).Count -eq 53) {
	Close-TMXTestResult -Name $testResultName -TestPassed;
} else {
	Close-TMXTestResult -Name $testResultName -TestPassed:$false;
	# do additional actions if needed
}

Open-TMXTestScenario -Id maths;
[string]$modeName = 'in the Scientific mode';
calculateExpression $modeName; # in the Scientific mode

# test reports are still ugly!!!
Export-TMXTestResults -As HTML -Path C:\1\calc_result.htm