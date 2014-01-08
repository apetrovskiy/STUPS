/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmtTest
{
    using System;
    // using NUnit;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of MiddleLevelCode.
    /// </summary>
    public static class MiddleLevelCode
    {
        static MiddleLevelCode()
        {
        }
        
        public static void PrepareRunspace()
        {
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
        }
        
        public static void DisposeRunspace()
        {
            //CmdletUnitTest.TestRunspace.RunPSCode(
            //    @"[TMX.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
        
    }
}