/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/13/2014
 * Time: 10:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Wait
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Automation;
    using UIAutomation;
    using Xunit;
    using UIAutomation.Commands;
    using UIAutomation.Helpers.Commands;
    
    /// <summary>
    /// Description of WaitUIAControlStateCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class WaitUIAControlStateCommandTestFixture
    {
        public WaitUIAControlStateCommandTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        private void TestParametersAgainstCollection(
            Hashtable[] inputData,
            IEnumerable<IUiElement> collection,
            bool expectedResult)
        {
            // Arrange
            var data =
                new ControlSearcherData {
                SearchCriteria = inputData
            };
            
            Condition condition =
                ControlSearcher.GetWildcardSearchCondition(data);
            
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            var cmdlet =
                new WaitUiaControlStateCommand {
                SearchCriteria = inputData,
                InputObject = new[] { element },
                Timeout = 10
            };
            
            // Act
            var command = new WaitControlStateCommand(cmdlet);
            command.Execute();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual<bool>(
                expectedResult,
                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
            Assert.Equal<bool>(
                expectedResult,
                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
        #endregion helpers
        
        #region no parameters
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore("this is unclear yet until the input validator is here")]
        [MbUnit.Framework.Ignore("this is unclear yet until the input validator is here")]
        [NUnit.Framework.Ignore("this is unclear yet until the input validator is here")]
        public void Get0_NoParam_AllInputNull()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            // ControlType controlType = null;
            TestParametersAgainstCollection(
                null,
                null,
                false);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_NoParam_HashtablesNull()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            // ControlType controlType = null;
            TestParametersAgainstCollection(
                null,
                new UiElement[] {},
                false);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore("this is unclear yet until the input validator is here")]
        [MbUnit.Framework.Ignore("this is unclear yet until the input validator is here")]
        [NUnit.Framework.Ignore("this is unclear yet until the input validator is here")]
        public void Get0_NoParam_ElementsNull()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            // ControlType controlType = null;
            TestParametersAgainstCollection(
                new Hashtable[] {},
                null,
                false);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_NoParam()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            // ControlType controlType = null;
            TestParametersAgainstCollection(
                new Hashtable[] {},
                new UiElement[] {},
                false);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_NoParam()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            // ControlType controlType = null;
            TestParametersAgainstCollection(
                new Hashtable[] {},
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.TabItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                false);
        }
        #endregion no parameters
        
        #region ControlType + Class
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht = new Hashtable();
            ht.Add("controlType", "button");
            ht.Add("class", className);
            var inputData = new[] { ht };
            TestParametersAgainstCollection(
                inputData,
                new UiElement[] {},
                false);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of4_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht = new Hashtable();
            ht.Add("controlType", "button");
            ht.Add("class", className);
            var inputData = new[] { ht };
            TestParametersAgainstCollection(
                inputData,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl02", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                false);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of4_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht = new Hashtable();
            ht.Add("controlType", "button");
            ht.Add("class", className);
            var inputData = new[] { ht };
            TestParametersAgainstCollection(
                inputData,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                true);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get2of4_byControlTypeClass_X2()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht1 = new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            var ht2 = new Hashtable();
            ht2.Add("controlType", "headeritem");
            var inputData = new[] { ht1, ht2 };
            TestParametersAgainstCollection(
                inputData,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                true);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of4_byControlTypeClass_X2()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht1 = new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            var ht2 = new Hashtable();
            ht2.Add("controlType", "menu");
            var inputData = new[] { ht1, ht2 };
            TestParametersAgainstCollection(
                inputData,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                false);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of4_byControlTypeClass_X5()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht1 = new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            var ht2 = new Hashtable();
            ht2.Add("controlType", "headeritem");
            var ht3 = new Hashtable();
            ht3.Add("controlType", "button");
            ht3.Add("class", "cl03");
            var ht4 = new Hashtable();
            ht4.Add("controlType", "button");
            ht4.Add("class", className);
            var ht5 = new Hashtable();
            ht5.Add("controlType", "headeritem");
            var inputData = new[] { ht1, ht2, ht3, ht4, ht5 };
            TestParametersAgainstCollection(
                inputData,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                true);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of4_byControlTypeClass_X5()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            var ht1 = new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            var ht2 = new Hashtable();
            ht2.Add("controlType", "menu");
            var ht3 = new Hashtable();
            ht3.Add("controlType", "button");
            ht3.Add("class", "cl03");
            var ht4 = new Hashtable();
            ht4.Add("controlType", "button");
            ht4.Add("class", className);
            var ht5 = new Hashtable();
            ht5.Add("controlType", "headeritem");
            var inputData = new[] { ht1, ht2, ht3, ht4, ht5 };
            TestParametersAgainstCollection(
                inputData,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                false);
        }
        #endregion ControlType + Class
    }
}
