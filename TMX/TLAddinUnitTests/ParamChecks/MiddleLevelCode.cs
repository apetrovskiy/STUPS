/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2012
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.CheckCmdletParameters
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
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[Tmx.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
    }
}
