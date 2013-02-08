# ipmo UIAutomation.dll
$global:annals = New-Object System.Collections.ArrayList;
Start-Process calc -PassThru | Get-UIAWindow | Register-UIAStructureChangedEvent -ChildrenBulkAdded -ChildAdded -ChildRemoved -ChildrenReordered -EventAction { param($src, $e) $global:annals.Add($src.Current.Name); $global:annals.Add($e.StructureChangeType); };

# perform manual or programmatic actions like show/hide worksheets or change mode

# display which event have been caught
$global:annals;

