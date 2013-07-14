ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

Start-Process calc;
sleep -Milliseconds 500;

Write-Host "should be found:";
Wait-UIAWindow -Class *frame* -WithControl @{controlType="button";name="1"};

Write-Host "should be found:";
Wait-UIAWindow -Class *frame* -WithControl @{controlType="button";name="1"},@{controlType="button";name="2"},@{controlType="button";name="3"};

Write-Host "could not be found:";
Wait-UIAWindow -Class *frame* -WithControl @{controlType="button";name="1"},@{controlType="button";name="2"},@{controlType="button";name="3"},@{controlType="button";name="10"}; # -Verbose;

Write-Host "should be found:";
Wait-UIAWindow -Class *frame* -WithControl @{controlType="button";name="1"},@{controlType="button";name="2"},@{controlType="button";name="3"},@{controlType="button";name="1"};