###################################################################################
#  the TMX module release script
# v. 1.0 2013/03/06 the initial version
###################################################################################

param(
      [string]$Password,
      [string]$DirName
      )

Set-StrictMode -Version Latest;
if ("" -eq $DirName) {
	Write-Error "Empty dir!";
}

[string]$pathToSignTool = "C:\Program Files (x86)\Windows Kits\8.0\bin\x64\signtool.exe";
[string]$pathToProjectRoot = "C:\Projects\PS\STUPS";
[string]$pathToCertificate = "$($pathToProjectRoot)\certificate\my\SoftwareTestingUsingPowerShell.pfx";
[string]$pathToTimeStamp = "http://timestamp.verisign.com/scripts/timestamp.dll";


# Creating output directories
New-Item -Path "$($pathToProjectRoot)\out\" -Name "$($DirName)" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "35-32" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "35-64" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "40-32" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "40-64" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "sources" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "samples" -ItemType directory

# Version .NET 3.5
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TMX\TMX\bin\Release35\TMX.dll") -NoNewWindow;
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TMX\TMX\bin\Release35\PSTestLibrary.dll") -NoNewWindow;

Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX\bin\Release35\TMX.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\35-32"
Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX\bin\Release35\PSTestLibrary.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\35-32"
Copy-Item -Path "$($pathToProjectRoot)\binaries\sqlite\35\32\*sqlite*" -Destination "$($pathToProjectRoot)\out\$($DirName)\35-32"
Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX\bin\Release35\TMX.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\35-64"
Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX\bin\Release35\PSTestLibrary.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\35-64"
Copy-Item -Path "$($pathToProjectRoot)\binaries\sqlite\35\64\*sqlite*" -Destination "$($pathToProjectRoot)\out\$($DirName)\35-64"

# Version .NET 4.0
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TMX\TMX40\bin\Release35\TMX.dll") -NoNewWindow;
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TMX\TMX40\bin\Release35\PSTestLibrary.dll") -NoNewWindow;

Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX40\bin\Release35\TMX.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\40-32"
Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX40\bin\Release35\PSTestLibrary.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\40-32"
Copy-Item -Path "$($pathToProjectRoot)\binaries\sqlite\40\32\*sqlite*" -Destination "$($pathToProjectRoot)\out\$($DirName)\40-32"
Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX40\bin\Release35\TMX.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\40-64"
Copy-Item -Path "$($pathToProjectRoot)\TMX\TMX40\bin\Release35\PSTestLibrary.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\40-64"
Copy-Item -Path "$($pathToProjectRoot)\binaries\sqlite\40\64\*sqlite*" -Destination "$($pathToProjectRoot)\out\$($DirName)\40-64"

# Source code
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\TMX\*.?s*", "$($pathToProjectRoot)\out\$($DirName)\sources\TMX\", "/s", "/v", "/i", "/exclude:exclude_TMX.txt") -NoNewWindow -PassThru;
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\PS\*.cs*", "$($pathToProjectRoot)\out\$($DirName)\sources\PS\", "/s", "/v", "/i") -NoNewWindow -PassThru;
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\PSTestLib\*.cs*", "$($pathToProjectRoot)\out\$($DirName)\sources\PSTestLib\", "/s", "/v", "/i") -NoNewWindow -PassThru;
Copy-Item -Path "$($pathToProjectRoot)\*.sln" -Destination "$($pathToProjectRoot)\out\$($DirName)\sources";

# Samples
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\samples\TMX\*.ps*", "$($pathToProjectRoot)\out\$($DirName)\samples", "/s", "/v", "/i") -NoNewWindow -PassThru;
return;