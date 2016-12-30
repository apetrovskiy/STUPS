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
    using Xunit;
    
    /// <summary>
    /// Description of ControlSearchTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    // [Ignore("20130313")]
    public class ControlSearchTestFixture
    {
        public ControlSearchTestFixture()
        {
            FakeFactory.Init();
            Preferences.DisableExactSearch = true;
            Preferences.DisableWildCardSearch = false;
            Preferences.DisableWin32Search = false;
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
            Preferences.DisableExactSearch = true;
            Preferences.DisableWildCardSearch = false;
            Preferences.DisableWin32Search = false;
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        private IUiElement[] GetCmdletInputObject_Empty()
        {
            return new [] {
                FakeFactory.GetElement_ForFindAll(
                    new IUiElement [] {
                        null
                    },
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button))
            };
        }
        
        private IUiElement[] GetCmdletInputObject_Three()
        {
            return new [] {
                FakeFactory.GetElement_ForFindAll(
                    new IUiElement [] {
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "name1", "automationId1", "className1", "value1"),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "name2", "automationId2", "className2", "value2"),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "name3", "automationId3", "className3", "value3"),
                    },
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button))
            };
        }
        
        private GetControlCmdletBase GetInputCmdlet(bool empty)
        {
            var cmdlet =
                new GetControlCmdletBase {Win32 = false, Regex = false};

            cmdlet.InputObject = empty ? GetCmdletInputObject_Empty() : GetCmdletInputObject_Three();
            
            return cmdlet;
        }
        
        private ControlSearcher PerformGetElements(GetControlCmdletBase cmdlet)
        {
            var controlSearcher =
                AutomationFactory.GetSearcherImpl<ControlSearcher>() as ControlSearcher;
            
            controlSearcher.GetElements(
                controlSearcher.ConvertCmdletToControlSearcherData(cmdlet),
                0);
            
            return controlSearcher;
        }
        #endregion helpers
        
        // ============================================= empty result ===============================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TextSearch_DefaultGlobalSettings_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.ContainsText = "name1";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_TextSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_TextSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TextSearchWin32_DefaultGlobalSettings_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.ContainsText = "name1";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_TextSearchWin32, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_TextSearchWin32, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_Name_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Name = "Name2";
            Preferences.DisableExactSearch = false;
            Preferences.DisableWildCardSearch = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_AutomationId_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.AutomationId = "AutomationId3";
            Preferences.DisableExactSearch = false;
            Preferences.DisableWildCardSearch = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_Class_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Class = "Class1";
            Preferences.DisableExactSearch = false;
            Preferences.DisableWildCardSearch = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_Value_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Value = "Value2";
            Preferences.DisableExactSearch = false;
            Preferences.DisableWildCardSearch = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_Name_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Name = "Name1";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_AutomationId_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.AutomationId = "AutomationId2";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_Class_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Class = "ClassName3";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_Value_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Value = "Value3";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_Name_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Name = "Name1";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_AutomationId_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.AutomationId = "AutomationId3";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_Class_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Class = "Class3";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_Value_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Value = "Value1";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_Name_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Name = "Name3";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_AutomationId_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.AutomationId = "AutomationId2";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_Class_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Class = "Class3";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_Value_EmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(true);
            cmdlet.Value = "Value1";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        // =========================================== non-empty result =============================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TextSearch_DefaultGlobalSettings_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.ContainsText = "name1";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_TextSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_TextSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TextSearchWin32_DefaultGlobalSettings_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.ContainsText = "name1";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_TextSearchWin32, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_TextSearchWin32, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_Name_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Name = "Name2";
            Preferences.DisableExactSearch = false;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_AutomationId_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.AutomationId = "AutomationId3";
            Preferences.DisableExactSearch = false;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_Class_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Class = "Class1";
            Preferences.DisableExactSearch = false;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExactSearch_NotDisableExactSearch_Value_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Value = "Value2";
            Preferences.DisableExactSearch = false;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_ExactSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_Name_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Name = "Name1";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_AutomationId_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.AutomationId = "AutomationId2";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_Class_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Class = "ClassName3";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void WildcardSearch_DefaultGlobalSettings_Value_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Value = "Value3";
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_WildcardSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_Name_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Name = "Name1";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_AutomationId_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.AutomationId = "AutomationId3";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_Class_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Class = "Class3";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RegexSearch_DefaultGlobalSettings_Value_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Value = "Value1";
            cmdlet.Regex = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_RegexSearch, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_Name_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Name = "Name3";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_AutomationId_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.AutomationId = "AutomationId2";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_Class_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Class = "Class3";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Win32Search_Value_NonEmptyInput()
        {
            // Arrange
            var cmdlet = GetInputCmdlet(false);
            cmdlet.Value = "Value1";
            cmdlet.Win32 = true;
            
            // Act
            var controlSearch = PerformGetElements(cmdlet);
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
            Assert.Equal(UsedSearchType.Control_Win32Search, controlSearch.UsedSearchType);
        }
    }
}
