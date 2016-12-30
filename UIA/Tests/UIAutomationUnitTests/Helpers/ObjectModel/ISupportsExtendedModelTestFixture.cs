/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 3:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;using NUnit.Framework;
    using NSubstitute;
    using WindowsInput;
    using WindowsInput.Native;
    
    /// <summary>
    /// Description of ISupportsExtendedModelTestFixture.
    /// </summary>
    [MbUnit.Framework.Parallelizable(TestScope.All)]
    [NUnit.Framework.Parallelizable(ParallelScope.Fixtures)]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsExtendedModelTestFixture
    {
        public ISupportsExtendedModelTestFixture()
        {
            FakeFactory.Init();
            
            ExtensionMethodsElementExtended.InputSimulator = Substitute.For<IInputSimulator>();
            
            Preferences.Timeout = 10;
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
            
            ExtensionMethodsElementExtended.InputSimulator = Substitute.For<IInputSimulator>();
            
            Preferences.Timeout = 10;
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            Preferences.Timeout = 5000;
        }
        
        #region helpers
        private IUiElement TestElementsCollectionOfCertainType(ControlType controlType, out IUiElement[] elements)
        {
            // Arrange
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty)
                };
            elements = elementsArray;
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        controlType));
            
            return element;
        }
        #endregion helpers
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Buttons_Descendants_None()
        {
            // Arrange
            var elements = new IUiElement[] {};
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Buttons_Descendants_One()
        {
            // Arrange
            ControlType controlType = ControlType.Button;
            IUiElement[] elements =
                new[] { FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty) };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        controlType));
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Buttons_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Calendars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void CheckBoxes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ComboBoxes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ComboBoxes;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Customs_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void DataGrids_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataGrids;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void DataItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Documents_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Edits_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Groups_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Groups;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Headers_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Headers;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void HeaderItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).HeaderItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Hyperlinks_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Hyperlinks;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Images_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Lists_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Lists;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ListItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ListItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Menus_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Menus;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void MenuBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).MenuBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void MenuItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).MenuItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Panes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Panes;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ProgressBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ProgressBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RadioButtons_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).RadioButtons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ScrollBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ScrollBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Separators_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Separators;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Sliders_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Sliders;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Spinners_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Spinners;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void SplitButtons_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).SplitButtons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void StatusBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).StatusBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Tabs_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Tabs;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TabItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TabItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Tables_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Tables;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Texts_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Texts;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Thumbs_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Thumbs;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TitleBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TitleBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ToolBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ToolBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ToolTips_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ToolTips;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Trees_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TreeItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TreeItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Windows_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        // =============================================================================================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Buttons_Children_None()
        {
            // Arrange
            var elements = new IUiElement[] {};
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Buttons_Children_One()
        {
            // Arrange
            ControlType controlType = ControlType.Button;
            IUiElement[] elements =
                new[] { FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty) };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        controlType));
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Buttons_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Calendars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Calendars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void CheckBoxes_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).CheckBoxes;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ComboBoxes_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ComboBoxes;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Customs_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Customs;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void DataGrids_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).DataGrids;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void DataItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Documents_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Edits_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Edits;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Groups_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Groups;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Headers_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Headers;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void HeaderItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).HeaderItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Hyperlinks_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Hyperlinks;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Images_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Lists_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Lists;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ListItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ListItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Menus_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Menus;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void MenuBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).MenuBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void MenuItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).MenuItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Panes_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Panes;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ProgressBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ProgressBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void RadioButtons_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).RadioButtons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ScrollBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ScrollBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Separators_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Separators;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Sliders_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Sliders;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Spinners_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Spinners;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void SplitButtons_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).SplitButtons;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void StatusBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).StatusBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Tabs_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Tabs;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TabItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TabItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Tables_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Tables;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Texts_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Texts;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Thumbs_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Thumbs;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TitleBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TitleBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ToolBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ToolBars;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ToolTips_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ToolTips;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Trees_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Trees;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void TreeItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TreeItems;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Windows_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Windows;
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
            Xunit.Assert.Equal(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        // ==========================================================================================================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void VariousTypes_Children_Three()
        {
            // Arrange
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "1", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Document, "2", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "3", string.Empty, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new OrCondition(
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.Button),
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.Document),
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.Image)));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons[0];
            var elementDocument = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents[1];
            var elementImage = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images[2];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(ControlType.Button, elementButton.Current.ControlType); // (elementButton as IUiElement).Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(ControlType.Document, elementDocument.Current.ControlType); // (elementDocument as IUiElement).Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(ControlType.Image, elementImage.Current.ControlType); // (elementImage as IUiElement).Current.ControlType);
            MbUnit.Framework.Assert.AreEqual(ControlType.Button, elementButton.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(ControlType.Document, elementDocument.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(ControlType.Image, elementImage.GetCurrent().ControlType);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Calendars);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).CheckBoxes);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(ControlType.Button, elementButton.Current.ControlType);
