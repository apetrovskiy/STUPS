/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2012
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TLAddinUnitTests.CheckParameters
{
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
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetParamCheck($false);");
        }
        
        public static void PrepareRunspaceForParamChecks()
        {
            CmdletUnitTest.TestRunspace.IitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetParamCheck($true);");
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"Add-Type -Path '.\SePSXTest.dll';");
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
				@"[TMX.TestData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
	}
}
