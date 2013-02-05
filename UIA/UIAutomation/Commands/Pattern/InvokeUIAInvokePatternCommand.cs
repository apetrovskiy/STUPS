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
    /// Description of InvokeUIAInvokePatternCommand.
    /// </summary>
    // 20130204
    [Cmdlet(VerbsLifecycle.Invoke, "UIAInvokePattern")]
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAInvokePattern", DefaultParameterSetName = "UIAWildCard")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAInvokePatternCommand : PatternCmdletBase
    {
        public InvokeUIAInvokePatternCommand() { WhatToDo = "Invoke"; }
    }

    /// <summary>
    /// Description of InvokeUIAButtonClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAButtonClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAButtonClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIAButtonClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIACustomClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIACustomClickCommand() { } }

    /// <summary>
    /// Description of InvokeUIAHeaderItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderItemClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIAHeaderItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIALinkLabelClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIALinkLabelClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIALinkLabelClickCommand : InvokeUIAHyperlinkClickCommand
    { public InvokeUIALinkLabelClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAHyperlinkClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHyperlinkClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHyperlinkClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIAHyperlinkClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAImageClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAImageClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAImageClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIAImageClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIAListItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIAMenuItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIASplitButtonClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIASplitButtonClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIASplitButtonClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIASplitButtonClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATabItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATabItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATabItemClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIATabItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATreeItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemClickCommand : InvokeUIAInvokePatternCommand
    { public InvokeUIATreeItemClickCommand() { } }
}