//            Xunit.Assert.Equal(ControlType.Document, elementDocument.Current.ControlType);
//            Xunit.Assert.Equal(ControlType.Image, elementImage.Current.ControlType);
            Xunit.Assert.Equal(ControlType.Button, elementButton.GetCurrent().ControlType);
            Xunit.Assert.Equal(ControlType.Document, elementDocument.GetCurrent().ControlType);
            Xunit.Assert.Equal(ControlType.Image, elementImage.GetCurrent().ControlType);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void VariousTypes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, string.Empty, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons[0];
            var elementDocument = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents[1];
            var elementImage = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images[2];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(ControlType.Button, elementButton.Current.ControlType); // (elementButton as IUiElement).Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(ControlType.Document, elementDocument.Current.ControlType); // (elementDocument as IUiElement).Current.ControlType);
//            MbUnit.Framework.Assert.AreEqual(ControlType.Image, elementImage.Current.ControlType); // (elementImage as IUiElement).Current.ControlType);
            MbUnit.Framework.Assert.AreEqual(ControlType.Button, elementButton.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(ControlType.Document, elementDocument.GetCurrent().ControlType);
            MbUnit.Framework.Assert.AreEqual(ControlType.Image, elementImage.GetCurrent().ControlType);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(ControlType.Button, elementButton.Current.ControlType);
//            Xunit.Assert.Equal(ControlType.Document, elementDocument.Current.ControlType);
//            Xunit.Assert.Equal(ControlType.Image, elementImage.Current.ControlType);
            Xunit.Assert.Equal(ControlType.Button, elementButton.GetCurrent().ControlType);
            Xunit.Assert.Equal(ControlType.Document, elementDocument.GetCurrent().ControlType);
            Xunit.Assert.Equal(ControlType.Image, elementImage.GetCurrent().ControlType);
        }
        
        // ==========================================================================================================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Search_Children_Name_1of3()
        {
            // Arrange
            const string expectedName = "btn";
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, expectedName, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Image, string.Empty, string.Empty, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons[expectedName][0];
            var elementDocument = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents[expectedName][0];
            var elementImage = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images[expectedName][0];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedName, (elementButton as IUiElement).Current.Name);
            MbUnit.Framework.Assert.AreEqual(expectedName, (elementButton as IUiElement).GetCurrent().Name);
//            MbUnit.Framework.Assert.IsNull(elementDocument);
//            MbUnit.Framework.Assert.IsNull(elementImage);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(expectedName, (elementButton as IUiElement).Current.Name);
            Xunit.Assert.Equal(expectedName, (elementButton as IUiElement).GetCurrent().Name);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Search_Children_AutomationId_1of3()
        {
            // Arrange
            const string expectedAutomationId = "auId";
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, expectedAutomationId, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Image, string.Empty, string.Empty, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons[expectedAutomationId][0];
            var elementDocument = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents[expectedAutomationId][0];
            var elementImage = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images[expectedAutomationId][0];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedAutomationId, (elementButton as IUiElement).Current.AutomationId);
            MbUnit.Framework.Assert.AreEqual(expectedAutomationId, (elementButton as IUiElement).GetCurrent().AutomationId);
