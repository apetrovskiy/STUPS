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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    using UIAutomation.Commands;
    using UIAutomation.Helpers.Commands;
    
    /// <summary>
    /// Description of WaitUIAControlStateCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class WaitUIAControlStateCommandTestFixture
    {
        public WaitUIAControlStateCommandTestFixture()
        {
            FakeFactory.Init();
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
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
            Xunit.Assert.Equal<bool>(
                expectedResult,
                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
        #endregion helpers
        
        #region no parameters
        [Test]// [Fact]
        [Ignore("this is unclear yet until the input validator is here")]
        public void Get0_NoParam_AllInputNull()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                null,
                null,
                false);
        }
        
        [Test][Fact]
        public void Get0_NoParam_HashtablesNull()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                null,
                new UiElement[] {},
                false);
        }
        
        [Test]// [Fact]
        [Ignore("this is unclear yet until the input validator is here")]
        public void Get0_NoParam_ElementsNull()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                new Hashtable[] {},
                null,
                false);
        }
        
        [Test][Fact]
        public void Get0_NoParam()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                new Hashtable[] {},
                new UiElement[] {},
                false);
        }
        
        [Test][Fact]
        public void Get3of3_NoParam()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
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
        [Test][Fact]
        public void Get0_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht =
                new Hashtable();
            ht.Add("controlType", "button");
            ht.Add("class", className);
            Hashtable[] inputData =
                new[] { ht };
            TestParametersAgainstCollection(
                inputData,
                new UiElement[] {},
                false);
        }
        
        [Test][Fact]
        public void Get0of4_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht =
                new Hashtable();
            ht.Add("controlType", "button");
            ht.Add("class", className);
            Hashtable[] inputData =
                new[] { ht };
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
        
        [Test][Fact]
        public void Get1of4_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht =
                new Hashtable();
            ht.Add("controlType", "button");
            ht.Add("class", className);
            Hashtable[] inputData =
                new[] { ht };
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
        
        [Test][Fact]
        public void Get2of4_byControlTypeClass_X2()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht1 =
                new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            Hashtable ht2 =
                new Hashtable();
            ht2.Add("controlType", "headeritem");
            Hashtable[] inputData =
                new[] { ht1, ht2 };
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
        
        [Test][Fact]
        public void Get0of4_byControlTypeClass_X2()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht1 =
                new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            Hashtable ht2 =
                new Hashtable();
            ht2.Add("controlType", "menu");
            Hashtable[] inputData =
                new[] { ht1, ht2 };
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
        
        [Test][Fact]
        public void Get3of4_byControlTypeClass_X5()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht1 =
                new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            Hashtable ht2 =
                new Hashtable();
            ht2.Add("controlType", "headeritem");
            Hashtable ht3 =
                new Hashtable();
            ht3.Add("controlType", "button");
            ht3.Add("class", "cl03");
            Hashtable ht4 =
                new Hashtable();
            ht4.Add("controlType", "button");
            ht4.Add("class", className);
            Hashtable ht5 =
                new Hashtable();
            ht5.Add("controlType", "headeritem");
            Hashtable[] inputData =
                new[] { ht1, ht2, ht3, ht4, ht5 };
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
        
        [Test][Fact]
        public void Get0of4_byControlTypeClass_X5()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            
            Hashtable ht1 =
                new Hashtable();
            ht1.Add("controlType", "button");
            ht1.Add("class", className);
            Hashtable ht2 =
                new Hashtable();
            ht2.Add("controlType", "menu");
            Hashtable ht3 =
                new Hashtable();
            ht3.Add("controlType", "button");
            ht3.Add("class", "cl03");
            Hashtable ht4 =
                new Hashtable();
            ht4.Add("controlType", "button");
            ht4.Add("class", className);
            Hashtable ht5 =
                new Hashtable();
            ht5.Add("controlType", "headeritem");
            Hashtable[] inputData =
                new[] { ht1, ht2, ht3, ht4, ht5 };
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
