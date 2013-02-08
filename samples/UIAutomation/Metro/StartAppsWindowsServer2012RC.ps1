Get-UIADesktop;
Show-UIAMetroStartScreen;
Get-UIAListItem -Name *Internet*Explorer* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *control* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *computer* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *task*man* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *admi*tool* | Invoke-UIAListItemClick;