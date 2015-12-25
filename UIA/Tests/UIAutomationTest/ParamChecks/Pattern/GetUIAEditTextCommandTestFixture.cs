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
    /// Description of GetUiaEditTextCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20140128")]
    public class GetUiaEditTextCommandTestFixture
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
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Description("Get-UiaEditText")]
        public void Get_UiaEditText_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-UiaEditText;");
        }
    }
}
