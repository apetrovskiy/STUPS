ipmo 'C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll'
Import-TMXTestResults -As xml -Path '\\10.0.1.214\c$\old\_TESTHOME87\Reports\rdp.xml' -Verbose
Search-TMXTestResult | fl id,name,details
Export-TMXTestResults -As xml -Path C:\1\export_of_imported.xml

