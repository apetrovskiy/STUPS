/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/28/2012
 * Time: 1:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BDDAddinUnitTests.CheckCmdletParameters
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
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($false);");
        }
        
        public static void PrepareRunspaceForParamChecks()
        {
            PSCmdletBase.UnitTestMode = false;
            
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($true);");
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"Add-Type -Path '.\SePSXTest.dll';");
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
				@"[Tmx.Core.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
    }
}
