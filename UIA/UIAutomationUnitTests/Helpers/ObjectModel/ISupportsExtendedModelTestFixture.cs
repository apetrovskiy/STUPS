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
            UIAutomation.Preferences.UseElementsSearchObjectModel = true;
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
        public void NoExtension()
        {
            // Arrange
            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
            
            // Act
            IUiElement[] elements = new IUiElement[] {};
            IUiElement element =
                FakeFactory.GetElement_ForFindAll(
                    elements,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Button));
            
            // Assert
            Assert.IsNull(element as ISupportsExtendedModel);
        }
        
        [Test]
        public void Buttons_Null()
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
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Buttons_One()
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
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Buttons_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Buttons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Calendars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Calendars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void CheckBoxes_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).CheckBoxes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ComboBoxes_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).ComboBoxes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Customs_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Customs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void DataGrids_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).DataGrids;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void DataItems_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).DataItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Documents_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Documents;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Edits_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Edits;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Groups_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Groups;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Headers_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Headers;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void HeaderItems_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).HeaderItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Hyperlinks_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Hyperlinks;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void Images_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Images;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Lists_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Lists;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ListItems_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).ListItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Menus_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Menus;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void MenuBars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).MenuBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void MenuItems_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).MenuItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Panes_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Panes;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ProgressBars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).ProgressBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void RadioButtons_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).RadioButtons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ScrollBars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).ScrollBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Separators_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Separators;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Sliders_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Sliders;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void Spinners_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Spinners;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void SplitButtons_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).SplitButtons;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void StatusBars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).StatusBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Tabs_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Tabs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TabItems_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).TabItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Tables_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Tables;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Texts_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Texts;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Thumbs_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Thumbs;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TitleBars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).TitleBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ToolBars_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).ToolBars;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void ToolTips_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).ToolTips;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Trees_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Trees;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        
        [Test]
        public void TreeItems_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).TreeItems;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
        
        [Test]
        public void Windows_Three()
        {
            // Arrange
            IUiElement[] elements;
            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
            
            // Act
            var resultCollection = ((element as ISupportsExtendedModel).Elements as IExtendedModel).Windows;
            
            // Assert
            Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
        }
    }
}
