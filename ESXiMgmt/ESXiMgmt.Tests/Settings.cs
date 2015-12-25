/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Tests
{
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        static Settings()
        {
        }
        
        public static string RunspaceCommand = 
#if DEBUG
                        @"Import-Module '..\..\..\ESXiMgmt\bin\Debug\ESXiMgmt.dll' -Force;" + //);
#else
                        @"Import-Module '..\..\..\ESXiMgmt\bin\Release\ESXiMgmt.dll' -Force;" + //);
#endif
                        @"";
    }
}