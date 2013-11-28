using System.Collections;
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
    public class SearchByExactConditionsViaUiaTestFixture
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
        /*
        internal void SearchByExactConditionsViaUia(
            GetControlCmdletBase cmdlet,
            IMySuperWrapper inputObject,
            AndCondition conditions,
            // 20131126
            ArrayList listOfColllectedResults)
        */
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
            
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(controlType, searchString);
            // 20131128
            //AndCondition condition =
            //    cmdlet.GetControlConditionsForWildcardSearch(cmdlet, controlTypeString, false, false) as AndCondition;
            OrCondition condition =
                cmdlet.GetControlConditionsForExactSearch(cmdlet, controlTypeString, false, false) as OrCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
//            conditionsForTextSearch =
//                        GetControlConditions(
//                            tempCmdlet,
//                            tempCmdlet.ControlType,
//                            cmdlet.CaseSensitive,
//                            false) as AndCondition;
            
            // Act
            ArrayList resultList = RealCodeCaller.GetResultArrayList_ExactSearch(cmdlet, element, condition);
            
            // Assert
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(searchString)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == searchString);
            }
            if (!string.IsNullOrEmpty(searchString)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == searchString);
            }
            if (!string.IsNullOrEmpty(searchString)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == searchString);
            }
            if (null != controlType) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == controlType);
            }
            if (!string.IsNullOrEmpty(searchString)) {
                Assert.ForAll(
                    resultList
                    .Cast<IMySuperWrapper>()
                    .ToList<IMySuperWrapper>(), x =>
                    {
                        IMySuperValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern;
                        return valuePattern != null && valuePattern.Current.Value == searchString;
                    });
            }
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.TabItem, string.Empty, string.Empty, string.Empty, string.Empty)
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, string.Empty, "automation id", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.TabItem, string.Empty, string.Empty, "className", "value")
                },
                0);
        }
        #endregion no parameters (impossible)
        
        #region ControlType
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
        public void Get0of3_byContainsTextControlType()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.Calendar, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.ComboBox, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get0of3_byContainsTextControlType_2()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]//
        public void Get0of3_byContainsTextControlType_3()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_1()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_2()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_3()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get1of3_byContainsTextControlType_4()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_1()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, searchString, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_2()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_3()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, searchString)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_4()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, searchString, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, searchString, string.Empty, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_5()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, string.Empty)
                },
                3);
        }
        
        [Test]
        public void Get3of3_byContainsTextControlType_6()
        {
            string searchString = "str";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, searchString),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, searchString, searchString),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, searchString)
                },
                3);
        }
        #endregion ControlType
        
        #region Contains
        [Test]
        public void Get0_byName()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byName()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byName()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Image, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byName()
        {
            const string searchString = "str";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                searchString,
                new [] {
                    FakeFactory.GetAutomationElement(ControlType.Button, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, searchString, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Hyperlink, searchString, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion Contains
    }
}
