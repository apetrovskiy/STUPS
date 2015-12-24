/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/19/2012
 * Time: 10:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaScrollItemPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaScrollItemPattern")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaScrollItemPatternCommand : PatternCmdletBase
    { public InvokeUiaScrollItemPatternCommand() 
      { 
            WhatToDo = "ScrollItem";
            
            PassThru = true;
            //base.Child = this;
      }
    }

    /// <summary>
    /// Description of InvokeUiaCustomScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomScrollItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomScrollItemCommand : InvokeUiaScrollItemPatternCommand
    { public InvokeUiaCustomScrollItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataItemScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDataItemScrollItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDataItemScrollItemCommand : InvokeUiaScrollItemPatternCommand
    { public InvokeUiaDataItemScrollItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListItemScrollItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaListItemScrollItemCommand : InvokeUiaScrollItemPatternCommand
    { public InvokeUiaListItemScrollItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTreeItemScrollItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTreeItemScrollItemCommand : InvokeUiaScrollItemPatternCommand
    { public InvokeUiaTreeItemScrollItemCommand() { } }
}
