###################################################################################
#  the TAMS module release script
# v. 1.0 2013/03/23 the initial version
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
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "35" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "40" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "sources" -ItemType directory
New-Item -Path "$($pathToProjectRoot)\out\$($DirName)\" -Name "samples" -ItemType directory

# Version .NET 3.5
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TAMS\TAMS\bin\Release35\TAMS.dll") -NoNewWindow;
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TAMS\TAMS\bin\Release35\PSTestLibrary.dll") -NoNewWindow;

Copy-Item -Path "$($pathToProjectRoot)\TAMS\TAMS\bin\Release35\TAMS.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\35"
Copy-Item -Path "$($pathToProjectRoot)\TAMS\TAMS\bin\Release35\PSTestLibrary.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\35"
Copy-Item -Path "$($pathToProjectRoot)\TAMS\TAMS\bin\Release35\*TestApi*.*" -Destination "$($pathToProjectRoot)\out\$($DirName)\35"

# Version .NET 4.0
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TAMS\TAMS40\bin\Release35\TAMS.dll") -NoNewWindow;
Start-Process -FilePath $pathToSignTool -ArgumentList @("sign", "/f", "$($pathToCertificate)", "/t", "$($pathToTimeStamp)", "/p", "$($Password)", "$($pathToProjectRoot)\TAMS\TAMS40\bin\Release35\PSTestLibrary.dll") -NoNewWindow;

Copy-Item -Path "$($pathToProjectRoot)\TAMS\TAMS40\bin\Release35\TAMS.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\40"
Copy-Item -Path "$($pathToProjectRoot)\TAMS\TAMS40\bin\Release35\PSTestLibrary.dll" -Destination "$($pathToProjectRoot)\out\$($DirName)\40"
Copy-Item -Path "$($pathToProjectRoot)\TAMS\TAMS40\bin\Release35\*TestApi*.*" -Destination "$($pathToProjectRoot)\out\$($DirName)\40"

# Source code
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\TAMS\*.?s*", "$($pathToProjectRoot)\out\$($DirName)\sources\TAMS\", "/s", "/v", "/i", "/exclude:exclude_TAMS.txt") -NoNewWindow -PassThru;
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\PS\*.cs*", "$($pathToProjectRoot)\out\$($DirName)\sources\PS\", "/s", "/v", "/i") -NoNewWindow -PassThru;
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\PSTestLib\*.cs*", "$($pathToProjectRoot)\out\$($DirName)\sources\PSTestLib\", "/s", "/v", "/i") -NoNewWindow -PassThru;
Copy-Item -Path "$($pathToProjectRoot)\*.sln" -Destination "$($pathToProjectRoot)\out\$($DirName)\sources";

# Samples
Start-Process -FilePath "xcopy" -ArgumentList @("$($pathToProjectRoot)\samples\TAMS\*.ps*", "$($pathToProjectRoot)\out\$($DirName)\samples", "/s", "/v", "/i") -NoNewWindow -PassThru;
return;