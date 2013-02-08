ipmo $global:uiautomationModule;

[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Normal;

# click the Start button
Get-UIADesktop | Get-UIAButton -Name Start | Invoke-UIAButtonClick;

# open the Control Panel window
Get-UIAListItem -Name 'Control Panel' | Invoke-UIAControlClick;

# search for the Sound dialog
$w = Get-UIAWindow -Name 'Control Panel'; # the name will be changed during the test
Get-UIAWindow -Name 'Control Panel' | Get-UIAEdit -AutomationId 'SearchEditBox' | Set-UIAEditText -Text 'sound';
sleep -Seconds 1; # for the Normal mode only
# if you are running this script with the 
# [UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation
# set, you can cut out this sleep
# Otherwise, there happened someting like 'the window couldn't form itself without a bit of time'
# Thus, this is unavoidable timeout (at least a half of second)

# open the Sound dialog
#Get-UIAHyperlink -AutomationId 'name' -Name 'Sound' | Invoke-UIAHyperlinkClick;
#$w | Get-UIAHyperlink -Name 'Sound' | Invoke-UIAHyperlinkClick;
$w | Search-UIAControl -Name 'Sound' -Highlight | Invoke-UIAHyperlinkClick;
	
# search for the Speakers device
$neededItem = Get-UIAWindow -Name 'Sound' | Search-UIAControl -Name 'Speak*' -Highlight;
$neededItem | Read-UIAControlName;
$neededItem | Read-UIAControlAutomationId;
$neededItem | Read-UIAControlType;