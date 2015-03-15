/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using System;
    using SePSX;
    using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeNavigateForwardCommand.
    /// </summary>
    [TestFixture]
    public class InvokeSeNavigateForwardCommand_ParamCheck // NavigationCmdletBase
    {
        public InvokeSeNavigateForwardCommand_ParamCheck()
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
        [Category("Invoke-SeNavigateForward")]
        public void InvokeSeNavigateForward_Empty()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Invoke-SeNavigateForward;");
        }
    }
}
