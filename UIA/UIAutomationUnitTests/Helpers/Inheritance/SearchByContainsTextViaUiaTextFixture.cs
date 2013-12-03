/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2013
 * Time: 2:49 AM
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
    
    /// <summary>
    /// Description of SearchByExactConditionsViaUiaTestFixture.
    /// </summary>
    [TestFixture]
    public class SearchByContainsTextViaUiaTextFixture
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
            string searchString,
            IEnumerable<IMySuperWrapper> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            string controlTypeString = string.Empty;
            if (null != controlType) {
                controlTypeString = controlType.ProgrammaticName.Substring(12);
            }
            
            GetControlCmdletBase cmdlet =
                FakeFactory.Get_GetControlCmdletBase(controlType, searchString);
            Condition condition =
                cmdlet.GetTextSearchCondition(searchString, new string[]{ controlTypeString }, false);
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            // Act
            List<IMySuperWrapper> resultList = RealCodeCaller.GetResultList_TextSearch(cmdlet, element, condition);
            
            // Assert
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(searchString)) {
                Assert.ForAll(
                    resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(),
                    x => x.Current.Name == searchString || x.Current.AutomationId == searchString || x.Current.ClassName == searchString ||
                    (null != (x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern) ? (x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value == searchString : false));
            }
//            if (null != controlType) {
//                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == controlType);
//            }
        }
        #endregion helpers
        
        #region no parameters (impossible)
        [Test]
        public void Get0_NoParam()
        {
            string searchString = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of3_NoParam()
        {
            string searchString = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.TabItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get0of3_NoParam_2()
        {
            string searchString = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, "automation id", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.TabItem, string.Empty, string.Empty, "className", "value")
                },
                0);
        }
        #endregion no parameters (impossible)
        
        #region ContainsText + ControlType
        [Test]
        public void Get0_byContainsTextControlType()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byContainsTextControlType_None()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Calendar, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.ComboBox, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get0of3_byContainsTextControlType_OneControlType()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]//
        public void Get0of3_byContainsTextControlType_ThreeControlType()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_Name()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_AutomationId()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_Class()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_Value()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_Name()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, searchString, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_NameAutomationIdClass()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_AutomationIdClassValue()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, searchString)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_AutomationId()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, searchString, string.Empty, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_Class()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_ClassValue()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, searchString, searchString),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, searchString)
                },
                3);
        }
        #endregion ContainsText + ControlType
        
        #region ContainsText
        [Test]
        public void Get0_byContainsText()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new MySuperWrapper[] {},
                0);
        }
        #endregion ContainsText
        
        #region ContainsText vs Name
        [Test]
        public void Get0of3_byContainsText_Name()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsText_Name()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsText_Name()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, searchString, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ContainsText vs Name
        
        #region ContainsText vs AutomationId
        [Test]
        public void Get0of3_byContainsText_AutomationId()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "other id", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, "second id", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, string.Empty, "third id", string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsText_AutomationId()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, string.Empty, "other id", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "third id", string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsText_AutomationId()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, string.Empty, searchString, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ContainsText vs AutomationId
        
        #region ContainsText vs Class
        [Test]
        public void Get0of3_byContainsText_Class()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "other class", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, string.Empty, "second class", string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, string.Empty, string.Empty, "third class", string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsText_Class()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, string.Empty, string.Empty, "other class", string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsText_Class()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, string.Empty, string.Empty, searchString, string.Empty)
                },
                3);
        }
        #endregion ContainsText vs Class
        
        #region ContainsText vs Value
        [Test]
        public void Get0of3_byContainsText_Value()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "other value"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, string.Empty, string.Empty, "second value"),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, string.Empty, string.Empty, string.Empty, "third value")
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsText_Value()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, string.Empty, string.Empty, string.Empty, "other value"),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "third value")
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsText_Value()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, string.Empty, string.Empty, string.Empty, searchString)
                },
                3);
        }
        #endregion ContainsText vs Value
        
        #region ContainsText vs Mix
        [Test]
        public void Get0of3_byContainsText_NameAutomationIdClass()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, string.Empty, "second automation Id", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, string.Empty, string.Empty, "third class", string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsText_NameAutomationIdClass()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsText_AutomationIdClassValue()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, string.Empty, string.Empty, string.Empty, searchString)
                },
                3);
        }
        #endregion ContainsText vs Mix
    }
}
