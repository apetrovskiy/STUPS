/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/30/2012
 * Time: 12:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SwitchSeToAlertCommand.
    /// </summary>
    [TestFixture]
    public class SwitchSeToAlertCommandTestFixture // NavigationCmdletBase //SwitchToCmdletBase
    {
        public SwitchSeToAlertCommandTestFixture()
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
