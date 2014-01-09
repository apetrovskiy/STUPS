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
    using UIAutomation;
    using NSubstitute;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of FakeFactory.
    /// </summary>
    public class FakeFactory
    {
        public static void Init()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            InitForPowerShell();
            // AutomationFactory.InitUnitTests();
            // UIAutomation.Preferences.UseElementsPatternObjectModel = true;
            // UIAutomation.Preferences.UseElementsSearchObjectModel = true;
        }
        
        public static void InitForPowerShell()
        {
            // UnitTestingHelper.PrepareUnitTestDataStore();
            AutomationFactory.InitUnitTests();
            UIAutomation.Preferences.UseElementsPatternObjectModel = true;
            UIAutomation.Preferences.UseElementsSearchObjectModel = true;
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
                FakeFactory.GetAutomationElement(
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
            FakeSourcePattern sourcePattern = new FakeSourcePattern();
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
            IValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(txtValue)) {
                valuePattern = FakeFactory.GetValuePattern(new PatternsData{ ValuePattern_Value = txtValue });
            }
            return GetAutomationElement(controlType, name, automationId, className, new IBasePattern[] { valuePattern }, true);
        }
        
        public static  IFakeUiElement GetAutomationElementNotExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            IValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(txtValue)) {
                valuePattern = FakeFactory.GetValuePattern(new PatternsData{ ValuePattern_Value = txtValue });
            }
            return GetAutomationElement(controlType, name, automationId, className, new IBasePattern[] { valuePattern }, false);
        }
        
//        private static void TestPattern<T>(AutomationPattern pattern, IBasePattern[] patterns, ref IFakeUiElement element) where T : IBasePattern
//        {
//            object patternObject;
//            if (patterns.Any(ptrn => ptrn is T)) {
//                element.GetCurrentPattern<T>(pattern).Returns<T>((T)element.Patterns.Find(ptrn => ptrn is T));
//                element.TryGetCurrentPattern(pattern, out patternObject).Returns(true);
//            } else {
//                element.TryGetCurrentPattern(pattern, out patternObject).Returns(false);
//            }
//        }
        
        
        /*
        private static void TestPattern<T>(AutomationPattern pattern, IBasePattern[] patterns, ref IFakeUiElement element) where T : IBasePattern
        {
            object patternObject;
            if (patterns.Any(ptrn => ptrn is T)) {
                element.GetCurrentPattern<T>(pattern).Returns<T>((T)element.Patterns.Find(ptrn => ptrn is T));
                element.TryGetCurrentPattern(pattern, out patternObject).Returns(true);
            } else {
                element.TryGetCurrentPattern(pattern, out patternObject).Returns(false);
            }
        }
        */
       
        private static IFakeUiElement AddPatternAction<T>(AutomationPattern pattern, IBasePattern[] patterns, IFakeUiElement element) where T : IBasePattern
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
            IFakeUiElement element = Substitute.For<FakeUiElement>();
            element.Current.ProcessId.Returns(333);
            element.Current.ControlType.Returns(controlType);
            element.Current.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            element.Current.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            element.Current.ClassName.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            element.Patterns.AddRange(patterns);
            element.GetSupportedPatterns().Returns<IBasePattern[]>(element.Patterns.ToArray());
//Console.WriteLine("GetAutomationElement 0010");
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//}
            
//            TestPattern<IDockPattern>(DockPattern.Pattern, patterns, ref element);
//            TestPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern, patterns, ref element);
//            TestPattern<IGridItemPattern>(GridItemPattern.Pattern, patterns, ref element);
//            TestPattern<IGridPattern>(GridPattern.Pattern, patterns, ref element);
//            TestPattern<IInvokePattern>(InvokePattern.Pattern, patterns, ref element);
//            TestPattern<IRangeValuePattern>(RangeValuePattern.Pattern, patterns, ref element);
//            TestPattern<IScrollItemPattern>(ScrollItemPattern.Pattern, patterns, ref element);
//            TestPattern<IScrollPattern>(ScrollPattern.Pattern, patterns, ref element);
//            TestPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern, patterns, ref element);
//            TestPattern<ISelectionPattern>(SelectionPattern.Pattern, patterns, ref element);
//            TestPattern<ITableItemPattern>(TableItemPattern.Pattern, patterns, ref element);
//            TestPattern<ITablePattern>(TablePattern.Pattern, patterns, ref element);
//            TestPattern<ITextPattern>(TextPattern.Pattern, patterns, ref element);
//            TestPattern<ITogglePattern>(TogglePattern.Pattern, patterns, ref element);
//            TestPattern<ITransformPattern>(TransformPattern.Pattern, patterns, ref element);
//            TestPattern<IValuePattern>(ValuePattern.Pattern, patterns, ref element);
//            TestPattern<IWindowPattern>(WindowPattern.Pattern, patterns, ref element);

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
            
            // 20130104
            // if (expected) { element.Tag.Returns("expected"); }
            if (expected) { element.GetTag().Returns("expected"); }
            element.GetSourceElement().Returns<object>(element);
            
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//}
            
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
            
//if (null == fakeElement) {
//    Console.WriteLine("null == fakeElement");
//} else {
//    Console.WriteLine("null != fakeElement");
//}
            
            var proxiedElement =
                AutomationFactory.GetUiElement(
                    fakeElement as IUiElement);
            
//if (null == proxiedElement) {
//    Console.WriteLine("null == proxiedElement");
//} else {
//    Console.WriteLine("null != proxiedElement");
//}
            
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
            
            IUiEltCollection fullListOfElements = AutomationFactory.GetUiEltCollection(elements);
            
            Condition[] condCollection = null;
            if (null != conditions as AndCondition) {
                condCollection = (conditions as AndCondition).GetConditions();
            }
            
            if (null != conditions as OrCondition) {
                condCollection = (conditions as OrCondition).GetConditions();
            }
            
            // emulates FindAll(TreeScope.Descendants, ...)
            IUiEltCollection descendants = AutomationFactory.GetUiEltCollection();
            foreach (IUiElement elt in fullListOfElements
                .Cast<IUiElement>()
                // 20130104
                // .Where(elt => "expected" == elt.Tag))
                .Where(elt => "expected" == elt.GetTag()))
            {
                descendants.SourceCollection.Add(elt);
            }
            
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants);
            
            // 20140105
            // emulates FindAll(TreeScope.Children, ...)
            IUiEltCollection children = AutomationFactory.GetUiEltCollection();
            foreach (IUiElement elt in fullListOfElements
                .Cast<IUiElement>()
                .Where(elt => "expected" == elt.GetTag()))
            {
                children.SourceCollection.Add(elt);
            }
            
            element.FindAll(TreeScope.Children, Arg.Any<Condition>()).Returns(children);
            
            return element;
        }
    }
    
    public class FakeSourcePattern
    {
        public static AutomationPattern Pattern { get; set; }
    }
}
