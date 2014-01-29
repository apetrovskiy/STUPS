/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2013
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{
    using MbUnit.Framework;// using Xunit;
    
    /// <summary>
    /// Description of SetUiaEditTextCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class SetUiaEditTextCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode2.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]// [Fact]
        [Category("Fast")]
        [Ignore("It's difficult to learn now what is the problem with it")]
        [Description("Set-UiaEditText -Text 'text' -InputObject $obj")]
        public void Set_UiaEditText_Text()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Set-UiaEditText -Text 'text' -InputObject $obj;");
        }
        
        [Test]// [Fact]
        [Category("Fast")]
        [Ignore("It's difficult to learn now what is the problem with it")]
        [Description("Set-UiaEditText 'text' -InputObject $obj")]
        public void Set_UiaEditText_Text_Position0()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		"Set-UiaEditText 'text' -InputObject $obj;");
        }
    }
}
