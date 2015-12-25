/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2013
 * Time: 12:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    
    using System.Windows.Automation;
    using System.Linq;
    using System.Collections.Generic;
    using NSubstitute;
    using UIAutomation;
    
    /// <summary>
    /// Description of FakeFactory.
    /// </summary>
    public class FakeFactory
    {
        public static void Init()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            InitForPowerShell();
        }
        
        public static void InitForPowerShell()
        {
            AutomationFactory.InitUnitTests();
            Preferences.UseElementsPatternObjectModel = true;
            Preferences.UseElementsSearchObjectModel = true;
            Preferences.UseElementsCurrent = true;
            Preferences.UseElementsCached = false;
        }
        
        public static void Reset()
        {
            AutomationFactory.Reset();
        }
        
        #region patterns
        public static IDockPattern GetDockPattern(PatternsData data)
        {
            var dockPattern = Substitute.For<IDockPattern>();
            dockPattern.SetDockPosition(Arg.Do<DockPosition>(pos => data.DockPattern_DockPosition = pos));
            dockPattern.Current.DockPosition.Returns(data.DockPattern_DockPosition);
            dockPattern.Cached.DockPosition.Returns(data.DockPattern_DockPosition);
            return dockPattern;
        }
        
        public static IExpandCollapsePattern GetExpandCollapsePattern(PatternsData data)
        {
            IExpandCollapsePattern expandCollapsePattern = Substitute.For<IExpandCollapsePattern>();
            expandCollapsePattern.Current.ExpandCollapseState.Returns(data.ExpandCollapsePattern_ExpandCollapseState);
            expandCollapsePattern.Cached.ExpandCollapseState.Returns(data.ExpandCollapsePattern_ExpandCollapseState);
            return expandCollapsePattern;
        }
        
        public static IGridItemPattern GetGridItemPattern(PatternsData data)
        {
            var gridItemPattern = Substitute.For<IGridItemPattern>();
            gridItemPattern.Current.Column.Returns(data.GridItemPattern_Column);
            gridItemPattern.Current.ColumnSpan.Returns(data.GridItemPattern_ColumnSpan);
            gridItemPattern.Current.ContainingGrid.Returns(data.GridItemPattern_ContainingGrid);
            gridItemPattern.Current.Row.Returns(data.GridItemPattern_Row);
            gridItemPattern.Current.RowSpan.Returns(data.GridItemPattern_RowSpan);
            gridItemPattern.Cached.Column.Returns(data.GridItemPattern_Column);
            gridItemPattern.Cached.ColumnSpan.Returns(data.GridItemPattern_ColumnSpan);
            gridItemPattern.Cached.ContainingGrid.Returns(data.GridItemPattern_ContainingGrid);
            gridItemPattern.Cached.Row.Returns(data.GridItemPattern_Row);
            gridItemPattern.Cached.RowSpan.Returns(data.GridItemPattern_RowSpan);
            return gridItemPattern;
        }
        
        public static IGridPattern GetGridPattern(PatternsData data)
        {
            var gridPattern = Substitute.For<IGridPattern>();
            IUiElement fakeElement =
                GetAutomationElement(
                    data.GridPattern_GetItem_ControlType,
                    data.GridPattern_GetItem_Name,
                    data.GridPattern_GetItem_AutomationId,
                    data.GridPattern_GetItem_Class,
                    new IBasePattern[] {},
                    true);
            
            gridPattern.GetItem(Arg.Any<int>(), Arg.Any<int>()).Returns(fakeElement);
            gridPattern.Current.ColumnCount.Returns(data.GridPattern_ColumnCount);
            gridPattern.Current.RowCount.Returns(data.GridPattern_RowCount);
            gridPattern.Cached.ColumnCount.Returns(data.GridPattern_ColumnCount);
            gridPattern.Cached.RowCount.Returns(data.GridPattern_RowCount);
            return gridPattern;
        }
        
        public static IInvokePattern GetInvokePattern(PatternsData data)
        {
            IInvokePattern invokePattern = Substitute.For<IInvokePattern>();
            // invokePattern.Invoke
            return invokePattern;
        }
        
        public static IRangeValuePattern GetRangeValuePattern(PatternsData data)
        {
            IRangeValuePattern rangeValuePattern = Substitute.For<IRangeValuePattern>();
            rangeValuePattern.SetValue(Arg.Do<double>(arg => data.RangeValuePattern_Value = arg));
            rangeValuePattern.Current.IsReadOnly.Returns(data.RangeValuePattern_IsReadOnly);
            rangeValuePattern.Current.LargeChange.Returns(data.RangeValuePattern_LargeChange);
            rangeValuePattern.Current.Maximum.Returns(data.RangeValuePattern_Maximum);
            rangeValuePattern.Current.Minimum.Returns(data.RangeValuePattern_Minimum);
            rangeValuePattern.Current.SmallChange.Returns(data.RangeValuePattern_SmallChange);
            rangeValuePattern.Current.Value.Returns(data.RangeValuePattern_Value);
            return rangeValuePattern;
        }
        
        public static IScrollItemPattern GetScrollItemPattern(PatternsData data)
        {
            IScrollItemPattern scrollItemPattern = Substitute.For<IScrollItemPattern>();
            // scrollItemPattern.ScrollIntoView().Received();
            return scrollItemPattern;
        }
        
        public static IScrollPattern GetScrollPattern(PatternsData data)
        {
            IScrollPattern scrollPattern = Substitute.For<IScrollPattern>();
            // scrollPattern.Scroll(Arg.Any<ScrollAmount>(), Arg.Any<ScrollAmount>()).Returns(new[] { data.ScrollPattern_HorizontalAmount, data.ScrollPattern_VerticalAmount });
            // scrollPattern.ScrollHorizontal(Arg.Any<ScrollAmount>()).Returns(data.ScrollPattern_HorizontalAmount);
            // scrollPattern.ScrollVertical(Arg.Any<ScrollAmount>()).Returns(data.ScrollPattern_VerticalAmount);
            // scrollPattern.SetScrollPercent(Arg.Any<double>(), Arg.Any<double>()).Returns(new[] { data.ScrollPattern_HorizontalPercent, data.ScrollPattern_VerticalPercent });
            
            scrollPattern.Current.HorizontallyScrollable.Returns(data.ScrollPattern_HorizontallyScrollable);
            scrollPattern.Current.HorizontalScrollPercent.Returns(data.ScrollPattern_HorizontalScrollPercent);
            scrollPattern.Current.HorizontalViewSize.Returns(data.ScrollPattern_HorizontalViewSize);
            scrollPattern.Current.VerticallyScrollable.Returns(data.ScrollPattern_VerticallyScrollable);
            scrollPattern.Current.VerticalScrollPercent.Returns(data.ScrollPattern_VerticalScrollPercent);
            scrollPattern.Current.VerticalViewSize.Returns(data.ScrollPattern_VerticalViewSize);
            
            scrollPattern.Cached.HorizontallyScrollable.Returns(data.ScrollPattern_HorizontallyScrollable);
            scrollPattern.Cached.HorizontalScrollPercent.Returns(data.ScrollPattern_HorizontalScrollPercent);
            scrollPattern.Cached.HorizontalViewSize.Returns(data.ScrollPattern_HorizontalViewSize);
            scrollPattern.Cached.VerticallyScrollable.Returns(data.ScrollPattern_VerticallyScrollable);
            scrollPattern.Cached.VerticalScrollPercent.Returns(data.ScrollPattern_VerticalScrollPercent);
            scrollPattern.Cached.VerticalViewSize.Returns(data.ScrollPattern_VerticalViewSize);
            
            return scrollPattern;
        }
        
        public static ISelectionItemPattern GetSelectionItemPattern(PatternsData data)
        {
            ISelectionItemPattern selectionItemPattern = Substitute.For<ISelectionItemPattern>();
            // selectionItemPattern.AddToSelection()
            // selectionItemPattern.RemoveFromSelection()
            // selectionItemPattern.Select()
            
            selectionItemPattern.Current.IsSelected.Returns(data.SelectionItemPattern_IsSelected);
            selectionItemPattern.Current.SelectionContainer.Returns(data.SelectionItemPattern_SelectionContainer);
            
            selectionItemPattern.Cached.IsSelected.Returns(data.SelectionItemPattern_IsSelected);
            selectionItemPattern.Cached.SelectionContainer.Returns(data.SelectionItemPattern_SelectionContainer);
            
            return selectionItemPattern;
        }
        
        public static ISelectionPattern GetSelectionPattern(PatternsData data)
        {
            ISelectionPattern selectionPattern = Substitute.For<ISelectionPattern>();
            //selectionPattern.Current.GetSelection()
            
            selectionPattern.Current.CanSelectMultiple.Returns(data.SelectionPattern_CanSelectMultiple);
            selectionPattern.Current.IsSelectionRequired.Returns(data.SelectionPattern_IsSelectionRequired);
            
            selectionPattern.Cached.CanSelectMultiple.Returns(data.SelectionPattern_CanSelectMultiple);
            selectionPattern.Cached.IsSelectionRequired.Returns(data.SelectionPattern_IsSelectionRequired);
            
            return selectionPattern;
        }
        
        public static ITableItemPattern GetTableItemPattern(PatternsData data)
        {
            ITableItemPattern tableItemPattern = Substitute.For<ITableItemPattern>();
            tableItemPattern.Current.GetColumnHeaderItems().Returns(new IUiElement[] {});
            tableItemPattern.Current.GetRowHeaderItems().Returns(new IUiElement[] {});
            tableItemPattern.Current.Column.Returns(data.TableItemPattern_Column);
            tableItemPattern.Current.ColumnSpan.Returns(data.TableItemPattern_ColumnSpan);
            tableItemPattern.Current.ContainingGrid.Returns(data.TableItemPattern_ContainingGrid);
            tableItemPattern.Current.Row.Returns(data.TableItemPattern_Row);
            tableItemPattern.Current.RowSpan.Returns(data.TableItemPattern_RowSpan);
            tableItemPattern.Cached.Column.Returns(data.TableItemPattern_Column);
            tableItemPattern.Cached.ColumnSpan.Returns(data.TableItemPattern_ColumnSpan);
            tableItemPattern.Cached.ContainingGrid.Returns(data.TableItemPattern_ContainingGrid);
            tableItemPattern.Cached.Row.Returns(data.TableItemPattern_Row);
            tableItemPattern.Cached.RowSpan.Returns(data.TableItemPattern_RowSpan);
            return tableItemPattern;
        }
        
        public static ITablePattern GetTablePattern(PatternsData data)
        {
            ITablePattern tablePattern = Substitute.For<ITablePattern>();
            tablePattern.Current.GetColumnHeaders().Returns(new IUiElement[] {});
            tablePattern.Current.GetRowHeaders().Returns(new IUiElement[] {});
            tablePattern.Current.ColumnCount.Returns(data.TablePattern_ColumnCount);
            tablePattern.Current.RowCount.Returns(data.TablePattern_RowCount);
            tablePattern.Current.RowOrColumnMajor.Returns(data.TablePattern_RowOrColumnMajor);
            tablePattern.Cached.ColumnCount.Returns(data.TablePattern_ColumnCount);
            tablePattern.Cached.RowCount.Returns(data.TablePattern_RowCount);
            tablePattern.Cached.RowOrColumnMajor.Returns(data.TablePattern_RowOrColumnMajor);
            return tablePattern;
        }
        
        public static ITextPattern GetTextPattern(PatternsData data)
        {
            ITextPattern textPattern = Substitute.For<ITextPattern>();
            // textPattern.GetSelection
            // textPattern.GetVisibleRanges
            // textPattern.RangeFromChild
            // textPattern.RangeFromPoint
            textPattern.DocumentRange.Returns(data.TextPattern_DocumentRange);
            textPattern.SupportedTextSelection.Returns(data.TextPattern_SupportedTextSelection);
            return textPattern;
        }
        
        public static ITogglePattern GetTogglePattern(PatternsData data)
        {
            ITogglePattern togglePattern = Substitute.For<ITogglePattern>();
            // togglePattern.Toggle().Received();
            // togglePattern.Toggle.SetDockPosition(Arg.Do<DockPosition>(pos => data.DockPattern_DockPosition = pos));
            togglePattern.Current.ToggleState.Returns(data.TogglePattern_ToggleState);
            return togglePattern;
        }
        
        public static ITransformPattern GetTransformPattern(PatternsData data)
        {
            ITransformPattern transformPattern = Substitute.For<ITransformPattern>();
            // transformPattern.Move
            // transformPattern.Resize
            // transformPattern.Rotate
            // transformPattern.Move(Arg.Do<double>(x, y => transformPattern.GetParentElement().Current.BoundingRectangle.X.Returns(x); transformPattern.GetParentElement().Current.BoundingRectangle.Y.Returns(y)));
            transformPattern.Current.CanMove.Returns(data.TransformPattern_CanMove);
            transformPattern.Current.CanResize.Returns(data.TransformPattern_CanResize);
            transformPattern.Current.CanRotate.Returns(data.TransformPattern_CanRotate);
            transformPattern.Cached.CanMove.Returns(data.TransformPattern_CanMove);
            transformPattern.Cached.CanResize.Returns(data.TransformPattern_CanResize);
            transformPattern.Cached.CanRotate.Returns(data.TransformPattern_CanRotate);
            return transformPattern;
        }
        
        public static IValuePattern GetValuePattern(PatternsData data)
        {
            IValuePattern valuePattern = Substitute.For<IValuePattern>();
            valuePattern.SetValue(Arg.Do<string>(arg => data.ValuePattern_Value = arg));
            IValuePatternInformation valuePatternInformation = Substitute.For<IValuePatternInformation>();
            valuePatternInformation.Value.Returns(data.ValuePattern_Value);
            valuePattern.Current.Returns(valuePatternInformation);
            // FakeSourcePattern sourcePattern = new FakeSourcePattern();
            var sourcePattern = new FakeSourcePattern();
            FakeSourcePattern.Pattern = ValuePattern.Pattern;
            valuePattern.SetSourcePattern(sourcePattern);
            return valuePattern;
        }
        
        public static IWindowPattern GetWindowPattern(PatternsData data)
        {
            IWindowPattern windowPattern = Substitute.For<IWindowPattern>();
            // windowPattern.Close()
            windowPattern.SetWindowVisualState(Arg.Do<WindowVisualState>(state => data.WindowPattern_WindowVisualState = state));
            windowPattern.WaitForInputIdle(data.WindowPattern_Milliseconds);
            
            windowPattern.Current.CanMaximize.Returns(data.WindowPattern_CanMaximize);
            windowPattern.Current.CanMinimize.Returns(data.WindowPattern_CanMinimize);
            windowPattern.Current.IsModal.Returns(data.WindowPattern_IsModal);
            windowPattern.Current.IsTopmost.Returns(data.WindowPattern_IsTopmost);
            windowPattern.Current.WindowInteractionState.Returns(data.WindowPattern_WindowInteractionState);
            windowPattern.Current.WindowVisualState.Returns(data.WindowPattern_WindowVisualState);
            return windowPattern;
        }
        #endregion patterns
        
        public static IFakeUiElement GetAutomationElementExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            return GetAutomationElementExpected(controlType, name, automationId, className, txtValue, 0);
        }
        
        public static IFakeUiElement GetAutomationElementExpected(ControlType controlType, string name, string automationId, string className, string txtValue, int handle)
        {
            return GetAutomationElementExpected(
                new ElementData {
                    Current_ControlType = controlType,
                    Current_Name = name,
                    Current_AutomationId = automationId,
                    Current_ClassName = className,
                    Current_Value = txtValue,
                    Current_ProcessId = 333,
                    Current_NativeWindowHandle = handle
                });
        }
        
        public static IFakeUiElement GetAutomationElementExpected(ElementData data)
        {
            IValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(data.Current_Value)) {
                valuePattern = GetValuePattern(new PatternsData{ ValuePattern_Value = data.Current_Value });
            }
            return GetAutomationElement(data, new IBasePattern[] { valuePattern }, true);
        }
        
        public static  IFakeUiElement GetAutomationElementNotExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            return GetAutomationElementNotExpected(controlType, name, automationId, className, txtValue, 0);
        }
        
        public static  IFakeUiElement GetAutomationElementNotExpected(ControlType controlType, string name, string automationId, string className, string txtValue, int handle)
        {
            return GetAutomationElementNotExpected(
                new ElementData {
                    Current_ControlType = controlType,
                    Current_Name = name,
                    Current_AutomationId = automationId,
                    Current_ClassName = className,
                    Current_Value = txtValue,
                    Current_ProcessId = 333,
                    Current_NativeWindowHandle = handle
                });
        }
        
        public static  IFakeUiElement GetAutomationElementNotExpected(ElementData data)
        {
            IValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(data.Current_Value)) {
                valuePattern = GetValuePattern(new PatternsData{ ValuePattern_Value = data.Current_Value });
            }
            return GetAutomationElement(data, new IBasePattern[] { valuePattern }, false);
        }
        
        private static IFakeUiElement AddPatternAction<T>(AutomationPattern pattern, IEnumerable<IBasePattern> patterns, IFakeUiElement element) where T : IBasePattern
        {
            object patternObject;
            if (patterns.Any(ptrn => ptrn is T)) {
                element.GetCurrentPattern<T>(pattern).Returns<T>((T)element.Patterns.Find(ptrn => ptrn is T));
                element.TryGetCurrentPattern(pattern, out patternObject).Returns(true);
            } else {
                element.TryGetCurrentPattern(pattern, out patternObject).Returns(false);
            }
            
            return element;
        }
        
        internal static IFakeUiElement GetAutomationElement(ControlType controlType, string name, string automationId, string className, IBasePattern[] patterns, bool expected)
        {
            return GetAutomationElement(controlType, name, automationId, className, 0, patterns, expected);
        }
        
        internal static IFakeUiElement GetAutomationElement(ControlType controlType, string name, string automationId, string className, int handle, IBasePattern[] patterns, bool expected)
        {
            var elementData = new ElementData {
                Current_ControlType = controlType,
                Current_Name = name,
                Current_AutomationId = automationId,
                Current_ClassName = className,
                Current_ProcessId = 333
                //Current_NativeWindowHandle = 1234567
            };
            
            if (0 != handle) elementData.Current_NativeWindowHandle = handle;
            
            return GetAutomationElement(elementData, patterns, expected);
        }
        
        internal static IFakeUiElement GetAutomationElement(ElementData data, IBasePattern[] patterns, bool expected)
        {
            // 20140312
            // IFakeUiElement element = Substitute.For<FakeUiElement,ISupportsCached,ISupportsCurrent>();
            IFakeUiElement element = null;
            
            if (Preferences.UseElementsCurrent && !Preferences.UseElementsCached) {
                element = Substitute.For<FakeUiElement,ISupportsCurrent>();
            }
            if (Preferences.UseElementsCached && !Preferences.UseElementsCurrent) {
                element = Substitute.For<FakeUiElement,ISupportsCached>();
            }
            if (Preferences.UseElementsCached && Preferences.UseElementsCurrent) {
                element = Substitute.For<FakeUiElement,ISupportsCached,ISupportsCurrent>();
            }
            if (!Preferences.UseElementsCached && !Preferences.UseElementsCurrent) {
                element = Substitute.For<FakeUiElement>();
            }
            
            if (Preferences.UseElementsCurrent) {
                var current = Substitute.For<IUiElementInformation>();
                current.ProcessId.Returns(data.Current_ProcessId);
                current.ControlType.Returns(data.Current_ControlType);
                current.Name.Returns(!string.IsNullOrEmpty(data.Current_Name) ? data.Current_Name : string.Empty);
                current.AutomationId.Returns(!string.IsNullOrEmpty(data.Current_AutomationId) ? data.Current_AutomationId : string.Empty);
                current.ClassName.Returns(!string.IsNullOrEmpty(data.Current_ClassName) ? data.Current_ClassName : string.Empty);
                current.NativeWindowHandle.Returns(data.Current_NativeWindowHandle);
                element.GetCurrent().Returns<IUiElementInformation>(current);
            }
            
            if (Preferences.UseElementsCached) {
                var cached = Substitute.For<IUiElementInformation>();
                
                cached.ProcessId.Returns(data.Cached_ProcessId);
                cached.ControlType.Returns(data.Cached_ControlType);
                cached.Name.Returns(!string.IsNullOrEmpty(data.Cached_Name) ? data.Cached_Name : string.Empty);
                cached.AutomationId.Returns(!string.IsNullOrEmpty(data.Cached_AutomationId) ? data.Cached_AutomationId : string.Empty);
                cached.ClassName.Returns(!string.IsNullOrEmpty(data.Cached_ClassName) ? data.Cached_ClassName : string.Empty);
                cached.NativeWindowHandle.Returns(data.Cached_NativeWindowHandle);
                element.GetCached().Returns<IUiElementInformation>(cached);
            }
            
            element.Patterns.AddRange(patterns);
            element.GetSupportedPatterns().Returns(element.Patterns.ToArray());
            
            element = AddPatternAction<IDockPattern>(DockPattern.Pattern, patterns, element);
            element = AddPatternAction<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern, patterns, element);
            element = AddPatternAction<IGridItemPattern>(GridItemPattern.Pattern, patterns, element);
            element = AddPatternAction<IGridPattern>(GridPattern.Pattern, patterns, element);
            element = AddPatternAction<IInvokePattern>(InvokePattern.Pattern, patterns, element);
            element = AddPatternAction<IRangeValuePattern>(RangeValuePattern.Pattern, patterns, element);
            element = AddPatternAction<IScrollItemPattern>(ScrollItemPattern.Pattern, patterns, element);
            element = AddPatternAction<IScrollPattern>(ScrollPattern.Pattern, patterns, element);
            element = AddPatternAction<ISelectionItemPattern>(SelectionItemPattern.Pattern, patterns, element);
            element = AddPatternAction<ISelectionPattern>(SelectionPattern.Pattern, patterns, element);
            element = AddPatternAction<ITableItemPattern>(TableItemPattern.Pattern, patterns, element);
            element = AddPatternAction<ITablePattern>(TablePattern.Pattern, patterns, element);
            element = AddPatternAction<ITextPattern>(TextPattern.Pattern, patterns, element);
            element = AddPatternAction<ITogglePattern>(TogglePattern.Pattern, patterns, element);
            element = AddPatternAction<ITransformPattern>(TransformPattern.Pattern, patterns, element);
            element = AddPatternAction<IValuePattern>(ValuePattern.Pattern, patterns, element);
            element = AddPatternAction<IWindowPattern>(WindowPattern.Pattern, patterns, element);
            
            if (expected) { element.GetTag().Returns("expected"); }
            
            element.GetSourceElement().Returns(element);
            
            return element;
        }
        
        private static IUiElement GetAutomationElementForObjectModelTesting(ControlType controlType, string name, string automationId, string className, IBasePattern[] patterns, bool expected)
        {
            var fakeElement =
                GetAutomationElement(
                    controlType,
                    name,
                    automationId,
                    className,
                    patterns,
                    expected);
            
            var proxiedElement =
                AutomationFactory.GetUiElement(
                    fakeElement as IUiElement);
            
            return proxiedElement;
        }
        
        public static IUiElement GetAutomationElementForMethodsOfObjectModel(IBasePattern[] patterns)
        {
            return GetAutomationElementForObjectModelTesting(ControlType.Button, string.Empty, string.Empty, string.Empty, patterns, true);
        }
        
        public static GetControlCmdletBase Get_GetControlCmdletBase(ControlType[] controlTypes, string name, string automationId, string className, string txtValue)
        {
            GetControlCmdletBase cmdlet = Substitute.For<GetControlCmdletBase>();
            
            if (null != controlTypes && 0 < controlTypes.Length) {
                
                cmdlet.ControlType.Returns<string[]>(controlTypes.Select(
                    ct =>
                    null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray());
            } else {
                cmdlet.ControlType.Returns(new string[] {});
            }
            
            cmdlet.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            cmdlet.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            cmdlet.Class.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            cmdlet.Value.Returns(!string.IsNullOrEmpty(txtValue) ? txtValue : string.Empty);
            return cmdlet;
        }
        
        public static GetControlCmdletBase Get_GetControlCmdletBase(ControlType controlType, string searchString)
        {
            GetControlCmdletBase cmdlet = Substitute.For<GetControlCmdletBase>();
            if (null != controlType) {
                cmdlet.ControlType.Returns(
                    new[] {
                        controlType.ProgrammaticName.Substring(12)
                    }
                   );
            }
            cmdlet.ContainsText.Returns(!string.IsNullOrEmpty(searchString) ? searchString : string.Empty);
            return cmdlet;
        }
        
        public static IUiElement GetElement_ForFindAll(IEnumerable<IUiElement> elements, Condition conditions)
        {
            var elementBeforeProxy =
                GetAutomationElement(ControlType.Pane, string.Empty, string.Empty, string.Empty, new IBasePattern[] {}, false);
            
            var element =
                AutomationFactory.GetUiElement(
                    elementBeforeProxy as IUiElement);
            
            Condition[] condCollection = null;
            if (null != conditions as AndCondition) {
                condCollection = (conditions as AndCondition).GetConditions();
            }
            
            if (null != conditions as OrCondition) {
                condCollection = (conditions as OrCondition).GetConditions();
            }
            
            IUiEltCollection descendants =
                AutomationFactory.GetUiEltCollection();
            descendants.SourceCollection.AddRange(
                AutomationFactory.GetUiEltCollection(elements)
                .ToArray().Where(elt => "expected" == elt.GetTag()));
            
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Button)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.Button));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Calendar)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.Calendar));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.CheckBox)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.CheckBox));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.ComboBox)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.ComboBox));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Custom)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.Custom));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.DataItem)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.DataItem));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Document)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.Document));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Image)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.Image));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.TreeItem)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.TreeItem));
//            element.FindAll(TreeScope.Descendants, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Window)).Returns<IEnumerable<IUiElement>>(descendants.ToArray().Select(elt => elt.Current.ControlType == ControlType.Window));
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants);
            
            IUiEltCollection children =
                AutomationFactory.GetUiEltCollection();
            children.SourceCollection.AddRange(
                AutomationFactory.GetUiEltCollection(elements)
                .ToArray().Where(elt => "expected" == elt.GetTag()));
            
