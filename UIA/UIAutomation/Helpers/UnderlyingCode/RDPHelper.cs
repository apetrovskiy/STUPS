/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/26/2013
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of RDPHelper.
    /// </summary>
    public static class RDPHelper
    {
        static RDPHelper()
        {
        }
        
        public static string rDPProtocolFile = @"screen mode id:i:1
use multimon:i:0
desktopwidth:i:1024
desktopheight:i:768
smart sizing:i:0
session bpp:i:32
winposstr:s:0,1,63,37,1200,900
compression:i:1
keyboardhook:i:2
audiocapturemode:i:0
videoplaybackmode:i:1
connection type:i:7
networkautodetect:i:1
bandwidthautodetect:i:1
displayconnectionbar:i:1
enableworkspacereconnect:i:0
disable wallpaper:i:0
allow font smoothing:i:0
allow desktop composition:i:0
disable full window drag:i:1
disable menu anims:i:1
disable themes:i:0
disable cursor setting:i:0
bitmapcachepersistenable:i:1
audiomode:i:2
redirectprinters:i:0
redirectcomports:i:0
redirectsmartcards:i:0
redirectclipboard:i:0
redirectposdevices:i:0
autoreconnection enabled:i:1
authentication level:i:2
prompt for credentials:i:0
negotiate security layer:i:1
remoteapplicationmode:i:0
remoteapplicationprogram:s:
remoteapplicationcmdline:s:
alternate shell:s:
shell working directory:s:
gatewayhostname:s:
gatewayusagemethod:i:4
gatewaycredentialssource:i:4
gatewayprofileusagemethod:i:0
promptcredentialonce:i:0
use redirection server name:i:0
rdgiskdcproxy:i:0
kdcproxyname:s:
drivestoredirect:s:
";

// drivestoredirect:s:C:\;
        
//        public static string RDPFileTemplate
//        {
//            get { return rDPProtocolFile; }
//            set { rDPProtocolFile = value; }
//        }
        
        public static string RDPFileTemplate { get; set; }
        
        //public static void CreateRDPFile(NewUIARemoteDesktopProtocolFileCommand cmdlet)
        public static void CreateRDPFile(RDPCmdletBase cmdlet)
        {
            if (null != cmdlet.Template && string.Empty != cmdlet.Template) {
                
                cmdlet.WriteVerbose(cmdlet, "Using the external template");
                RDPFileTemplate = cmdlet.Template;
            } else {
                
                cmdlet.WriteVerbose(cmdlet, "Using the default template");
                RDPFileTemplate = rDPProtocolFile;
            }
            
            RDPFileTemplate +=
                "full address:s:" +
                cmdlet.Hostname +
                "\r\n";
            RDPFileTemplate +=
                "username:s:" +
                cmdlet.Username +
                "\r\n";
            RDPFileTemplate +=
                "domain:s:" +
                cmdlet.Domain +
                "\r\n";
            RDPFileTemplate +=
                "password 51:b:" +
                DataProtectionForRDPWrapper.Encrypt(cmdlet.Password) +
                "\r\n";
            
            if (cmdlet.RemoteAppMode) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "remoteapplicationmode:i:0",
                        "remoteapplicationmode:i:1");
            }
            
            if (null != cmdlet.RemoteAppProgram && string.Empty != cmdlet.RemoteAppProgram) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "remoteapplicationprogram:s:",
                        "remoteapplicationprogram:s:" +
                        cmdlet.RemoteAppProgram);
            }
            
            if (null != cmdlet.RemoteAppCmdline && string.Empty != cmdlet.RemoteAppCmdline) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "remoteapplicationcmdline:s:",
                        "remoteapplicationcmdline:s:" +
                        cmdlet.RemoteAppCmdline);
            }
            
            if (null != cmdlet.AlternateShell && string.Empty != cmdlet.AlternateShell) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "alternate shell:s:",
                        "alternate shell:s:" +
                        cmdlet.AlternateShell);
            }
            
            if (null != cmdlet.ShellWorkingDir && string.Empty != cmdlet.ShellWorkingDir) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "shell working directory:s:",
                        "shell working directory:s:" +
                        cmdlet.ShellWorkingDir);
            }
            
            if (null != cmdlet.AuthenticationLevel) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "authentication level:i:0",
                        "authentication level:i:" +
                        cmdlet.AuthenticationLevel);
            }

            if (null != cmdlet.Autoreconnection) {
                
                int autoreconnection = cmdlet.Autoreconnection ? 1 : 0;
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "autoreconnection enabled:i:1",
                        "autoreconnection enabled:i:" +
                        autoreconnection);
            }
            
            if (null != cmdlet.DesktopHeight) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "desktopheight:i:768",
                        "desktopheight:i:" +
                        cmdlet.DesktopHeight);
            }
            
            if (null != cmdlet.DesktopWidth) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "desktopwidth:i:1024",
                        "desktopwidth:i:" +
                        cmdlet.DesktopWidth);
            }
            
            if (null != cmdlet.SmartSizing) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "smart sizing:i:0",
                        "smart sizing:i:1");
            }
            
            if (null != cmdlet.DisableThemes) {
                
                int disableThemes = cmdlet.DisableThemes ? 1 : 0;
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "disable themes:i:0",
                        "disable themes:i:" +
                        disableThemes);
            }

            if (null != cmdlet.DisableWallpaper) {
                
                int disableWallpaper = cmdlet.DisableWallpaper ? 1 : 0;
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "disable wallpaper:i:0",
                        "disable wallpaper:i:" +
                        disableWallpaper);
            }
            
            if (null != cmdlet.RedirectClipboard) {
                
                int redirectClipboard = cmdlet.RedirectClipboard ? 1 : 0;
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "redirectclipboard:i:0",
                        "redirectclipboard:i:" +
                        redirectClipboard);
            }
            
            if (null != cmdlet.DriveStoreRedirect && string.Empty != cmdlet.DriveStoreRedirect) {
                
                RDPFileTemplate =
                    RDPFileTemplate.Replace(
                        "drivestoredirect:s:",
                        "drivestoredirect:s:" +
                        cmdlet.DriveStoreRedirect);
            }
            
            try {
                System.IO.StreamWriter writer =
                    new System.IO.StreamWriter(((NewUIARemoteDesktopProtocolFileCommand)cmdlet).Path);
                writer.Write(RDPFileTemplate);
                writer.Flush();
                writer.Close();
                
                cmdlet.WriteObject(cmdlet, ((NewUIARemoteDesktopProtocolFileCommand)cmdlet).Path);
            }
            catch (Exception eWriter) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to create an RDP file '" +
                    RDPFileTemplate +
                    "'." +
                    eWriter.Message,
                    "FailedToCreateFile",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
    }
}
