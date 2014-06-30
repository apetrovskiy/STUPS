ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Get-UiaWindow -Name *etwr*dit*

$treeItem01 = Get-UiaTreeItem -Name *comp*coll*
$treeItem02 = Get-UiaTreeItem -Name *folder*

$treeItem01 | Invoke-UiaControlClick;
$treeItem01.Mouse.LeftButtonDown();
$treeItem01 | Move-UiaCursor -X 5 -Y 5;
$treeItem02 | Move-UiaCursor -X 5 -Y 5;
$treeItem02.SetFocus();
sleep -Seconds 2;
$treeItem02.Mouse.LeftButtonUp();


