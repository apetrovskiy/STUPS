/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of ReadSeWebDriverNativeWindowHandleCommand.
    /// </summary>
    [TestFixture]
    public class ReadSeWebDriverNativeWindowHandleCommand_ParamCheck // HasWebDriverInputCmdletBase
    {
        public ReadSeWebDriverNativeWindowHandleCommand_ParamCheck()
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
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
