/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2013
 * Time: 10:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.Searchers
{
    using System.Collections.Generic;
    using System.Windows.Automation;
    using UIAutomation;
    using Xunit;
    
    /// <summary>
    /// Description of SearchByContainsTextViaWin32TestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class SearchByContainsTextViaWin32TestFixture_less_useful
    {
        public SearchByContainsTextViaWin32TestFixture_less_useful()
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
            var resultList = RealCodeCaller.SearchByContainsTextViaWin32(FakeFactory.GetAutomationElementNotExpected(null, string.Empty, string.Empty, string.Empty, string.Empty), containsText, controlTypeNames, collection, handles);
            
            // Assert
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Assert.Equal(expectedNumberOfElements, resultList.Count);
        }
        #endregion helpers
        
        #region Name
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_byName()
        {
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
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty, 10),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty, 20),
                    FakeFactory.GetAutomationElementExpected(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty, 30)
                },
                new int[] { 10, 20, 30 },
                3);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_byName()
        {
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty, 10),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "name matches", string.Empty, string.Empty, string.Empty, 20),
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty, 30)
                },
                new int[] { 10, 20, 30 },
                3);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byName()
        {
            const string containsText = "*ame??atche*";
            TestParametersAgainstCollection(
                containsText,
                null,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "name matches", string.Empty, string.Empty, string.Empty, 10),
                    FakeFactory.GetAutomationElementExpected(ControlType.Custom, "Name matches", string.Empty, string.Empty, string.Empty, 20),
                    FakeFactory.GetAutomationElementExpected(ControlType.Hyperlink, "name matcheZ", string.Empty, string.Empty, string.Empty, 30)
                },
                new int[] { 10, 20, 30 },
                3);
        }
        #endregion Name
        
        #region ControlType + Name
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0_byControlTypeName()
        {
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
        public void Get0of4_byControlTypeName()
        {
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(controlType, "other name", string.Empty, string.Empty, string.Empty, 10),
                    FakeFactory.GetAutomationElementExpected(controlType, "second name", string.Empty, string.Empty, string.Empty, 20),
                    FakeFactory.GetAutomationElementExpected(controlType, "third name", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.DataGrid, containsText, string.Empty, string.Empty, string.Empty, 40)
                },
                new int[] { 10, 20, 30, 40 },
                3);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of4_byControlTypeName()
        {
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(controlType, "other name", string.Empty, string.Empty, string.Empty, 10),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", string.Empty, string.Empty, string.Empty, 20),
                    FakeFactory.GetAutomationElementExpected(controlType, "third name", string.Empty, string.Empty, string.Empty, 30),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Group, containsText, string.Empty, string.Empty, string.Empty, 40)
                },
                new int[] { 10, 20, 30, 40 },
                3);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_byControlTypeName()
        {
            const string containsText = "*ame??atche*";
            ControlType controlType = ControlType.Button;
            TestParametersAgainstCollection(
                containsText,
                controlType.ConvertControlTypeToStringArray(),
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(controlType, "name matches", string.Empty, string.Empty, string.Empty, 10),
                    FakeFactory.GetAutomationElementExpected(controlType, "NNName matches", string.Empty, string.Empty, string.Empty, 20),
                    FakeFactory.GetAutomationElementExpected(controlType, "name matcheZ", string.Empty, string.Empty, string.Empty, 30)
                },
                new int[] { 10, 20, 30 },
                3);
        }
        #endregion ControlType + Name
    }
}
