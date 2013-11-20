/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2013
 * Time: 12:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using System;
    using PSTestLib;
    
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
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($false);");
        }
        
        public static void PrepareRunspaceForParamChecks()
        {
            PSCmdletBase.UnitTestMode = false;
            
            CmdletUnitTest.TestRunspace.IitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($true);");
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"Add-Type -Path '.\SePSXTest.dll';");
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
				@"[UIAutomation.CurrentData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
    }
}
