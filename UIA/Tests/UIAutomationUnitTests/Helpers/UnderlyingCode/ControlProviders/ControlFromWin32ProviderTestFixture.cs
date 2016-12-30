/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/19/2014
 * Time: 2:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.ControlProviders
{
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Linq;
    using Xunit;
    using UIAutomation;
    
    /// <summary>
    /// Description of ControlFromWin32ProviderTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ControlFromWin32ProviderTestFixture
    {
        public ControlFromWin32ProviderTestFixture()
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
            string containsText,
            string[] controlTypeNames,
            IEnumerable<IUiElement> collection,
            IEnumerable<int> handles,
            int expectedNumberOfElements)
        {
            // Act
            var resultList = RealCodeCaller.Win32Gateway_GetElements_WithControlSearcherDataInput(
                FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, new IBasePattern[] {}, true),
                collection.ToArray(),
                handles,
                containsText);
            
            // Assert
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Assert.Equal(expectedNumberOfElements, resultList.Count);
        }
        #endregion helpers
        
        #region Name
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_byName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new UiElement[] {},
                new int[] {},
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "name matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "Name matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, "name matcheZ", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                3);
        }
        #endregion Name
        
        #region ControlType + Name
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_byControlTypeName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new UiElement[] {},
                new int[] {},
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of4_byControlTypeName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(controlType, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(controlType, "second name", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(controlType, "third name", string.Empty, string.Empty, string.Empty, 45),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, containsText, string.Empty, string.Empty, string.Empty, 60)
                },
                new int[] { 15, 30, 45, 60 },
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get2of4_byControlTypeName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(controlType, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(controlType, "third name", string.Empty, string.Empty, string.Empty, 45),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, containsText, string.Empty, string.Empty, string.Empty, 60)
                },
                new int[] { 15, 30, 45, 60 },
                2);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byControlTypeName()
        {
            // Arrange
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(controlType, "NNName matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matcheZ", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                3);
        }
        #endregion ControlType + Name
        
        #region AutomationId
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byAutomationId()
        {
            // Arrange
            const string containsText = "*aaa!!bbb*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "second name", "wrong", string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byAutomationId()
        {
            // Arrange
            const string containsText = "*auto*id*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Tab, "other name", "automationId", string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "name matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byAutomationId()
        {
            // Arrange
            const string containsText = "*au??id*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", "mauxyidz", string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "Name matches", "AU23id", string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, "name matcheZ", "au..ID", string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                3);
        }
        #endregion AutomationId
        
        #region ClassName
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byClassName()
        {
            // Arrange
            const string containsText = "*aaa!!bbb*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "second name", "wrong", "nope", string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byClassName()
        {
            // Arrange
            const string containsText = "*class*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Tab, "other name", "automationId", string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "name matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "third name", string.Empty, "className", string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byClassName()
        {
            // Arrange
            const string containsText = "*cl*na*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", "mauxyidz", "classname", string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "Name matches", "AU23id", "class name", string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, "name matcheZ", "au..ID", "clockname", string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                3);
        }
        #endregion ClassName
        
        #region Value
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_byValue()
        {
            // Arrange
            const string containsText = "*aaa!!bbb*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty, 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "second name", "wrong", "nope", "wrongval", 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byValue()
        {
            // Arrange
            const string containsText = "*valu*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Tab, "other name", "automationId", string.Empty, "value", 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "name matches", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "third name", string.Empty, "className", string.Empty, 45)
                },
                new int[] { 15, 30, 45 },
                1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byValue()
        {
            // Arrange
            const string containsText = "*va*lue*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", "mauxyidz", "classname", "my value", 15),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "Name matches", "AU23id", "class name", "the value", 30),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, "name matcheZ", "au..ID", "clockname", "value", 45)
                },
                new int[] { 15, 30, 45 },
                3);
        }
        #endregion Value
    }
}
