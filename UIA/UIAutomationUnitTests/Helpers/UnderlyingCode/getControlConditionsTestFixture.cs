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
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetControlConditionsTestFixture.
    /// </summary>
    [TestFixture]
    public class GetControlConditionsTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        // 20131118
        // object -> Condition
        private AndCondition ResultCondition { get; set; }
        //private Condition ResultCondition { get; set; }

        private void getConditions(string name, string automationId, string className, string controlType)
        {
            ResultCondition = null;
            
            GetControlCmdletBase cmdlet =
                new GetControlCmdletBase {Name = name, AutomationId = automationId, Class = className, CaseSensitive = false };

            CommonCmdletBase common =
                new CommonCmdletBase();
            
            ResultCondition =
                // 20131118
                // object -> Condition
                (common.GetControlConditions(cmdlet, controlType, cmdlet.CaseSensitive, true) as AndCondition);
                //common.GetControlConditions(cmdlet, controlType, cmdlet.CaseSensitive, true);

        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType()
        {
            getConditions(null, null, null, "button");

            PropertyCondition propertyCondition = ResultCondition.GetConditions()[0] as PropertyCondition;
            if (propertyCondition != null)
                Assert.AreEqual(
                    System.Windows.Automation.ControlType.Button.Id,
                    propertyCondition.Value);
            /*
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            */

            Assert.AreEqual(
                Condition.TrueCondition,
                (ResultCondition.GetConditions()[1]));
           
           Assert.ForAll(ResultCondition.GetConditions(), x => x is PropertyCondition | ((x as PropertyCondition).Value as ControlType).Id == System.Windows.Automation.ControlType.Button.Id | (x as Condition) == Condition.TrueCondition);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name()
        {
            string expectedName = "name1";
            
            getConditions(expectedName, null, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_AutomationId()
        {
            const string expectedAutomationId = "au1";
            
            getConditions(null, expectedAutomationId, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_ClassName()
        {
            const string expectedClassName = "className1";
            
            getConditions(null, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_AutomationId()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            
            getConditions(expectedName, expectedAutomationId, null, "button");

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_ClassName()
        {
            string expectedName = "name1";
            string expectedClassName = "className1";
            
            getConditions(expectedName, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_AutomationId_ClassName()
        {
            string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getConditions(null, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_AutomationId_ClassName()
        {
            string expectedName = "name1";
            string expectedAutomationId = "au1";
            string expectedClassName = "className1";
            
            getConditions(expectedName, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }

        // =========================
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void No_conditions()
        {
            getConditions(null, null, null, "");
            
            Assert.AreEqual(
                Condition.TrueCondition,
                (ResultCondition.GetConditions()[0]));
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name()
        {
            string expectedName = "name1";
            
            getConditions(expectedName, null, null, "");
            
            Assert.AreEqual(
                expectedName,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId()
        {
            const string expectedAutomationId = "au1";
            
            getConditions(null, expectedAutomationId, null, "");
            
            Assert.AreEqual(
                expectedAutomationId,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ClassName()
        {
            string expectedClassName = "className1";
            
            getConditions(null, null, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            
            getConditions(expectedName, expectedAutomationId, null, "");
            
            Assert.AreEqual(
                expectedName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_ClassName()
        {
            const string expectedName = "name1";
            const string expectedClassName = "className1";
            
            getConditions(expectedName, null, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId_ClassName()
        {
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getConditions(null, expectedAutomationId, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditions(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId_ClassName()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getConditions(expectedName, expectedAutomationId, expectedClassName, "");
            
            Assert.AreEqual(
                expectedClassName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedName,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((ResultCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }
        
    }
}
