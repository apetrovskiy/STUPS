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
    /// Description of InvokeUiaInvokePatternCommand.
    /// </summary>
    // 20130204
    [Cmdlet(VerbsLifecycle.Invoke, "UiaInvokePattern")]
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaInvokePattern", DefaultParameterSetName = "UiaWildCard")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaInvokePatternCommand : PatternCmdletBase
    {
        public InvokeUiaInvokePatternCommand() { WhatToDo = "Invoke"; }
    }

    /// <summary>
    /// Description of InvokeUiaButtonClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaButtonClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaButtonClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaButtonClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaCustomClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaCustomClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaCustomClickCommand() { } }

    /// <summary>
    /// Description of InvokeUiaHeaderItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaHeaderItemClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaHeaderItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaLinkLabelClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaLinkLabelClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaLinkLabelClickCommand : InvokeUiaHyperlinkClickCommand
    { public InvokeUiaLinkLabelClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaHyperlinkClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHyperlinkClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaHyperlinkClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaHyperlinkClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaImageClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaImageClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaImageClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaImageClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaListItemClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaListItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaMenuItemClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaMenuItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaSplitButtonClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaSplitButtonClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaSplitButtonClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaSplitButtonClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTabItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTabItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaTabItemClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaTabItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTreeItemClick")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaTreeItemClickCommand : InvokeUiaInvokePatternCommand
    { public InvokeUiaTreeItemClickCommand() { } }
}