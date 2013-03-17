md C:\Projects\PS\STUPS\out\%2
md C:\Projects\PS\STUPS\out\%2\35
md C:\Projects\PS\STUPS\out\%2\40
md C:\Projects\PS\STUPS\out\%2\Metro

[string]$pathToSignTool = "C:\Program Files (x86)\Windows Kits\8.0\bin\x64\signtool.exe";
[string]$pathToProjectRoot = "C:\Projects\PS\STUPS";
[string]$pathToCertificate = "$($pathToProjectRoot)\certificate\my\SoftwareTestingUsingPowerShell.pfx";

rem 3.5
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy\bin\Release35\UIAutomation.dll"
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy\bin\Release35\TMX.dll"
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy\bin\Release35\UIAutomationSpy.exe"
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationAliases\bin\Release35\UIAutomationAliases.dll"
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\UIARunner.exe
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\PSRunner.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\PSTestRunner.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\PSTestLibrary.dll
rem $pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 B:\samples\bgshell-21772\NET40\BgShell\bin\Release\*.*

copy "$($pathToProjectRoot)\UIA\UIAutomationSpy\bin\Release35\UIAutomation.dll "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationSpy\bin\Release35\TMX.dll "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationSpy\bin\Release35\UIAutomationSpy.* "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationAliases\bin\Release35\UIAutomationAliases.dll "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\UIARunner.* "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\PSRunner.dll "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\PSTestRunner.dll "$($pathToProjectRoot)\out\%2\35\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner\bin\Release35\PSTestLibrary.dll "$($pathToProjectRoot)\out\%2\35\*.*
rem copy B:\samples\bgshell-21772\NET40\BgShell\bin\Release\*.* "$($pathToProjectRoot)\out\%2\35\*.*


rem 4.0
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy40\bin\Release35\UIAutomation.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy40\bin\Release35\TMX.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy40\bin\Release35\UIAutomationSpy.exe
rem $pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationAliases\bin\Release35\UIAutomationAliases.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\UIARunner.exe
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\PSRunner.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\PSTestRunner.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\PSTestLibrary.dll
rem $pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 B:\samples\bgshell-21772\NET40\BgShell\bin\Release\*.*

copy "$($pathToProjectRoot)\UIA\UIAutomationSpy40\bin\Release35\UIAutomation.dll "$($pathToProjectRoot)\out\%2\40\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationSpy40\bin\Release35\TMX.dll "$($pathToProjectRoot)\out\%2\40\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationSpy40\bin\Release35\UIAutomationSpy.* "$($pathToProjectRoot)\out\%2\40\*.*
rem copy "$($pathToProjectRoot)\UIA\UIAutomationAliases\bin\Release35\UIAutomationAliases.dll "$($pathToProjectRoot)\out\%2\40\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\UIARunner.* "$($pathToProjectRoot)\out\%2\40\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\PSRunner.dll "$($pathToProjectRoot)\out\%2\40\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\PSTestRunner.dll "$($pathToProjectRoot)\out\%2\40\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40\bin\Release35\PSTestLibrary.dll "$($pathToProjectRoot)\out\%2\40\*.*
rem copy B:\samples\bgshell-21772\NET40\BgShell\bin\Release\*.* "$($pathToProjectRoot)\out\%2\40\*.*

; Metro
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy40Metro\bin\Release35\UIAutomation.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy40Metro\bin\Release35\TMX.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationSpy40Metro\bin\Release35\UIAutomationSpy.exe
rem $pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIAutomationAliases\bin\Release35\UIAutomationAliases.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\UIARunner.exe
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\PSRunner.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\PSTestRunner.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\PSTestLibrary.dll
$pathToSignTool sign /f $pathToCertificate /t http://timestamp.verisign.com/scripts/timestamp.dll /p %1 "$($pathToProjectRoot)\UIA\bgshell-21772\NET40\BgShell\bin\Release\*.*

copy "$($pathToProjectRoot)\UIA\UIAutomationSpy40Metro\bin\Release35\UIAutomation.dll "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationSpy40Metro\bin\Release35\TMX.dll "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\UIAutomationSpy40Metro\bin\Release35\UIAutomationSpy.* "$($pathToProjectRoot)\out\%2\Metro\*.*
rem copy "$($pathToProjectRoot)\UIA\UIAutomationAliases\bin\Release35\UIAutomationAliases.dll "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\UIARunner.* "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\PSRunner.dll "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\PSTestRunner.dll "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\UIARunner40Metro\bin\Release35\PSTestLibrary.dll "$($pathToProjectRoot)\out\%2\Metro\*.*
copy "$($pathToProjectRoot)\UIA\bgshell-21772\NET40\BgShell\bin\Release\*.* "$($pathToProjectRoot)\out\%2\Metro\*.*

copy "$($pathToProjectRoot)\certificate\SoftwareTestingUsingPowerShell.cer "$($pathToProjectRoot)\out\%2\Metro\*.*