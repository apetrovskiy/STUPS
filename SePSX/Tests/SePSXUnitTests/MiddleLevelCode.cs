/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    // using NUnit;

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
            
            //
            //
            // MiddleLevelCode.DisposeRunspace(); // 20121226
            MiddleLevelCode.DisposeRunspace();
            //
            //
            
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($false);");
        }
        
        public static void PrepareRunspaceForParamChecks()
        {
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            CmdletUnitTest.TestRunspace.RunPSCode("[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($true);");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Add-Type -Path '.\SePSXUnitTests.dll';");
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement();");
        }
        
        public static void DisposeRunspace()
        {
            try {
                CmdletUnitTest.TestRunspace.RunPSCode(
                    //@"foreach ($driver  in  [SePSX.CurrentData]::Drivers.Keys) {[SePSX.CurrentData]::Drivers[$driver].Quit();}; " +
                    //@"[SePSX.CurrentData]::Drivers.Clear(); " + 
                    @"[SePSX.CurrentData]::ResetData();");
                
            }
            catch (Exception eOnReset) {
                Console.WriteLine(eOnReset.Message);
            }
                
                //@"[SePSX.CurrentData]::CurrentWebDriver = $null; ");
            try {
                CmdletUnitTest.TestRunspace.CloseRunspace();
            }
            catch (Exception eOnClose) {
                Console.WriteLine(eOnClose.Message);
            }
        }
        
        public static string GetURLFromPath(string path)
        {
            string result = @"file:///" + path;
            
            result = result.Replace(@"\", @"/");
            
            return result;
        }
        
        
    }
}
