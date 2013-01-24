/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 11:11 PM
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
    /// Description of EnterSeURLCommand.
    /// </summary>
    [TestFixture]
    public class EnterSeURLCommand_ParamCheck // NavigationCmdletBase
    {
        public EnterSeURLCommand_ParamCheck()
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
        
//        [Test]
//        [Category("Fast")]
//        public void Empty() //never should work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "Enter-SeURL;");
//        }
        
        [Test]
        [Category("Fast")]
        public void UrlValue()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Enter-SeURL 'http://google.com';");
        }
        
        [Test]
        [Category("Fast")]
        public void UrlParam_UrlValue()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "Enter-SeURL -URL 'http://google.com';");
        }
    }
}
