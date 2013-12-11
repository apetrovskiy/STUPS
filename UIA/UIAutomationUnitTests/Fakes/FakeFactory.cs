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
        private static IMySuperDockPattern GetDockPattern(PatternsData data)
        {
            var dockPattern = Substitute.For<IMySuperDockPattern>();
            // dockPattern.SetDockPosition(Arg.Any<DockPosition>()).Received();
            dockPattern.Current.DockPosition.Returns(data.DockPattern_DockPosition);
            dockPattern.Cached.DockPosition.Returns(data.DockPattern_DockPosition);
            return dockPattern;
        }
        
        private static IMySuperExpandCollapsePattern GetExpandCollapsePattern(PatternsData data)
        {
            IMySuperExpandCollapsePattern expandCollapsePattern = Substitute.For<IMySuperExpandCollapsePattern>();
            // expandCollapsePattern.Collapse().Received();
            // expandCollapsePattern.Expand().Received();
            expandCollapsePattern.Current.ExpandCollapseState.Returns(data.ExpandCollapsePattern_ExpandCollapseState);
            expandCollapsePattern.Cached.ExpandCollapseState.Returns(data.ExpandCollapsePattern_ExpandCollapseState);
            return expandCollapsePattern;
        }
        
        private static IMySuperInvokePattern GetInvokePattern()
        {
            IMySuperInvokePattern invokePattern = Substitute.For<IMySuperInvokePattern>();
            return invokePattern;
        }
        
        private static IMySuperRangeValuePattern GetRangeValuePattern(PatternsData data)
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
        
        private static IMySuperScrollItemPattern GetScrollItemPattern()
        {
            IMySuperScrollItemPattern scrollItemPattern = Substitute.For<IMySuperScrollItemPattern>();
            // scrollItemPattern.ScrollIntoView().Received();
            return scrollItemPattern;
        }
        
        private static IMySuperScrollPattern GetScrollPattern(PatternsData data)
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
        
        private static IMySuperSelectionItemPattern GetSelectionItemPattern(PatternsData data)
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
        
        private static IMySuperSelectionPattern GetSelectionPattern(PatternsData data)
        {
            IMySuperSelectionPattern selectionPattern = Substitute.For<IMySuperSelectionPattern>();
            //selectionPattern.Current.GetSelection()
            
            selectionPattern.Current.CanSelectMultiple.Returns(data.SelectionPattern_CanSelectMultiple);
            selectionPattern.Current.IsSelectionRequired.Returns(data.SelectionPattern_IsSelectionRequired);
            
            selectionPattern.Cached.CanSelectMultiple.Returns(data.SelectionPattern_CanSelectMultiple);
            selectionPattern.Cached.IsSelectionRequired.Returns(data.SelectionPattern_IsSelectionRequired);
            
            return selectionPattern;
        }
        
        private static IMySuperTogglePattern GetTogglePattern(PatternsData data)
        {
            IMySuperTogglePattern togglePattern = Substitute.For<IMySuperTogglePattern>();
            // togglePattern.Toggle().Received();
            
            togglePattern.Current.ToggleState.Returns(data.TogglePattern_ToggleState);
            return togglePattern;
        }
        
        private static IMySuperValuePattern GetValuePattern(PatternsData data)
        {
Console.WriteLine("GetValuePattern 00001");
            IMySuperValuePattern valuePattern = Substitute.For<IMySuperValuePattern>();
            IValuePatternInformation valuePatternInformation = Substitute.For<IValuePatternInformation>();
            valuePatternInformation.Value.Returns(data.ValuePattern_Value);
Console.WriteLine("valuePatternInformation.Value = {0}", valuePatternInformation.Value);
            valuePattern.Current.Returns(valuePatternInformation);
Console.WriteLine("valuePattern.Current.Value = {0}", valuePattern.Current.Value);
Console.WriteLine("GetValuePattern 00005");
            FakeSourcePattern sourcePattern = new FakeSourcePattern();
            FakeSourcePattern.Pattern = ValuePattern.Pattern;
            valuePattern.SourcePattern = sourcePattern;
            return valuePattern;
        }
        
        private static IMySuperWindowPattern GetWindowPattern(PatternsData data)
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
        
        // public static IUiElement GetAutomationElementExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        public static IFakeUiElement GetAutomationElementExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            // return GetAutomationElement(controlType, name, automationId, className, txtValue, true);
            IMySuperValuePattern valuePattern = null;
Console.WriteLine("GetAutomationElementExpected 00001");
            if (!string.IsNullOrEmpty(txtValue)) {
Console.WriteLine("GetAutomationElementExpected 00002");
                valuePattern = FakeFactory.GetValuePattern(new PatternsData{ ValuePattern_Value = txtValue });
Console.WriteLine("GetAutomationElementExpected 00003");
Console.WriteLine("FakeFactory.GetValuePattern -> {0}", valuePattern.Current.Value);
            }
