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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    // using System.Windows.Automation.Text;

    /// <summary>
    /// Description of ExtensionMethodsElementPatterns.
    /// </summary>
    public static class ExtensionMethodsElementPatterns
    {
        #region Patterns
        #region DockPattern
        public static IUiElement PerformSetDockPosition(this IUiElement element, classic.DockPosition dockPosition)
        {
            element.GetCurrentPattern<IDockPattern>(classic.DockPattern.Pattern).SetDockPosition(dockPosition);
            return element;
        }
        
        public static classic.DockPosition GetDockPosition(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IDockPattern>(classic.DockPattern.Pattern).Current.DockPosition;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.DockPosition.None;
        }
        #endregion DockPattern
        #region ExpandCollapsePattern
        public static IUiElement PerformExpand(this IUiElement element)
        {
            element.GetCurrentPattern<IExpandCollapsePattern>(classic.ExpandCollapsePattern.Pattern).Expand();
            return element;
        }
        
        public static IUiElement PerformCollapse(this IUiElement element)
        {
            element.GetCurrentPattern<IExpandCollapsePattern>(classic.ExpandCollapsePattern.Pattern).Collapse();
            return element;
        }
        
        public static classic.ExpandCollapseState GetExpandCollapseState(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IExpandCollapsePattern>(classic.ExpandCollapsePattern.Pattern).Current.ExpandCollapseState;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.ExpandCollapseState.LeafNode;
        }
        #endregion ExpandCollapsePattern
        #region GridItemPattern
        public static int GetRowGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern).Current.Row;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern).Current.Column;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        
        public static int GetRowSpanGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern).Current.RowSpan;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnSpanGridItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern).Current.ColumnSpan;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static IUiElement GetContainingGridGridItemPattern(this IUiElement element)
        {
            try {
                // 20140102
                // return AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern).Current.ContainingGrid.GetSourceElement());
                return AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern).Current.ContainingGrid.GetSourceElement() as classic.AutomationElement);
                
            } catch (Exception) {
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
                // return element.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern).GetItem(row, column);
                return AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern).GetItem(row, column).GetSourceElement());
                
                // 20140102
                // IUiElement eltInExtMethod = AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern).GetItem(row, column).GetSourceElement());
                // IUiElement eltInExtMethod = AutomationFactory.GetUiElement(element.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern).GetItem(row, column).GetSourceElement()); // as AutomationElement);
                
                // return eltInExtMethod;
                
            } catch (Exception) {
                // 
                // throw;
            }
            return null;
        }
        
        public static int GetRowCountGridPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern).Current.RowCount;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnCountGridPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern).Current.ColumnCount;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        #endregion GridPattern
        #region InvokePattern
        public static IUiElement PerformInvoke(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<IInvokePattern>(classic.InvokePattern.Pattern).Invoke();
                return element;
                
            } catch (Exception) {
                // 
                // throw;
                return null;
            }
        }
        
