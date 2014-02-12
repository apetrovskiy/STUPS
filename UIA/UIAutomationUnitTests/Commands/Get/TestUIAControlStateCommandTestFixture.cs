/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/13/2014
 * Time: 2:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Get
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
    /// Description of TestUIAControlStateCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class TestUIAControlStateCommandTestFixture
    {
        public TestUIAControlStateCommandTestFixture()
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
                new TestUiaControlStateCommand {
                SearchCriteria = inputData,
                InputObject = new[] { element }
            };
            
            // Act
            var command = new TestControlStateCommand(cmdlet);
            command.Execute();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual<bool>(
                expectedResult,
                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
            Xunit.Assert.Equal<bool>(
                expectedResult,
                (bool)PSTestLib.UnitTestOutput.LastOutput[0]);
            
//            // Assert
//            const WildcardOptions options = WildcardOptions.IgnoreCase;
//            WildcardPattern namePattern = new WildcardPattern(name, options);
//            WildcardPattern automationIdPattern = new WildcardPattern(automationId, options);
//            WildcardPattern classNamePattern = new WildcardPattern(className, options);
//            WildcardPattern txtValuePattern = new WildcardPattern(txtValue, options);
//            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
//            Xunit.Assert.Equal(expectedNumberOfElements, resultList.Count);
//            
//            if (!string.IsNullOrEmpty(name)) {
//                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => namePattern.IsMatch(x.Current.Name));
//                resultList.All(x => namePattern.IsMatch(x.Current.Name));
//            }
//            if (!string.IsNullOrEmpty(automationId)) {
//                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => automationIdPattern.IsMatch(x.Current.AutomationId));
//                resultList.All(x => automationIdPattern.IsMatch(x.Current.AutomationId));
//            }
//            if (!string.IsNullOrEmpty(className)) {
//                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => classNamePattern.IsMatch(x.Current.ClassName));
//                resultList.All(x => classNamePattern.IsMatch(x.Current.ClassName));
//            }
//            if (null != controlType) {
//                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => x.Current.ControlType == controlType);
//                resultList.All(x => x.Current.ControlType == controlType);
//            }
//            if (string.IsNullOrEmpty(txtValue)) return;
//            
//            MbUnit.Framework.Assert.ForAll(
//                resultList
//                    .Cast<IUiElement>()
//                    .ToList<IUiElement>(), x =>
//                    {
//                        IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
//                        return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
//                    });
//                
//            resultList.All(
//                x => {
//                         IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
//                         return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
//                });
        }
        #endregion helpers
        
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
        #endregion ControlType + Class
    }
}
