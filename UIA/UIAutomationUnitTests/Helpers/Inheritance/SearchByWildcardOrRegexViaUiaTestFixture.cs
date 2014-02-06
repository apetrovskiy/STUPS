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
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchByWildcardOrRegexViaUiaTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class SearchByWildcardOrRegexViaUiaTestFixture
    {
        public SearchByWildcardOrRegexViaUiaTestFixture()
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
            ControlType controlType,
            string name,
            string automationId,
            string className,
            string txtValue,
            IEnumerable<IUiElement> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            // 20140205
//            string controlTypeString = string.Empty;
//            if (null != controlType) {
//                controlTypeString = controlType.ProgrammaticName.Substring(12);
//            }
            
            // 20140205
//            ControlType[] controlTypes =
//                new[] { controlType };
            
            // 20140205
//            GetControlCmdletBase cmdlet =
//                FakeFactory.Get_GetControlCmdletBase(controlTypes, name, automationId, className, txtValue);
            
            // 20140205
            var data =
                new ControlSearcherData {
                // InputObject = new IUiElement[] {},
                // ControlType = FakeFactory.ConvertControlTypeToStringArray(controlTypes),
                ControlType = FakeFactory.ConvertControlTypeToStringArray(new[] { controlType }),
                // Name = name,
                Name = (string.IsNullOrEmpty(name) ? string.Empty : name),
                // AutomationId = automationId,
                AutomationId = (string.IsNullOrEmpty(automationId) ? string.Empty : automationId),
                // Class = className,
                Class = (string.IsNullOrEmpty(className) ? string.Empty : className),
                // Value = txtValue// ,
                Value = (string.IsNullOrEmpty(txtValue) ? string.Empty : txtValue)
                // SearchCriteria = new Hashtable[] {}
            };
            
//foreach (string cType in data.ControlType) {
//    Console.WriteLine("control type = {0}", cType);
//}
//Console.WriteLine("name = {0}", data.Name);
//Console.WriteLine("auid = {0}", data.AutomationId);
//Console.WriteLine("class = {0}", data.Class);
//Console.WriteLine("value = {0}", data.Value);
            
            // 20140205
            /*
            Condition condition =
                ControlSearcher.GetWildcardSearchCondition(
                    new ControlSearcherData {
                        ControlType = FakeFactory.ConvertControlTypeToStringArray(controlTypes),
                        Name = name,
                        AutomationId = automationId,
                        Class = className,
                        Value = txtValue
                    });
            */
            
            Condition condition =
                ControlSearcher.GetWildcardSearchCondition(data);
            
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            // Act
            /*
            var data =
                new ControlSearcherData {
                InputObject = cmdlet.InputObject,
                Name = cmdlet.Name,
                AutomationId = cmdlet.AutomationId,
                Class = cmdlet.Class,
                Value = cmdlet.Value,
                ControlType = cmdlet.ControlType,
                SearchCriteria = cmdlet.SearchCriteria
            };
            */
            
            // 20140205
            // List<IUiElement> resultList = RealCodeCaller.GetResultList_ViaWildcards(cmdlet, element, condition);
            data.InputObject = new IUiElement[] {};
            // data.SearchCriteria = new Hashtable[] {};
            List<IUiElement> resultList = RealCodeCaller.GetResultList_ViaWildcards(data, element, condition);
            
Console.WriteLine("TestParametersAgainstCollection: 0006");
            
            // Assert
            const WildcardOptions options = WildcardOptions.IgnoreCase;
            WildcardPattern namePattern = new WildcardPattern(name, options);
            WildcardPattern automationIdPattern = new WildcardPattern(automationId, options);
            WildcardPattern classNamePattern = new WildcardPattern(className, options);
            WildcardPattern txtValuePattern = new WildcardPattern(txtValue, options);
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Xunit.Assert.Equal(expectedNumberOfElements, resultList.Count);
            
            if (!string.IsNullOrEmpty(name)) {
                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => namePattern.IsMatch(x.Current.Name));
                resultList.All(x => namePattern.IsMatch(x.Current.Name));
            }
            if (!string.IsNullOrEmpty(automationId)) {
                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => automationIdPattern.IsMatch(x.Current.AutomationId));
                resultList.All(x => automationIdPattern.IsMatch(x.Current.AutomationId));
            }
            if (!string.IsNullOrEmpty(className)) {
                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => classNamePattern.IsMatch(x.Current.ClassName));
                resultList.All(x => classNamePattern.IsMatch(x.Current.ClassName));
            }
            if (null != controlType) {
                MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => x.Current.ControlType == controlType);
                resultList.All(x => x.Current.ControlType == controlType);
            }
            if (string.IsNullOrEmpty(txtValue)) return;
            
            MbUnit.Framework.Assert.ForAll(
                resultList
                    .Cast<IUiElement>()
                    .ToList<IUiElement>(), x =>
                    {
                        IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
                        return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
                    });
                
            resultList.All(
                x => {
                         IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
                         return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
                });
            /*
            if (!string.IsNullOrEmpty(txtValue)) {
                MbUnit.Framework.Assert.ForAll(
                    resultList
                    .Cast<IUiElement>()
                    .ToList<IUiElement>(), x =>
                    {
                        IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
                        return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
                    });
                
                resultList.All(
                    x => {
                        IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
                        return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
                    });
            }
            */
        }
        #endregion helpers
        
        #region no parameters
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
