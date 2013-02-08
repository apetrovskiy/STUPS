Set-StrictMode -Version Latest

[UIAutomation.Preferences]::Timeout = 10000;
[UIAutomation.Preferences]::EveryCmdletAsTestResult = $true;
[UIAutomation.Preferences]::OnSuccessDelay = 0;

Get-UIADesktop | Get-UIAListItem -Name Mail | Invoke-UIAListItemClick;
Get-UIAWindow -n Mail


Get-UIAListItem -Name people | Invoke-UIAListItemClick;


Get-UIAListItem -Name finan* | Invoke-UIAListItemClick;