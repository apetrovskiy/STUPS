ipmo C:\Projects\PS\SePSX\SePSX\bin\Release35\SePSX.dll
$ff01 = Start-SeChrome;
$searchBox = ($ff01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$searchBox.SendKeys("Cheese");
$searchBox.Submit();
sleep -Seconds 3; # to observe the result
$ff01.Title;
$ff01 | Stop-SeChrome;
