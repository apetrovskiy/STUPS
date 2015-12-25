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
    // using Xunit;

    /// <summary>
    /// Description of GetControlConditionsTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("Incompatible with contemporary code")]
    [MbUnit.Framework.Ignore("Incompatible with contemporary code")]
    [NUnit.Framework.Ignore("Incompatible with contemporary code")]
    public class GetControlConditionsTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        private AndCondition ResultAndCondition { get; set; }
        private OrCondition ResultOrCondition { get; set; }
        
        private void getAndConditions(string name, string automationId, string className, string controlType)
        {
            ResultAndCondition = null;
            
            var cmdlet =
                new GetControlCmdletBase {Name = name, AutomationId = automationId, Class = className, CaseSensitive = false };

            var common =
                new CommonCmdletBase();
            
            // 20131128
            //ResultAndCondition =
            //    (common.GetControlConditionsForWildcardSearch(cmdlet, controlType, cmdlet.CaseSensitive, true) as AndCondition);
            // 20131129
            // ResultAndCondition =
            //     (common.GetControlConditionsForWildcardSearch(cmdlet, controlType, cmdlet.CaseSensitive));
            ResultAndCondition =
                // common.GetWildcardSearchCondition(cmdlet) as AndCondition;
                ControlSearcher.GetWildcardSearchCondition(
                    new ControlSearcherData {
                        Name = name,
                        AutomationId = automationId,
                        Class = className,
                        CaseSensitive = false
                    }) as AndCondition;
        }
        
        private void getOrConditions(string searchString, string controlType)
        {
            ResultOrCondition = null;
            
            GetControlCmdletBase cmdlet =
                new GetControlCmdletBase {ContainsText = searchString };

            CommonCmdletBase common =
                new CommonCmdletBase();
            
            // 20131129
            // ResultOrCondition =
            //     (common.GetControlConditionsForExactSearch(cmdlet, controlType, cmdlet.CaseSensitive, false) as OrCondition);
            ResultOrCondition =
                // common.GetTextSearchCondition(searchString, new string[] { controlType }, cmdlet.CaseSensitive) as OrCondition;
                ControlSearcher.GetTextSearchCondition(searchString, new string[] { controlType }, cmdlet.CaseSensitive) as OrCondition;
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType()
        {
            getAndConditions(null, null, null, "button");

            PropertyCondition propertyCondition = ResultAndCondition.GetConditions()[0] as PropertyCondition;
            if (propertyCondition != null)
                MbUnit.Framework.Assert.AreEqual(
                    System.Windows.Automation.ControlType.Button.Id,
                    propertyCondition.Value);
            /*
            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            */

            MbUnit.Framework.Assert.AreEqual(
                Condition.TrueCondition,
                (ResultAndCondition.GetConditions()[1]));
           
           //Assert.ForAll(ResultCondition.GetConditions(), x => x is PropertyCondition | ((x as PropertyCondition).Value as ControlType).Id == System.Windows.Automation.ControlType.Button.Id | (x as Condition) == Condition.TrueCondition);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_Name()
        {
            const string expectedName = "name1";
            
            getAndConditions(expectedName, null, null, "button");
            
            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[1] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_AutomationId()
        {
            const string expectedAutomationId = "au1";
            
            getAndConditions(null, expectedAutomationId, null, "button");
            
            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[1] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_ClassName()
        {
            const string expectedClassName = "className1";
            
            getAndConditions(null, null, expectedClassName, "button");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_Name_AutomationId()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            
            getAndConditions(expectedName, expectedAutomationId, null, "button");

            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_Name_ClassName()
        {
            const string expectedName = "name1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, null, expectedClassName, "button");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_AutomationId_ClassName()
        {
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(null, expectedAutomationId, expectedClassName, "button");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ControlType_Name_AutomationId_ClassName()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, expectedAutomationId, expectedClassName, "button");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }

        // =========================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void No_conditions()
        {
            getAndConditions(null, null, null, "");
            
            MbUnit.Framework.Assert.AreEqual(
                Condition.TrueCondition,
                (ResultAndCondition.GetConditions()[0]));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void Name()
        {
            const string expectedName = "name1";
            
            getAndConditions(expectedName, null, null, "");
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void AutomationId()
        {
            const string expectedAutomationId = "au1";
            
            getAndConditions(null, expectedAutomationId, null, "");
            
            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ClassName()
        {
            const string expectedClassName = "className1";
            
            getAndConditions(null, null, expectedClassName, "");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void Name_AutomationId()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            
            getAndConditions(expectedName, expectedAutomationId, null, "");
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void Name_ClassName()
        {
            const string expectedName = "name1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, null, expectedClassName, "");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void AutomationId_ClassName()
        {
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(null, expectedAutomationId, expectedClassName, "");

            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void Name_AutomationId_ClassName()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, expectedAutomationId, expectedClassName, "");
            
            MbUnit.Framework.Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }
        
        // ======================================================================================================
        // OrCondition (ContainsText)
        // ======================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        //[Description("CommonCmdletBase.GetControlConditionsForExactSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ContainsText_1()
        {
            const string expectedText = "text";
            string controlTypeText = string.Empty;
            
            getOrConditions(expectedText, controlTypeText);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[1] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[2] as PropertyCondition).Value);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        //[Description("CommonCmdletBase.GetControlConditionsForExactSearch(HasControlInputCmdletBase, string)")]
//        [Category("Fast")]
        public void ContainsTextControlType_1()
        {
            const string expectedText = "text";
            const string controlTypeText = "button";
            
            getOrConditions(expectedText, controlTypeText);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[0] as PropertyCondition).Value);

            MbUnit.Framework.Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[1] as PropertyCondition).Value);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[2] as PropertyCondition).Value);
        }
    }
}
