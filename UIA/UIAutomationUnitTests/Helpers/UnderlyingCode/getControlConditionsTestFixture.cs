/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/25/2013
 * Time: 8:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of getControlConditionsTestFixture.
    /// </summary>
    [TestFixture]
    public class getControlConditionsTestFixture
    {
        public getControlConditionsTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private AndCondition ResultCondition { get; set; }

        private void getConditions(string name, string automationId, string className, string controlType)
        {
            this.ResultCondition = null;
            
            GetControlCmdletBase cmdlet =
                new GetControlCmdletBase();
            cmdlet.Name = name;
            cmdlet.AutomationId = automationId;
            cmdlet.Class = className;
            
            UIAutomation.CommonCmdletBase common =
                new UIAutomation.CommonCmdletBase();
            
            this.ResultCondition =
                (common.getControlConditions(cmdlet, controlType, cmdlet.CaseSensitive, true) as AndCondition);

        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType()
        {
            this.getConditions(null, null, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
                
            Assert.AreEqual(
                Condition.TrueCondition,
                (this.ResultCondition.GetConditions()[1]));
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name()
        {
            string expectedName = "name1";
            
            this.getConditions(expectedName, null, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_AutomationId()
        {
            string expectedAutomationId = "au1";
            
            this.getConditions(null, expectedAutomationId, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_ClassName()
        {
            string expectedClassName = "className1";
            
            this.getConditions(null, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_AutomationId()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            
            this.getConditions(expectedName, expectedAutomationId, null, "button");

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_ClassName()
        {
            string expectedName = "name1";
            string expectedClassName = "className1";
            
            this.getConditions(expectedName, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_AutomationId_ClassName()
        {
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            this.getConditions(null, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_AutomationId_ClassName()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            this.getConditions(expectedName, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }

        // =========================
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void No_conditions()
        {
            this.getConditions(null, null, null, "");
            
            Assert.AreEqual(
                Condition.TrueCondition,
                (this.ResultCondition.GetConditions()[0]));
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name()
        {
            string expectedName = "name1";
            
            this.getConditions(expectedName, null, null, "");
            
            Assert.AreEqual(
                expectedName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId()
        {
            string expectedAutomationId = "au1";
            
            this.getConditions(null, expectedAutomationId, null, "");
            
            Assert.AreEqual(
                expectedAutomationId,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ClassName()
        {
            string expectedClassName = "className1";
            
            this.getConditions(null, null, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            
            this.getConditions(expectedName, expectedAutomationId, null, "");
            
            Assert.AreEqual(
                expectedName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_ClassName()
        {
            string expectedName = "name1";
            string expectedClassName = "className1";
            
            this.getConditions(expectedName, null, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId_ClassName()
        {
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            this.getConditions(null, expectedAutomationId, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId_ClassName()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            this.getConditions(expectedName, expectedAutomationId, expectedClassName, "");
            
            Assert.AreEqual(
                expectedClassName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedName,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((this.ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }
        
    }
}
