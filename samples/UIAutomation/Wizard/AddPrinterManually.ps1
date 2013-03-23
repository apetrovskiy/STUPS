ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

[scriptblock]$backwardAction = { Get-UIAButton -AutomationId 'backbutton' | Invoke-UIAButtonClick; };
[scriptblock]$cancelAction = { Get-UIAButton -AutomationId 'cancelbutton' | Invoke-UIAButtonClick; };
[scriptblock]$getWindowAction = { Wait-UIAWindow -pn "rundll32" -Seconds 10; };
[UIAutomation.WizardCollection]::ResetData();

New-UIAWizard -Name AddPrinterWizard `
    -GetWindowAction $getWindowAction `
    -StartAction { Start-Process "$($env:SystemRoot)\System32\rundll32.exe" -ArgumentList "printui.dll`,PrintUIEntry","/il" -PassThru | Get-UIAWindow; } | `
    Add-UIAWizardStep -Name Step01Initial `
        -Description "Searching for available printers..." `
        -SearchCriteria @{controlType="pane";class="Button";name="*the*printer*that*i*want*isn't*listed*"} `
        -StepForwardAction { Get-UIAPane -Name "*the*printer*that*i*want*isn't*listed*" | Invoke-UIAControlClick; } `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step02Initial2 `
        -Description "No printers were found." `
        -SearchCriteria @{controlType="pane";class="Button";name="*the*printer*that*i*want*isn't*listed*"} `
        -StepForwardAction { Get-UIAPane -Name "*the*printer*that*i*want*isn't*listed*" | Invoke-UIAControlClick; } `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step03ChooseSettings `
        -Description "Find a printer by other options" `
        -SearchCriteria @{controlType="radiobutton";name="*add*manual*settings*"} `
        -StepForwardAction { 
            Get-UIARadioButton -Name "*add*manual*settings*" | Set-UIARadioButtonToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step04ChoosePort `
        -Description "Choose a printer port" `
        -SearchCriteria @{controlType="RadioButton";name="*create*new*port*"} `
        -StepForwardAction {
            Get-UIARadioButton -Name "*create*new*port*" | Set-UIARadioButtonToggleState $true;
            Get-UIAComboBox -Name "*type*of*port*" | Get-UIAButton | Invoke-UIAButtonClick;
            Get-UIAComboBox -Name "*type*of*port*" | Get-UIAListItem -Name "*standard*tcp*port*" | Invoke-UIAListItemClick;
            sleep -Seconds 2;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step05PrinterData `
        -Description "Type a printer hostname or IP address" `
        -SearchCriteria @{controlType="text";name="*hostname*or*ip*address*"} `
        -StepForwardAction {
            param(
                  [string]$PrinterName,
                  [string]$PortName
                  )
            Get-UIAEdit -AutomationId '4690' | Set-UIAEditText $PrinterName;
            Get-UIAEdit -AutomationId '4692' | Set-UIAEditText $PortName;
            Get-UIACheckBox -Name "*query*" | Set-UIACheckBoxToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step06DetectingPort `
        -Description "Detecting TCP/IP port" `
        -SearchCriteria @{controlType="text";name="*Detecting*the*TCP/IP*port*"} `
        -StepForwardAction {} `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step07AdditionalPortInformation `
        -Description "Additional port information required" `
        -SearchCriteria @{controlType="text";name="*The*device*is*not*found*on*the*network*"} `
        -StepForwardAction {
            Get-UIARadioButton -Name "Standard" | Set-UIARadioButtonToggleState $true;
            Get-UIAComboBox -Name "*Device*type*" | Get-UIAListItem -Name "*generic*" | Invoke-UIAListItemSelectItem "*generic*";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step08DetectingDriverModel `
        -Description "Detecting the driver model..." `
        -SearchCriteria @{controlType="text";name="*Windows*is*communicating*with*the*printer*"} `
        -StepForwardAction {} `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step09InstallPrinterDriver `
        -Description "Install the printer driver" `
        -SearchCriteria @{controlType="text";name="*choose*your*printer*from*the*list*"} `
        -StepForwardAction {
            param(
                  [string]$PrinterVendor,
                  [string]$PrinterModel
                  )
            Get-UIADataGrid -AutomationId '1580' -Class 'SysListView32' | Get-UIADataItem -Name 'Canon' | Invoke-UIADataItemSelectItem "$($PrinterVendor)";
            Get-UIADataGrid -AutomationId '1581' -Class 'SysListView32' | Get-UIADataItem -Name '*0303*' | Invoke-UIADataItemSelectItem "$($PrinterModel)";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step10DriverVersion `
        -Description "Which version of the driver do you want to use?" `
        -SearchCriteria @{controlType="text";name="*Windows*detected*driver*already*installed*printer*"} `
        -StepForwardAction {
            Get-UIARadioButton -Name '*Use*driver*currently*installed*recommended*' | Set-UIARadioButtonToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step11PrinterName `
        -Description "Type a printer name" `
        -SearchCriteria @{controlType="text";name="*printer*name*:*"} `
        -StepForwardAction {
            param(
                  [string]$PrinterName
                  )
            Get-UIAEdit -AutomationId '1046' | Set-UIAEditText "$($PrinterName)";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step12InstallingDriver `
        -Description "" `
        -SearchCriteria @{controlType="text";name="*installing*"} `
        -StepForwardAction {} `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step13PrinterSharing `
        -Description "Printer Sharing" `
        -SearchCriteria @{controlType="radiobutton";name="*share*printer*"} `
        -StepForwardAction {
            param(
                  [string]$ShareName,
                  [string]$Location,
                  [string]$Comment
                  )
            Get-UIARadioButton -Name "*share*printer*others*can*find*" | Set-UIARadioButtonToggleState $true;
            Get-UIAEdit -AutomationId '3302' | Set-UIAEditText "$($ShareName)";
            Get-UIAEdit -AutomationId '4553' | Set-UIAEditText "$($Location)";
            Get-UIAEdit -AutomationId '4552' | Set-UIAEditText "$($Comment)";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction | `
    Add-UIAWizardStep -Name Step14Finish `
        -Description "" `
        -SearchCriteria @{controlType="button";name="*finish*"} `
        -StepForwardAction {
            try {
                Get-UIACheckBox -Name "*set*as*the*default*printer*" | Set-UIACheckBoxToggleState $true;
            }
            catch {}
            Get-UIAButton -AutomationId 'finishbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction;

    Invoke-UIAWizard -Name AddPrinterWizard `
        -Parameters @{step="Step05PrinterData";action="forward";parameters=@("printer_1","port_1")},
                    @{step="Step09InstallPrinterDriver";action="forward";parameters=@('Canon','*0303*')},
                    @{step="Step11PrinterName";action="forward";parameters=@("one more printer")},
                    @{step="Step13PrinterSharing";action="forward";parameters=@('share$$','location01','my comment')} -Verbose;

    Invoke-UIAWizard -Name AddPrinterWizard `
        -Directions @{step="Step05PrinterData";action="backward"},
                    @{step="Step05PrinterData";action="forward"},
                    @{step="Step05PrinterData";action="backward"},
                    @{step="Step09InstallPrinterDriver";action="backward"},
                    @{step="Step11PrinterName";action="backward"},
                    @{step="Step13PrinterSharing";action="backward"} `
        -Parameters @{step="Step05PrinterData";action="forward";parameters=@("printer_2","port_2")},
                    @{step="Step09InstallPrinterDriver";action="forward";parameters=@('Canon','*0303*')},
                    @{step="Step11PrinterName";action="forward";parameters=@("the second one")},
                    @{step="Step13PrinterSharing";action="forward";parameters=@('share$$$','location02','my new comment')} -Verbose;