/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2012
 * Time: 8:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of SaveSeScreenshotCommand.
    /// </summary>
    [TestFixture]
    public class SaveSeScreenshotCommand_ParamCheck
    {
        #region Constructor
        public SaveSeScreenshotCommand_ParamCheck()
        {
        }
        #endregion Constructor
        
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
    
    /// <summary>
    /// Description of GetSeScreenshotCommand.
    /// </summary>
    [TestFixture]
    public class GetSeScreenshotCommand_ParamCheck
    {
        public GetSeScreenshotCommand_ParamCheck()
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
