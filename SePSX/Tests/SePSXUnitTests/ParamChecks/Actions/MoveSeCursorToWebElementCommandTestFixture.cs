/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 3:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of MoveSeCursorToWebElementCommand.
    /// </summary>
    [TestFixture]
    public class MoveSeCursorToWebElementCommand_ParamCheck // ActionsCmdletBase
    {
        public MoveSeCursorToWebElementCommand_ParamCheck()
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
