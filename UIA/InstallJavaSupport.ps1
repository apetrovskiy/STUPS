# ########################################################################################
#                      Installation of Java Access Bridge 2.0.2                          #
# Download the package from the following page                                           #
# http://www.oracle.com/technetwork/java/javase/downloads/jab-2-0-2-download-354311.html #
# unblock it if necessary                                                                #
# and set up the following variables:                                                    #

# the folder the package has been extracted to
[string]$JavaAccessBridgeFolder = "C:\Projects\PS\STUPS\binaries\accessbridge2_0_2\";
# nothing to change
[string]$WINDOWSHOME = $env:SystemRoot;
# path to 64-bit Java on a 64-bit system
[string]$JAVAHOME64 = "C:\Program Files\Java\jre7";
# path to 32-bit Java on a 64-bit system
[string]$JAVAHOME32 = "C:\Program Files (x86)\Java\jre7";
# path to Java on a 32-bit system
[string]$JAVAHOME = "C:\Program Files\Java\jre6";

# check administrative privileges
# TBD


# steps according to the listed on the page
# http://docs.oracle.com/javase/accessbridge/2.0.2/setup.htm

# Step 1
if ($env:PROCESSOR_ARCHITECTURE.Contains("64")) {
	Copy-Item -Path "$($JavaAccessBridgeFolder)\WindowsAccessBridge-32.dll" -Destination "$($WINDOWSHOME)\SysWOW64";
	Copy-Item -Path "$($JavaAccessBridgeFolder)\WindowsAccessBridge-64.dll" -Destination "$($WINDOWSHOME)\System32";
	Copy-Item -Path "$($JavaAccessBridgeFolder)\JavaAccessBridge-32.dll" -Destination "$($JAVAHOME32)\bin"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\JavaAccessBridge-64.dll" -Destination "$($JAVAHOME64)\bin"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\JAWTAccessBridge-32.dll" -Destination "$($JAVAHOME32)\bin"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\JAWTAccessBridge-64.dll" -Destination "$($JAVAHOME64)\bin"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\accessibility.properties" -Destination "$($JAVAHOME32)\lib"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\accessibility.properties" -Destination "$($JAVAHOME64)\lib"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\access-bridge-32.jar" -Destination "$($JAVAHOME32)\lib\ext"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\access-bridge-64.jar" -Destination "$($JAVAHOME64)\lib\ext"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\jaccess.jar" -Destination "$($JAVAHOME32)\lib\ext"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\jaccess.jar" -Destination "$($JAVAHOME64)\lib\ext"
} else {
	Copy-Item -Path "$($JavaAccessBridgeFolder)\WindowsAccessBridge.dll" -Destination "$($WINDOWSHOME)\System32";
	Copy-Item -Path "$($JavaAccessBridgeFolder)\JavaAccessBridge.dll" -Destination "$($JAVAHOME)\bin"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\JAWTAccessBridge.dll" -Destination "$($JAVAHOME)\bin"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\accessibility.properties" -Destination "$($JAVAHOME)\lib"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\access-bridge.jar" -Destination "$($JAVAHOME)\lib\ext"
	Copy-Item -Path "$($JavaAccessBridgeFolder)\jaccess.jar" -Destination "$($JAVAHOME)\lib\ext"
}