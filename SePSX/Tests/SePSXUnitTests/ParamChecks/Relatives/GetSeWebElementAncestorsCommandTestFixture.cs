/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10.08.2012
 * Time: 6:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of GetSeWebElementAncestorsCommand.
    /// </summary>
    [TestFixture]
    public class GetSeWebElementAncestorsCommand_ParamCheck // WebElementCmdletBase
    {
        public GetSeWebElementAncestorsCommand_ParamCheck()
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
