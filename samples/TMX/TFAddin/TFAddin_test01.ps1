ipmo C:\Projects\PS\STUPS\TMX\TFAddin\bin\Release35\TFAddin.dll
Connect-TFServer -Url http://njdevcenter.nwx.local:8080/tfs -Credentials (Get-Credential);
Get-TFCollection defaultcollection;
$project = Get-TFProject 'R&D tasks'
$projects = Get-TFProject 'RnD tasks',training
