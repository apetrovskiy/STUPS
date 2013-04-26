ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

[string]$Hostname = "myhost"; #"1.2.3.4";
[string]$Domain = "mydom";
[string]$Username = "Administrator";
[string]$Password = "pa$$word";

New-UIARemoteDesktopProtocolFile -Path c:\1\short.rdp -Domain $Domain -Username $Username -Password $Password -Hostname $Hostname
New-UIARemoteDesktopProtocolFile -Path c:\1\longer.rdp -Domain $Domain -Username $Username -Password $Password -Hostname $Hostname -DesktopHeight 500 -DesktopWidth 1200 -DisableWallpaper $true -DisableThemes $true -Autoreconnection $true -RedirectClipboard $true -AuthenticationLevel 0
New-UIARemoteDesktopProtocolFile -Path c:\1\the_longest.rdp -Domain $Domain -Username $Username -Password $Password -Hostname $Hostname -DesktopHeight 800 -DesktopWidth 800 -DisableWallpaper $true -DisableThemes $true -Autoreconnection $true -RedirectClipboard $false -AlternateShell c:\windows\system32\cmd.exe

C:\1\short.rdp
C:\1\longer.rdp
C:\1\the_longest.rdp

