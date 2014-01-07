ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
$di = Get-UiaWindow -n services | Get-UiaDataGrid | Get-UiaDataItem -n *application*experience*

# via SelectionItemPattern
$p2 = $di.GetCurrentPattern([System.Windows.Automation.SelectionItemPattern]::Pattern)
$p2
$p2.Current
$p2.Current.SelectionContainer
$p2.Current.SelectionContainer.Current

# via dynamic property
$di.SelectionContainer
$di.SelectionContainer.Current
$di.SelectionContainer.Current.SourceInformation


