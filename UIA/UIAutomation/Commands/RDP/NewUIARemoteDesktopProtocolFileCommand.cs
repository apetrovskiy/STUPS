/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/19/2013
 * Time: 10:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewUIARemoteDesktopProtocolFileCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UIARemoteDesktopProtocolFile")]
    public class NewUIARemoteDesktopProtocolFileCommand : RDPCmdletBase
    {
        public NewUIARemoteDesktopProtocolFileCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Path { get; set; }
        
//        [Parameter(Mandatory = true)]
//        [ValidateNotNullOrEmpty()]
//        public string Hostname { get; set; }
//        
//        [Parameter(Mandatory = true)]
//        [ValidateNotNullOrEmpty()]
//        public string Domain { get; set; }
//        
//        [Parameter(Mandatory = true)]
//        [ValidateNotNullOrEmpty()]
//        public string Username { get; set; }
//        
//        [Parameter(Mandatory = true)]
//        [ValidateNotNullOrEmpty()]
//        public string Password { get; set; }
        #endregion Parameters
        
//        internal string rDPProtocolFile = @"screen mode id:i:1
//use multimon:i:0
//desktopwidth:i:1024
//desktopheight:i:768
//session bpp:i:32
//winposstr:s:0,1,63,37,1200,900
//compression:i:1
//keyboardhook:i:2
//audiocapturemode:i:0
//videoplaybackmode:i:1
//connection type:i:7
//networkautodetect:i:1
//bandwidthautodetect:i:1
//displayconnectionbar:i:1
//enableworkspacereconnect:i:0
//disable wallpaper:i:0
//allow font smoothing:i:0
//allow desktop composition:i:0
//disable full window drag:i:1
//disable menu anims:i:1
//disable themes:i:0
//disable cursor setting:i:0
//bitmapcachepersistenable:i:1
//audiomode:i:2
//redirectprinters:i:0
//redirectcomports:i:0
//redirectsmartcards:i:0
//redirectclipboard:i:0
//redirectposdevices:i:0
//autoreconnection enabled:i:1
//authentication level:i:0
//prompt for credentials:i:0
//negotiate security layer:i:1
//remoteapplicationmode:i:0
//alternate shell:s:
//shell working directory:s:
//gatewayhostname:s:
//gatewayusagemethod:i:4
//gatewaycredentialssource:i:4
//gatewayprofileusagemethod:i:0
//promptcredentialonce:i:0
//use redirection server name:i:0
//rdgiskdcproxy:i:0
//kdcproxyname:s:
//drivestoredirect:s:C:\;
//";
        
        protected override void BeginProcessing()
        {
            UIANewRemoteDesktopProtocolFileCommand command =
                new UIANewRemoteDesktopProtocolFileCommand(this);
            command.Execute();
            
//            this.rDPProtocolFile +=
//                "full address:s:" +
//                this.Hostname +
//                "\r\n";
//            this.rDPProtocolFile +=
//                "username:s:" +
//                this.Username +
//                "\r\n";
//            this.rDPProtocolFile +=
//                "domain:s:" +
//                this.Domain +
//                "\r\n";
//            this.rDPProtocolFile +=
//                "password 51:b:" +
//                //this.EncryptPassword(this.Password) +
//                //RijndaelSettings.Encrypt(this.Password) +
//                DataProtectionForRDPWrapper.Encrypt(this.Password) +
//                "\r\n";
//            
//            try {
//                System.IO.StreamWriter writer =
//                    new System.IO.StreamWriter(this.Path);
//                writer.Write(this.rDPProtocolFile);
//                writer.Flush();
//                writer.Close();
//                
//                this.WriteObject(this, this.Path);
//            }
//            catch (Exception eWriter) {
//                this.WriteError(
//                    this,
//                    "Failed to create an RDP file '" +
//                    this.rDPProtocolFile +
//                    "'." +
//                    eWriter.Message,
//                    "FailedToCreateFile",
//                    ErrorCategory.InvalidOperation,
//                    true);
//            }
        }
    }
}
