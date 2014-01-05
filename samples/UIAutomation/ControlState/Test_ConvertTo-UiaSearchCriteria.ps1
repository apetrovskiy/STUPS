ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
$wnd = Start-Process calc -PassThru | Get-UiaWindow

# default (included name, automationId, controlType; excluded labeledBy, processId, nativeWindowHandle)
$wnd | ConvertTo-UiaSearchCriteria

# the full set of properties
$wnd | ConvertTo-UiaSearchCriteria -Full

$wnd | ConvertTo-UiaSearchCriteria -Include name,classname,controltype,nativewindowhandle

$wnd | ConvertTo-UiaSearchCriteria -Include name,classname,controltype,nativewindowhandle,processid

$wnd | ConvertTo-UiaSearchCriteria -Include name,classname,controltype,nativewindowhandle,processid,nativewindowhandle

$wnd | ConvertTo-UiaSearchCriteria -Include name,classname,controltype,nativewindowhandle,processid,nativewindowhandle -Exclude automationid