//            MbUnit.Framework.Assert.IsNull(elementDocument);
//            MbUnit.Framework.Assert.IsNull(elementImage);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(expectedAutomationId, (elementButton as IUiElement).Current.AutomationId);
            Xunit.Assert.Equal(expectedAutomationId, (elementButton as IUiElement).GetCurrent().AutomationId);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Search_Children_ClassName_1of3()
        {
            // Arrange
            const string expectedClassName = "class";
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, expectedClassName, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Image, string.Empty, string.Empty, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons[expectedClassName][0];
            var elementDocument = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents[expectedClassName][0];
            var elementImage = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images[expectedClassName][0];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedClassName, (elementButton as IUiElement).Current.ClassName);
            MbUnit.Framework.Assert.AreEqual(expectedClassName, (elementButton as IUiElement).GetCurrent().ClassName);
//            MbUnit.Framework.Assert.IsNull(elementDocument);
//            MbUnit.Framework.Assert.IsNull(elementImage);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(expectedClassName, (elementButton as IUiElement).Current.ClassName);
            Xunit.Assert.Equal(expectedClassName, (elementButton as IUiElement).GetCurrent().ClassName);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Search_Descendants_Name_1of3()
        {
            // Arrange
            const string expectedName = "img";
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, expectedName, string.Empty, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Image));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons[expectedName][0];
            var elementDocument = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents[expectedName][0];
            var elementImage = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images[expectedName][0];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedName, (elementImage as IUiElement).Current.Name);
            MbUnit.Framework.Assert.AreEqual(expectedName, (elementImage as IUiElement).GetCurrent().Name);
//            MbUnit.Framework.Assert.IsNull(elementButton);
//            MbUnit.Framework.Assert.IsNull(elementDocument);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(expectedName, (elementImage as IUiElement).Current.Name);
            Xunit.Assert.Equal(expectedName, (elementImage as IUiElement).GetCurrent().Name);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Search_Descendants_AutomationId_1of3()
        {
            // Arrange
            const string expectedAutomationId = "aaa";
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, expectedAutomationId, string.Empty, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Image));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons[expectedAutomationId][0];
            var elementDocument = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents[expectedAutomationId][0];
            var elementImage = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images[expectedAutomationId][0];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedAutomationId, (elementImage as IUiElement).Current.AutomationId);
            MbUnit.Framework.Assert.AreEqual(expectedAutomationId, (elementImage as IUiElement).GetCurrent().AutomationId);
//            MbUnit.Framework.Assert.IsNull(elementButton);
//            MbUnit.Framework.Assert.IsNull(elementDocument);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(expectedAutomationId, (elementImage as IUiElement).Current.AutomationId);
            Xunit.Assert.Equal(expectedAutomationId, (elementImage as IUiElement).GetCurrent().AutomationId);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Search_Descendants_ClassName_1of3()
        {
            // Arrange
            const string expectedClassName = "cl01";
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementNotExpected(ControlType.Document, string.Empty, string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, string.Empty, string.Empty, expectedClassName, string.Empty)
                };
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elementsArray,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Image));
            
            // Act
            var elementButton = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons[expectedClassName][0];
            var elementDocument = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents[expectedClassName][0];
            var elementImage = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images[expectedClassName][0];
            
            // Assert
            // 20140312
//            MbUnit.Framework.Assert.AreEqual(expectedClassName, (elementImage as IUiElement).Current.ClassName);
            MbUnit.Framework.Assert.AreEqual(expectedClassName, (elementImage as IUiElement).GetCurrent().ClassName);
