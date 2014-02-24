using System;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2013
 * Time: 10:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

// namespace UIAutomationUnitTests.Helpers.Inheritance
namespace UIAutomationUnitTests.Helpers.UnderlyingCode.Searchers
{
    // using System;
    // using System.Collections;
    using System.Collections.Generic;
    // using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    // using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchByContainsTextViaWin32TestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class SearchByContainsTextViaWin32TestFixture
    {
    	public SearchByContainsTextViaWin32TestFixture()
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
            Xunit.Assert.Equal(expectedNumberOfElements, resultList.Count);
        }
        #endregion helpers
        
        #region Name
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
        
        [Test][Fact]
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
