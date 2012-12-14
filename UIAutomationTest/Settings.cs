/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 9:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest
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
//                        @"Import-Module '..\..\..\UIAutomation\bin\Debug\UIAutomation.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\UIAutomation\bin\Release35\UIAutomation.dll' -Force;" + //);
//#endif
            
            
                        // 20120702
                        @"Import-Module '.\UIAutomation.dll' -Force;" + 
                        @"Import-Module '.\TMX.dll' -Force;" + 
            
                        @"[UIAutomation.Preferences]::OnSuccessDelay = 0; " +
                        @"[UIAutomation.Preferences]::OnErrorDelay = 0; " +
                        @"[UIAutomation.Preferences]::OnClickDelay = 0; " +
                        @"[UIAutomation.Preferences]::OnSleepDelay = 0; " +
                        @"[UIAutomation.Preferences]::Timeout = 3000; " + 
                        @"[UIAutomation.Preferences]::OnErrorScreenShot = $false; " + 
                        @"[UIAutomation.Preferences]::Log = $false; " + 
                        @"[UIAutomation.CurrentData]::SetCurrentWindow($null); ";
    }
}
