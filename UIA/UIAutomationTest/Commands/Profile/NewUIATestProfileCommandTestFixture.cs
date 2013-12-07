/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 8:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Profile
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewUiaTestProfileCommandTestFixture.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UiaTestProfile")]
    public class NewUiaTestProfileCommandTestFixture
    {
        public NewUiaTestProfileCommandTestFixture()
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
        [Category("Slow")][Category("New_UiaTestProfile")]
        public void NewTestProfile_Simple()
        {
            string name = "prof";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$profile = New-UiaTestProfile -Name '" + 
                name +
                "'; " + 
                "$profile.Name;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("New_UiaTestProfile")]
        public void NewTestProfile_Complex1()
        {
            string name = @"<<p`r*o''f>>";
            string answer = @"<<p`r*o'f>>";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$profile = New-UiaTestProfile -Name '" + 
                name +
                "'; " + 
                "$profile.Name;",
                answer);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("New_UiaTestProfile")]
        public void NewTestProfile_Complex2()
        {
            string name = @"``//\\`""`''#$(1)567";
            string answer = @"``//\\`""`'#$(1)567";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$profile = New-UiaTestProfile -Name '" + 
                name +
                "'; " + 
                "$profile.Name;",
                answer);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("New_UiaTestProfile")]
        public void NewTestProfile_Simple_AlreadyExists()
        {
            string name = "prof";
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$profile = New-UiaTestProfile -Name '" + 
                name +
                "'; " + 
                @"$profile = New-UiaTestProfile -Name '" + 
                name +
                "';",
                "CmdletInvocationException",
                "The profile already exists");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
