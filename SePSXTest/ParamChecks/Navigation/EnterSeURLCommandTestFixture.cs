/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 11:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of EnterSeURLCommand.
    /// </summary>
    [TestFixture]
    public class EnterSeURLCommandTestFixture // NavigationCmdletBase
    {
        public EnterSeURLCommandTestFixture()
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
        
//        [Test]
//        public void Empty() //never should work
//        {
//            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
//                "Enter-SeURL;");
//        }
        
        [Test]
        public void UrlValue()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Enter-SeURL 'http://google.com';");
        }
        
        [Test]
        public void UrlParam_UrlValue()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckParameters(
                "Enter-SeURL -URL 'http://google.com';");
        }
    }
}
