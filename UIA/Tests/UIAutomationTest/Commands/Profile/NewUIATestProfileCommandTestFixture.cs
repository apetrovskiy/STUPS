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
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::Profiles.Clear());");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("New_UiaTestProfile")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("New_UiaTestProfile")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("New_UiaTestProfile")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("New_UiaTestProfile")]
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
