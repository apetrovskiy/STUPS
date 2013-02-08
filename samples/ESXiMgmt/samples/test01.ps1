ipmo C:\Projects\PS\ESXiMgmt\ESXiMgmt\bin\Release\ESXiMgmt.dll
$a = Connect-ESXiHost -Server 10.30.42.238 -Username root -Password =1qwerty -DatastoreName datastore1
Invoke-ESXiCommand -Command "ls -la" -InputObject $a