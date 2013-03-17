[scriptblock]$backwardAction = { Get-UIAButton -AutomationId 'backbutton' | Invoke-UIAButtonClick; };
[scriptblock]$cancelAction = { Get-UIAButton -AutomationId 'cancelbutton' | Invoke-UIAButtonClick; };
[scriptblock]$getWindowAction = { Wait-UIAWindow -pn "rundll32" -Seconds 10; };

New-UIAWizard -Name AddPrinterWizard `
    -StartAction { Start-Process "$($env:SystemRoot)\System32\rundll32.exe" -ArgumentList "'printui.dll,PrintUIEntry'","/il" -PassThru | Get-UIAWindow; } | `
    Add-UIAWizardStep -Name Step01Initial `
        -StepForwardAction { Get-UIAPane -Name "*the*printer*that*i*wand*isn't*listed*" | Invoke-UIAControlClick; } `
        -StepBackwardAction {} `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*searching*for*available*printers*"} | `
    Add-UIAWizardStep -Name Step02ChooseSettings `
        -StepForwardAction { 
            Get-UIARadioButton -Name "*add*manual*settings*" | Set-UIARadioButtonToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*find*a*printer*by*other*options*"} | `
    Add-UIAWizardStep -Name Step03ChoosePort `
        -StepForwardAction {
            Get-UIARadioButton -Name "*create*new*port*" | Set-UIARadioButtonToggleState $true;
            Get-UIAComboBox -Name "*type*of*port*" | Get-UIAListItem -Name "*standard*tcp*port*" | Invoke-UIAListItemSelectItem "*standard*tcp*port*";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*choose*a*printer*port*"} | `
    Add-UIAWizardStep -Name Step04PrinterData `
        -StepForwardAction {
            Get-UIAEdit -AutomationId '4690' | Set-UIAEditText "printer001";
            Get-UIAEdit -AutomationId '4692' | Set-UIAEditText "port001";
            Get-UIACheckBox -Name "*query*" | Set-UIACheckBoxToggleState $true;
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*type*a*printer*hostname*or*ip*address*"} | `
    Add-UIAWizardStep -Name Step06AdditionalPortInformation `
        -StepForwardAction {
            Get-UIARadioButton -Name "Standard" | Set-UIARadioButtonToggleState $true;
            Get-UIAComboBox -Name "*Device*type*" | Get-UIAListItem -Name "*generic*" | Invoke-UIAListItemSelectItem "*generic*";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*additional*port*information*required*"} | `
    Add-UIAWizardStep -Name Step07InstallPrinterDriver `
        -StepForwardAction {
            Get-UIADataGrid -AutomationId '1580' -Class 'SysListView32' | Get-UIADataItem -Name 'Canon' | Invoke-UIADataItemSelectItem 'Canon';
            Get-UIADataGrid -AutomationId '1581' -Class 'SysListView32' | Get-UIADataItem -Name '*0303*' | Invoke-UIADataItemSelectItem '*0303*';
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*install*the*printer*driver*"} | `
    Add-UIAWizardStep -Name Step08PrinterName `
        -StepForwardAction {
            Get-UIAEdit -AutomationId '1046' | Set-UIAEditText "new printer";
            Get-UIAButton -AutomationId 'nextbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*type*a*printer*name*"} | `
    Add-UIAWizardStep -Name Step09PrinterSharing `
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
        -SearchCriteria @{controlType="text";name="*printer*sharing*"} | `
    Add-UIAWizardStep -Name Step10Finish `
        -StepForwardAction {
            Get-UIARadioButton -Name "*share*printer*others*can*find*" | Set-UIARadioButtonToggleState $true;
            Get-UIACheckBox -Name "*set*as*the*default*printer*" | Set-UIACheckBoxToggleState $true;
            Get-UIAButton -AutomationId 'finishbutton' | Invoke-UIAButtonClick;
                           } `
        -StepBackwardAction $backwardAction `
        -StepCancelAction $cancelAction `
        -StepGetWindowAction $getWindowAction `
        -SearchCriteria @{controlType="text";name="*you've*successfully*added*driver**"} | `