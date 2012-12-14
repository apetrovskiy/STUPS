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
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIATogglePatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATogglePattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATogglePatternCommand : PatternCmdletBase
    { public InvokeUIATogglePatternCommand() { WhatToDo = "Toggle"; }
    }
    
    /// <summary>
    /// Description of InvokeUIAButtonToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAButtonToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAButtonToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIAButtonToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIACheckBoxToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACheckBoxToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACheckBoxToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIACheckBoxToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIACustomToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIACustomToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataItemToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADataItemToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataItemToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIADataItemToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListItemToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIAListItemToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuItemToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIAMenuItemToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIARadioButtonToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIARadioButtonToggle")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIARadioButtonToggleCommand : InvokeUIATogglePatternCommand 
    { public InvokeUIARadioButtonToggleCommand() { } }
}
