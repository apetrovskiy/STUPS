/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUIAPropertyChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAPropertyChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAPropertyChangedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUIAPropertyChangedEventCommand()
        {
//            base.AutomationEventType = 
//                AutomationElement.AutomationPropertyChangedEvent;
            this.AutomationEventType = 
                AutomationElement.AutomationPropertyChangedEvent;
            // base.AutomationEventHandler = OnUIAutomationPropertyChangedEvent;
//            base.AutomationPropertyChangedEventHandler = 
//                OnUIAutomationPropertyChangedEvent;
            this.AutomationPropertyChangedEventHandler = 
                OnUIAutomationPropertyChangedEvent;
        }
        #endregion Constructor
    }
    
    
    
    /// <summary>
    /// Description of RegisterUIAGridRowCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAGridRowCountChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAGridRowCountChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIAGridRowCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.RowCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUIAGridColumnCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAGridColumnCountChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAGridColumnCountChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIAGridColumnCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.ColumnCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUIARangeValueChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIARangeValueChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIARangeValueChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIARangeValueChangedEventCommand()
        {
            base.AutomationProperty = 
                RangeValuePattern.ValueProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUIATableRowCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIATableRowCountChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIATableRowCountChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIATableRowCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.RowCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUIATableColumnCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIATableColumnCountChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIATableColumnCountChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIATableColumnCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.ColumnCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUIAToggleStateChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAToggleStateChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAToggleStateChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIAToggleStateChangedEventCommand()
        {
            base.AutomationProperty = 
                TogglePattern.ToggleStateProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUIAValueChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAValueChangedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAValueChangedEventCommand : RegisterUIAPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUIAValueChangedEventCommand()
        {
            base.AutomationProperty = 
                ValuePattern.ValueProperty;
        }
        #endregion Constructor
    }
}

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