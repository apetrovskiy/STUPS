/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/16/2012
 * Time: 1:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of ConvertToSeAutomationElementCommand.
    /// </summary>
    [TestFixture]
    public class ConvertToSeAutomationElementCommand_ParamCheck // ConvertCmdletBase
    {
        public ConvertToSeAutomationElementCommand_ParamCheck()
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
