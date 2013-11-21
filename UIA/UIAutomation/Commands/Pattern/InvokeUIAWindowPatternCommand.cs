/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaWindowPatternCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaWindowPattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaWindowPatternCommand : PatternCmdletBase
    { public InvokeUiaWindowPatternCommand() { WhatToDo = "Window"; } }
    
    /// <summary>
    /// Description of InvokeUiaCustomWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaCustomWindowStateCommand : InvokeUiaWindowPatternCommand
    { public InvokeUiaCustomWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUiaPaneWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaPaneWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaPaneWindowStateCommand : InvokeUiaWindowPatternCommand
    { public InvokeUiaPaneWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUiaToolTipWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToolTipWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaToolTipWindowStateCommand : InvokeUiaWindowPatternCommand
    { public InvokeUiaToolTipWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUiaWindowWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWindowWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaWindowWindowStateCommand : InvokeUiaWindowPatternCommand
    { public InvokeUiaWindowWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUiaChildWindowWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaChildWindowWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaChildWindowWindowStateCommand : InvokeUiaWindowWindowStateCommand
    { public InvokeUiaChildWindowWindowStateCommand() { } }
}