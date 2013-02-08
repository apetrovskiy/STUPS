ipmo C:\Projects\PS\SePSX\SePSX\bin\Release35\SePSX.dll
$ff01 = Start-SeFirefox;
$ff01 | `
	Enter-SeURL -URL "http://www.google.com/" | `
	Get-SeWebElement -Name "q" | `
	Set-SeWebElementKeys -Text "Cheese" | `
	Submit-SeWebElement;
sleep -Seconds 3; # to observe the result
$ff01.Title;
$ff01 | Stop-SeFirefox;

$ff02 = Start-SeFirefox;
Enter-SeURL -URL "http://www.google.com/" | `
	Get-SeWebElement -Name "q" | `
	Set-SeWebElementKeys -Text "Cheese" | `
	Submit-SeWebElement;
sleep -Seconds 3; # to observe the result
$ff02.Title;
$ff02 | Stop-SeFirefox;

$ie01 = Start-SeInternetExplorer;
Enter-SeURL -URL "http://www.google.com/" | `
	Get-SeWebElement -Name "q" | `
	Set-SeWebElementKeys -Text "Cheese" | `
	Submit-SeWebElement;
sleep -Seconds 3; # to observe the result
$ie01.Title;
$ie01 | Stop-SeInternetExplorer;

$ch01 = Start-SeChrome;
Enter-SeURL -URL "http://www.google.com/" | `
	Get-SeWebElement -Name "q" | `
	Set-SeWebElementKeys -Text "Cheese" | `
	Submit-SeWebElement;
sleep -Seconds 3; # to observe the result
$ch01.Title;
$ch01 | Stop-SeChrome;