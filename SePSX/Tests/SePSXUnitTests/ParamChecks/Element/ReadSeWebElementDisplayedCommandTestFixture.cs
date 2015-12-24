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
    /// Description of ReadSeWebElementDisplayedCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementDisplayedCommand_ParamCheck
    {
        public ReadSeWebElementDisplayedCommand_ParamCheck()
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
        public void ReadSeWebElementDisplayed_InputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Read-SeWebElementDisplayed " +
                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementDisplayed_NoInputObject()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementDisplayed;");
        }
    }
}
