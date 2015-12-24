/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30/11/2011
 * Time: 08:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaCollapsePatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCollapsePattern")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCollapsePatternCommand : PatternCmdletBase
    { public InvokeUiaCollapsePatternCommand() { WhatToDo = "Collapse"; }
    }
    
    /// <summary>
    /// Description of InvokeUiaButtonCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaButtonCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaButtonCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaButtonCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaComboBoxCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaComboBoxCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaComboBoxCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaComboBoxCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaCustomCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaCustomCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDataItemCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDataItemCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaDataItemCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaGroupCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaGroupCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaGroupCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaGroupCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaGroupBoxCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaGroupBoxCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaGroupBoxCollapseCommand : InvokeUiaGroupCollapseCommand
    { public InvokeUiaGroupBoxCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListItemCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaListItemCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaListItemCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuBarCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuBarCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuBarCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaMenuBarCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuItemCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuItemCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaMenuItemCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaSplitButtonCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaSplitButtonCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaSplitButtonCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaSplitButtonCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaToolBarCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToolBarCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaToolBarCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaToolBarCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTreeItemCollapse")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTreeItemCollapseCommand : InvokeUiaCollapsePatternCommand
    { public InvokeUiaTreeItemCollapseCommand() { } }
}
