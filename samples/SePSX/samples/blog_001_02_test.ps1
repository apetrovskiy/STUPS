ipmo C:\Projects\PS\SePSX\SePSX\bin\Release35\SePSX.dll
$ff01 = Start-SeChrome;
$searchBox = ($ff01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$searchBox.SendKeys("Cheese");
$searchBox.Submit();
sleep -Seconds 3; # to observe the result
$ff01.Title;
$ff01 | Stop-SeChrome;

$ch01 = Start-SeChrome;
$searchBox = ($ch01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$searchBox.SendKeys("Cheese");
$searchBox.Submit();
sleep -Seconds 3; # to observe the result
$ch01.Title;
$ch01 | Stop-SeChrome;

$ie01 = Start-SeInternetExplorer;
$searchBox = ($ie01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$searchBox.SendKeys("Cheese");
$searchBox.Submit();
sleep -Seconds 3; # to observe the result
$ie01.Title;
$ie01 | Stop-SeInternetExplorer;

$ff01 = Start-SeChrome;
$searchBox = ($ff01 | Enter-SeURL -URL "http://www.yandex.ru/" | Get-SeWebElement -Id "text");
$searchBox.SendKeys("Cheese");
$searchBox.Submit();
sleep -Seconds 3; # to observe the result
$ff01.Title;
$ff01 | Stop-SeChrome;