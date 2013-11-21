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
    /// Description of GetUiaTestProfileCommandTestFixture.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTestProfile")]
    public class GetUiaTestProfileCommandTestFixture
    {
        public GetUiaTestProfileCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::Profiles.Clear());");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("Get_UiaTestProfile")]
        public void GetTestProfile_ByName_Simple()
        {
            string name = @"prof";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-UiaTestProfile -Name '" + 
                name +
                "'; " + 
                "(Get-UiaTestProfile -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("Get_UiaTestProfile")]
        public void GetTestProfile_ByName_Complex()
        {
            string name = @"<<p`r*o''f>>";
            string answer = @"<<p`r*o'f>>";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-UiaTestProfile -Name '" + 
                name +
                "'; " + 
                "(Get-UiaTestProfile -Name '" + 
                name + 
                "').Name;",
                answer);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("Get_UiaTestProfile")]
        public void GetTestProfile_FromPipeline_Simple()
        {
            string name = @"prof";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaTestProfile -Name '" + 
                name +
                "' | " + 
                "Get-UiaTestProfile).Name;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("Get_UiaTestProfile")]
        public void GetTestProfile_FromPipeline_Complex()
        {
            string name = @"<<p`r*o''f>>";
            string answer = @"<<p`r*o'f>>";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaTestProfile -Name '" + 
                name +
                "' | " + 
                "Get-UiaTestProfile).Name;",
                answer);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
