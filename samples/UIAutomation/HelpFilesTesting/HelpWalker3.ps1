####################################################################################################
# Script name: HelpWalker3.ps1
# Description: demonstrates how to work with the Invoke-UIATreeItemScrollItem cmdlet
#              and how to check hyperlinks
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

param(
	[string]$FileName,
	[string]$AppTitle,
	[string]$HelpTitle
     )
Set-StrictMode -Version Latest
cls;

ipmo $global:uiautomationModule;
ipmo $global:tmxModule;

if ($FileName.Length -eq 0 -or $AppTitle.Length -eq 0 -or $HelpTitle.Length -eq 0) {
	Write-Host "Please specify parameters as .\HelpWakler2.ps1 app_file_name application_title help_title";
	exit;
}

# the log file
[string]$logFile = "C:\1\help_test.log";

# set a small delay between nodes
# because the refresh of each page should take time
[UIAutomation.Preferences]::OnSuccessDelay = 50;
# set a long timeout because UI Automation might
# take a time in case of there are a number of conrol on a page
[UIAutomation.Preferences]::Timeout = 120000;

# create our enum object
[PSObject]$script:testNames = New-Object PSObject;
$script:testNames | `
	Add-Member -MemberType NoteProperty -Name AppTitle -Value $AppTitle -PassThru | `
	Add-Member -MemberType NoteProperty -Name HelpTitle -Value $HelpTitle -PassThru | `
	Add-Member -MemberType NoteProperty -Name AppName -Value $FileName;

# start the AUT, its help file and get the window
Start-Process $script:testNames.AppName -PassThru | Get-UIAWindow -Seconds 120 | `
	Get-UIAMenuItem -Name Help | Invoke-UIAMenuItemClick | `
	Get-UIAMenuItem -Name 'Help*Topic*' | INvoke-UIAMenuItemClick;
#Get-UIAWindow -Name $testNames.HelpTitle -Seconds 120;

function Invoke-TreeNodeExpand
{
	param(
		  [ValidateNotNull()]
		  [System.Windows.Automation.AutomationElement]$element
		 )
	[void]($element | Invoke-UIAControlClick -DoubleClick -PassThru:$false);
}

function Invoke-TreeNodeCollapse
{
	param(
		  [ValidateNotNull()]
		  [System.Windows.Automation.AutomationElement]$element
		 )
	[void]($element | Invoke-UIAControlClick -DoubleClick -PassThru:$false);
}


function Invoke-TreeNodeShowRightPane
{
	param(
		  [ValidateNotNull()]
		  [System.Windows.Automation.AutomationElement]$element
		 )
	[void]($element | Invoke-UIAControlClick -PassThru:$false);
}

function Invoke-TreeNodeScrollTo
{
	param(
		  [ValidateNotNull()]
		  [System.Windows.Automation.AutomationElement]$element
		 )
	[void]($element | Invoke-UIATreeItemScrollItem);
}

function Test-Hyperlinks
{
	param(
		  [ValidateNotNull()]
		  [System.Windows.Automation.AutomationElement]$initialElement # the node where the checking of hyperlinks starts
		 )

	">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>processing element: $($initialElement.Current.Name):" >> $logFile;
	Get-Date >> $logFile;
	Start-UIACacheRequest;
	$rightPane = Get-UIAWindow -Name $testNames.AppTitle | Get-UIAPane -Class '*Internet*Explorer*'; # -FromCache;
	$hyperlinks = $rightPane | Get-UIAControlDescendants -ControlType Hyperlink;
	[System.Collections.Generic.List[string]]$hypNames = New-Object System.Collections.Generic.List[string];
	for ($i = 0; $i -lt $hyperlinks.Count; $i++) {
		$hypNames.Add($hyperlinks[$i].Current.Name);
	}
	
	for ($i = 0; $i -lt $hypNames.Count; $i++) {
		Write-Host "link: $($hypNames[$i])";
		">>>>>>>>>>>>>>>>>>>>processing link: $($hypNames[$i]):" >> $logFile;
		Get-Date >> $logFile;
		
		if ($hypNames.Contains("http")) {
write-host "===========================http==============================";			
		} else {
			$null = $rightPane | `
				Get-UIAHyperlink -Name $hypNames[$i] -FromCache | Invoke-UIAHyperlinkClick;
#			try {
			$null = $rightPane | `
				Get-UIAText -Name $hypNames[$i] -TestResultName "checking link: $($hypNames[$i])" -FromCache;
#			}
#			catch {
#				Close-TMXTestResult -Name "checking link: $($hypNames[$i])" -TestPassed:$false -TestLog;
#			}
#			try {
				#Get-UIAWindow -Name $script:testNames.HelpTitle | `
				$null = Get-UIAButton -Name '*Back*' -FromCache | `
					Invoke-UIAButtonClick;
#			}
#			catch {
#				Close-TMXTestResult -Name "wrong Back result from $($hypNames[$i]) to the original node: $($initialElement.Current.Name)" -TestPassed:$false -TestLog;
#			}
			try {
				$null = $rightPane | `
					Get-UIAText -Name $($initialElement.Current.Name) -TestResultName "checking original node: $($initialElement.Current.Name)" -FromCache;
			}
			catch {
				Close-TMXTestResult -Name "checking original node: $($initialElement.Current.Name)" -TestPassed:$false -TestLog;
			}
		}
	}
	Stop-UIACacheRequest;
}

function Invoke-TreeNodeChildrenProcess
{
	param(
		  [ValidateNotNull()]
		  [System.Windows.Automation.AutomationElement]$element,
		  [string]$NodeHierarchy
		 )
	
	# children of the node or top-level nodes
	$children = $element | Get-UIAControlChildren -ControlType TreeItem;

	if ($children -ne $null -and $children -is [Object[]] -and $children.Count -gt 0) {

		# we store the previous node in a variable, so that
		# we can return to it and collapse its chilren 
		# after we walked through all of them
		[System.Windows.Automation.AutomationElement]$previousChild = $null;

		foreach ($childNode in $children) {
			try {
				if ($previousChild -ne $null) {
					# collapse the previous node
					Invoke-TreeNodeShowRightPane $previousChild;
					Invoke-TreeNodeCollapse $previousChild;
				}
				$previousChild = $childNode;

				# expand the current node
				Invoke-TreeNodeScrollTo $childNode;
				Invoke-TreeNodeExpand $childNode;
				Invoke-TreeNodeShowRightPane $childNode;

				# print out the hierarchy
				[string]$fullHierarchy = "";
				if ($NodeHierarchy.Length -gt 0) {
					$fullHierarchy = $NodeHierarchy + " -> " + $childNode.Current.Name;
				} else {
					$fullHierarchy = $childNode.Current.Name;
				}
				Write-Host $fullHierarchy;

				Test-Hyperlinks $childNode;

				# go down the hierarchy
				Invoke-TreeNodeChildrenProcess $childNode $fullHierarchy;
			}
			catch {
				Write-Host $Error[0];
				break;
			}
		}
	}
}

# first time, the tree is given as the root node
"Test started">> $logFile;
Get-Date >> $logFile;
$rootNode = Get-UIAWindow -Name $testNames.HelpTitle -Seconds 120 | Get-UIATree -Seconds 120;
Invoke-TreeNodeChildrenProcess $rootNode;
Export-TMXTestResults -As HTML -Path C:\1\help_test_reslt.htm
"Test finished" >> $logFile;
Get-Date >> $logFile;