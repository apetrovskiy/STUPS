/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/30/2012
 * Time: 12:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of SwitchSeToAlertCommand.
    /// </summary>
    [TestFixture]
    public class SwitchSeToAlertCommand_ParamCheck // NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToAlertCommand_ParamCheck()
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
