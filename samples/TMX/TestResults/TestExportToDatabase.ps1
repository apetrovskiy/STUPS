ipmo C:\Projects\PS\STUPS\TMX\bin\Release35\TMX.dll
ipmo C:\Projects\PS\STUPS\UIAutomation\bin\Release35\UIAutomation.dll
C:\Projects\PS\STUPS\samples\samples\TMX\testTMX.ps1
New-TMXTestDB -ResultsDB -FileName c:\1\00112233.db3 -Name 1234
Backup-TMXTestResults -Verbose
Export-TMXTestResults -As XML -Path C:\1\test_results.xml


