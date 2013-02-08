ipmo C:\Projects\PS\SePSX\SePSX\bin\Release35\SePSX.dll
$ff01 = Start-SeFirefox
$ff02 = Start-SeWebDriver -DriverName Firefox
Start-SeFirefox -Name ff03
$ch01 = Start-SeChrome
Start-SeChrome -Name ch02
$ie01 = Start-SeInternetExplorer
Start-SeInternetExplorer -Name ie02
Stop-SeFirefox -Name ff03
Stop-SeChrome -Name ch02
Stop-SeInternetExplorer -Name ie02
$ff01 | Stop-SeFirefox
$ff02 | Stop-SeFirefox
$ch01 | Stop-SeChrome
$ie01 | Stop-SeInternetExplorer