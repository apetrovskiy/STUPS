/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2013
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;// using Xunit;
    
    /// <summary>
    /// Description of GetUiaEditTextCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class GetUiaEditTextCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]// [Fact]
        [Category("Fast")]
        [Description("Get-UiaEditText")]
        public void Get_UiaEditText_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		"Get-UiaEditText;");
        }
    }
}
