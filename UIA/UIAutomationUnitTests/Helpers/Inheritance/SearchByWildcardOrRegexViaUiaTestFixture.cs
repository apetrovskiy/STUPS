/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2013
 * Time: 10:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchByWildcardOrRegexViaUiaTestFixture.
    /// </summary>
    [TestFixture]
    public class SearchByWildcardOrRegexViaUiaTestFixture
    {
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
            ControlType controlType,
            string name,
            string automationId,
            string className,
            string txtValue,
            IEnumerable<IUiElement> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            string controlTypeString = string.Empty;
            if (null != controlType) {
                controlTypeString = controlType.ProgrammaticName.Substring(12);
            }
            
            ControlType[] controlTypes =
                new[] { controlType };
            
            GetControlCmdletBase cmdlet =
                // FakeFactory.Get_GetControlCmdletBase(new ControlType[] { controlType }, name, automationId, className, txtValue);
                FakeFactory.Get_GetControlCmdletBase(controlTypes, name, automationId, className, txtValue);
            
            Condition condition =
                cmdlet.GetWildcardSearchCondition(cmdlet);
            
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            // Act
            List<IUiElement> resultList = RealCodeCaller.GetResultList_ViaWildcards(cmdlet, element, condition);
            
            // Assert
            WildcardOptions options = WildcardOptions.IgnoreCase;
            WildcardPattern namePatern = new WildcardPattern(name, options);
            WildcardPattern automationIdPatern = new WildcardPattern(automationId, options);
            WildcardPattern classNamePatern = new WildcardPattern(className, options);
            WildcardPattern txtValuePatern = new WildcardPattern(txtValue, options);
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(name)) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => namePatern.IsMatch(x.Current.Name));
            }
            if (!string.IsNullOrEmpty(automationId)) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => automationIdPatern.IsMatch(x.Current.AutomationId));
            }
            if (!string.IsNullOrEmpty(className)) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => classNamePatern.IsMatch(x.Current.ClassName));
            }
            if (null != controlType) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => x.Current.ControlType == controlType);
            }
            if (!string.IsNullOrEmpty(txtValue)) {
                Assert.ForAll(
                    resultList
                    .Cast<IUiElement>()
                    .ToList<IUiElement>(), x =>
                    {
                        IMySuperValuePattern valuePattern = x.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern) as IMySuperValuePattern;
                        return valuePattern != null && txtValuePatern.IsMatch(valuePattern.Current.Value);
                    });
            }
        }
        #endregion helpers
        
        #region no parameters
        [Test]
        public void Get0_NoParam()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get3of3_NoParam()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.TabItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion no parameters
        
        #region ControlType
        [Test]
        public void Get0_byControlType()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byControlType()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Calendar, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.ComboBox, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byControlType()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlType()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ControlType
        
        #region Name
        [Test]
        public void Get0_byName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "name matches", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "Name matches", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, "name matcheZ", string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion Name
        
        #region AutomationId
        [Test]
        public void Get0_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "au02", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, "automationId is good", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, "automationId is good", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, "automationId is always cool", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, "AUautomationId woo", string.Empty, string.Empty)
                },
                3);
        }
        #endregion AutomationId
        
        #region Class
        [Test]
        public void Get0_byClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "first class", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "second class", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "first class", string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, className, string.Empty)
                },
                3);
        }
        #endregion Class
        
        #region Value
        [Test]
        public void Get0_byValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value2"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
                },
                0);
        }
        
        [Test]
        public void Get1of3_byValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
                },
                1);
        }
        
        [Test]
        public void Get3of3_byValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue)
                },
                3);
        }
        #endregion Value
        
        #region ControlType + Name
        [Test]
        public void Get0_byControlTypeName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byControlTypeName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, name, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byControlTypeName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, name, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlTypeName()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, "NNName matches", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matcheZ", string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ControlType + Name
        
        #region ControlType + AutomationId
        [Test]
        public void Get0_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, "au02", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, "au03", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, automationId, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, "au03", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, automationId, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, automationId, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ControlType + AutomationId
        
        #region ControlType + Class
        [Test]
        public void Get0_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl02", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, className, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlTypeClass()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, className, string.Empty)
                },
                3);
        }
        #endregion ControlType + Class
        
        #region ControlType + Value
        [Test]
        public void Get0_byControlTypeValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byControlTypeValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, "first value"),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, "second value"),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, "third value"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.HeaderItem, string.Empty, string.Empty, string.Empty, txtValue)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byControlTypeValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, "value 01"),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, "value 03"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, txtValue)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlTypeValue()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, txtValue)
                },
                3);
        }
        #endregion ControlType + Value
        
        #region Name + AutomationId
        [Test]
        public void Get0_byNameAutomationId()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameAutomationId()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "second name", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, "name matches", "fourth automationId", string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameAutomationId()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "ABCame matches", "third automationId", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, "name matchez", string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameAutomationId()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "*ame matches", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matcheR", automationId, string.Empty, string.Empty)
                },
                3);
        }
        #endregion Name + AutomationId
        
        #region Name + Class
        [Test]
        public void Get0_byNameClass()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameClass()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "name matches", string.Empty, "second className", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, className, string.Empty, "name matches", string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameClass()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, "name matches!!!", string.Empty, "fourth className", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameClass()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name_matches", string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matche111", string.Empty, className, string.Empty)
                },
                3);
        }
        #endregion Name + Class
        
        #region Name + Value
        [Test]
        public void Get0_byNameValue()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameValue()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "name matches", string.Empty, string.Empty," second value"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, txtValue, string.Empty, string.Empty, "name matches")
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameValue()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, "third value"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, "name matchES", string.Empty, "fourth className", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameValue()
        {
            const string name = "*ame??atche*";
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "///ame matches", string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matche///", string.Empty, string.Empty, txtValue)
                },
                3);
        }
        #endregion Name + Value
        
        #region AutomationId + Class
        [Test]
        public void Get0_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "other auId", className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, automationId, "second className", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, className, automationId, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "other auId", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, string.Empty, automationId, "fourth className", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "*au*oo*";
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, automationId, className, string.Empty)
                },
                3);
        }
        #endregion AutomationId + Class
        
        #region Name + AutomationId + Class + Value + ControlType
        [Test]
        public void Get0_byNameAutomationIdClassValueControlType()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            const string className = "yyy";
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new UiElement[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameAutomationIdClassValueControlType()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            const string className = "yyy";
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, "name matches", automationId, "second className", txtValue),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, automationId, className, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, txtValue, className, automationId, "name matches")
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameAutomationIdClassValueControlType()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            const string className = "yyy";
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, "other auId", className, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", automationId, className, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, "name matches?", automationId, className, txtValue)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameAutomationIdClassValueControlType()
        {
            const string name = "*ame??atche*";
            const string automationId = "*au*oo*";
            const string className = "yyy";
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new [] {
                        FakeFactory.GetAutomationElementExpected(controlType, "name matches", automationId, className, txtValue),
                        FakeFactory.GetAutomationElementExpected(controlType, "name+matches", automationId, className, txtValue),
                        FakeFactory.GetAutomationElementExpected(controlType, "_name matches_", automationId, className, txtValue)
                },
                3);
        }
        #endregion AutomationId + Class
    }
}
