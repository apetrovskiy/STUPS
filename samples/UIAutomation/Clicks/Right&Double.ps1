Get-UIAWindow -n services | Get-UIATreeItem | Invoke-UIAControlContextMenu | Get-UIAMenuItem -n connect* | Invoke-UIAMenuItemClick;

Get-UIAWindow -n services | Get-UIADataGrid | Get-UIADataItem BranchCache | Invoke-UIAControlClick -DoubleClick;