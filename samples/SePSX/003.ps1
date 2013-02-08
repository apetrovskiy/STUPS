ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll
[SePSX.Preferences]::OnSuccessDelay=0
[SePSX.Preferences]::OnErrorDelay=0
[SePSX.Preferences]::OnSleepDelay=10
[SePSX.Preferences]::HighlightParent=$false
$driver = Start-SeChrome
$driver.Manage().Timeouts().SetPageLoadTimeout([System.TimeSpan]::MinValue);
Enter-SeURL "http://www.rbc.ru" | Get-SeWebElement -XPath "/html/body/div[1]/div/div[2]/table/tbody/tr[1]/td[1]/div/div/div[1]/h3/a[2]" -First | Invoke-SeWebElementClick;






ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll
[SePSX.Preferences]::OnSuccessDelay=0
[SePSX.Preferences]::OnErrorDelay=0
[SePSX.Preferences]::OnSleepDelay=10
[SePSX.Preferences]::HighlightParent=$false
$driver = Start-SeChrome
$driver.Manage().Timeouts().SetPageLoadTimeout([System.TimeSpan]::Zero);
Enter-SeURL "http://www.rbc.ru" | Get-SeWebElement -XPath "/html/body/div[1]/div/div[2]/table/tbody/tr[1]/td[1]/div/div/div[1]/h3/a[2]" -First | Invoke-SeWebElementClick;





ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll
[SePSX.Preferences]::OnSuccessDelay=0
Start-SeChrome | Set-SeWebDriverTimeout -PageLoadTimeout 1;
#$driver.Manage().Timeouts().SetPageLoadTimeout(1, [System.TimeSpan]::TicksPerMillisecond);
Enter-SeURL "http://www.rbc.ru" | Get-SeWebElement -XPath "/html/body/div[1]/div/div[2]/table/tbody/tr[1]/td[1]/div/div/div[1]/h3/a[2]" -First | Invoke-SeWebElementClick;



ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll
[SePSX.Preferences]::OnSuccessDelay=0
[SePSX.Preferences]::OnErrorDelay=0
[SePSX.Preferences]::OnSleepDelay=200
Start-SeChrome;
Set-SeWebDriverTimeout -PageLoadTimeout 1000 -Verbose;
Enter-SeURL "http://www.rbc.ru" | Get-SeWebElement -XPath "/html/body/div[1]/div/div[2]/table/tbody/tr[1]/td[1]/div/div/div[1]/h3/a[2]" -First | Invoke-SeWebElementClick;



