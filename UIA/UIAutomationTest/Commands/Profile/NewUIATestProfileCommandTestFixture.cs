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
    /// Description of NewUIATestProfileCommandTestFixture.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UIATestProfile")]
    public class NewUIATestProfileCommandTestFixture
    {
        public NewUIATestProfileCommandTestFixture()
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
        [Category("Slow")][Category("New_UIATestProfile")]
        public void NewTestProfile_Simple()
        {
            string name = "prof";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$profile = New-UIATestProfile -Name '" + 
                name +
                "'; " + 
                "$profile.Name;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("New_UIATestProfile")]
        public void NewTestProfile_Complex1()
        {
            string name = @"<<p`r*o''f>>";
            string answer = @"<<p`r*o'f>>";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$profile = New-UIATestProfile -Name '" + 
                name +
                "'; " + 
                "$profile.Name;",
                answer);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("New_UIATestProfile")]
        public void NewTestProfile_Complex2()
        {
            string name = @"``//\\`""`''#$(1)567";
            string answer = @"``//\\`""`'#$(1)567";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$profile = New-UIATestProfile -Name '" + 
                name +
                "'; " + 
                "$profile.Name;",
                answer);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Profile")]
        [Category("Slow")][Category("New_UIATestProfile")]
        public void NewTestProfile_Simple_AlreadyExists()
        {
            string name = "prof";
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$profile = New-UIATestProfile -Name '" + 
                name +
                "'; " + 
                @"$profile = New-UIATestProfile -Name '" + 
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
