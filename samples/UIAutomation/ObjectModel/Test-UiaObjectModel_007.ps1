$wnd = Start-Process calc -PassThru | Get-UiaWindow;
$wnd.Descendants.Buttons['1'].Click();
$wnd.Descendants.MenuItems['view'].Expand() | Get-UiaMenuItem Standard | Invoke-UiaControlClick;
$wnd.Descendants.MenuItems['view'].Expand() | Get-UiaMenuItem Worksheets | Move-UiaCursor -X 10 -Y 10 | Get-UiaMenuItem Mortgage | Invoke-UiaMenuItemClick;
sleep -Seconds 2;
$wnd.Descendants.Edits['purch*price'][0].Value = 123;
$wnd.Descendants.MenuItems['view'].Expand() | Get-UiaMenuItem basic | Invoke-UiaMenuItemClick;


