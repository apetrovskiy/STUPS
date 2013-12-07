# Arrange:
# calc.exe
# the Standard mode
# Worksheets -> Mortgage
# Purchase price == "22"
# this code returns three controls in versions until 0.8.7 Aplha 2
# in contemporary versions, this code returns only one control ("Purchase price")
Get-UiaWindow -n *calc* | Get-UiaEdit -n "(purchase\sprice|down\spayment|term\s\(years\))" -Regex -Value 22