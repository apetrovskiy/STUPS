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
            AutomationFactory.InitUnitTests();
        }
        
        #region patterns
        public static IMySuperDockPattern GetDockPattern(PatternsData data)
        {
            var dockPattern = Substitute.For<IMySuperDockPattern>();
            // dockPattern.SetDockPosition(Arg.Any<DockPosition>()).Received();
            dockPattern.Current.DockPosition.Returns(data.DockPattern_DockPosition);
            dockPattern.Cached.DockPosition.Returns(data.DockPattern_DockPosition);
            return dockPattern;
        }
        
        public static IMySuperExpandCollapsePattern GetExpandCollapsePattern(PatternsData data)
        {
            IMySuperExpandCollapsePattern expandCollapsePattern = Substitute.For<IMySuperExpandCollapsePattern>();
            // expandCollapsePattern.Collapse().Received();
            // expandCollapsePattern.Expand().Received();
            expandCollapsePattern.Current.ExpandCollapseState.Returns(data.ExpandCollapsePattern_ExpandCollapseState);
            expandCollapsePattern.Cached.ExpandCollapseState.Returns(data.ExpandCollapsePattern_ExpandCollapseState);
            return expandCollapsePattern;
        }
        
        public static IMySuperGridItemPattern GetGridItemPattern(PatternsData data)
        {
            var gridItemPattern = Substitute.For<IMySuperGridItemPattern>();
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
        
        public static IMySuperGridPattern GetGridPattern(PatternsData data)
        {
            var gridPattern = Substitute.For<IMySuperGridPattern>();
            // gridPattern.GetItem(
            gridPattern.Current.ColumnCount.Returns(data.GridPattern_ColumnCount);
            gridPattern.Current.RowCount.Returns(data.GridPattern_RowCount);
            gridPattern.Cached.ColumnCount.Returns(data.GridPattern_ColumnCount);
            gridPattern.Cached.RowCount.Returns(data.GridPattern_RowCount);
            return gridPattern;
        }
        
        public static IMySuperInvokePattern GetInvokePattern(PatternsData data)
        {
            IMySuperInvokePattern invokePattern = Substitute.For<IMySuperInvokePattern>();
            // invokePattern.Invoke
            return invokePattern;
        }
        
        public static IMySuperRangeValuePattern GetRangeValuePattern(PatternsData data)
        {
            IMySuperRangeValuePattern rangeValuePattern = Substitute.For<IMySuperRangeValuePattern>();
            // rangeValuePattern.SetValue(Arg.Any<int>()).Returns(data.RangeValuePattern_ValueSet);
            
            rangeValuePattern.Current.IsReadOnly.Returns(data.RangeValuePattern_IsReadOnly);
            rangeValuePattern.Current.LargeChange.Returns(data.RangeValuePattern_LargeChange);
            rangeValuePattern.Current.Maximum.Returns(data.RangeValuePattern_Maximum);
            rangeValuePattern.Current.Minimum.Returns(data.RangeValuePattern_Minimum);
            rangeValuePattern.Current.SmallChange.Returns(data.RangeValuePattern_SmallChange);
            rangeValuePattern.Current.Value.Returns(data.RangeValuePattern_Value);
            return rangeValuePattern;
        }
        
        public static IMySuperScrollItemPattern GetScrollItemPattern(PatternsData data)
        {
            IMySuperScrollItemPattern scrollItemPattern = Substitute.For<IMySuperScrollItemPattern>();
            // scrollItemPattern.ScrollIntoView().Received();
            return scrollItemPattern;
        }
        
        public static IMySuperScrollPattern GetScrollPattern(PatternsData data)
        {
            IMySuperScrollPattern scrollPattern = Substitute.For<IMySuperScrollPattern>();
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
        
        public static IMySuperSelectionItemPattern GetSelectionItemPattern(PatternsData data)
        {
            IMySuperSelectionItemPattern selectionItemPattern = Substitute.For<IMySuperSelectionItemPattern>();
            // selectionItemPattern.AddToSelection()
            // selectionItemPattern.RemoveFromSelection()
            // selectionItemPattern.Select()
            
            selectionItemPattern.Current.IsSelected.Returns(data.SelectionItemPattern_IsSelected);
            selectionItemPattern.Current.SelectionContainer.Returns(data.SelectionItemPattern_SelectionContainer);
            
            selectionItemPattern.Cached.IsSelected.Returns(data.SelectionItemPattern_IsSelected);
            selectionItemPattern.Cached.SelectionContainer.Returns(data.SelectionItemPattern_SelectionContainer);
            
            return selectionItemPattern;
        }
        
        public static IMySuperSelectionPattern GetSelectionPattern(PatternsData data)
        {
            IMySuperSelectionPattern selectionPattern = Substitute.For<IMySuperSelectionPattern>();
            //selectionPattern.Current.GetSelection()
            
            selectionPattern.Current.CanSelectMultiple.Returns(data.SelectionPattern_CanSelectMultiple);
            selectionPattern.Current.IsSelectionRequired.Returns(data.SelectionPattern_IsSelectionRequired);
            
            selectionPattern.Cached.CanSelectMultiple.Returns(data.SelectionPattern_CanSelectMultiple);
            selectionPattern.Cached.IsSelectionRequired.Returns(data.SelectionPattern_IsSelectionRequired);
            
            return selectionPattern;
        }
        
        public static IMySuperTableItemPattern GetTableItemPattern(PatternsData data)
        {
            IMySuperTableItemPattern tableItemPattern = Substitute.For<IMySuperTableItemPattern>();
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
        
        public static IMySuperTablePattern GetTablePattern(PatternsData data)
        {
            IMySuperTablePattern tablePattern = Substitute.For<IMySuperTablePattern>();
            tablePattern.Current.ColumnCount.Returns(data.TablePattern_ColumnCount);
            tablePattern.Current.RowCount.Returns(data.TablePattern_RowCount);
            tablePattern.Current.RowOrColumnMajor.Returns(data.TablePattern_RowOrColumnMajor);
            tablePattern.Cached.ColumnCount.Returns(data.TablePattern_ColumnCount);
            tablePattern.Cached.RowCount.Returns(data.TablePattern_RowCount);
            tablePattern.Cached.RowOrColumnMajor.Returns(data.TablePattern_RowOrColumnMajor);
            return tablePattern;
        }
        
        public static IMySuperTextPattern GetTextPattern(PatternsData data)
        {
            IMySuperTextPattern textPattern = Substitute.For<IMySuperTextPattern>();
            // textPattern.GetSelection
            // textPattern.GetVisibleRanges
            // textPattern.RangeFromChild
            // textPattern.RangeFromPoint
            textPattern.DocumentRange.Returns(data.TextPattern_DocumentRange);
            textPattern.SupportedTextSelection.Returns(data.TextPattern_SupportedTextSelection);
            return textPattern;
        }
        
        public static IMySuperTogglePattern GetTogglePattern(PatternsData data)
        {
            IMySuperTogglePattern togglePattern = Substitute.For<IMySuperTogglePattern>();
            // togglePattern.Toggle().Received();
            
            togglePattern.Current.ToggleState.Returns(data.TogglePattern_ToggleState);
            return togglePattern;
        }
        
        public static IMySuperTransformPattern GetTransformPattern(PatternsData data)
        {
            IMySuperTransformPattern transformPattern = Substitute.For<IMySuperTransformPattern>();
            // transformPattern.Move
            // transformPattern.Resize
            // transformPattern.Rotate
            transformPattern.Current.CanMove.Returns(data.TransformPattern_CanMove);
            transformPattern.Current.CanResize.Returns(data.TransformPattern_CanResize);
            transformPattern.Current.CanRotate.Returns(data.TransformPattern_CanRotate);
            transformPattern.Cached.CanMove.Returns(data.TransformPattern_CanMove);
            transformPattern.Cached.CanResize.Returns(data.TransformPattern_CanResize);
            transformPattern.Cached.CanRotate.Returns(data.TransformPattern_CanRotate);
            return transformPattern;
        }
        
        public static IMySuperValuePattern GetValuePattern(PatternsData data)
        {
            IMySuperValuePattern valuePattern = Substitute.For<IMySuperValuePattern>();
            IValuePatternInformation valuePatternInformation = Substitute.For<IValuePatternInformation>();
            valuePatternInformation.Value.Returns(data.ValuePattern_Value);
            valuePattern.Current.Returns(valuePatternInformation);
            FakeSourcePattern sourcePattern = new FakeSourcePattern();
            FakeSourcePattern.Pattern = ValuePattern.Pattern;
            valuePattern.SetSourcePattern(sourcePattern);
            return valuePattern;
        }
        
        public static IMySuperWindowPattern GetWindowPattern(PatternsData data)
        {
            IMySuperWindowPattern windowPattern = Substitute.For<IMySuperWindowPattern>();
            // windowPattern.Close()
            windowPattern.SetWindowVisualState(data.WindowPattern_WindowVisualStateSet);
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
            IMySuperValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(txtValue)) {
                valuePattern = FakeFactory.GetValuePattern(new PatternsData{ ValuePattern_Value = txtValue });
            }
            return GetAutomationElement(controlType, name, automationId, className, new IBasePattern[] { valuePattern }, true);
        }
        
        public static  IFakeUiElement GetAutomationElementNotExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            IMySuperValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(txtValue)) {
                valuePattern = FakeFactory.GetValuePattern(new PatternsData{ ValuePattern_Value = txtValue });
            }
            return GetAutomationElement(controlType, name, automationId, className, new IBasePattern[] { valuePattern }, false);
        }
        
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
            
            TestPattern<IMySuperDockPattern>(DockPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperExpandCollapsePattern>(ExpandCollapsePattern.Pattern, patterns, ref element);
            TestPattern<IMySuperGridItemPattern>(GridItemPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperGridPattern>(GridPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperInvokePattern>(InvokePattern.Pattern, patterns, ref element);
            TestPattern<IMySuperRangeValuePattern>(RangeValuePattern.Pattern, patterns, ref element);
            TestPattern<IMySuperScrollItemPattern>(ScrollItemPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperScrollPattern>(ScrollPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperSelectionItemPattern>(SelectionItemPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperSelectionPattern>(SelectionPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperTableItemPattern>(TableItemPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperTablePattern>(TablePattern.Pattern, patterns, ref element);
            TestPattern<IMySuperTextPattern>(TextPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperTogglePattern>(TogglePattern.Pattern, patterns, ref element);
            TestPattern<IMySuperTransformPattern>(TransformPattern.Pattern, patterns, ref element);
            TestPattern<IMySuperValuePattern>(ValuePattern.Pattern, patterns, ref element);
            TestPattern<IMySuperWindowPattern>(WindowPattern.Pattern, patterns, ref element);
            /*
            if (patterns.Any(ptrn => ptrn is IMySuperDockPattern)) {
                element.GetCurrentPattern<IMySuperDockPattern>(DockPattern.Pattern).Returns<IMySuperDockPattern>(element.Patterns.Find(ptrn => ptrn is IMySuperDockPattern) as IMySuperDockPattern);
                element.TryGetCurrentPattern(DockPattern.Pattern, out patternObject).Returns(true);
            }
            element.GetCurrentPattern<IMySuperExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Returns<IMySuperExpandCollapsePattern>(element.Patterns.Find(ptrn => ptrn is IMySuperExpandCollapsePattern) as IMySuperExpandCollapsePattern);
            element.GetCurrentPattern<IMySuperGridItemPattern>(GridItemPattern.Pattern).Returns<IMySuperGridItemPattern>(element.Patterns.Find(ptrn => ptrn is IMySuperGridItemPattern) as IMySuperGridItemPattern);
            element.GetCurrentPattern<IMySuperGridPattern>(GridPattern.Pattern).Returns<IMySuperGridPattern>(element.Patterns.Find(ptrn => ptrn is IMySuperGridPattern) as IMySuperGridPattern);
            element.GetCurrentPattern<IMySuperInvokePattern>(InvokePattern.Pattern).Returns<IMySuperInvokePattern>(element.Patterns.Find(ptrn => ptrn is IMySuperInvokePattern) as IMySuperInvokePattern);
            element.GetCurrentPattern<IMySuperRangeValuePattern>(RangeValuePattern.Pattern).Returns<IMySuperRangeValuePattern>(element.Patterns.Find(ptrn => ptrn is IMySuperRangeValuePattern) as IMySuperRangeValuePattern);
            element.GetCurrentPattern<IMySuperScrollItemPattern>(ScrollItemPattern.Pattern).Returns<IMySuperScrollItemPattern>(element.Patterns.Find(ptrn => ptrn is IMySuperScrollItemPattern) as IMySuperScrollItemPattern);
            element.GetCurrentPattern<IMySuperScrollPattern>(ScrollPattern.Pattern).Returns<IMySuperScrollPattern>(element.Patterns.Find(ptrn => ptrn is IMySuperScrollPattern) as IMySuperScrollPattern);
            
            element.GetCurrentPattern<IMySuperTogglePattern>(TogglePattern.Pattern).Returns<IMySuperTogglePattern>(element.Patterns.Find(ptrn => ptrn is IMySuperTogglePattern) as IMySuperTogglePattern);
            element.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern).Returns<IMySuperValuePattern>(element.Patterns.Find(ptrn => ptrn is IMySuperValuePattern) as IMySuperValuePattern);
//            object patternObject;
            element.TryGetCurrentPattern(ValuePattern.Pattern, out patternObject).Returns(true);
            */
            if (expected) { element.Tag.Returns("expected"); }
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
        
        internal static IUiElement GetAutomationElementForMethodsOfObjectModel(IBasePattern[] patterns)
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
        
        public static IFakeUiElement GetElement_ForFindAll(IEnumerable<IUiElement> elements, Condition conditions)
        {
            IFakeUiElement element =
                GetAutomationElement(ControlType.Pane, string.Empty, string.Empty, string.Empty, new IBasePattern[] {}, false);
            IUiEltCollection descendants = AutomationFactory.GetUiEltCollection(elements);
            
            Condition[] condCollection = null;
            if (null != conditions as AndCondition) {
                condCollection = (conditions as AndCondition).GetConditions();
            }
            
            if (null != conditions as OrCondition) {
                condCollection = (conditions as OrCondition).GetConditions();
            }
            
            IUiEltCollection descendants2 = AutomationFactory.GetUiEltCollection();
            foreach (IUiElement elt in descendants
                .Cast<IUiElement>()
                .Where(elt => "expected" == elt.Tag))
            {
                descendants2.SourceCollection.Add(elt);
            }
            
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants2);
            return element;
        }
    }
    
    public class FakeSourcePattern
    {
        public static AutomationPattern Pattern { get; set; }
    }
}
