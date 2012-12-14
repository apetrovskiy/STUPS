/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSePageRefreshCommand.
    /// </summary>
    [TestFixture]
    public class InvokeSePageRefreshCommandTestFixture // NavigationCmdletBase
    {
        public InvokeSePageRefreshCommandTestFixture()
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
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        public void Empty()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Invoke-SePageRefresh;");
        }
    }
}
