ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

[scriptblock]$backwardAction = { Get-UIAButton -AutomationId 'backbutton' | Invoke-UIAButtonClick; };
[scriptblock]$cancelAction = { Get-UIAButton -AutomationId 'cancelbutton' | Invoke-UIAButtonClick; };
[scriptblock]$getWindowAction = { Wait-UIAWindow -pn "rundll32" -Seconds 10; };
[UIAutomation.WizardCollection]::ResetData();

New-UIAWizard -Name AddPrinterWizard `
    -DefaultStepGetWindowAction $getWindowAction `
    -StartAction { Start-Process "$($env:SystemRoot)\System32\rundll32.exe" -ArgumentList "printui.dll`,PrintUIEntry","/il" -PassThru | Get-UIAWindow; } | `
    Add-UIAWizardStep -Name Step01Initial `
        -Description "Searching for available printers..." `
        -StepForwardAction { Get-UIAPane -Name "*the*printer*that*i*want*isn't*listed*" | Invoke-UIAControlClick; } `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="pane";class="Button";name="*the*printer*that*i*want*isn't*listed*"} | `
    Add-UIAWizardStep -Name Step02Initial2 `
        -Description "No printers were found." `
        -StepForwardAction { Get-UIAPane -Name "*the*printer*that*i*want*isn't*listed*" | Invoke-UIAControlClick; } `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="pane";class="Button";name="*the*printer*that*i*want*isn't*listed*"} | `
    Add-UIAWizardStep -Name Step03ChooseSettings `
        -Description "Find a printer by other options" `
        -StepForwardAction { 
            Get-UIARadioButton -Name "*add*manual*settings*" | Set-UIARadioButtonToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="radiobutton";name="*add*manual*settings*"} | `
    Add-UIAWizardStep -Name Step04ChoosePort `
        -Description "Choose a printer port" `
        -StepForwardAction {
            Get-UIARadioButton -Name "*create*new*port*" | Invoke-UIARadioButtonSelectItem -ItemName "*create*new*port*"; #Invoke-UIARadioButtonToggle; #Set-UIARadioButtonToggleState $true;
            Get-UIAComboBox -Name "*type*of*port*" | Get-UIAButton | Invoke-UIAButtonClick;
            Get-UIAComboBox -Name "*type*of*port*" | Get-UIAListItem -Name "*standard*tcp*port*" | Invoke-UIAListItemClick;
            #| Invoke-UIAListItemSelectItem - "*standard*tcp*port*";
            sleep -Seconds 2;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="RadioButton";name="*create*new*port*"} | `
    Add-UIAWizardStep -Name Step05PrinterData `
        -Description "Type a printer hostname or IP address" `
        -StepForwardAction {
            param(
                  [string]$PrinterName,
                  [string]$PortName
                  )
            Get-UIAEdit -AutomationId '4690' | Set-UIAEditText $PrinterName; #"printer001";
            Get-UIAEdit -AutomationId '4692' | Set-UIAEditText $PortName; #"port_001";
            Get-UIACheckBox -Name "*query*" | Set-UIACheckBoxToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*hostname*or*ip*address*"} | `
    Add-UIAWizardStep -Name Step05PrinterData `
        -Description "Detecting TCP/IP port" `
        -StepForwardAction {} `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*Detecting*the*TCP/IP*port*"} | `
    Add-UIAWizardStep -Name Step07AdditionalPortInformation `
        -Description "Additional port information required" `
        -StepForwardAction {
            Get-UIARadioButton -Name "Standard" | Set-UIARadioButtonToggleState $true;
            Get-UIAComboBox -Name "*Device*type*" | Get-UIAListItem -Name "*generic*" | Invoke-UIAListItemSelectItem "*generic*";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*The*device*is*not*found*on*the*network*"} | `
    Add-UIAWizardStep -Name Step08DetectingDriverModel `
        -Description "detecting the driver model..." `
        -StepForwardAction {} `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*Windows*is*communicating*with*the*printer*"} | `
    Add-UIAWizardStep -Name Step09InstallPrinterDriver `
        -Description "Install the printer driver" `
        -StepForwardAction {
            Get-UIADataGrid -AutomationId '1580' -Class 'SysListView32' | Get-UIADataItem -Name 'Canon' | Invoke-UIADataItemSelectItem 'Canon';
            Get-UIADataGrid -AutomationId '1581' -Class 'SysListView32' | Get-UIADataItem -Name '*0303*' | Invoke-UIADataItemSelectItem '*0303*';
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*choose*your*printer*from*the*list*"} | `
    Add-UIAWizardStep -Name Step10DriverVersion `
        -Description "Which version of the driver do you want to use?" `
        -StepForwardAction {
            Get-UIARadioButton -Name '*Use*driver*currently*installed*recommended*' | Invoke-UIARadioButtonSelectItem -ItemName '*Use*driver*currently*installed*recommended*';
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*Windows*detected*driver*already*installed*printer*"} | `
    Add-UIAWizardStep -Name Step11PrinterName `
        -Description "" `
        -StepForwardAction {
            Get-UIAEdit -AutomationId '1046' | Set-UIAEditText "new printer";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*printer*name*"} | `
    Add-UIAWizardStep -Name Step12InstallingDriver `
        -Description "" `
        -StepForwardAction {} `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{} | `
    Add-UIAWizardStep -Name Step13PrinterSharing `
        -Description "" `
        -StepForwardAction {
            Get-UIARadioButton -Name "*share*printer*others*can*find*" | Set-UIARadioButtonToggleState $true;
            Get-UIAEdit -AutomationId '3302' | Set-UIAEditText 'share$$';
            Get-UIAEdit -AutomationId '4553' | Set-UIAEditText "location";
            Get-UIAEdit -AutomationId '4552' | Set-UIAEditText "my comment";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="RadioButton";name="*Share*this*printer*"} | `
    Add-UIAWizardStep -Name Step14Finish `
        -Description "" `
        -StepForwardAction {
            Get-UIARadioButton -Name "*share*printer*others*can*find*" | Set-UIARadioButtonToggleState $true;
            Get-UIACheckBox -Name "*set*as*the*default*printer*" | Set-UIACheckBoxToggleState $true;
            Get-UIAButton -AutomationId 'finishbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="button";name="*finish*"} # | `
    #Invoke-UIAWizard -Automatic -ForwardDirection -Name AddPrinterWizard -Verbose;
    #Invoke-UIAWizard -Automatic -ForwardDirection -Name AddPrinterWizard -Parameters @{step="Step05PrinterData";action="forward";parameters=@("printer_parameterized","port_parameterized")}
    Invoke-UIAWizard -Automatic -ForwardDirection -Name AddPrinterWizard -Parameters @{step="Step05PrinterData";action="forward";parameters=@("printer_parameterized_2","port_parameterized_2")}