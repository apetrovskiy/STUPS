param(
	[string]$FileName,
	[string]$AppTitle,
	[string]$HelpTitle
     )
Set-StrictMode -Version Latest
cls;

ipmo C:\Distrib\QMMAD\UIAutomation\UIAutomation.dll;
# set a small delay between nodes
# because the refresh of each page should take time
[UIAutomation.Preferences]::OnSuccessDelay = 100;

# create our enum object
[PSObject]$testNames = New-Object PSObject;
$testNames | `
	Add-Member -MemberType NoteProperty -Name AppTitle -Value $AppTitle -PassThru | `
	Add-Member -MemberType NoteProperty -Name HelpTitle -Value $HelpTitle -PassThru | `
	Add-Member -MemberType NoteProperty -Name AppName -Value $FileName;

# start the AUT, its help file and get the window
Start-Process $testNames.AppName -PassThru | Get-UIAWindow -Seconds 120 | `
	Get-UIAMenuItem -Name Help | Invoke-UIAMenuItemClick | `
	Get-UIAMenuItem -Name 'Help*Topic*' | INvoke-UIAMenuItemClick;
Get-UIAWindow -Name $testNames.HelpTitle -Seconds 120;

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
$rootNode = Get-UIATree -Seconds 120;
Invoke-TreeNodeChildrenProcess $rootNode;