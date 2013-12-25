/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/21/2013
 * Time: 12:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PSTestLib;
    
    /// <summary>
    /// Description of ExtensionMethodsElementPatterns.
    /// </summary>
    public static class ExtensionMethodsElementPatterns
    {
        #region Patterns
        #region DockPattern
        public static IUiElement PerformSetDockPosition(this IUiElement element, DockPosition dockPosition)
        {
            try {
                element.GetCurrentPattern<IDockPattern>(DockPattern.Pattern).SetDockPosition(dockPosition);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static DockPosition GetDockPosition(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IDockPattern>(DockPattern.Pattern).Current.DockPosition;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return DockPosition.None;
        }
        #endregion DockPattern
        #region ExpandCollapsePattern
        public static IUiElement PerformExpand(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Expand();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformCollapse(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Collapse();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static ExpandCollapseState GetExpandCollapseState(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Current.ExpandCollapseState;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return ExpandCollapseState.LeafNode;
        }
        #endregion ExpandCollapsePattern
        #region GridItemPattern
        public static int GetRowGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(GridItemPattern.Pattern).Current.Row;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(GridItemPattern.Pattern).Current.Column;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        
        public static int GetRowSpanGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(GridItemPattern.Pattern).Current.RowSpan;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnSpanGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(GridItemPattern.Pattern).Current.ColumnSpan;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static IUiElement GetContainingGridGridItemPattern(this IUiElement element)
        {
            try {
                return AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridItemPattern>(GridItemPattern.Pattern).Current.ContainingGrid.GetSourceElement());
                
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return null;
        }
        #endregion GridItemPattern
        #region GridPattern
        public static IUiElement PerformGetItem(this IUiElement element, int row, int column)
        {
            try {
                // return element.GetCurrentPattern<IGridPattern>(GridPattern.Pattern).GetItem(row, column);
                return AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridPattern>(GridPattern.Pattern).GetItem(row, column).GetSourceElement());
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return null;
        }
        
        public static int GetRowCountGridPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridPattern>(GridPattern.Pattern).Current.RowCount;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnCountGridPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridPattern>(GridPattern.Pattern).Current.ColumnCount;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        #endregion GridPattern
        #region InvokePattern
        public static IUiElement PerformClick(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformCoordinatedClick(this IUiElement element, int X, int Y)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                50,
                X,
                Y);
            
            return element;
        }
        
        public static IUiElement PerformDoubleClick(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformCoordinatedDoubleClick(this IUiElement element, int X, int Y)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                50,
                X,
                Y);
            
            return element;
        }
        
        public static IUiElement PerformRightClick(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                true,
                false,
                false,
                false,
                false,
                false,
                false,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformCtrlClick(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                false,
                true,
                false,
                false,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformAltClick(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                true,
                false,
                false,
                false,
                false,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformShiftClick(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformContextMenu(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            cmdlet.ClickControl(
                cmdlet,
                element,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                50,
                Preferences.ClickOnControlByCoordX,
                Preferences.ClickOnControlByCoordY);
            
            return element;
        }
        
        public static IUiElement PerformInvokeContextMenu(this IUiElement element)
        {
            HasControlInputCmdletBase cmdlet =
                new HasControlInputCmdletBase();
            
            element.InvokeContextMenu(cmdlet);
            
            return element;
        }
        #endregion InvokePattern
        #region RangeValuePattern
        public static IUiElement PerformSetValueRangeValuePattern(this IUiElement element, double value)
        {
            try {
                element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).SetValue(value);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static double PerformGetValueRangeValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Current.Value;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static bool GetIsReadOnlyRangeValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Current.IsReadOnly;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return true;
        }
        
        public static double GetMaximum(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Current.Maximum;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetMinimum(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Current.Minimum;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetLargeChange(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Current.LargeChange;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetSmallChange(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(RangeValuePattern.Pattern).Current.SmallChange;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        #endregion RangeValuePattern
        #region ScrollItemPattern
        public static IUiElement PerformScrollIntoView(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<IScrollItemPattern>(ScrollItemPattern.Pattern).ScrollIntoView();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        #endregion ScrollItemPattern
        #region ScrollPattern
        public static IUiElement PerformSetScrollPercent(this IUiElement element, double horizontalPercent, double verticalPercent)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).SetScrollPercent(horizontalPercent, verticalPercent);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformScroll(this IUiElement element, ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Scroll(horizontalAmount, verticalAmount);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformScrollHorizontal(this IUiElement element, ScrollAmount amount)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).ScrollHorizontal(amount);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformScrollVertical(this IUiElement element, ScrollAmount amount)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).ScrollVertical(amount);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static double GetHorizontalScrollPercent(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Current.HorizontalScrollPercent;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetVerticalScrollPercent(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Current.VerticalScrollPercent;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetHorizontalViewSize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Current.HorizontalViewSize;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetVerticalViewSize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Current.VerticalViewSize;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static bool GetHorizontallyScrollable(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Current.HorizontallyScrollable;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetVerticallyScrollable(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(ScrollPattern.Pattern).Current.VerticallyScrollable;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return false;
        }
        #endregion ScrollPattern
        #region SelectionItemPattern
        public static IUiElement PerformSelect(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Select();
            }
            catch {
                //
            }
            return element;
        }
        
        public static IUiElement PerformAddToSelection(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).AddToSelection();
            }
            catch {
                // 
            }
            return element;
        }
        
        public static IUiElement PerformRemoveFromSelection(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).RemoveFromSelection();
            }
            catch {
                // 
            }
            return element;
        }
        
        public static bool GetIsSelected(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Current.IsSelected;
            }
            catch {
                //
            }
            return false;
        }
        
        public static IUiElement GetSelectionContainer(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionItemPattern>(SelectionItemPattern.Pattern).Current.SelectionContainer;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return null;
        }
        #endregion SelectionItemPattern
        #region SelectionPattern
        public static IUiElement[] PerformGetSelectionSelectionPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionPattern>(SelectionPattern.Pattern).Current.GetSelection();
            }
            catch (Exception eExtensionMethod) {
                // 
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static bool GetCanSelectMultiple(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionPattern>(SelectionPattern.Pattern).Current.CanSelectMultiple;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetIsSelectionRequired(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionPattern>(SelectionPattern.Pattern).Current.IsSelectionRequired;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return false;
        }
        #endregion SelectionPattern
        #region TableItemPattern
        public static IUiElement[] PerformGetRowHeaderItems(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.GetRowHeaderItems();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static IUiElement[] PerformGetColumnHeaderItems(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.GetColumnHeaderItems();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static int GetRowTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.Row;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.Column;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetRowSpanTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.RowSpan;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnSpanTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.ColumnSpan;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static IUiElement GetContainingGridTableItemPattern(this IUiElement element)
        {
            try {
                return AutomationFactory.GetUiElement(element.GetCurrentPattern<ITableItemPattern>(TableItemPattern.Pattern).Current.ContainingGrid.GetSourceElement());
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return null;
        }
        #endregion TableItemPattern
        #region TablePattern
        public static IUiElement[] PerformGetRowHeaders(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.GetRowHeaders();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static IUiElement[] PerformGetColumnHeaders(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.GetColumnHeaders();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static int GetRowCountTablePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.RowCount;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
        }
        
		public static int GetColumnCountTablePattern(this IUiElement element)
		{
		    try {
                return element.GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.ColumnCount;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return 0;
		}
		
		public static RowOrColumnMajor GetRowOrColumnMajor(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITablePattern>(TablePattern.Pattern).Current.RowOrColumnMajor;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return RowOrColumnMajor.Indeterminate;
		}
        #endregion TablePattern
        #region TextPattern
        public static TextPatternRange[] PerformGetSelectionTextPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(TextPattern.Pattern).GetSelection();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return new TextPatternRange[] {};
        }
        
		public static TextPatternRange[] PerformGetVisibleRanges(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITextPattern>(TextPattern.Pattern).GetVisibleRanges();
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return new TextPatternRange[] {};
		}
		
		public static TextPatternRange PerformRangeFromChild(this IUiElement element, IUiElement childElement)
		{
		    try {
		        return element.GetCurrentPattern<ITextPattern>(TextPattern.Pattern).RangeFromChild(childElement);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
		    return null;
		}
		
		public static TextPatternRange PerformRangeFromPoint(this IUiElement element, System.Windows.Point screenLocation)
		{
		    try {
		        return element.GetCurrentPattern<ITextPattern>(TextPattern.Pattern).RangeFromPoint(screenLocation);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
		    return null;
		}
		
		public static TextPatternRange GetDocumentRange(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITextPattern>(TextPattern.Pattern).DocumentRange;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
		    return null;
		}
		
		public static SupportedTextSelection GetSupportedTextSelection(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITextPattern>(TextPattern.Pattern).SupportedTextSelection;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
		    return SupportedTextSelection.None;
		}
        #endregion TextPattern
        #region TogglePattern
        public static IUiElement PerformToggle(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Toggle();
            }
            catch {
                // maybe, a click
            }
            return element;
        }
        
        public static ToggleState GetToggleState(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITogglePattern>(TogglePattern.Pattern).Current.ToggleState;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return ToggleState.Indeterminate;
        }
        #endregion TogglePattern
        #region TransformPattern
        public static IUiElement PerformMove(this IUiElement element, double x, double y)
        {
            try {
                element.GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Move(x, y);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
		
		public static IUiElement PerformResize(this IUiElement element, double width, double height)
		{
		    try {
		        element.GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Resize(width, height);
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return element;
		}
		
		public static IUiElement PerformRotate(this IUiElement element, double degrees)
		{
		    try {
		        element.GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Rotate(degrees);
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return element;
		}
		
		public static bool GetCanMove(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Current.CanMove;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static bool GetCanResize(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Current.CanResize;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static bool GetCanRotate(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<ITransformPattern>(TransformPattern.Pattern).Current.CanRotate;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
        #endregion TransformPattern
        #region ValuePattern
        public static IUiElement PerformSetValueValuePattern(this IUiElement element, string value)
        {
            try {
                element.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).SetValue(value);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
        public static string PerformGetValueValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Current.Value;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return string.Empty;
        }
        
        public static bool GetIsReadOnlyValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Current.IsReadOnly;
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return false;
        }
        #endregion ValuePattern
        #region WindowPattern
        public static IUiElement PerformSetWindowVisualState(this IUiElement element, WindowVisualState state)
        {
            try {
                element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).SetWindowVisualState(state);
            } catch (Exception eExtensionMethod) {
                // 
                // throw;
            }
            return element;
        }
        
		public static IUiElement PerformClose(this IUiElement element)
		{
		    try {
		        element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Close();
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return element;
		}
		
		public static bool PerformWaitForInputIdle(this IUiElement element, int milliseconds)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).WaitForInputIdle(milliseconds);
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static bool GetCanMaximize(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Current.CanMaximize;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static bool GetCanMinimize(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Current.CanMinimize;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static bool GetIsModal(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Current.IsModal;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static bool GetIsTopmost(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Current.IsTopmost;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return false;
		}
		
		public static WindowInteractionState GetWindowInteractionState(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Current.WindowInteractionState;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return WindowInteractionState.NotResponding;
		}
		
		public static WindowVisualState GetWindowVisualState(this IUiElement element)
		{
		    try {
		        return element.GetCurrentPattern<IWindowPattern>(WindowPattern.Pattern).Current.WindowVisualState;
		    } catch (Exception eExtensionMethod) {
		        // 
		        // throw;
		    }
		    return WindowVisualState.Normal;
		}
        #endregion WindowPattern
        #region Navigation
        public static IUiElement PerformNavigateToParent(this IUiElement element)
		{
			IUiElement result = null;

			TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);

			try {
				result = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToFirstChild(this IUiElement element)
		{
			IUiElement result = null;

			TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);

			try {
				result = AutomationFactory.GetUiElement(walker.GetFirstChild(element.GetSourceElement()));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToLastChild(this IUiElement element)
		{
			IUiElement result = null;

			TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);

			try {
				result = AutomationFactory.GetUiElement(walker.GetLastChild(element.GetSourceElement()));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToNextSibling(this IUiElement element)
		{
			IUiElement result = null;

			TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);

			try {
				result = AutomationFactory.GetUiElement(walker.GetNextSibling(element.GetSourceElement()));
			} catch {
			}

			return result;
		}

		public static IUiElement PerformNavigateToPreviousSibling(this IUiElement element)
		{
			IUiElement result = null;

			TreeWalker walker = new TreeWalker(System.Windows.Automation.Condition.TrueCondition);

			try {
				result = AutomationFactory.GetUiElement(walker.GetPreviousSibling(element.GetSourceElement()));
			} catch {
			}

			return result;
		}
        #endregion Navigation
        #region Highlighter
        public static IUiElement PerformHighlight(this IUiElement element)
		{
			UiaHelper.Highlight(element);
			return element;
		}
        #endregion Highlighter
        #endregion Patterns
    }
}
