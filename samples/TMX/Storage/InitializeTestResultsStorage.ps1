ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
[UIAutomation.Preferences]::EveryCmdletAsTestResult = $true
Initialize-TMXResultsStorage -Server wks301\sqlexpress -Database probe -IntegratedSecurity -Verbose
#Initialize-TMXResultsStorage -Server SPB8638\FIRST -Database probe -IntegratedSecurity
[TMX.Preferences]::StorageConnectionString


