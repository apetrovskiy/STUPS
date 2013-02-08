ipmo C:\Projects\PS\STUPS\UIAutomation\bin\Release35\UIAutomation.dll

[System.Windows.Automation.AutomationElement]::RootElement.FindAll([System.Windows.Automation.TreeScope]::Children, (New-Object System.Windows.Automation.PropertyCondition([System.Windows.Automation.Automationelement]::NameProperty, "Windows PowerShell"))) | Get-UIAWindow

