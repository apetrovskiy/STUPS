ipmo C:\Projects\ps\STUPS\TMX\TMX\bin\Release35\TMX.dll
New-TMXTestPlatform -Name platform1 -Version (Get-WmiObject -Class Win32_OperatingSystem).Version -Architecture $env:PROCESSOR_ARCHITECTURE -Language (Get-WmiObject -Class Win32_OperatingSystem).OSLanguage;

