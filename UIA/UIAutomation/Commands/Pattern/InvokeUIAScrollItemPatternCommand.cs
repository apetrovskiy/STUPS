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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAScrollItemPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAScrollItemPattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAScrollItemPatternCommand : PatternCmdletBase
    { public InvokeUIAScrollItemPatternCommand() 
      { 
            WhatToDo = "ScrollItem";
            
            this.PassThru = true;
            //base.Child = this;
      }
    }

    /// <summary>
    /// Description of InvokeUIACustomScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomScrollItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomScrollItemCommand : InvokeUIAScrollItemPatternCommand
    { public InvokeUIACustomScrollItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataItemScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADataItemScrollItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataItemScrollItemCommand : InvokeUIAScrollItemPatternCommand
    { public InvokeUIADataItemScrollItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListItemScrollItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemScrollItemCommand : InvokeUIAScrollItemPatternCommand
    { public InvokeUIAListItemScrollItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemScrollItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATreeItemScrollItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemScrollItemCommand : InvokeUIAScrollItemPatternCommand
    { public InvokeUIATreeItemScrollItemCommand() { } }
}
