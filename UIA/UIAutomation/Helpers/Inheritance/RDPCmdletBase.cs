/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/13/2013
 * Time: 5:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RDPCmdletBase.
    /// </summary>
    public class RDPCmdletBase : CommonCmdletBase
    {
        public RDPCmdletBase()
        {
        }
        
        #region Parameters
#region file
//screen mode id:i:1
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
//full address:s:10.0.1.143
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
//alternate shell:s:C:\TESTHOME\FitNesse\PowerSlim35.cmd
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
//username:s:Administrator
//domain:s:OUTCAST
//password 51:b:01000000D08C9DDF0115D1118C7A00C04FC297EB01000000C03FE22CC8812640859E96726A703A500400000008000000700073007700000003660000C0000000100000006BFB98E9F62AC7000C1E03F4AEE068B10000000004800000A000000010000000352FE9F5FBEA964390272A7049658F3C180000006AAED1F95C148474FE4CE51CA14F5C9D9EF660A41D0B5868140000003765D71521A38B3D10E962351B04828C53C33C17
#endregion file
        #region prioritized
        //2 screen mode id:i:1
        //2 use multimon:i:0
        //1 desktopwidth:i:1024
        //1 desktopheight:i:768
        //2 session bpp:i:32
        //2 winposstr:s:0,1,63,37,1200,900
        //2 compression:i:1
        //2 keyboardhook:i:2
        //2 audiocapturemode:i:0
        //2 videoplaybackmode:i:1
        //2 connection type:i:7
        //2 networkautodetect:i:1
        //2 bandwidthautodetect:i:1
        //2 displayconnectionbar:i:1
        //2 enableworkspacereconnect:i:0
        //1 disable wallpaper:i:0
        //2 allow font smoothing:i:0
        //2 allow desktop composition:i:0
        //2 disable full window drag:i:1
        //2 disable menu anims:i:1
        //1 disable themes:i:0
        //2 disable cursor setting:i:0
        //2 bitmapcachepersistenable:i:1
        //1 full address:s:10.0.1.143
        //2 audiomode:i:2
        //2 redirectprinters:i:0
        //2 redirectcomports:i:0
        //2 redirectsmartcards:i:0
        //1 redirectclipboard:i:0
        //2 redirectposdevices:i:0
        //1 autoreconnection enabled:i:1
        //1 authentication level:i:0
        //2 prompt for credentials:i:0
        //12 negotiate security layer:i:1
        //12 remoteapplicationmode:i:0
        //1 alternate shell:s:C:\TESTHOME\FitNesse\PowerSlim35.cmd
        //12 shell working directory:s:
        //2 gatewayhostname:s:
        //2 gatewayusagemethod:i:4
        //2 gatewaycredentialssource:i:4
        //2 gatewayprofileusagemethod:i:0
        //2 promptcredentialonce:i:0
        //2 use redirection server name:i:0
        //2 rdgiskdcproxy:i:0
        //2 kdcproxyname:s:
        //2 drivestoredirect:s:C:\;
        //1 username:s:Administrator
        //1 domain:s:OUTCAST
        //1 password 51:b:01000000D08C9DDF0115D1118C7A00C04FC297EB01000000C03FE22CC8812640859E96726A703A500400000008000000700073007700000003660000C0000000100000006BFB98E9F62AC7000C1E03F4AEE068B10000000004800000A000000010000000352FE9F5FBEA964390272A7049658F3C180000006AAED1F95C148474FE4CE51CA14F5C9D9EF660A41D0B5868140000003765D71521A38B3D10E962351B04828C53C33C17
        #endregion prioritized
        
        // 1 desktopwidth:i:1024
        // 1 desktopheight:i:768
        // 1 disable wallpaper:i:0
        // 1 disable themes:i:0
        // 1 full address:s:10.0.1.143
        // 1 redirectclipboard:i:0
        // 1 autoreconnection enabled:i:1
        // 1 authentication level:i:0
        // 1 alternate shell:s:C:\TESTHOME\FitNesse\PowerSlim35.cmd
        // 1 username:s:Administrator
        // 1 domain:s:OUTCAST
        // 1 password 51:
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Domain { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Username { get; set; }
        
        [Parameter(Mandatory = true)]
        public string Password { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Hostname { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter RemoteAppMode { get; set; }
        
        [Parameter(Mandatory = false)]
        public string RemoteAppProgram { get; set; }
        
        [Parameter(Mandatory = false)]
        public string RemoteAppCmdline { get; set; }
        
        [Parameter(Mandatory = false)]
        public string AlternateShell { get; set; }
        
        [Parameter(Mandatory = false)]
        public string ShellWorkingDir { get; set; }
        
        [Parameter(Mandatory = false)]
        public int DesktopHeight { get; set; }
        
        [Parameter(Mandatory = false)]
        public int DesktopWidth { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter SmartSizing { get; set; }
        
        [Parameter(Mandatory = false)]
        public bool DisableWallpaper { get; set; }
        
        [Parameter(Mandatory = false)]
        public bool DisableThemes { get; set; }
        
        [Parameter(Mandatory = false)]
        public bool Autoreconnection { get; set; }
        
        [Parameter(Mandatory = false)]
        public bool RedirectClipboard { get; set; }
        
        [Parameter(Mandatory = false)]
        public string DriveStoreRedirect { get; set; }
        
        [Parameter(Mandatory = false)]
        public int AuthenticationLevel { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Template { get; set; }
        #endregion Parameters
        
        // http://www.pinvoke.net
        // http://www.netcoole.com/delphi2cs/datatype.htm
        // http://www.delphipraxis.net/88732-password-hash-rdp-files.html
        // http://www.delphibasics.co.uk/RTL.asp?Name=Cardinal
        // http://death-team.su/archive/index.php/t-15089.html
        
        // !!
        // http://www.obviex.com/samples/dpapi.aspx
        // !!

	// http://social.msdn.microsoft.com/Forums/en-US/searchserverfaq/thread/bff6522e-c820-411a-82cf-6da9b7e646a8
	// http://www.go4answers.com/Example/disable-warnig-unknown-publisher-147063.aspx
	// http://www.remkoweijnen.nl/blog/2007/10/18/how-rdp-passwords-are-encrypted/
        
        protected string EncryptPassword(string password)
        {
            string result = string.Empty;
            
//            //function CryptRDPPassword(sPassword: string): string; 
//            //var DataIn: DATA_BLOB; 
//            //    DataOut: DATA_BLOB; 
//            //    pwDescription: PWideChar; 
//            //    PwdHash: string; 
//            //begin 
//            //  PwdHash := '';                                      
//            string PwdHash = "";
//            
//            NativeMethods.DATA_BLOB DataIn;
//            NativeMethods.DATA_BLOB DataOut;
//             
//            //  DataOut.cbData := 0; 
//            //  DataOut.pbData := nil;                                      
//            
//            DataOut.cbData = 0;
//            DataOut.pbData = IntPtr.Zero;
//             
//              // RDP uses UniCode 
//            //  DataIn.pbData := Pointer(WideString(sPassword)); 
//            //  DataIn.cbData := Length(sPassword) * SizeOf(WChar);                                      
//            
//            DataIn.pbData = (System.IntPtr)password;
//            DataIn.cbData = password.Length * sizeof(char);
//             
//              // RDP always sets description to psw 
//            //  pwDescription := WideString('psw');                                      
//            string pwDescription = "psw";
//             
////              if CryptProtectData(@DataIn, 
////                                  pwDescription, 
////                                  nil, 
////                                  nil, 
////                                  nil, 
////                                  CRYPTPROTECT_UI_FORBIDDEN,  // Never show interface 
////                                  @DataOut) then 
////              begin 
////                PwdHash := BlobDataToHexStr(DataOut.pbData, DataOut.cbData); 
////              end; 
////              Result := PwdHash;                             
//
//            if (NativeMethods.CryptProtectData(
//                  ref DataIn,
//                  pwDescription,
//                  ref DataIn, //null, //ref null,
//                  IntPtr.Zero, //null,
//                  ref (NativeMethods.CRYPTPROTECT_PROMPTSTRUCT)null, //null,
//                  NativeMethods.CRYPTPROTECT_UI_FORBIDDEN,  // Never show interface
//                  ref DataOut)) {
//                PwdHash = BlobDataToHexStr(DataOut.pbData, DataOut.cbData); 
//            }
//            string Result = PwdHash;
//             
//              // Cleanup 
//            //  LocalFree(Cardinal(DataOut.pbData)); 
//            //  LocalFree(Cardinal(DataIn.pbData));                                      
//            NativeMethods.LocalFree((System.IntPtr)DataOut.pbData);
//            NativeMethods.LocalFree((System.IntPtr)DataOut.pbData);
//             
//            return Result;
//            
//            //end;

            return result;
        }
    }
}
