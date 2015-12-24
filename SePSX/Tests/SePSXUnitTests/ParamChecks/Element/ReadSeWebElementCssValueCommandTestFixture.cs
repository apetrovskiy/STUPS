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
    /// Description of ReadSeWebElementCssValueCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebElementCssValueCommand_ParamCheck
    {
        public ReadSeWebElementCssValueCommand_ParamCheck()
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
        
//        [Test]
//        [Category("Fast")]
//        public void InputObject_NoPropertyName() // this should not work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Read-SeWebElementCssValue " +
//                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement());");
//        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementCssValue_InputObject_PropertyName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Read-SeWebElementCssValue " +
                "-InputObject ([SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement()) " +
                "-PropertyName aaa;");
        }
        
        [Test]
        [Category("Fast")]
        public void ReadSeWebElementCssValue_NoInputObject_PropertyName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "[SePSXUnitTests.ParamChecks.FakeWebObjectsFactory]::GetFakeWebElement() | " +
                "Read-SeWebElementCssValue -PropertyName aaa;");
        }
    }
}
