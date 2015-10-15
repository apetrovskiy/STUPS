/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 9:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of StopSeWebDriverCommand.
    /// </summary>
    [TestFixture]
    public class StopSeWebDriverCommand_ParamCheck
    {
        public StopSeWebDriverCommand_ParamCheck()
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
        public void StopSeWebDriver_InputObject_NoInstanceName()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Stop-SeWebDriver -InputObject $null;");
        }
        
        [Test]
        [Category("Fast")]
        public void StopSeWebDriver_InstanceName() // any type of a driver
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Stop-SeWebDriver -InstanceName aaa;");
        }
    }
    
//    /// <summary>
//    /// 
//    /// </summary>
//    public class StopSeFirefoxCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeFirefoxCommandTestFixture(){}
//    }
//    
//    /// <summary>
//    /// 
//    /// </summary>
//    public class StopSeChromeCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeChromeCommandTestFixture(){}
//    }
//    
//    /// <summary>
//    /// 
//    /// </summary>
//    public class StopSeInternetExplorerCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeInternetExplorerCommandTestFixture(){}
//    }
//    
//    /// <summary>
//    /// 
//    /// </summary>
//    internal class StopSeSafariCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeSafariCommandTestFixture(){}
//    }
    
//    /// <summary>
//    /// 
//    /// </summary>
//    internal class StopSeOperaCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeOperaCommandTestFixture(){}
//    }
//    
//    /// <summary>
//    /// 
//    /// </summary>
//    internal class StopSeAndroidCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeAndroidCommandTestFixture(){}
//    }
//    
//    /// <summary>
//    /// 
//    /// </summary>
//    public class StopSeHTMLUnitCommandTestFixture // StopSeWebDriverCommand
//    {
//        public StopSeHTMLUnitCommandTestFixture(){}
//    }
}
