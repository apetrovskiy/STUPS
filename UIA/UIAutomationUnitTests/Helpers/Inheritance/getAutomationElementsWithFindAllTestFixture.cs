/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/17/2013
 * Time: 11:14 PM
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
    /// Description of getAutomationElementsWithFindAllTestFixture.
    /// </summary>
    [TestFixture]
    public class GetAutomationElementsWithFindAllTestFixture
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
//        private ArrayList GetResultArrayList(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, Condition condition)
//        {
//            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
//            
//            ArrayList resultList =
//                cmdletDerived.GetAutomationElementsWithFindAll(
//                    element,
//                    cmdlet.Name,
//                    cmdlet.AutomationId,
//                    cmdlet.Class,
//                    cmdlet.Value,
//                    cmdlet.ControlType,
//                    condition,
//                    false,
//                    false,
//                    false,
//                    true);
//            
//            return resultList;
//        }
        
        private void TestParametersAgainstCollection(
            ControlType controlType,
            string name,
            string automationId,
            string className,
            string txtValue,
            IEnumerable<IMySuperWrapper> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            string controlTypeString = string.Empty;
            if (null != controlType) {
                controlTypeString = controlType.ProgrammaticName.Substring(12);
            }
            
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(controlType, name, automationId, className, txtValue);
            // 20131128
            //AndCondition condition =
            //    cmdlet.GetControlConditionsForWildcardSearch(cmdlet, controlTypeString, false, true) as AndCondition;
            // 20131129
            // AndCondition condition =
            //     cmdlet.GetControlConditionsForWildcardSearch(cmdlet, controlTypeString, false);
            Condition condition =
                cmdlet.GetWildcardSearchCondition(cmdlet);
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            // Act
            //ArrayList resultList = GetResultArrayList(cmdlet, element, condition);
            ArrayList resultList = RealCodeCaller.GetResultArrayList_ViaWildcards(cmdlet, element, condition);
            
            // Assert
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(name)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
            }
            if (!string.IsNullOrEmpty(automationId)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automationId);
            }
            if (!string.IsNullOrEmpty(className)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
            }
            if (null != controlType) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == controlType);
            }
            if (!string.IsNullOrEmpty(txtValue)) {
                Assert.ForAll(
                    resultList
                    .Cast<IMySuperWrapper>()
                    .ToList<IMySuperWrapper>(), x =>
                    {
                        IMySuperValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern;
                        return valuePattern != null && valuePattern.Current.Value == txtValue;
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
                new MySuperWrapper[] {},
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.TabItem, string.Empty, string.Empty, string.Empty, string.Empty)
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
                new MySuperWrapper[] {},
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
                    FakeFactory.GetAutomationElement(ControlType.Calendar, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.ComboBox, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, string.Empty, string.Empty, string.Empty, string.Empty)
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
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ControlType
        
        #region Name
        [Test]
        public void Get0_byName()
        {
            const string name = "aaa";
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
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byName()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byName()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Image, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byName()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Hyperlink, name, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion Name
        
        #region AutomationId
        [Test]
        public void Get0_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of3_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au02", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of3_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty)
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
                new MySuperWrapper[] {},
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "first class", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "second class", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "first class", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty)
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
                new MySuperWrapper[] {},
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value2"),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue)
                },
                3);
        }
        #endregion Value
        
        #region ControlType + Name
        [Test]
        public void Get0_byControlTypeName()
        {
            const string name = "aaa";
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
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byControlTypeName()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(controlType, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, name, string.Empty, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byControlTypeName()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(controlType, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, name, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlTypeName()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(controlType, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, name, string.Empty, string.Empty, string.Empty)
                },
                3);
        }
        #endregion ControlType + Name
        
        #region ControlType + AutomationId
        [Test]
        public void Get0_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, "au02", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, "au03", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Custom, string.Empty, automationId, string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, "au01", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, "au03", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, automationId, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byControlTypeAutomationId()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, automationId, string.Empty, string.Empty)
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
                new MySuperWrapper[] {},
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, "cl02", string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, "cl01", string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, "cl03", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Document, string.Empty, string.Empty, className, string.Empty)
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, className, string.Empty)
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
                new MySuperWrapper[] {},
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, "first value"),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, "second value"),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, "third value"),
                    FakeFactory.GetAutomationElement(ControlType.HeaderItem, string.Empty, string.Empty, string.Empty, txtValue)
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, "value 01"),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, "value 03"),
                    FakeFactory.GetAutomationElement(ControlType.Document, string.Empty, string.Empty, string.Empty, txtValue)
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, string.Empty, txtValue)
                },
                3);
        }
        #endregion ControlType + Value
        
        #region Name + AutomationId
        [Test]
        public void Get0_byNameAutomationId()
        {
            const string name = "aaa";
            const string automationId = "zzz";
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameAutomationId()
        {
            const string name = "aaa";
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, "second name", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, name, "fourth automationId", string.Empty, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameAutomationId()
        {
            const string name = "aaa";
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, "third automationId", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, name, string.Empty, string.Empty, string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameAutomationId()
        {
            const string name = "aaa";
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, name, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, automationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, automationId, string.Empty, string.Empty)
                },
                3);
        }
        #endregion Name + AutomationId
        
        #region Name + Class
        [Test]
        public void Get0_byNameClass()
        {
            const string name = "aaa";
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
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameClass()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, "second className", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, className, string.Empty, name, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameClass()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, name, string.Empty, "fourth className", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameClass()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, className, string.Empty)
                },
                3);
        }
        #endregion Name + Class
        
        #region Name + Value
        [Test]
        public void Get0_byNameValue()
        {
            const string name = "aaa";
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
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameValue()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty," second value"),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, txtValue, string.Empty, string.Empty, name)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameValue()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, "third value"),
                    FakeFactory.GetAutomationElement(ControlType.Group, name, string.Empty, "fourth className", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameValue()
        {
            const string name = "aaa";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, txtValue)
                },
                3);
        }
        #endregion Name + Value
        
        #region AutomationId + Class
        [Test]
        public void Get0_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "zzz";
            const string className = "yyy";
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "other auId", className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, "second className", string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, className, automationId, string.Empty)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "other auId", string.Empty, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, string.Empty, automationId, "fourth className", string.Empty)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byAutomationIdClass()
        {
            string name = string.Empty;
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, className, string.Empty)
                },
                3);
        }
        #endregion AutomationId + Class
        
        #region Name + AutomationId + Class + Value + ControlType
        [Test]
        public void Get0_byNameAutomationIdClassValueControlType()
        {
            const string name = "aaa";
            const string automationId = "zzz";
            const string className = "yyy";
            const string txtValue = "xxx";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                txtValue,
                new MySuperWrapper[] {},
                0);
        }
        
        [Test]
        public void Get0of4_byNameAutomationIdClassValueControlType()
        {
            const string name = "aaa";
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, automationId, className, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, name, automationId, "second className", txtValue),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, automationId, className, txtValue),
                    FakeFactory.GetAutomationElement(ControlType.DataGrid, txtValue, className, automationId, name)
                },
                0);
        }
        
        [Test]
        public void Get1of4_byNameAutomationIdClassValueControlType()
        {
            const string name = "aaa";
            const string automationId = "zzz";
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
                    FakeFactory.GetAutomationElement(controlType, string.Empty, "other auId", className, string.Empty),
                    FakeFactory.GetAutomationElement(controlType, name, automationId, className, txtValue),
                    FakeFactory.GetAutomationElement(controlType, string.Empty, string.Empty, className, string.Empty),
                    FakeFactory.GetAutomationElement(ControlType.Group, name, automationId, className, txtValue)
                },
                1);
        }
        
        [Test]
        public void Get3of3_byNameAutomationIdClassValueControlType()
        {
            const string name = "aaa";
            const string automationId = "zzz";
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
                        FakeFactory.GetAutomationElement(controlType, name, automationId, className, txtValue),
                        FakeFactory.GetAutomationElement(controlType, name, automationId, className, txtValue),
                        FakeFactory.GetAutomationElement(controlType, name, automationId, className, txtValue)
                },
                3);
        }
        #endregion AutomationId + Class
    }
}
