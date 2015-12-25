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
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Get_UiaTestProfile")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Get_UiaTestProfile")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Get_UiaTestProfile")]
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Profile")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Get_UiaTestProfile")]
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
