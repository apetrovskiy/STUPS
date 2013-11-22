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
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of RegisterUiaPropertyChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaPropertyChangedEvent")]
    
    public class RegisterUiaPropertyChangedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUiaPropertyChangedEventCommand()
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
    /// Description of RegisterUiaGridRowCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaGridRowCountChangedEvent")]
    
    public class RegisterUiaGridRowCountChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaGridRowCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.RowCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUiaGridColumnCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaGridColumnCountChangedEvent")]
    
    public class RegisterUiaGridColumnCountChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaGridColumnCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.ColumnCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUiaRangeValueChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaRangeValueChangedEvent")]
    
    public class RegisterUiaRangeValueChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaRangeValueChangedEventCommand()
        {
            base.AutomationProperty = 
                RangeValuePattern.ValueProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUiaTableRowCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaTableRowCountChangedEvent")]
    
    public class RegisterUiaTableRowCountChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaTableRowCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.RowCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUiaTableColumnCountChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaTableColumnCountChangedEvent")]
    
    public class RegisterUiaTableColumnCountChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaTableColumnCountChangedEventCommand()
        {
            base.AutomationProperty = 
                TablePattern.ColumnCountProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUiaToggleStateChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaToggleStateChangedEvent")]
    
    public class RegisterUiaToggleStateChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaToggleStateChangedEventCommand()
        {
            base.AutomationProperty = 
                TogglePattern.ToggleStateProperty;
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of RegisterUiaValueChangedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UiaValueChangedEvent")]
    
    public class RegisterUiaValueChangedEventCommand : RegisterUiaPropertyChangedEventCommand
    {
        #region Constructor
        public RegisterUiaValueChangedEventCommand()
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