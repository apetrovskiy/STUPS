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
