using System;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/17/2014
 * Time: 2:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.NewModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    // using NSubstitute;
    
    /// <summary>
    /// Description of ControlSearchTestFixture.
    /// </summary>
    [TestFixture]
    public class ControlSearchTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
            Preferences.DisableExactSearch = true;
            Preferences.DisableWildCardSearch = false;
            Preferences.DisableWin32Search = false;
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        private IUiElement[] GetCmdletInputObject()
        {
            return new [] {
                FakeFactory.GetElement_ForFindAll(
                    new [] { FakeFactory.GetAutomationElementExpected(ControlType.Button, "name", "automaitonId", "className", "value") },
                    null)
            };
        }
        
        private GetControlCmdletBase GetInputCmdlet()
        {
            var cmdlet =
                new GetControlCmdletBase();
            
            cmdlet.InputObject = GetCmdletInputObject();
            
            return cmdlet;
        }
        #endregion helpers
        
        [Test]
        public void TextSearch()
        {
            // Arrange
            var cmdlet = GetInputCmdlet();
            cmdlet.ContainsText = "abc";
            
            // Act
            var controlSearch =
                AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
            
            controlSearch.GetElements(
                controlSearch.ConvertCmdletToControlSearchData(cmdlet),
                0);
            
            // Assert
            Assert.AreEqual(UsedSearchType.TextSearch, controlSearch.UsedSearchType);
        }
        
        [Test]
        public void TextSearchWin32()
        {
            // Arrange
            var cmdlet = GetInputCmdlet();
            cmdlet.ContainsText = "abc";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch =
                AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
            
            controlSearch.GetElements(
                controlSearch.ConvertCmdletToControlSearchData(cmdlet),
                0);
            
            // Assert
            Assert.AreEqual(UsedSearchType.TextSearchWin32, controlSearch.UsedSearchType);
        }
        
        [Test]
        public void ExactSearch_Name()
        {
            // Arrange
            var cmdlet = GetInputCmdlet();
            cmdlet.Name = "abc";
            Preferences.DisableExactSearch = false;
            
            // Act
            var controlSearch =
                AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
            
            controlSearch.GetElements(
                controlSearch.ConvertCmdletToControlSearchData(cmdlet),
                0);
            
            // Assert
            Assert.AreEqual(UsedSearchType.ExactSearch, controlSearch.UsedSearchType);
        }
        
        [Test]
        public void WildcardSearch_Name()
        {
            // Arrange
            var cmdlet = GetInputCmdlet();
            cmdlet.Name = "abc";
            
            // Act
            var controlSearch =
                AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
            
            controlSearch.GetElements(
                controlSearch.ConvertCmdletToControlSearchData(cmdlet),
                0);
            
            // Assert
            Assert.AreEqual(UsedSearchType.WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [Test]
        public void RegexSsearch_Name()
        {
            // Arrange
            var cmdlet = GetInputCmdlet();
            cmdlet.Name = "abc";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch =
                AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
            
            controlSearch.GetElements(
                controlSearch.ConvertCmdletToControlSearchData(cmdlet),
                0);
            
            // Assert
            Assert.AreEqual(UsedSearchType.RegexSsearch, controlSearch.UsedSearchType);
        }
        
        [Test]
        public void Win32Search_Name()
        {
            // Arrange
            var cmdlet = GetInputCmdlet();
            cmdlet.Name = "abc";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch =
                AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
            
            controlSearch.GetElements(
                controlSearch.ConvertCmdletToControlSearchData(cmdlet),
                0);
            
            // Assert
            Assert.AreEqual(UsedSearchType.Win32Search, controlSearch.UsedSearchType);
        }
    }
}
