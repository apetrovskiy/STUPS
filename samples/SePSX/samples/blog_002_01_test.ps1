ipmo C:\Projects\PS\SePSX\SePSX\bin\Release35\SePSX.dll
$ff01 = Start-SeChrome;
$box = ($ff01 | `
	Enter-SeURL -URL "http://www.google.com/" | `
	Get-SeWebElement -Name "q"); # | `
$box;
$box.Gettype().Name;
$box |	Set-SeWebElementKeys -Text "Cheese" -Verbose; # | `
$box |		Submit-SeWebElement -Verbose;
sleep -Seconds 3; # to observe the result
$ff01.Title;
$ff01 | Stop-SeChrome;
