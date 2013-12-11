using System;
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
    using MbUnit.Framework;
    using UIAutomation;

    /// <summary>
    /// Description of ReturnOnlyRightElementsTestFixture.
    /// </summary>
    public class ReturnOnlyRightElementsTestFixture
    {
        [SetUp]
        public void SetUp()
        {
//            UnitTestingHelper.PrepareUnitTestDataStore();
//            ObjectsFactory.InitUnitTests();
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        private void TestParametersAgainstCollection(
            // ControlType[] controlTypes,
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
            
            Condition condition;
            bool useWildcardOrRegex = true;
            switch (selector) {
                case UIAutomationUnitTests.Helpers.Inheritance.UsualWildcardRegex.Usual:
                    condition =
                        cmdlet.GetWildcardSearchCondition(cmdlet);
                    useWildcardOrRegex = true;
                    break;
                case UIAutomationUnitTests.Helpers.Inheritance.UsualWildcardRegex.Wildcard:
                    condition =
                        cmdlet.GetWildcardSearchCondition(cmdlet);
                    useWildcardOrRegex = true;
                    break;
                case UIAutomationUnitTests.Helpers.Inheritance.UsualWildcardRegex.Regex:
                    condition =
                        cmdlet.GetWildcardSearchCondition(cmdlet);
                    useWildcardOrRegex = false;
                    break;
                // default:
                //     throw new Exception("Invalid value for UsualWildcardRegex");
            }
            
            // Act
            List<IUiElement> resultList = RealCodeCaller.GetResultList_ReturnOnlyRightElements(cmdlet, collection.ToArray(), useWildcardOrRegex);
            
            // Assert
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(name)) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => x.Current.Name == name);
            }
            if (!string.IsNullOrEmpty(automationId)) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => x.Current.AutomationId == automationId);
            }
            if (!string.IsNullOrEmpty(className)) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => x.Current.ClassName == className);
            }
            string[] controlTypeNames =
                controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
            if (null != controlType) {
                Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
            }
            if (!string.IsNullOrEmpty(txtValue)) {
                Assert.ForAll(
                    resultList
                    .Cast<IUiElement>()
                    .ToList<IUiElement>(), x =>
                    {
                        // 20131208
                        // IMySuperValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern;
                        // IMySuperValuePattern valuePattern = x.GetCurrentPattern<IMySuperValuePattern, ValuePattern>(ValuePattern.Pattern) as IMySuperValuePattern;
                        IMySuperValuePattern valuePattern = x.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern) as IMySuperValuePattern;
                        return valuePattern != null && valuePattern.Current.Value == txtValue;
                    });
            }
        }
        #endregion helpers
        
        #region for starers
        [Test]
        public void NoResults_NullInput()
        {
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            List<IUiElement> resultList =
                HasTimeoutCmdletBase.ReturnOnlyRightElements(
                    cmdlet,
                    null,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    new string[] {},
                    false,
                    true);
            
            Assert.AreEqual(0, resultList.Count);
        }
        
        [Test]
        public void NoResults_ZeroInput()
        {
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            List<IUiElement> resultList =
                HasTimeoutCmdletBase.ReturnOnlyRightElements(
                    cmdlet,
                    new UiElement[] {},
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    new string[] {},
                    false,
                    true);
            
            Assert.AreEqual(0, resultList.Count);
        }
        
        [Test]
        public void OneResult_Name_Simple()
        {
            string expectedName = "name";
            
            HasTimeoutCmdletBase cmdlet =
                new HasTimeoutCmdletBase();
            
            IFakeUiElement element =
                FakeFactory.GetAutomationElementExpected(
                    ControlType.Button,
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            
            List<IUiElement> resultList =
                HasTimeoutCmdletBase.ReturnOnlyRightElements(
                    cmdlet,
                    new[] { element },
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    new string[] {},
                    false,
                    true);
            
            Assert.AreEqual(1, resultList.Count);
            Assert.Exists(resultList, e => e.Current.Name == expectedName);
        }
        
        [Test]
        public void ThreeResults()
        {
            string expectedName = "name";
            
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
            
            List<IUiElement> resultList =
                HasTimeoutCmdletBase.ReturnOnlyRightElements(
                    cmdlet,
                    new[] { element01, element02, element03, element04 },
                    expectedName,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    new string[] {},
                    false,
                    true);
            
            Assert.AreEqual(3, resultList.Count);
            Assert.Exists(resultList, e => e.Current.Name == expectedName); // ??
        }
        #endregion for starers
        
//        [Test]
//        public void MaximumResults()
//        {
//            HasTimeoutCmdletBase cmdlet =
//                new HasTimeoutCmdletBase();
//            
//        }
        
        
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
                new UiElement[] {},
                UsualWildcardRegex.Wildcard,
                0);
        }
        
        [Test]
        public void Get0of3_byName_Wildcard()
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
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Wildcard,
                0);
        }
        
        [Test]
        public void Get0of3_byName_Regex()
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
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Regex,
                0);
        }
        
        [Test]
        public void Get1of3_byName_Wildcard()
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
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Wildcard,
                1);
        }
        
        [Test]
        public void Get1of3_byName_Regex()
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
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Regex,
                1);
        }
        
        [Test]
        public void Get3of3_byName_Wildcard()
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
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, name, string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Wildcard,
                3);
        }
        
        [Test]
        public void Get3of3_byName_Regex()
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
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, name, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, name, string.Empty, string.Empty, string.Empty)
                },
                UsualWildcardRegex.Regex,
                3);
        }
        #endregion Name
    }
    
    public enum UsualWildcardRegex
    {
        Usual,
        Wildcard,
        Regex
    }
}
