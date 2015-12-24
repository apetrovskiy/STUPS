/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/19/2012
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of ReadSeWebElementEnabledCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementEnabledCommand_ParamCheck
    {
        public ReadSeWebElementEnabledCommand_ParamCheck()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace(); // 20121226
        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementEnabled_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Read-SeWebElementEnabled " +
                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementEnabled_NoInputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementEnabled;");
        }
    }
}