//            element.FindAll(
//                TreeScope.Children,
//                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)).Returns<IEnumerable>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Button));
//            element.FindAll(
//                TreeScope.Children,
//                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)).Returns<IEnumerable>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Document));
//            element.FindAll(
//                TreeScope.Children,
//                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Image)).Returns<IEnumerable>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Image));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Button)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Button));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Calendar)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Calendar));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.CheckBox)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.CheckBox));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.ComboBox)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.ComboBox));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Custom)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Custom));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.DataItem)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.DataItem));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Document)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Document));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Image)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Image));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.TreeItem)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.TreeItem));
//            element.FindAll(TreeScope.Children, Arg.Is<PropertyCondition>(x => (x as PropertyCondition).Value == ControlType.Window)).Returns<IEnumerable<IUiElement>>(children.ToArray().Select(elt => elt.Current.ControlType == ControlType.Window));
            element.FindAll(TreeScope.Children, Arg.Any<Condition>()).Returns(children);
            
            return element;
        }
        
        public static IUiEltCollection GetFakeCollection(IEnumerable<IUiElement> elements)
        {
            var collection = Substitute.For<IUiEltCollection>();
            collection.Count.Returns(elements.Count());
            collection.ToArray().Returns(elements);
            return collection;
        }
        
        public static IAutomation GetAutomationRoot()
        {
            var automation = Substitute.For<IAutomation>();
            
            return automation;
        }
        
        internal static ControlFromWin32Provider GetControlFromWin32Provider_old(IEnumerable<IUiElement> collection, SingleControlSearcherData data)
        {
            var controlProvider = Substitute.For<ControlFromWin32Provider>();
            controlProvider.GetElements(Arg.Any<SingleControlSearcherData>()).Returns(collection.ToList<IUiElement>());
            var data1 = data as SearcherTemplateData;
            controlProvider.SearchData.Returns(data1);
            return controlProvider;
        }
        
        internal static ControlFromWin32Provider GetControlFromWin32Provider_in_progress(IEnumerable<IUiElement> collection, SingleControlSearcherData data)
        {
            var controlProvider = Substitute.For<ControlFromWin32Provider>();
            // controlProvider.GetElements(Arg.Any<SingleControlSearcherData>()).Returns(collection.ToList<IUiElement>());
            // TODO: need to separate the input collection (LoadElements) from the output collection (FilterElements -> collection) 
            controlProvider.FilterElements(Arg.Any<SingleControlSearcherData>(), Arg.Any<List<IUiElement>>()).Returns(collection.ToList<IUiElement>());
            var data1 = data as SearcherTemplateData;
            controlProvider.SearchData.Returns(data1);
            return controlProvider;
        }
        
        internal static HandleCollector GetHandleCollector(IUiElement element, IEnumerable<int> handles, IUiElement[] collection)
        {
            var handleCollector = Substitute.For<HandleCollector>();
            var handleCollection =
                new List<IntPtr>();
            handles.All(h => { handleCollection.Add(new IntPtr(h)); return true; });
            
            handleCollector.CollectRecursively(
                Arg.Any<IUiElement>(),
                Arg.Any<string>(),
                1).Returns(handleCollection);
            
            if (null == collection || 0 == collection.Length) {
                handleCollector.GetElementsFromHandles(Arg.Any<List<IntPtr>>()).Returns(new List<IUiElement>());
            } else {
                handleCollector.GetElementsFromHandles(handleCollection).Returns(collection.ToList<IUiElement>());
            }
            
            return handleCollector;
        }
    }
}
