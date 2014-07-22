/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 10:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest
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
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[Tmx.Core.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
        
        
    }
}
