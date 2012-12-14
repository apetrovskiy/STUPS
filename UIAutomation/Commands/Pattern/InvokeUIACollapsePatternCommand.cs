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
    /// Description of InvokeUIACollapsePatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACollapsePattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACollapsePatternCommand : PatternCmdletBase
    { public InvokeUIACollapsePatternCommand() { WhatToDo = "Collapse"; }
    }
    
    /// <summary>
    /// Description of InvokeUIAButtonCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAButtonCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAButtonCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAButtonCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAComboBoxCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAComboBoxCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAComboBoxCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAComboBoxCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIACustomCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIACustomCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADataItemCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataItemCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIADataItemCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAGroupCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAGroupCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAGroupCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAGroupCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAGroupBoxCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAGroupBoxCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAGroupBoxCollapseCommand : InvokeUIAGroupCollapseCommand
    { public InvokeUIAGroupBoxCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListItemCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAListItemCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuBarCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuBarCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuBarCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAMenuBarCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuItemCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAMenuItemCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIASplitButtonCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIASplitButtonCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIASplitButtonCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIASplitButtonCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAToolBarCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAToolBarCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAToolBarCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIAToolBarCollapseCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemCollapseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATreeItemCollapse")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemCollapseCommand : InvokeUIACollapsePatternCommand
    { public InvokeUIATreeItemCollapseCommand() { } }
}
