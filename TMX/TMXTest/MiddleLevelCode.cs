/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 10:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest
{
    using System;
    // using NUnit;
    using System.Diagnostics;
    //using System.Management.Automation;
    
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
            CmdletUnitTest.TestRunspace.IitializeRunspace(Settings.RunspaceCommand);
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[TMX.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
        
        
    }
}
