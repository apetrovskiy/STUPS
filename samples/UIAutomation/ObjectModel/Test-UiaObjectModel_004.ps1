ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
# calc.exe in the Programmer mode
$radioButtons = Get-UiaWindow -n *calc* | Get-UiaRadioButton;
$radioButtons[0].Select();
$radioButtons[2].Select();
$radioButtons[7].Select();