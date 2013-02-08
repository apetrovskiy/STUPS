ipmo C:\Projects\PS\SePSX\SePSX\bin\Release35\SePSX.dll
$ff01 = Start-SeFirefox
$elementFF = ($ff01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$elementFF.SendKeys("Cheese").Submit();
$ch01 = Start-SeChrome
$elementChrome = ($ch01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$elementChrome.SendKeys("Cheese").Submit();
$ie01 = Start-SeInternetExplorer
$elementIE = ($ie01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElement -Name "q");
$elementIE.SendKeys("Cheese").Submit();

$ff01 | Stop-SeFirefox
$ch01 | Stop-SeChrome
$ie01 | Stop-SeInternetExplorer


$ff01 = Start-SeFirefox
$elementsFF = ($ff01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElementCollection -Name "q");
$elementsFF;
$ch01 = Start-SeChrome
$elementsChrome = ($ch01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElementCollection -Name "q");
$elementsChrome;
$ie01 = Start-SeInternetExplorer
$elementsIE = ($ie01 | Enter-SeURL -URL "http://www.google.com/" | Get-SeWebElementCollection -Name "q");
$elementsIE;

$ff01 | Stop-SeFirefox
$ch01 | Stop-SeChrome
$ie01 | Stop-SeInternetExplorer