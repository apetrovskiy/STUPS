/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 10:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest
{
    using System;
    
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        static Settings()
        {
        }
        
        public static string RunspaceCommand = 
//#if DEBUG
//                        @"Import-Module '..\..\..\TMX\bin\Debug\TMX.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\TMX\bin\Release35\TMX.dll' -Force;" + //);
//#endif
//                        @"";
        
                        // 20120706
                        @"Import-Module '.\UIAutomation.dll' -Force;" + 
                        @"Import-Module '.\TMX.dll' -Force;";
        
                        //@"[TMX.TestData]::TestSuites.Clear();";
//                        @"[UIAutomation.Preferences]::OnSuccessDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnErrorDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnClickDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnSleepDelay = 0;" +
//                        @"[UIAutomation.Preferences]::Timeout = 3000;" + 
//                        @"[UIAutomation.Preferences]::OnErrorScreenShot = $false;" + 
//                        @"[UIAutomation.Preferences]::Log = $false;";
        
        
        public static string FileName { get { return @".\1.db3"; } }
        public static string DatabaseName { get { return @"001"; } }
    }
}
