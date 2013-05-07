services.msc
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Get-UIAWindow -pn mmc -n services -WithControl @{controlType="datagrid"}

# getting a row
Get-UIAWindow -pn mmc -n services -WithControl @{controlType="datagrid"} | Get-UIADataGrid | Get-UIADataItem 'Base Filtering Engine'

# selecting another row
Get-UIAWindow -pn mmc -n services -WithControl @{controlType="datagrid"} | Get-UIADataGrid | Get-UIADataItem 'avast! Antivirus' | Invoke-UIADataItemSelectItem

# diplaying the selection
Get-UIADataGrid | Get-UIADataGridSelection | Read-UIAControlName




