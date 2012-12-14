/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeNavigateBackCommand.
    /// </summary>
    [TestFixture]
    public class InvokeSeNavigateBackCommandTestFixture // NavigationCmdletBase
    {
        public InvokeSeNavigateBackCommandTestFixture()
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
                "Invoke-SeNavigateBack;");
        }
    }
}
