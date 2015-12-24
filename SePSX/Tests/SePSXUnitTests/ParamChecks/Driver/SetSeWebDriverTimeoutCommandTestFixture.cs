/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of SetSeWebDriverTimeoutCommand.
    /// </summary>
    [TestFixture]
    public class SetSeWebDriverTimeoutCommand_ParamCheck // HasWebDriverInputCmdletBase
    {
        public SetSeWebDriverTimeoutCommand_ParamCheck()
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
