/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of NewSeChromeOptionsCommand.
    /// </summary>
    [TestFixture]
    public class NewSeChromeOptionsCommand_ParamCheck // ChromeOptionsCmdletBase
    {
        public NewSeChromeOptionsCommand_ParamCheck()
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
