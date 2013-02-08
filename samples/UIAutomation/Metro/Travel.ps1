[UIAutomation.Preferences]::Timeout = 10000;
Get-UIADesktop;
Show-UIAMetroStartScreen;

# clicking on the tile of the AUT
Get-UIAListItem -Name 'Travel' | `
Invoke-UIAListItemClick;

# the loading screen
try {
	Get-UIAWindow -Name 'Travel' | `
	Get-UIAProgressBar;
	#sleep -Seconds 5; # the app is loading
}
catch {}

Get-UIAWindow -Name 'Travel' | `
Get-UIAList -Name 'Featured Destinations' -Seconds 60;

# Click the app menu -> Destinations
Show-UIAMetroMenu;
Get-UIAWindow -Name 'Travel' | `
Get-UIAMenuBar -Name 'App Bar' | `
Get-UIAHyperlink -Name 'Destinations' | `
Invoke-UIAControlClick;
#Invoke-UIAHyperlinkClick;


#(Get-UIAWindow -Name 'Travel' | `
#Get-UIAList -Name 'Featured Destinations' -Seconds 60 | `
#Get-UIAListItem | `
#Invoke-UIAListItemScrollItem -PassThru).Current;
##Get-UIAControlDescendants | `
##%{$_.Current >> c:\1\FEatuedDestinations.txt;}