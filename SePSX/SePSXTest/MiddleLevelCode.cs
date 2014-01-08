/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest
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
        [STAThread]
        public static void PrepareRunspace()
        {
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($false);");
        }
        
        public static void PrepareRunspaceForParamChecks()
        {
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($true);");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Add-Type -Path '.\SePSXTest.dll';");
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"[SePSXTest.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement();");
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
        		//@"foreach ($driver  in  [SePSX.CurrentData]::Drivers.Keys) {[SePSX.CurrentData]::Drivers[$driver].Quit();}; " +
				//@"[SePSX.CurrentData]::Drivers.Clear(); " + 
				@"[SePSX.CurrentData]::ResetData();");
			    //@"[SePSX.CurrentData]::CurrentWebDriver = $null; ");
            CmdletUnitTest.TestRunspace.CloseRunspace();
        }
        
        public static string GetURLFromPath(string path)
        {
        	string result = @"file:///" + path;
        	
        	result = result.Replace(@"\", @"/");
        	
        	return result;
        }
        
        
    }
}
