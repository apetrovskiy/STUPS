/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/18/2013
 * Time: 1:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Xunit;
    using UIAutomation;

    /// <summary>
    /// Description of ReturnOnlyRightElementsTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ReturnOnlyRightElementsTestFixture
    {
        public ReturnOnlyRightElementsTestFixture()
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
            ControlType controlType,
            string name,
            string automationId,
            string className,
            string txtValue,
            IEnumerable<IUiElement> collection,
            UsualWildcardRegex selector,
            int expectedNumberOfElements)
        {
            // Arrange
            ControlType[] controlTypes =
                new[] { controlType };
            
            GetControlCmdletBase cmdlet =
                FakeFactory.Get_GetControlCmdletBase(controlTypes, name, automationId, className, txtValue);
            
            var data =
                new ControlSearcherData {
                ControlType = controlTypes.ConvertControlTypeToStringArray(),
                Name = name,
                AutomationId = automationId,
                Class = className,
                Value = txtValue
            };
            
            Condition condition;
            bool useWildcardOrRegex = true;
            switch (selector) {
                case UsualWildcardRegex.Wildcard:
                    condition =
                        ControlSearcher.GetWildcardSearchCondition(
                            data);
                    useWildcardOrRegex = true;
                    break;
                case UsualWildcardRegex.Regex:
                    condition =
                        ControlSearcher.GetWildcardSearchCondition(
                            data);
                    useWildcardOrRegex = false;
                    break;
            }
            
            // Act
            var resultList = RealCodeCaller.GetResultList_ReturnOnlyRightElements(collection.ToArray(), data, useWildcardOrRegex);
            
            // Assert
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Assert.Equal(expectedNumberOfElements, resultList.Count);
            string[] controlTypeNames;
            switch (selector) {
                case UsualWildcardRegex.Wildcard:
                    const WildcardOptions options = WildcardOptions.IgnoreCase;
                    // 20140312
//                    WildcardPattern namePattern = new WildcardPattern(name, options);
//                    WildcardPattern automationIdPattern = new WildcardPattern(automationId, options);
//                    WildcardPattern classNamePattern = new WildcardPattern(className, options);
//                    WildcardPattern txtValuePattern = new WildcardPattern(txtValue, options);
                    var namePattern = new WildcardPattern(name, options);
                    var automationIdPattern = new WildcardPattern(automationId, options);
                    var classNamePattern = new WildcardPattern(className, options);
                    var txtValuePattern = new WildcardPattern(txtValue, options);
                    
                    // 20140312
//                    if (!string.IsNullOrEmpty(name)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => namePattern.IsMatch(x.Current.Name));
//                        resultList.All(x => namePattern.IsMatch(x.Current.Name));
//                    }
//                    if (!string.IsNullOrEmpty(automationId)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => automationIdPattern.IsMatch(x.Current.AutomationId));
//                        resultList.All(x => automationIdPattern.IsMatch(x.Current.AutomationId));
//                    }
//                    if (!string.IsNullOrEmpty(className)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => classNamePattern.IsMatch(x.Current.ClassName));
//                        resultList.All(x => classNamePattern.IsMatch(x.Current.ClassName));
//                    }
//                    controlTypeNames =
//                        controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
//                    if (null != controlType) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                        resultList.All(x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                    }
                    if (!string.IsNullOrEmpty(name)) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => namePattern.IsMatch(x.GetCurrent().Name));
                        resultList.All(x => namePattern.IsMatch(x.GetCurrent().Name));
                    }
                    if (!string.IsNullOrEmpty(automationId)) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => automationIdPattern.IsMatch(x.GetCurrent().AutomationId));
                        resultList.All(x => automationIdPattern.IsMatch(x.GetCurrent().AutomationId));
                    }
                    if (!string.IsNullOrEmpty(className)) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => classNamePattern.IsMatch(x.GetCurrent().ClassName));
                        resultList.All(x => classNamePattern.IsMatch(x.GetCurrent().ClassName));
                    }
                    controlTypeNames =
                        controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
                    if (null != controlType) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.GetCurrent().ControlType.ProgrammaticName.Substring(12)));
                        resultList.All(x => controlTypeNames.Contains(x.GetCurrent().ControlType.ProgrammaticName.Substring(12)));
                    }
                    
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
                    break;
                case UsualWildcardRegex.Regex:
                    // 20140312
