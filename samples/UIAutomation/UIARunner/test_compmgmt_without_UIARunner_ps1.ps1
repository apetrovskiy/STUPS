ipmo .\UIAutomation.dll;
ipmo .\TMX.dll;

Start-Process compmgmt.msc -PassThru | Get-UIAWindow | Get-UIATree | Get-UIATreeItem -n 'Shared Folders' | Invoke-UIATreeItemExpand | Get-UIATreeItem -n Shares | Invoke-UIAControlClick;