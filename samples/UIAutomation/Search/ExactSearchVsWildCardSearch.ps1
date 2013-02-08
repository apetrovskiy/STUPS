ipmo $global:uiautomationModule;

[UIAutomation.Preferences]::OnSuccessDelay = 0;

# regular search
[UIAutomation.Preferences]::DisableExactSearch = $false
Write-host "exact matching (one of few controls of the MenuItem type):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name File}).TotalSeconds
Stop-Process -Name mmc;

# search with wildcards
[UIAutomation.Preferences]::DisableExactSearch = $true
Write-host "wildcard matching (one of few controls of the MenuItem type):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name Fil*}).TotalSeconds
Stop-Process -Name mmc;

# regular search
[UIAutomation.Preferences]::DisableExactSearch = $false
Write-host "exact matching (one of a heap of controls of the Edit):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAEdit -Name BranchCache}).TotalSeconds
Stop-Process -Name mmc;

# search with wildcards
[UIAutomation.Preferences]::DisableExactSearch = $true
Write-host "wildcard matching (one of a heap of controls of the Edit):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAEdit -Name Branch*}).TotalSeconds
Stop-Process -Name mmc;

# regular search
[UIAutomation.Preferences]::DisableExactSearch = $false
Write-host "exact matching (one of few controls of the MenuItem type):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name File}).TotalSeconds
Stop-Process -Name mmc;

# search with wildcards
[UIAutomation.Preferences]::DisableExactSearch = $true
Write-host "wildcard matching (one of few controls of the MenuItem type):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name *il?}).TotalSeconds
Stop-Process -Name mmc;

# regular search
[UIAutomation.Preferences]::DisableExactSearch = $false
Write-host "exact matching (one of a heap of controls of the Edit):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAEdit -Name Workstation}).TotalSeconds
Stop-Process -Name mmc;

# search with wildcards
[UIAutomation.Preferences]::DisableExactSearch = $true
Write-host "wildcard matching (one of a heap of controls of the Edit):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAEdit -Name ?orksta*i*n*}).TotalSeconds
Stop-Process -Name mmc;

# regular search
[UIAutomation.Preferences]::DisableExactSearch = $false
Write-host "exact matching (one of few controls of the MenuItem type - it takes the full time timeout is set to):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name nothing}).TotalSeconds
Stop-Process -Name mmc;

# search with wildcards
[UIAutomation.Preferences]::DisableExactSearch = $true
Write-host "wildcard matching (one of few controls of the MenuItem type - it takes the full time timeout is set to):";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name not?ing}).TotalSeconds
Stop-Process -Name mmc;

# regular search
[UIAutomation.Preferences]::DisableExactSearch = $false
Write-host "exact matching:";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAEdit -Name nothing}).TotalSeconds
Stop-Process -Name mmc;

# search with wildcards
[UIAutomation.Preferences]::DisableExactSearch = $true
Write-host "wildcard matching:";
(Measure-Command {Start-Process services.msc -PassThru | Get-UIAWindow | Get-UIAEdit -Name ?othing}).TotalSeconds
Stop-Process -Name mmc;