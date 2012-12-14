/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    /// <summary>
    /// Description of NewSeChromeOptionsCommand.
    /// </summary>
    [TestFixture]
    public class NewSeChromeOptionsCommandTestFixture // ChromeOptionsCmdletBase
    {
        public NewSeChromeOptionsCommandTestFixture()
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
