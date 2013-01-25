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
        //private static AndCondition getConditions(GetControlCmdletBase cmdlet)
        //private AndCondition getConditions(string name, string automationId, string className, string controlType)
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
                common.getControlConditions(cmdlet, controlType);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void No_conditions()
        {
            this.getConditions(null, null, null, "button");
            
//            Assert.AreEqual<Condition[]>(
//                new Condition[] {
//                    Condition.TrueCondition,
//                    Condition.TrueCondition
//                },
//                this.ResultCondition.GetConditions());
            
//            Assert.AreEqual<AndCondition>(
//                new AndCondition(
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button),
//                    Condition.TrueCondition),
//                this.ResultCondition);

            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
                
            Assert.AreEqual(
                Condition.TrueCondition,
                (this.ResultCondition.GetConditions()[1]));
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name()
        {
            string expectedName = "name1";
            
            this.getConditions(expectedName, null, null, "button");
            
            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            Assert.AreEqual(
                expectedName,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
//Console.WriteLine("before AreElementsEqual<Condition[]>");
//            Assert.AreElementsEqual<System.Windows.Automation.Condition>(
//                new AndCondition(
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button),
//                    new PropertyCondition(
//                        AutomationElement.NameProperty,
//                        expectedName,
//                        PropertyConditionFlags.IgnoreCase)).GetConditions(),
//                this.ResultCondition.GetConditions(),
//                null);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId()
        {
            string expectedAutomationId = "au1";
            
            this.getConditions(null, expectedAutomationId, null, "button");
            
            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            Assert.AreEqual(
                expectedAutomationId,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
//Console.WriteLine("before Assert.AreElementsEqual");
//            Assert.AreElementsEqual(
//                new AndCondition(
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button),
//                    new PropertyCondition(
//                        AutomationElement.AutomationIdProperty,
//                        expectedAutomationId,
//                        PropertyConditionFlags.IgnoreCase)).GetConditions(),
//                this.ResultCondition.GetConditions());
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ClassName()
        {
            string expectedClassName = "className1";
            
            this.getConditions(null, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
//Console.WriteLine("before Assert.AreElementsSame");
//            Assert.AreElementsSame(
//                new AndCondition(
//                    new PropertyCondition(
//                        AutomationElement.ClassNameProperty,
//                        expectedClassName,
//                        PropertyConditionFlags.IgnoreCase),
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button)).GetConditions(),
//                this.ResultCondition.GetConditions());
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            
            this.getConditions(expectedName, expectedAutomationId, null, "button");

            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                (this.ResultCondition.GetConditions()[2] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_ClassName()
        {
            string expectedName = "name1";
            string expectedClassName = "className1";
            
            this.getConditions(expectedName, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                (this.ResultCondition.GetConditions()[2] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId_ClassName()
        {
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            this.getConditions(null, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                (this.ResultCondition.GetConditions()[2] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.getControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId_ClassName()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            this.getConditions(expectedName, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (this.ResultCondition.GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                ControlType.Button.Id,
                (this.ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                (this.ResultCondition.GetConditions()[2] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                (this.ResultCondition.GetConditions()[3] as PropertyCondition).Value);
        }
    }
}
