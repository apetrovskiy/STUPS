/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
//    using OpenQA.Selenium.Firefox;
//    using OpenQA.Selenium.Chrome;
//    using OpenQA.Selenium.IE;
//    using OpenQA.Selenium.Safari;
//    using OpenQA.Selenium.Android;
//    using OpenQA.Selenium.Remote;
    
    /// <summary>
    /// Description of CloseSeWebDriverCurrentBrowserWindowCommand.
    /// </summary>
    [TestFixture]
    public class CloseSeWebDriverCurrentBrowserWindowCommandTestFixture // HasWebDriverInputCmdletBase
    {
        public CloseSeWebDriverCurrentBrowserWindowCommandTestFixture()
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
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
