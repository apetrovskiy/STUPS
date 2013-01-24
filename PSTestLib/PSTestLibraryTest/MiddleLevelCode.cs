/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 9:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLibraryTest
{
    using System;
    // using NUnit;
    //using System.Diagnostics;
    //using System.Management.Automation;
    
    /// <summary>
    /// Description of MiddleLevelCode.
    /// </summary>
    public static class MiddleLevelCode
    {
        static MiddleLevelCode()
        {
        }
        
        
        public static void PrepareRunspace() //string command)
        {
            CmdletUnitTest.TestRunspace.IitializeRunspace(Settings.RunspaceCommand);
        }
        
        public static void DisposeRunspace()
        {
            //CmdletUnitTest.TestRunspace.RunPSCode(
            //    @"[TMX.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
    }
}
