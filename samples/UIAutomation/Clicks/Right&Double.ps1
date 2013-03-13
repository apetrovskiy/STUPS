# serivces.msc, run powershell as administrator
# open the Connect... window via right click on the tree item
Get-UIAWindow -n services | Get-UIATreeItem | Invoke-UIAControlContextMenu | Get-UIAMenuItem -n connect* | Invoke-UIAMenuItemClick;
Get-UIAWindow -pn mmc -n *select*computer* | Get-UIAButton Cancel | Invoke-UIAButtonClick;
# double click on a service in the grid:
Get-UIAWindow -n services | Get-UIADataGrid | Get-UIADataItem BranchCache | Invoke-UIAControlClick -DoubleClick;


