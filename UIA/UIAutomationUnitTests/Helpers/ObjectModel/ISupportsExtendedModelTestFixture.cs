using System;
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
    using MbUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsExtendedModelTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsExtendedModelTestFixture
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
        
        [Test]
        public void Buttons_Descendants_None()
        {
            // Arrange
            IUiElement[] elements = new IUiElement[] {};
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
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
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Buttons_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Calendars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void CheckBoxes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ComboBoxes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ComboBoxes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Customs_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void DataGrids_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataGrids;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void DataItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Documents_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Edits_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Groups_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Groups;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Headers_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Headers;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void HeaderItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).HeaderItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Hyperlinks_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Hyperlinks;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void Images_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Lists_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Lists;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ListItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ListItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Menus_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Menus;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void MenuBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).MenuBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void MenuItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).MenuItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Panes_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Panes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ProgressBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ProgressBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void RadioButtons_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).RadioButtons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ScrollBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ScrollBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Separators_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Separators;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Sliders_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Sliders;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void Spinners_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Spinners;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void SplitButtons_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).SplitButtons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void StatusBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).StatusBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Tabs_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Tabs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TabItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TabItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Tables_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Tables;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Texts_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Texts;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Thumbs_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Thumbs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TitleBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TitleBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ToolBars_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ToolBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ToolTips_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ToolTips;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Trees_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TreeItems_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TreeItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Windows_Descendants_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        // =============================================================================================================
        
        [Test]
        public void Buttons_Children_None()
        {
            // Arrange
            IUiElement[] elements = new IUiElement[] {};
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
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
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Buttons_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Calendars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Calendars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void CheckBoxes_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).CheckBoxes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ComboBoxes_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ComboBoxes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Customs_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Customs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void DataGrids_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).DataGrids;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void DataItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Documents_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Edits_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Edits;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Groups_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Groups;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Headers_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Headers;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void HeaderItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).HeaderItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Hyperlinks_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Hyperlinks;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void Images_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Lists_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Lists;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ListItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ListItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Menus_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Menus;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void MenuBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).MenuBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void MenuItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).MenuItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Panes_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Panes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ProgressBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ProgressBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void RadioButtons_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).RadioButtons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ScrollBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ScrollBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Separators_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Separators;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Sliders_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Sliders;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void Spinners_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Spinners;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void SplitButtons_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).SplitButtons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void StatusBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).StatusBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Tabs_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Tabs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TabItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TabItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Tables_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Tables;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Texts_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Texts;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Thumbs_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Thumbs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TitleBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TitleBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ToolBars_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ToolBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ToolTips_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ToolTips;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Trees_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Trees;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TreeItems_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TreeItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Windows_Children_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Windows;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        // ==========================================================================================================================
        
        [Test]
        public void VariousTypes_Children_Three()
        {
            // Arrange
            IUiElement[] elementsArray =
                new[] {
                    FakeFactory.GetAutomationElementExpected(ControlType.Button, "1", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Document, "2", string.Empty, string.Empty, string.Empty),
                    FakeFactory.GetAutomationElementExpected(ControlType.Image, "3", string.Empty, string.Empty, string.Empty)
                };
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elementsArray,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button));
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
            Assert.AreEqual(ControlType.Button, elementButton.Current.ControlType); // (elementButton as IUiElement).Current.ControlType);
            Assert.AreEqual(ControlType.Document, elementDocument.Current.ControlType); // (elementDocument as IUiElement).Current.ControlType);
            Assert.AreEqual(ControlType.Image, elementImage.Current.ControlType); // (elementImage as IUiElement).Current.ControlType);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Calendars);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).CheckBoxes);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
        }
        
        [Test]
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
            Assert.AreEqual(ControlType.Button, elementButton.Current.ControlType); // (elementButton as IUiElement).Current.ControlType);
            Assert.AreEqual(ControlType.Document, elementDocument.Current.ControlType); // (elementDocument as IUiElement).Current.ControlType);
            Assert.AreEqual(ControlType.Image, elementImage.Current.ControlType); // (elementImage as IUiElement).Current.ControlType);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
        }
        
        // ==========================================================================================================================
        
        [Test]
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
            Assert.AreEqual(expectedName, (elementButton as IUiElement).Current.Name);
//            Assert.IsNull(elementDocument);
//            Assert.IsNull(elementImage);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
        }
        
        [Test]
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
            Assert.AreEqual(expectedAutomationId, (elementButton as IUiElement).Current.AutomationId);
//            Assert.IsNull(elementDocument);
//            Assert.IsNull(elementImage);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
        }
        
        [Test]
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
            Assert.AreEqual(expectedClassName, (elementButton as IUiElement).Current.ClassName);
//            Assert.IsNull(elementDocument);
//            Assert.IsNull(elementImage);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Children as IExtendedModel).Windows);
        }
        
        [Test]
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
            Assert.AreEqual(expectedName, (elementImage as IUiElement).Current.Name);
//            Assert.IsNull(elementButton);
//            Assert.IsNull(elementDocument);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
        }
        
        [Test]
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
            Assert.AreEqual(expectedAutomationId, (elementImage as IUiElement).Current.AutomationId);
//            Assert.IsNull(elementButton);
//            Assert.IsNull(elementDocument);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
        }
        
        [Test]
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
            Assert.AreEqual(expectedClassName, (elementImage as IUiElement).Current.ClassName);
//            Assert.IsNull(elementButton);
//            Assert.IsNull(elementDocument);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees);
//            Assert.IsNull(((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows);
        }
        
        // ==========================================================================================================================
        
        [Test]
        public void Control_Click()
        {
            // Arrange
            IUiElement element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] {}) as IUiElement;
            
            // Act
            // Assert
            var elementWithControlInput = ((element as ISupportsExtendedModel).Control as IControlInput).Click();
        }
        
        [Test]
        public void Control_DoubleClick()
        {
            // Arrange
            IUiElement element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] {}) as IUiElement;
            
            // Act
            // Assert
            var elementWithControlInput = ((element as ISupportsExtendedModel).Control as IControlInput).Click();
        }
        
        // ==========================================================================================================================
        
        
        // ==========================================================================================================================
        
        [Test]
        public void Mouse_LeftButtonClick()
        {
            // Arrange
            IUiElement element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] {}) as IUiElement;
            
            // Act
            // Assert
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).LeftButtonClick();
        }
        
        [Test]
        public void Mouse_LeftButtonDoubleClick()
        {
            // Arrange
            IUiElement element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] {}) as IUiElement;
            
            // Act
            // Assert
            var elementWithMouseInput = ((element as ISupportsExtendedModel).Mouse as IMouseInput).LeftButtonDoubleClick();
        }
        
        // ==========================================================================================================================
        
        // ==========================================================================================================================
    }
}
