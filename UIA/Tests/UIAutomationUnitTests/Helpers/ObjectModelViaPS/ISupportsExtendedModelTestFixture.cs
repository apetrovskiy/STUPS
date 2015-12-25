/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModelViaPS
{
    // using Xunit;

    // using UIAutomationTest;
    
    /// <summary>
    /// Description of ISupportsExtendedModelTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsExtendedModelTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            // MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
        }
        
//        #region helpers
//        private IUiElement TestElementsCollectionOfCertainType(ControlType controlType, out IUiElement[] elements)
//        {
//            // Arrange
//            IUiElement[] elementsArray =
//                new[] {
//                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
//                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty),
//                    FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty)
//                };
//            elements = elementsArray;
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elements,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        controlType));
//            
//            return element;
//        }
//        #endregion helpers
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Buttons_Descendants_None()
//        {
//            // Arrange
//            IUiElement[] elements = new IUiElement[] {};
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elements,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button));
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Buttons_Descendants_One()
//        {
//            // Arrange
//            ControlType controlType = ControlType.Button;
//            IUiElement[] elements =
//                new[] { FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty) };
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elements,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        controlType));
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Buttons_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Buttons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Calendars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Calendars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void CheckBoxes_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).CheckBoxes;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ComboBoxes_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ComboBoxes;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Customs_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Customs;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void DataGrids_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataGrids;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void DataItems_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).DataItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Documents_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Documents;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Edits_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Edits;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Groups_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Groups;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Headers_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Headers;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void HeaderItems_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).HeaderItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Hyperlinks_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Hyperlinks;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Images_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Images;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Lists_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Lists;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ListItems_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ListItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Menus_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Menus;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void MenuBars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).MenuBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void MenuItems_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).MenuItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Panes_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Panes;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ProgressBars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ProgressBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void RadioButtons_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).RadioButtons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ScrollBars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ScrollBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Separators_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Separators;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Sliders_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Sliders;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Spinners_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Spinners;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void SplitButtons_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).SplitButtons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void StatusBars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).StatusBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Tabs_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Tabs;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TabItems_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TabItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Tables_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Tables;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Texts_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Texts;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Thumbs_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Thumbs;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TitleBars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TitleBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ToolBars_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ToolBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ToolTips_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).ToolTips;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Trees_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Trees;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TreeItems_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).TreeItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Windows_Descendants_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Descendants as IExtendedModel).Windows;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        // =============================================================================================================
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Buttons_Children_None()
//        {
//            // Arrange
//            IUiElement[] elements = new IUiElement[] {};
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elements,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Button));
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Buttons_Children_One()
//        {
//            // Arrange
//            ControlType controlType = ControlType.Button;
//            IUiElement[] elements =
//                new[] { FakeFactory.GetAutomationElementExpected(controlType, string.Empty, string.Empty, string.Empty, string.Empty) };
//            IUiElement element =
//                FakeFactory.GetElement_ForFindAll(
//                    elements,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        controlType));
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Buttons_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Button, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Buttons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Calendars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Calendar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Calendars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void CheckBoxes_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.CheckBox, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).CheckBoxes;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ComboBoxes_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ComboBox, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ComboBoxes;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Customs_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Custom, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Customs;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void DataGrids_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.DataGrid, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).DataGrids;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void DataItems_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.DataItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).DataItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Documents_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Document, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Documents;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Edits_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Edit, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Edits;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Groups_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Group, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Groups;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Headers_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Header, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Headers;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void HeaderItems_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.HeaderItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).HeaderItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Hyperlinks_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Hyperlink, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Hyperlinks;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Images_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Image, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Images;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Lists_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.List, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Lists;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ListItems_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ListItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ListItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Menus_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Menu, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Menus;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void MenuBars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.MenuBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).MenuBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void MenuItems_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.MenuItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).MenuItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Panes_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Pane, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Panes;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ProgressBars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ProgressBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ProgressBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void RadioButtons_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.RadioButton, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).RadioButtons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ScrollBars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ScrollBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ScrollBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Separators_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Separator, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Separators;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Sliders_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Slider, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Sliders;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Spinners_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Spinner, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Spinners;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void SplitButtons_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.SplitButton, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).SplitButtons;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void StatusBars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.StatusBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).StatusBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Tabs_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Tab, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Tabs;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TabItems_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.TabItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TabItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Tables_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Table, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Tables;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Texts_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Text, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Texts;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Thumbs_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Thumb, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Thumbs;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TitleBars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.TitleBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TitleBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ToolBars_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ToolBar, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ToolBars;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ToolTips_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.ToolTip, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).ToolTips;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Trees_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Tree, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Trees;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void TreeItems_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.TreeItem, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).TreeItems;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Windows_Children_Three()
//        {
//            // Arrange
//            IUiElement[] elements;
//            var element = TestElementsCollectionOfCertainType(ControlType.Window, out elements);
//            
//            // Act
//            var resultCollection = ((element as ISupportsExtendedModel).Children as IExtendedModel).Windows;
//            
//            // Assert
//            MbUnit.Framework.Assert.AreEqual(AutomationFactory.GetUiEltCollection(elements), resultCollection);
//        }
    }
}
