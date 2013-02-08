# this is deprecated since 0.8.0

ipmo $global:uiautomationModule;
ipmo $global:tmxModule;

[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation;
cls;

# here we are searching for all the element whose names start with 'a'
Start-Process calc -PassThru | Get-UIAWindow | Search-UIAControl -Name A*;

# here we get only button(s)
Start-Process calc -PassThru | Get-UIAWindow | Search-UIAControl -ControlType button -Name A*;

# this code should return the same as the first code snippet, 
# because there are only two types of controls whose names start with 'a'
Start-Process calc -PassThru | Get-UIAWindow | Search-UIAControl -ControlType button,menubar -Name A*;