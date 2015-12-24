/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2012
 * Time: 5:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    //using NUnit.Framework;
    using SePSX;
//    using PSTestLib;
//    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        static Settings()
        {
        }
        
        public static void CleanUpRecordingCollection()
        {
            if (null != Recorder.RecordingCollection) {
                Recorder.RecordingCollection.Clear();
            }
        }
        
        public static string RunspaceCommand = 
//#if DEBUG
//                        @"Import-Module '..\..\..\TMX\bin\Debug\Tmx.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\TMX\bin\Release35\Tmx.dll' -Force;" + //);
//#endif
//                        @"";
        
                        @"Import-Module '.\SePSX.dll' -Force;" +
                        //@"Import-Module '.\UIAutomation.dll' -Force;" + 
                        //@"Import-Module '.\Tmx.dll' -Force;";
        
                        //@"[Tmx.TestData]::TestSuites.Clear();";
//                        @"[UIAutomation.Preferences]::OnSuccessDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnErrorDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnClickDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnSleepDelay = 0;" +
//                        @"[UIAutomation.Preferences]::Timeout = 3000;" + 
//                        @"[UIAutomation.Preferences]::OnErrorScreenShot = $false;" + 
//                        @"[UIAutomation.Preferences]::Log = $false;";
            
                        @"[SePSX.Preferences]::OnSuccessDelay = 0; " +
                        @"[SePSX.Preferences]::OnErrorDelay = 0; " +
//                        @"[SePSX.Preferences]::OnClickDelay = 0; " +
                        @"[SePSX.Preferences]::OnSleepDelay = 100; " +
                        @"[SePSX.Preferences]::Timeout = 3000; " + 
                        @"[SePSX.Preferences]::OnErrorScreenShot = $false; " + 
                        @"[SePSX.Preferences]::Log = $false; ";
    }
}
