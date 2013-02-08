Get-UIADesktop;
Show-UIAMetroStartScreen;
Get-UIAListItem -Name *Internet*Explorer* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *people* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *messag* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *phot* | Invoke-UIAListItemClick;

Show-UIAMetroStartScreen;
Get-UIAListItem -Name *calen* | Invoke-UIAListItemClick;