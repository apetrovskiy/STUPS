ipmo C:\Projects\PS\STUPS\ESXiMgmt\ESXiMgmt.Cmdlets\bin\Release35\EsxiMgmt.Cmdlets.dll
New-EsxiHostConnectionData -Server 172.28.1.11 -Username root -Password =1qwerty -KeyFilePath E:\putty\my_esxi.key
[EsxiMgmt.Core.Data.ConnectionData]::Entries
Get-EsxiVm -Server 172.28.1.11 -Name *

New-EsxiVm -Server 172.28.1.11 -Name vm01 -Path "[datastore1] vm01.vmx"
New-EsxiVm -Server 172.28.1.11 -Name vm01

Get-EsxiVm -Server 172.28.1.11 -Name vm01
Get-EsxiVm -Server 172.28.1.11 -Name vm02
Get-EsxiVm -Server 172.28.1.11 -Id 3
Get-EsxiVm -Server 172.28.1.11 -Path "[datastore1] vm02.vmx"

# Remove-EsxiVm -Server 172.28.1.11 -Name vm01

"======================================================================"
Get-EsxiVm -Server 172.28.1.11 -Name *



