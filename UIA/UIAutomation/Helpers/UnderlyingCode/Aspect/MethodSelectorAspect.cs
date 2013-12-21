/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2013
 * Time: 3:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Reflection;
    using System.Windows.Automation;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of MethodSelectorAspect.
    /// </summary>
    public class MethodSelectorAspect : AbstractInterceptor
    {
        internal static bool AlreadySelected { get; set; }
        
        public override void Intercept(IInvocation invocation)
        {
//            bool returnItself = true;
            
            try {
                if (!AlreadySelected) {
                    AlreadySelected = true;
                    switch (invocation.Method.Name) {
                        #region DockPattern
                        case "SetDockPosition":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetDockPosition(
                                    (DockPosition)invocation.Arguments[0]);
                            break;
                        case "get_DockPosition":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetDockPosition();
                            break;
                        #endregion DockPattern
                        #region ExpandCollapsePattern
                        case "Expand":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformExpand();
                            break;
                        case "Collapse":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformCollapse();
                            break;
                        case "get_ExpandCollapseState":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetExpandCollapseState();
                            break;
                        #endregion ExpandCollapsePattern
                        #region GridItemPattern
                        case "get_GridRow":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowGridItemPattern();
                            break;
                        case "get_GridColumn":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetColumnGridItemPattern();
                            break;
                        case "get_GridRowSpan":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowSpanGridItemPattern();
                            break;
                        case "get_GridColumnSpan":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetColumnSpanGridItemPattern();
                            break;
                        case "get_GridContainingGrid":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetContainingGridGridItemPattern();
                            break;
                        #endregion GridItemPattern
                        #region GridPattern
                        case "GetItem":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetItem(
                                    (int)invocation.Arguments[0],
                                    (int)invocation.Arguments[1]);
                            break;
                        case "get_GridRowCount":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowCountGridPattern();
                            break;
                        case "get_GridColumnCount":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetColumnCountGridPattern();
                            break;
                        #endregion GridPattern
                        #region InvokePattern
                        case "Click":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformClick();
                            // (invocation.Proxy as UiElement).Click();
                            break;
                        case "DoubleClick":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformDoubleClick();
                            break;
                        #endregion InvokePattern
                        #region RangeValuePattern
                        case "set_RangeValue":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetValueRangeValuePattern(
                                    (double)invocation.Arguments[0]);
                            break;
                        case "get_RangeValue":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetValueRangeValuePattern();
                            break;
                        case "get_RangeIsReadOnly":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsReadOnlyRangeValuePattern();
                            break;
                        case "get_Maximum":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetMaximum();
                            break;
                        case "get_Minimum":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetMinimum();
                            break;
                        case "get_LargeChange":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetLargeChange();
                            break;
                        case "get_SmallChange":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetSmallChange();
                            break;
                        #endregion RangeValuePattern
                        #region ScrollItemPattern
                        case "ScrollIntoView":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformScrollIntoView();
                            break;
                        #endregion ScrollItemPattern
                        #region ScrollPattern
                        case "SetScrollPercent": //(double horizontalPercent, double verticalPercent);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetScrollPercent(
                                    (double)invocation.Arguments[0],
                                    (double)invocation.Arguments[1]);
                            break;
                        case "Scroll": //(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformScroll(
                                    (ScrollAmount)invocation.Arguments[0],
                                    (ScrollAmount)invocation.Arguments[1]);
                            break;
                        case "ScrollHorizontal": //(ScrollAmount amount);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformScrollHorizontal(
                                    (ScrollAmount)invocation.Arguments[0]);
                            break;
                        case "ScrollVertical": //(ScrollAmount amount);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformScrollVertical(
                                    (ScrollAmount)invocation.Arguments[0]);
                            break;
                        case "get_HorizontalScrollPercent":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetHorizontalScrollPercent();
                            break;
                        case "get_VerticalScrollPercent":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetVerticalScrollPercent();
                            break;
                        case "get_HorizontalViewSize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetHorizontalViewSize();
                            break;
                        case "get_VerticalViewSize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetVerticalViewSize();
                            break;
                        case "get_HorizontallyScrollable":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetHorizontallyScrollable();
                            break;
                        case "get_VerticallyScrollable":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetVerticallyScrollable();
                            break;
                        #endregion ScrollPattern
                        #region SelectionItemPattern
                        case "Select":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSelect();
                            break;
                        case "AddToSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformAddToSelection();
                            break;
                        case "RemoveFromSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformRemoveFromSelection();
                            break;
                        case "get_IsSelected":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsSelected();
                            break;
                        case "get_SelectionContainer":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetSelectionContainer();
                            break;
                        #endregion SelectionItemPattern
                        #region SelectionPattern
                        case "GetSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetSelection();
                            break;
                        case "get_CanSelectMultiple":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanSelectMultiple();
                            break;
                        case "get_IsSelectionRequired":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsSelectionRequired();
                            break;
                        #endregion SelectionPattern
                        #region TableItemPattern
                        case "GetRowHeaderItems":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetRowHeaderItems();
                            break;
                        case "GetColumnHeaderItems":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetColumnHeaderItems();
                            break;
                        case "get_TableRow":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowTableItemPattern();
                            break;
                        case "get_TableColumn":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetColumnTableItemPattern();
                            break;
                        case "get_TableRowSpan":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowSpanTableItemPattern();
                            break;
                        case "get_TableColumnSpan":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetColumnSpanTableItemPattern();
                            break;
                        case "get_TableContainingGrid":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetContainingGridTableItemPattern();
                            break;
                        #endregion TableItemPattern
                        #region TablePattern
                        case "GetRowHeaders":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetRowHeaders();
                            break;
                        case "GetColumnHeaders":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetColumnHeaders();
                            break;
                        case "get_TableRowCount":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowCountTablePattern();
                            break;
                        case "get_TableColumnCount":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetColumnCountTablePattern();
                            break;
                        case "get_RowOrColumnMajor":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetRowOrColumnMajor();
                            break;
                        #endregion TablePattern
                        #region TextPattern
                        case "GetTextSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetSelectionTextPattern();
                            break;
                        case "GetVisibleRanges":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetVisibleRanges();
                            break;
                        case "RangeFromChild": //(AutomationElement childElement);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformRangeFromChild(
                                    (IUiElement)invocation.Arguments[0]);
                            break;
                        case "RangeFromPoint": //(Point screenLocation);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformRangeFromPoint(
                                    (System.Windows.Point)invocation.Arguments[0]);
                            break;
                        case "get_DocumentRange":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetDocumentRange();
                            break;
                        case "get_SupportedTextSelection":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetSupportedTextSelection();
                            break;
                        #endregion TextPattern
                        #region TogglePattern
                        case "Toggle":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformToggle();
                            break;
                        case "get_ToggleState":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetToggleState();
                            break;
                        #endregion TogglePattern
                        #region TransformPattern
                        case "Move":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformMove(
                                    (double)invocation.Arguments[0],
                                    (double)invocation.Arguments[1]);
                            break;
                        case "Resize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformResize(
                                    (double)invocation.Arguments[0],
                                    (double)invocation.Arguments[1]);
                            break;
                        case "Rotate":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformRotate(
                                    (double)invocation.Arguments[0]);
                            break;
                        case "get_CanMove":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanMove();
                            break;
                        case "get_CanResize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanResize();
                            break;
                        case "get_CanRotate":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanRotate();
                            break;
                        #endregion TransformPattern
                        #region ValuePattern
                        case "get_Value":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformGetValueValuePattern();
                            break;
                        case "set_Value":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetValueValuePattern(
                                    invocation.Arguments[0].ToString());
                            break;
                        case "get_IsReadOnly":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsReadOnlyValuePattern();
                            break;
                        #endregion ValuePattern
                        #region WindowPattern
                        case "SetWindowVisualState": //(WindowVisualState state);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformSetWindowVisualState(
                                    (WindowVisualState)invocation.Arguments[0]);
                            break;
                        case "Close":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformClose();
                            break;
                        case "WaitForInputIdle": //(int milliseconds);
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).PerformWaitForInputIdle(
                                    (int)invocation.Arguments[0]);
                            break;
                        case "get_CanMaximize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanMaximize();
                            break;
                        case "get_CanMinimize":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetCanMinimize();
                            break;
                        case "get_IsModal":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsModal();
                            break;
                        case "get_IsTopmost":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetIsTopmost();
                            break;
                        case "get_WindowInteractionState":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetWindowInteractionState();
                            break;
                        case "get_WindowVisualState":
                            invocation.ReturnValue =
                                (invocation.Proxy as IUiElement).GetWindowVisualState();
                            break;
                        #endregion WindowPattern
                        default:
                            invocation.Proceed();
                        	break;
                    }
                    AlreadySelected = false;
                } else {
                    invocation.Proceed();
                }
                if (invocation.ReturnValue == invocation.InvocationTarget) {
                    invocation.ReturnValue = invocation.Proxy;
                }
            }
            catch {
                AlreadySelected = false;
            }
        }
    }
}
