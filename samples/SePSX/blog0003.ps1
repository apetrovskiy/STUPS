ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll

$searchData = @("cheese", "juice", "wine");

[SePSX.Preferences]::OnSuccessDelay=0
[SePSX.Preferences]::OnErrorDelay=0
[SePSX.Preferences]::OnSleepDelay=10
[SePSX.Preferences]::Highlight=$false
[SePSX.Preferences]::HighlightParent=$false

[int]$counter = 0;
$drivers = Start-SeChrome -Count 3;
$drivers | Enter-SeURL "http://google.com" | %{ $null = $_ | Get-SeWebElement -Name q | Set-SeWebElementKeys $searchData[$counter] | Submit-SeWebElement; $counter++; }

$drivers | Read-SeWEbDriverUrl;




