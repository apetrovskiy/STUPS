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
    /// Description of InvokeUIAWindowPatternCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAWindowPattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAWindowPatternCommand : PatternCmdletBase
    { public InvokeUIAWindowPatternCommand() { WhatToDo = "Window"; } }
    
    /// <summary>
    /// Description of InvokeUIACustomWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomWindowStateCommand : InvokeUIAWindowPatternCommand
    { public InvokeUIACustomWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUIAPaneWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAPaneWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAPaneWindowStateCommand : InvokeUIAWindowPatternCommand
    { public InvokeUIAPaneWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUIAToolTipWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAToolTipWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAToolTipWindowStateCommand : InvokeUIAWindowPatternCommand
    { public InvokeUIAToolTipWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUIAWindowWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWindowWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAWindowWindowStateCommand : InvokeUIAWindowPatternCommand
    { public InvokeUIAWindowWindowStateCommand() { } }

    /// <summary>
    /// Description of InvokeUIAChildWindowWindowStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAChildWindowWindowState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAChildWindowWindowStateCommand : InvokeUIAWindowWindowStateCommand
    { public InvokeUIAChildWindowWindowStateCommand() { } }
}