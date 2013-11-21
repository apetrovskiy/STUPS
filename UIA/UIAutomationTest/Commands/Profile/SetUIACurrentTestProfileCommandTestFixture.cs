/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Profile
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetUiaCurrentTestProfileCommandTestFixture.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCurrentTestProfile")]
    public class SetUiaCurrentTestProfileCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::Profiles.Clear());");
        }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