//                    if (!string.IsNullOrEmpty(name)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.Current.Name, name));
//                        resultList.All(x => Regex.IsMatch(x.Current.Name, name));
//                    }
//                    if (!string.IsNullOrEmpty(automationId)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.Current.AutomationId, automationId));
//                        resultList.All(x => Regex.IsMatch(x.Current.AutomationId, automationId));
//                    }
//                    if (!string.IsNullOrEmpty(className)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.Current.ClassName, className));
//                        resultList.All(x => Regex.IsMatch(x.Current.ClassName, className));
//                    }
//                    controlTypeNames =
//                        controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
//                    if (null != controlType) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                        resultList.All(x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                    }
                    if (!string.IsNullOrEmpty(name)) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.GetCurrent().Name, name));
                        resultList.All(x => Regex.IsMatch(x.GetCurrent().Name, name));
                    }
                    if (!string.IsNullOrEmpty(automationId)) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.GetCurrent().AutomationId, automationId));
                        resultList.All(x => Regex.IsMatch(x.GetCurrent().AutomationId, automationId));
                    }
                    if (!string.IsNullOrEmpty(className)) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.GetCurrent().ClassName, className));
                        resultList.All(x => Regex.IsMatch(x.GetCurrent().ClassName, className));
                    }
                    controlTypeNames =
                        controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
                    if (null != controlType) {
                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.GetCurrent().ControlType.ProgrammaticName.Substring(12)));
                        resultList.All(x => controlTypeNames.Contains(x.GetCurrent().ControlType.ProgrammaticName.Substring(12)));
                    }
                    
                    if (!string.IsNullOrEmpty(txtValue)) {
                        MbUnit.Framework.Assert.ForAll(
                            resultList
                            .Cast<IUiElement>()
                            .ToList<IUiElement>(), x =>
                            {
                                IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
                                return valuePattern != null && Regex.IsMatch(valuePattern.Current.Value, txtValue);
                            });
                        Assert.True(
                            resultList.All(
                                x => {
                                    IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
                                    return valuePattern != null && Regex.IsMatch(valuePattern.Current.Value, txtValue);
                                })
                           );
                    }
                    break;
            }
        }
        #endregion helpers
        
        #region for starters
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void NoResults_NullInput()
        {
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            var controlSearcherData =
                new ControlSearcherData {
                Name = string.Empty,
                AutomationId = string.Empty,
                Class = string.Empty,
                Value = string.Empty,
                ControlType = new string[] {}
            };
            
            List<IUiElement> resultList =
                WindowSearcher.ReturnOnlyRightElements(
                    null,
                    controlSearcherData,
                    false,
                    true);
            
            MbUnit.Framework.Assert.AreEqual(0, resultList.Count);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void NoResults_ZeroInput()
        {
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            var controlSearcherData =
                new ControlSearcherData {
                Name = string.Empty,
                AutomationId = string.Empty,
                Class = string.Empty,
                Value = string.Empty,
                ControlType = new string[] {}
            };
            
            List<IUiElement> resultList =
                WindowSearcher.ReturnOnlyRightElements(
                    new UiElement[] {},
                    controlSearcherData,
                    false,
                    true);
            
            MbUnit.Framework.Assert.AreEqual(0, resultList.Count);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneResult_Name_Simple()
        {
            const string expectedName = "name";
            
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            IFakeUiElement element =
                FakeFactory.GetAutomationElementExpected(
                    ControlType.Button,
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            
            var controlSearcherData =
                new ControlSearcherData {
                Name = expectedName,
                AutomationId = string.Empty,
                Class = string.Empty,
                Value = string.Empty,
                ControlType = new string[] {}
            };
            
            List<IUiElement> resultList =
                WindowSearcher.ReturnOnlyRightElements(
                    new[] { element },
                    controlSearcherData,
                    false,
                    true);
            
            MbUnit.Framework.Assert.AreEqual(1, resultList.Count);
            // 20140312
            // MbUnit.Framework.Assert.Exists(resultList, e => e.Current.Name == expectedName);
            MbUnit.Framework.Assert.Exists(resultList, e => e.GetCurrent().Name == expectedName);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ThreeResults()
        {
            const string expectedName = "name";
            
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            IFakeUiElement element01 =
                FakeFactory.GetAutomationElementExpected(
                    ControlType.Button,
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            
            IFakeUiElement element02 =
                FakeFactory.GetAutomationElementExpected(
                    ControlType.Button,
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            
            IFakeUiElement element03 =
                FakeFactory.GetAutomationElementExpected(
                    ControlType.Button,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            
            IFakeUiElement element04 =
                FakeFactory.GetAutomationElementExpected(
                    ControlType.Button,
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            
            var controlSearcherData =
                new ControlSearcherData {
                Name = expectedName,
                AutomationId = string.Empty,
                Class = string.Empty,
                Value = string.Empty
            };
            
            List<IUiElement> resultList =
                WindowSearcher.ReturnOnlyRightElements(
                    new[] { element01, element02, element03, element04 },
                    controlSearcherData,
                    false,
                    true);
            
            MbUnit.Framework.Assert.AreEqual(3, resultList.Count);
            // 20140312
            // MbUnit.Framework.Assert.Exists(resultList, e => e.Current.Name == expectedName); // ??
            MbUnit.Framework.Assert.Exists(resultList, e => e.GetCurrent().Name == expectedName); // ??
        }
        #endregion for starters
        
        #region Name
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
                new UiElement[] {},
                UsualWildcardRegex.Wildcard,
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byName_Wildcard()
        {
            // const string name = "aaa";
            const string expectedName = "*aa";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                expectedName,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Wildcard,
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byName_Regex()
        {
            // const string name = "aaa";
            const string expectedName = "[a]{2,3}";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                expectedName,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Regex,
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byName_Wildcard()
        {
            const string name = "aaa";
            const string expectedName = "*aa";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                expectedName,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Wildcard,
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byName_Regex()
        {
            const string name = "aaa";
            const string expectedName = "[a]{2,3}";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                expectedName,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Regex,
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byName_Wildcard()
        {
            const string name = "aaa";
            const string expectedName = "*aa";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                expectedName,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, name, string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Wildcard,
                3);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byName_Regex()
        {
            const string name = "aaa";
            const string expectedName = "[a]{2,3}";
            string automationId = string.Empty;
            string className = string.Empty;
            string txtValue = string.Empty;
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                expectedName,
                automationId,
                className,
                txtValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, name, string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Regex,
                3);
        }
        #endregion Name
        
        #region Value
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
                UsualWildcardRegex.Wildcard,
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byValue_Wildcard()
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
                UsualWildcardRegex.Wildcard,
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byValue_Regex()
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
                UsualWildcardRegex.Regex,
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byValue_Wildcard()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            const string expectedValue = "?x*";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                expectedValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
                },
                UsualWildcardRegex.Wildcard,
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byValue_Regex()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            const string expectedValue = "(x|y)[x]{2}";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                expectedValue,
                new [] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
                },
                UsualWildcardRegex.Regex,
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byValue_Wildcard()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            const string expectedValue = "?x*";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                expectedValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "xxxx"),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "yx x x ")
                },
                UsualWildcardRegex.Wildcard,
                3);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byValue_Regex()
        {
            string name = string.Empty;
            string automationId = string.Empty;
            string className = string.Empty;
            const string txtValue = "xxx";
            const string expectedValue = @"(x\s?){3}";
            ControlType controlType = null;
            TestParametersAgainstCollection(
                controlType,
                name,
                automationId,
                className,
                expectedValue,
                new [] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "xxxx"),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, "yx x x ")
                },
                UsualWildcardRegex.Regex,
                3);
        }
        #endregion Value
    }
    
    public enum UsualWildcardRegex
    {
        // Usual,
        Wildcard,
        Regex
    }
}
