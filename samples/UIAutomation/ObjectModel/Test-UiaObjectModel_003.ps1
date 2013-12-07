ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaControl | %{ $_.Click(); }