//        public static IUiElement PerformClick(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    // DoubleClickInterval = 50,
//                    RelativeX = Preferences.ClickOnControlByCoordX,
//                    RelativeY = Preferences.ClickOnControlByCoordY
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformCoordinatedClick(this IUiElement element, int X, int Y)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    // DoubleClickInterval = 50,
//                    RelativeX = X,
//                    RelativeY = Y
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformDoubleClick(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    DoubleClick = true,
//                    DoubleClickInterval = 50,
//                    RelativeX = Preferences.ClickOnControlByCoordX,
//                    RelativeY = Preferences.ClickOnControlByCoordY
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformCoordinatedDoubleClick(this IUiElement element, int X, int Y)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    DoubleClick = true,
//                    DoubleClickInterval = 50,
//                    RelativeX = X,
//                    RelativeY = Y
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformRightClick(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    RightClick = true,
//                    // DoubleClickInterval = 50,
//                    RelativeX = Preferences.ClickOnControlByCoordX,
//                    RelativeY = Preferences.ClickOnControlByCoordY
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformCtrlClick(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    Ctrl = true,
//                    // DoubleClickInterval = 50,
//                    RelativeX = Preferences.ClickOnControlByCoordX,
//                    RelativeY = Preferences.ClickOnControlByCoordY
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformAltClick(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    Alt = true,
//                    // DoubleClickInterval = 50,
//                    RelativeX = Preferences.ClickOnControlByCoordX,
//                    RelativeY = Preferences.ClickOnControlByCoordY
//                });
//            
//            return element;
//        }
//        
//        public static IUiElement PerformShiftClick(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            cmdlet.ClickControl(
//                cmdlet,
//                element,
//                new ClickSettings() {
//                    Shift = true,
//                    // DoubleClickInterval = 50,
//                    RelativeX = Preferences.ClickOnControlByCoordX,
//                    RelativeY = Preferences.ClickOnControlByCoordY
//                });
//            
//            return element;
//        }
//        
//        /// <summary>
//        /// Invokes the context menu and returns the object representing the menu invoked.
//        /// </summary>
//        /// <param name="element"></param>
//        /// <returns></returns>
//        public static IUiElement PerformInvokeContextMenu(this IUiElement element)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            
//            // 20131226
//            // element.InvokeContextMenu(cmdlet);
//            
//            // return element;
//            
//            // return the context menu window
//            return element.InvokeContextMenu(cmdlet, Preferences.ClickOnControlByCoordX, Preferences.ClickOnControlByCoordY);
//        }
//        
//        public static IUiElement PerformCoordinatedInvokeContextMenu(this IUiElement element, int X, int Y)
//        {
//            HasControlInputCmdletBase cmdlet =
//                new HasControlInputCmdletBase();
//            
//            // 20131226
//            // element.InvokeContextMenu(cmdlet);
//            
//            // return element;
//            
//            // return the context menu window
//            return element.InvokeContextMenu(cmdlet, X, Y);
//        }
        #endregion InvokePattern
        #region RangeValuePattern
        public static IUiElement PerformSetValueRangeValuePattern(this IUiElement element, double value)
        {
            try {
                element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).SetValue(value);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static double PerformGetValueRangeValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).Current.Value;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static bool GetIsReadOnlyRangeValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).Current.IsReadOnly;
            } catch (Exception) {
                // 
                // throw;
            }
            return true;
        }
        
        public static double GetMaximum(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).Current.Maximum;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetMinimum(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).Current.Minimum;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetLargeChange(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).Current.LargeChange;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetSmallChange(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern).Current.SmallChange;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        #endregion RangeValuePattern
        #region ScrollItemPattern
        public static IUiElement PerformScrollIntoView(this IUiElement element)
        {
            element.GetCurrentPattern<IScrollItemPattern>(classic.ScrollItemPattern.Pattern).ScrollIntoView();
            return element;
        }
        #endregion ScrollItemPattern
        #region ScrollPattern
        public static IUiElement PerformSetScrollPercent(this IUiElement element, double horizontalPercent, double verticalPercent)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).SetScrollPercent(horizontalPercent, verticalPercent);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformScroll(this IUiElement element, classic.ScrollAmount horizontalAmount, classic.ScrollAmount verticalAmount)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Scroll(horizontalAmount, verticalAmount);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformScrollHorizontal(this IUiElement element, classic.ScrollAmount amount)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).ScrollHorizontal(amount);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformScrollVertical(this IUiElement element, classic.ScrollAmount amount)
        {
            try {
                element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).ScrollVertical(amount);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static double GetHorizontalScrollPercent(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Current.HorizontalScrollPercent;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetVerticalScrollPercent(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Current.VerticalScrollPercent;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetHorizontalViewSize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Current.HorizontalViewSize;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static double GetVerticalViewSize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Current.VerticalViewSize;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static bool GetHorizontallyScrollable(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Current.HorizontallyScrollable;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetVerticallyScrollable(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern).Current.VerticallyScrollable;
            } catch (Exception) {
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
                element.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern).Select();
            }
            catch {
                //
            }
            return element;
        }
        
        public static IUiElement PerformAddToSelection(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern).AddToSelection();
            }
            catch {
                // 
            }
            return element;
        }
        
        public static IUiElement PerformRemoveFromSelection(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern).RemoveFromSelection();
            }
            catch {
                // 
            }
            return element;
        }
        
        public static bool GetIsSelected(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern).Current.IsSelected;
            }
            catch {
                //
            }
            return false;
        }
        
        public static IUiElement GetSelectionContainer(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern).Current.SelectionContainer;
            } catch (Exception) {
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
                return element.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern).Current.GetSelection();
            }
            catch (Exception) {
                // 
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static bool GetCanSelectMultiple(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern).Current.CanSelectMultiple;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetIsSelectionRequired(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern).Current.IsSelectionRequired;
            } catch (Exception) {
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
                return element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.GetRowHeaderItems();
            } catch (Exception) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static IUiElement[] PerformGetColumnHeaderItems(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.GetColumnHeaderItems();
            } catch (Exception) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static int GetRowTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.Row;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.Column;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetRowSpanTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.RowSpan;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnSpanTableItemPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.ColumnSpan;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static IUiElement GetContainingGridTableItemPattern(this IUiElement element)
        {
            try {
                // 20140102
                // return AutomationFactory.GetUiElement(element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.ContainingGrid.GetSourceElement());
                return AutomationFactory.GetUiElement(element.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern).Current.ContainingGrid.GetSourceElement() as classic.AutomationElement);
            } catch (Exception) {
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
                return element.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern).Current.GetRowHeaders();
            } catch (Exception) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static IUiElement[] PerformGetColumnHeaders(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern).Current.GetColumnHeaders();
            } catch (Exception) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return new UiElement[] {};
        }
        
        public static int GetRowCountTablePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern).Current.RowCount;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static int GetColumnCountTablePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern).Current.ColumnCount;
            } catch (Exception) {
                // 
                // throw;
            }
            return 0;
        }
        
        public static classic.RowOrColumnMajor GetRowOrColumnMajor(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern).Current.RowOrColumnMajor;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.RowOrColumnMajor.Indeterminate;
        }
        #endregion TablePattern
        #region TextPattern
        public static classic.Text.TextPatternRange[] PerformGetSelectionTextPattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern).GetSelection();
            } catch (Exception) {
                // 
                // throw;
            }
            return new classic.Text.TextPatternRange[] {};
        }
        
        public static classic.Text.TextPatternRange[] PerformGetVisibleRanges(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern).GetVisibleRanges();
            } catch (Exception) {
                // 
                // throw;
            }
            return new classic.Text.TextPatternRange[] {};
        }
        
        public static classic.Text.TextPatternRange PerformRangeFromChild(this IUiElement element, IUiElement childElement)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern).RangeFromChild(childElement);
            } catch (Exception) {
                // 
                // throw;
                // Console.WriteLine(eExtensionMethod.Message);
            }
            return null;
        }
        
        public static classic.Text.TextPatternRange PerformRangeFromPoint(this IUiElement element, System.Windows.Point screenLocation)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern).RangeFromPoint(screenLocation);
            } catch (Exception) {
                // 
                // throw;
            }
            return null;
        }
        
        public static classic.Text.TextPatternRange GetDocumentRange(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern).DocumentRange;
            } catch (Exception) {
                // 
                // throw;
            }
            return null;
        }
        
        public static classic.SupportedTextSelection GetSupportedTextSelection(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern).SupportedTextSelection;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.SupportedTextSelection.None;
        }
        #endregion TextPattern
        #region TogglePattern
        public static IUiElement PerformToggle(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern).Toggle();
            }
            catch {
                // maybe, a click
            }
            return element;
        }
        
        public static IUiElement PerformToggle(this IUiElement element, bool on)
        {
            try {
                ITogglePattern togglePattern =
                    element.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern);
                if ((on && classic.ToggleState.Off == togglePattern.Current.ToggleState) ||
                   !on && classic.ToggleState.On == togglePattern.Current.ToggleState) {
                    element.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern).Toggle();
                }
            }
            catch {
                // maybe, a click
            }
            return element;
        }
        
        public static classic.ToggleState GetToggleState(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern).Current.ToggleState;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.ToggleState.Indeterminate;
        }
        #endregion TogglePattern
        #region TransformPattern
        public static IUiElement PerformMove(this IUiElement element, double x, double y)
        {
            try {
                element.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern).Move(x, y);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformResize(this IUiElement element, double width, double height)
        {
            try {
                element.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern).Resize(width, height);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformRotate(this IUiElement element, double degrees)
        {
            try {
                element.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern).Rotate(degrees);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static bool GetCanMove(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern).Current.CanMove;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetCanResize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern).Current.CanResize;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetCanRotate(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern).Current.CanRotate;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        #endregion TransformPattern
        #region ValuePattern
        public static IUiElement PerformSetValueValuePattern(this IUiElement element, string value)
        {
//            try {
                element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern).SetValue(value);
//            } catch (Exception eExtensionMethod) {
//                // 
//                // throw;
//            }
            return element;
        }
        
        public static string PerformGetValueValuePattern(this IUiElement element)
        {
//            try {
                return element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern).Current.Value;
//            } catch (Exception eExtensionMethod) {
//                // 
//                // throw;
//            }
            // return string.Empty;
        }
        
        public static bool GetIsReadOnlyValuePattern(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern).Current.IsReadOnly;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        #endregion ValuePattern
        #region WindowPattern
        public static IUiElement PerformSetWindowVisualState(this IUiElement element, classic.WindowVisualState state)
        {
            try {
                element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).SetWindowVisualState(state);
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static IUiElement PerformClose(this IUiElement element)
        {
            try {
                element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Close();
            } catch (Exception) {
                // 
                // throw;
            }
            return element;
        }
        
        public static bool PerformWaitForInputIdle(this IUiElement element, int milliseconds)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).WaitForInputIdle(milliseconds);
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetCanMaximize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Current.CanMaximize;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetCanMinimize(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Current.CanMinimize;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetIsModal(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Current.IsModal;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static bool GetIsTopmost(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Current.IsTopmost;
            } catch (Exception) {
                // 
                // throw;
            }
            return false;
        }
        
        public static classic.WindowInteractionState GetWindowInteractionState(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Current.WindowInteractionState;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.WindowInteractionState.NotResponding;
        }
        
        public static classic.WindowVisualState GetWindowVisualState(this IUiElement element)
        {
            try {
                return element.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern).Current.WindowVisualState;
            } catch (Exception) {
                // 
                // throw;
            }
            return classic.WindowVisualState.Normal;
        }
        #endregion WindowPattern
        #endregion Patterns
    }
}