//            MbUnit.Framework.Assert.IsNull(elementButton);
//            MbUnit.Framework.Assert.IsNull(elementDocument);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            MbUnit.Framework.Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
            
            // 20140312
//            Xunit.Assert.Equal(expectedClassName, (elementImage as IUiElement).Current.ClassName);
            Xunit.Assert.Equal(expectedClassName, (elementImage as IUiElement).GetCurrent().ClassName);
        }
        
        // ==========================================================================================================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Control_Click()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            // Assert
            var elementWithControlInput = ((element as ISupportsExtendedModel).Control as IControlInput).Click();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Control_DoubleClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            // Assert
            var elementWithControlInput = ((element as ISupportsExtendedModel).Control as IControlInput).Click();
        }
        
        // ==========================================================================================================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Keyboard_KeyDown()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            ((element as ISupportsExtendedModel).Keyboard as IKeyboardInput).KeyDown(VirtualKeyCode.VK_F);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Keyboard.Received(1).KeyDown(VirtualKeyCode.VK_F);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Keyboard_KeyPress_Single()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            ((element as ISupportsExtendedModel).Keyboard as IKeyboardInput).KeyPress(VirtualKeyCode.VK_F);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Keyboard.Received(1).KeyPress(VirtualKeyCode.VK_F);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Keyboard_KeyPress_Multiple()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            ((element as ISupportsExtendedModel).Keyboard as IKeyboardInput).KeyPress(new [] { VirtualKeyCode.VK_A, VirtualKeyCode.VK_B, VirtualKeyCode.VK_C });
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Keyboard.Received(1).KeyPress(new [] { VirtualKeyCode.VK_A, VirtualKeyCode.VK_B, VirtualKeyCode.VK_C });
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Keyboard_KeyUp()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            ((element as ISupportsExtendedModel).Keyboard as IKeyboardInput).KeyUp(VirtualKeyCode.VK_F);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Keyboard.Received(1).KeyUp(VirtualKeyCode.VK_F);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Keyboard_TypeText()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            ((element as ISupportsExtendedModel).Keyboard as IKeyboardInput).TypeText("abc");
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Keyboard.Received(1).TextEntry("abc");
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Keyboard_TypeChar()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            ((element as ISupportsExtendedModel).Keyboard as IKeyboardInput).TypeChar('d');
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Keyboard.Received(1).TextEntry('d');
        }
        
        // ==========================================================================================================================
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_HorizontalScroll()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).HorizontalScroll(1);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).HorizontalScroll(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_LeftButtonClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).LeftButtonClick();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).LeftButtonClick();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_LeftButtonDoubleClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).LeftButtonDoubleClick();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).LeftButtonDoubleClick();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_LeftButtonDown()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).LeftButtonDown();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).LeftButtonDown();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_LeftButtonUp()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).LeftButtonUp();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).LeftButtonUp();
        }
        
        //
        //
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_RightButtonClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).RightButtonClick();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).RightButtonClick();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_RightButtonDoubleClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).RightButtonDoubleClick();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).RightButtonDoubleClick();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_RightButtonDown()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).RightButtonDown();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).RightButtonDown();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_RightButtonUp()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).RightButtonUp();
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).RightButtonUp();
        }
        
        //
        //
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_VerticalScroll()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).VerticalScroll(1);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).VerticalScroll(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_XButtonClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).XButtonClick(1);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).XButtonClick(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_XButtonDoubleClick()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).XButtonDoubleClick(1);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).XButtonDoubleClick(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_XButtonDown()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).XButtonDown(1);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).XButtonDown(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Mouse_XButtonUp()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementForMethodsOfObjectModel(new IBasePattern[] {}) as IUiElement;
            
            // Act
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).XButtonUp(1);
            
            // Assert
            ExtensionMethodsElementExtended.InputSimulator.Mouse.Received(1).XButtonUp(1);
        }
        
        // ==========================================================================================================================
        
        // ==========================================================================================================================
    }
}
