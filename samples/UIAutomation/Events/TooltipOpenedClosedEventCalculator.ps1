# ipmo UIAutomation
$elements = New-Object System.Collections.ArrayList;
Get-UIADesktop | Register-UIAToolTipOpenedEvent -EventAction { param($src, $e) $elements.Add("opened:"); $elements.Add($src.Current.Name); $elements.Add($src.Current.NativeWindowhandle); }
Get-UIADesktop | Register-UIAToolTipClosedEvent -EventAction { param($src, $e) $elements.Add("closed:"); $elements.Add($src.Current.NativeWindowhandle); }

