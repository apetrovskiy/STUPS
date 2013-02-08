ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll

Compare-Object $(Start-SeChrome | Enter-SeURL "C:\Projects\PS\STUPS\TestData\select.htm" | Get-SeWebElement -TagName select | Get-SeSelection -All | Read-SeWebElementText) $(Get-Content -Path "C:\Projects\PS\STUPS\TestData\select.txt")
Compare-Object $(Start-SeChrome | Enter-SeURL "C:\Projects\PS\STUPS\TestData\select.htm" | Get-SeWebElement -TagName select | Get-SeSelection -All | Read-SeWebElementText) $(Get-Content -Path "C:\Projects\PS\STUPS\TestData\select2.txt")