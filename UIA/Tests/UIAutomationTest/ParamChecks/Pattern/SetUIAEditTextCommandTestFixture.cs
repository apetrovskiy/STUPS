/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2013
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{ // using Xunit;
    
    /// <summary>
    /// Description of SetUiaEditTextCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class SetUiaEditTextCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode2.PrepareRunspaceForParamChecks();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Ignore("It's difficult to learn now what is the problem with it")]
        [NUnit.Framework.Ignore("It's difficult to learn now what is the problem with it")]
        [MbUnit.Framework.Description("Set-UiaEditText -Text 'text' -InputObject $obj")]
        public void Set_UiaEditText_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
                "Set-UiaEditText -Text 'text' -InputObject $obj;");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Ignore("It's difficult to learn now what is the problem with it")]
        [NUnit.Framework.Ignore("It's difficult to learn now what is the problem with it")]
        [MbUnit.Framework.Description("Set-UiaEditText 'text' -InputObject $obj")]
        public void Set_UiaEditText_Text_Position0()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
                "Set-UiaEditText 'text' -InputObject $obj;");
        }
    }
}