Console.WriteLine("GetAutomationElementExpected 00004");
            return GetAutomationElement(controlType, name, automationId, className, new IBasePattern[] { valuePattern }, true);
        }
        
        // public static  IUiElement GetAutomationElementNotExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        public static  IFakeUiElement GetAutomationElementNotExpected(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            // return GetAutomationElement(controlType, name, automationId, className, txtValue, false);
            IMySuperValuePattern valuePattern = null;
            if (!string.IsNullOrEmpty(txtValue)) {
                valuePattern = FakeFactory.GetValuePattern(new PatternsData{ ValuePattern_Value = txtValue });
            }
            return GetAutomationElement(controlType, name, automationId, className, new IBasePattern[] { valuePattern }, false);
        }
        
        // private static IUiElement GetAutomationElement(ControlType controlType, string name, string automationId, string className, string txtValue, bool expected)
        // private static IFakeUiElement GetAutomationElement(ControlType controlType, string name, string automationId, string className, IBasePattern[] patterns, bool expected)
        internal static IFakeUiElement GetAutomationElement(ControlType controlType, string name, string automationId, string className, IBasePattern[] patterns, bool expected)
        {
            // IUiElement element = Substitute.For<IUiElement>();
            IFakeUiElement element = Substitute.For<FakeUiElement>();
            element.Current.ProcessId.Returns(333);
            element.Current.ControlType.Returns(controlType);
            element.Current.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            element.Current.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            element.Current.ClassName.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            // IMySuperValuePattern valuePattern = FakeFactory.GetValuePattern(new PatternsData { ValuePattern_Value = txtValue });
            element.Patterns.AddRange(patterns);
            // element.GetSupportedPatterns().Returns(new AutomationPattern[] { ValuePattern.Pattern });
            element.GetSupportedPatterns().Returns<IBasePattern[]>(element.Patterns.ToArray());
var aaaaa = element.GetSupportedPatterns();
if (null == aaaaa) {
    Console.WriteLine("null == element.GetSupportedPatterns()");
} else {
    Console.WriteLine(aaaaa.GetType().Name);
    Console.WriteLine(aaaaa.Length.ToString());
    if (0 < aaaaa.Length) {
        foreach (var ptrn in aaaaa) {
            if (null == ptrn) {
                Console.WriteLine("null == ptrn");
            } else {
                Console.WriteLine(ptrn.GetType().Name);
                if (null == ptrn.SourcePattern) {
                    Console.WriteLine("null == ptrn.SourcePattern");
                } else {
                    Console.WriteLine(ptrn.SourcePattern.GetType().Name);
                    //Console.WriteLine((ptrn.SourcePattern as AutomationPattern).ProgrammaticName);
                    // Console.WriteLine(ptrn.SourcePattern.Pattern);
                }
            }
        }
    }
}
            // element.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern).Returns(valuePattern);
            element.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern).Returns<IMySuperValuePattern>(element.Patterns.Find(ptrn => ptrn is IMySuperValuePattern) as IMySuperValuePattern);
            object patternObject;
            element.TryGetCurrentPattern(ValuePattern.Pattern, out patternObject).Returns(true);
            if (expected) { element.Tag.Returns("expected"); }
            return element;
        }
        
        // 20131211
        // public static GetControlCmdletBase Get_GetControlCmdletBase(ControlType controlType, string name, string automationId, string className, string txtValue)
        public static GetControlCmdletBase Get_GetControlCmdletBase(ControlType[] controlTypes, string name, string automationId, string className, string txtValue)
        {
//Console.WriteLine("gccb 0001");
            GetControlCmdletBase cmdlet = Substitute.For<GetControlCmdletBase>();
//            if (null != controlType) {
//                cmdlet.ControlType.Returns(
//                    new[] {
//                        controlType.ProgrammaticName.Substring(12)
//                    }
//                   );
//            }
//Console.WriteLine("gccb 0002");
            
            if (null != controlTypes && 0 < controlTypes.Length) {
//Console.WriteLine("gccb 0003");
//Console.WriteLine(controlTypes.Count().ToString());
//if (null == controlTypes[0]) {
//    Console.WriteLine("null == controlTypes[0]");
//} else {
//    Console.WriteLine(controlTypes[0].GetType().Name);
//}
//IEnumerable<string> sss = controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty);
//Console.WriteLine("gccb 0003.1");
//if (null == sss) {
//    Console.WriteLine("null == sss");
//} else {
//    Console.WriteLine(sss.GetType().Name);
//    if (sss.Any()) {
//        // Console.WriteLine(sss.Count().ToString());
//        foreach (string str in sss) {
//            Console.WriteLine(str);
//        }
//    } else {
//        Console.WriteLine("there are no elements");
//    }
//}

                cmdlet.ControlType.Returns<string[]>(controlTypes.Select(
                    ct =>
                    null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray());
//Console.WriteLine("gccb 0004");
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
        
        // public static IUiElement GetElement_ForFindAll(IEnumerable<IUiElement> elements, Condition conditions)
        public static IFakeUiElement GetElement_ForFindAll(IEnumerable<IUiElement> elements, Condition conditions)
        {
            // IUiElement element =
            IFakeUiElement element =
                // GetAutomationElement(ControlType.Pane, string.Empty, string.Empty, string.Empty, string.Empty, false);
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
