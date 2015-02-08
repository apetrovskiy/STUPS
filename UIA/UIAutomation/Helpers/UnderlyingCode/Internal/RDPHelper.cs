/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/26/2013
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.IO;

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using Commands;
    
    /// <summary>
    /// Description of RDPHelper.
    /// </summary>
    public static class RdpHelper
    {
        public const string RDpProtocolFile = @"screen mode id:i:1
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
        
        public static string RdpFileTemplate { get; set; }
        
        public static void CreateRdpFile(RdpCmdletBase cmdlet)
        {
            if (!string.IsNullOrEmpty(cmdlet.Template)) {
                
                cmdlet.WriteVerbose(cmdlet, "Using the external template");
                RdpFileTemplate = cmdlet.Template;
            } else {
                
                cmdlet.WriteVerbose(cmdlet, "Using the default template");
                RdpFileTemplate = RDpProtocolFile;
            }
            
            RdpFileTemplate +=
                "full address:s:" +
                cmdlet.Hostname +
                "\r\n";
            RdpFileTemplate +=
                "username:s:" +
                cmdlet.Username +
                "\r\n";
            RdpFileTemplate +=
                "domain:s:" +
                cmdlet.Domain +
                "\r\n";
            RdpFileTemplate +=
                "password 51:b:" +
                DataProtectionForRDPWrapper.Encrypt(cmdlet.Password) +
                "\r\n";
            
            if (cmdlet.RemoteAppMode) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "remoteapplicationmode:i:0",
                        "remoteapplicationmode:i:1");
            }
            
            if (!string.IsNullOrEmpty(cmdlet.RemoteAppProgram)) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "remoteapplicationprogram:s:",
                        "remoteapplicationprogram:s:" +
                        cmdlet.RemoteAppProgram);
            }
            
            if (!string.IsNullOrEmpty(cmdlet.RemoteAppCmdline)) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "remoteapplicationcmdline:s:",
                        "remoteapplicationcmdline:s:" +
                        cmdlet.RemoteAppCmdline);
            }
            
            if (!string.IsNullOrEmpty(cmdlet.AlternateShell)) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "alternate shell:s:",
                        "alternate shell:s:" +
                        cmdlet.AlternateShell);
            }
            
            if (!string.IsNullOrEmpty(cmdlet.ShellWorkingDir)) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "shell working directory:s:",
                        "shell working directory:s:" +
                        cmdlet.ShellWorkingDir);
            }
            
//            if (null != cmdlet.AuthenticationLevel) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "authentication level:i:0",
                        "authentication level:i:" +
                        cmdlet.AuthenticationLevel);
//            }

//            if (null != cmdlet.Autoreconnection) {
                
                int autoreconnection = cmdlet.Autoreconnection ? 1 : 0;
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "autoreconnection enabled:i:1",
                        "autoreconnection enabled:i:" +
                        autoreconnection);
//            }
            
//            if (null != cmdlet.DesktopHeight) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "desktopheight:i:768",
                        "desktopheight:i:" +
                        cmdlet.DesktopHeight);
//            }
            
//            if (null != cmdlet.DesktopWidth) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "desktopwidth:i:1024",
                        "desktopwidth:i:" +
                        cmdlet.DesktopWidth);
//            }
            
            if (null != cmdlet.SmartSizing) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "smart sizing:i:0",
                        "smart sizing:i:1");
            }
            
//            if (null != cmdlet.DisableThemes) {
                
                int disableThemes = cmdlet.DisableThemes ? 1 : 0;
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "disable themes:i:0",
                        "disable themes:i:" +
                        disableThemes);
//            }

//            if (null != cmdlet.DisableWallpaper) {
                
                int disableWallpaper = cmdlet.DisableWallpaper ? 1 : 0;
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "disable wallpaper:i:0",
                        "disable wallpaper:i:" +
                        disableWallpaper);
//            }
            
//            if (null != cmdlet.RedirectClipboard) {
                
                int redirectClipboard = cmdlet.RedirectClipboard ? 1 : 0;
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "redirectclipboard:i:0",
                        "redirectclipboard:i:" +
                        redirectClipboard);
//            }
            
            if (!string.IsNullOrEmpty(cmdlet.DriveStoreRedirect)) {
                
                RdpFileTemplate =
                    RdpFileTemplate.Replace(
                        "drivestoredirect:s:",
                        "drivestoredirect:s:" +
                        cmdlet.DriveStoreRedirect);
            }
            
            try {
                using (var writer = new StreamWriter(((NewUiaRemoteDesktopProtocolFileCommand)cmdlet).Path)) {
                    writer.Write(RdpFileTemplate);
                    writer.Flush();
                    writer.Close();
                }
                
                cmdlet.WriteObject(cmdlet, ((NewUiaRemoteDesktopProtocolFileCommand)cmdlet).Path);
            }
            catch (Exception eWriter) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to create an RDP file '" +
                    RdpFileTemplate +
                    "'." +
                    eWriter.Message,
                    "FailedToCreateFile",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
    }
}
