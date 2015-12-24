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
    /// Description of InvokeUiaExpandPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaExpandPattern")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaExpandPatternCommand : PatternCmdletBase
    { public InvokeUiaExpandPatternCommand() { WhatToDo = "Expand"; }
    }
    
    /// <summary>
    /// Description of InvokeUiaButtonExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaButtonExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaButtonExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaButtonExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaComboBoxExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaComboBoxExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaComboBoxExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaComboBoxExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaCustomExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaCustomExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDataItemExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDataItemExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaDataItemExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaGroupExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaGroupExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaGroupExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaGroupExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaGroupBoxExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaGroupBoxExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaGroupBoxExpandCommand : InvokeUiaGroupExpandCommand
    { public InvokeUiaGroupBoxExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListItemExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaListItemExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaListItemExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuBarExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuBarExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuBarExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaMenuBarExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuItemExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuItemExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaMenuItemExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaSplitButtonExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaSplitButtonExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaSplitButtonExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaSplitButtonExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaToolBarExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToolBarExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaToolBarExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaToolBarExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTreeItemExpand")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTreeItemExpandCommand : InvokeUiaExpandPatternCommand
    { public InvokeUiaTreeItemExpandCommand() { } }
}
