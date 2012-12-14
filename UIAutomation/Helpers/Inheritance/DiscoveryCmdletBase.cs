/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/2/2011
 * Time: 5:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// The DiscoveryCmdletBase class is an ancestor of the general cmdlets like
    /// Get-UIAControlFromPoint, Get-UIACurrentPattern, Get-UIACurrentPatternFromPoint.
    /// </summary>
    public class DiscoveryCmdletBase : HasControlInputCmdletBase
    {
        #region Constructor
        public DiscoveryCmdletBase()
        {
        }
        #endregion Constructor
        
#region collected client patterns
// private void aaa() {
// System.Windows.Automation.DockPattern dp;
// dp.SetDockPosition();
// dp.Current.DockPosition;
//
// System.Windows.Automation.GridItemPattern gip;
// gip.Current.Column;
// gip.Current.ColumnSpan;
// gip.Current.ContainingGrid;
// gip.Current.Row;
// gip.Current.RowSpan;
// System.Windows.Automation.GridPattern gp;
// gp.GetItem(row, col);
// gp.Current.ColumnCount;
// gp.Current.RowCount;
// 
// System.Windows.Automation.InvokePattern ip;
// ip.Invoke();
// 
// System.Windows.Automation.MultipleViewPattern mvp;
// mvp.GetViewName();
// mvp.SetCurrentView();
// mvp.Current.CurrentView;
// mvp.Current.GetSupportedViews();
// 
// System.Windows.Automation.RangeValuePattern rvp;
// rvp.SetValue(dbl);
// rvp.Current.IsReadOnly;
// rvp.Current.LargeChange;
// rvp.Current.Maximum;
// rvp.Current.Minimum;
// rvp.Current.SmallChange;
// rvp.Current.Value;
// 
// System.Windows.Automation.ScrollItemPattern sip;
// sip.ScrollIntoView();
// 
// System.Windows.Automation.ScrollPattern sp;
// sp.Scroll(hor, vert);
// sp.ScrollHorizontal(amount);
// sp.ScrollVertical(amount);
// sp.SetScrollPercent(dblhor, dblvert);
// sp.Current.HorizontallyScrollable;
// sp.Current.HorizontalScrollPercent;
// sp.Current.HorizontalViewSize;
// sp.Current.VerticallyScrollable;
// sp.Current.VerticalScrollPercent;
// sp.Current.VerticalViewSize;
// 
// System.Windows.Automation.SelectionItemPattern seip;
// seip.Select();
// seip.AddToSelection();
// seip.RemoveFromSelection();
// seip.Current.IsSelected;
// seip.Current.SelectionContainer;
// 
// System.Windows.Automation.SelectionPattern sep;
// sep.Current.CanSelectMultiple;
// sep.Current.IsSelectionRequired;
// 
// System.Windows.Automation.TableItemPattern tip;
// tip.Current.Column;
// tip.Current.ColumnSpan;
// tip.Current.ContainingGrid;
// tip.Current.Row;
// tip.Current.RowSpan;
// tip.Current.GetColumnHeaderItems();
// tip.Current.GetRowHeaderItems();
// 
// System.Windows.Automation.TablePattern tp;
// tp.GetItem(introw, intcol);
// tp.Current.ColumnCount;
// tp.Current.GetColumnHeaders();
// tp.Current.GetRowHeaders();
// tp.Current.RowCount;
// tp.Current.RowOrColumnMajor;
// 
// System.Windows.Automation.TextPattern tep;
// tep.DocumentRange;
// tep.SupportedTextSelection;
// tep.GetSelection();
// tep.GetVisibleRanges();
// tep.RangeFromChild();
// tep.RangeFromPoint();
// 
// System.Windows.Automation.TogglePattern top;
// top.Toggle();
// top.Current.ToggleState;
// 
// System.Windows.Automation.TransformPattern trp;
// trp.Move(dblx, dbly);
// trp.Resize(dblw, dblh);
// trp.Rotate(dbldegree);
// trp.Current.CanMove;
// trp.Current.CanRotate;
// trp.Current.CanResize;
// 
// System.Windows.Automation.ValuePattern vp;
// vp.SetValue(str);
// vp.Current.IsReadOnly;
// vp.Current.Value;
// 
// System.Windows.Automation.WindowPattern wp;
// wp.SetWindowVisualState(WindowsVisualState state);
// wp.WaitForInputIdle(intmilliseconds);
// wp.Current.CanMaximize;
// wp.Current.CanMinimize;
// wp.Current.IsModal;
// wp.Current.IsTopmost;
// wp.Current.WindowInteractionState;
// wp.Current.WindowVisualState;
#endregion collected client patterns
    }
}
