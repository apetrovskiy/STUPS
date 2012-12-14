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
    /// Description of InvokeUIAExpandPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAExpandPattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAExpandPatternCommand : PatternCmdletBase
    { public InvokeUIAExpandPatternCommand() { WhatToDo = "Expand"; }
    }
    
    /// <summary>
    /// Description of InvokeUIAButtonExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAButtonExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAButtonExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAButtonExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAComboBoxExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAComboBoxExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAComboBoxExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAComboBoxExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIACustomExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIACustomExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADataItemExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataItemExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIADataItemExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAGroupExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAGroupExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAGroupExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAGroupExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAGroupBoxExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAGroupBoxExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAGroupBoxExpandCommand : InvokeUIAGroupExpandCommand
    { public InvokeUIAGroupBoxExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListItemExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAListItemExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuBarExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuBarExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuBarExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAMenuBarExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuItemExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAMenuItemExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIASplitButtonExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIASplitButtonExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIASplitButtonExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIASplitButtonExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAToolBarExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAToolBarExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAToolBarExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIAToolBarExpandCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemExpandCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATreeItemExpand")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemExpandCommand : InvokeUIAExpandPatternCommand
    { public InvokeUIATreeItemExpandCommand() { } }
}
