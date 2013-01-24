/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30/11/2011
 * Time: 08:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases.Commands
{
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;

//    /// <summary>
//    /// Description of InvokeUIAInvokePatternCommand.
//    /// </summary>
//    [Cmdlet(VerbsLifecycle.Invoke, "UIAInvokePattern")]
//    [OutputType(typeof(bool))]
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
//    public class InvokeUIAInvokePatternCommand : PatternCmdletBase
//    {
//        public InvokeUIAInvokePatternCommand() { WhatToDo = "Invoke"; }
//    }

    /// <summary>
    /// Description of InvokeUIAButtonClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAButtonClick")]
    [Cmdlet("Click", "Button")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAButtonClickCommand : UIAutomation.Commands.InvokeUIAButtonClickCommand
    { public InvokeUIAButtonClickCommand() { } }
    
    //===========================================================================
    /// <summary>
    /// Description of InvokeUIAButtonClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAButtonClick")]
    [Cmdlet(@"Кликнуть", @"ПоКнопке")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAButtonClickCommand1 : UIAutomation.Commands.InvokeUIAButtonClickCommand
    { public InvokeUIAButtonClickCommand1() { } }
    //===========================================================================
    
    /// <summary>
    /// Description of InvokeUIACustomClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIACustomClick")]
    [Cmdlet("Click", "Custom")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIACustomClickCommand() { } }

    /// <summary>
    /// Description of InvokeUIAHeaderItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderItemClick")]
    [Cmdlet("Click", "HeaderItem")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderItemClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIAHeaderItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIALinkLabelClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIALinkLabelClick")]
    [Cmdlet("Click", "LinkLabel")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIALinkLabelClickCommand : UIAutomation.Commands.InvokeUIAHyperlinkClickCommand
    { public InvokeUIALinkLabelClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAHyperlinkClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAHyperlinkClick")]
    [Cmdlet("Click", "Hyperlink")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHyperlinkClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIAHyperlinkClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAImageClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAImageClick")]
    [Cmdlet("Click", "Image")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAImageClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIAImageClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAListItemClick")]
    [Cmdlet("Click", "ListItem")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIAListItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIAMenuItemClick")]
    [Cmdlet("Click", "MenuItem")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIAMenuItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIASplitButtonClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIASplitButtonClick")]
    [Cmdlet("Click", "SplitButton")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIASplitButtonClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIASplitButtonClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATabItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIATabItemClick")]
    [Cmdlet("Click", "TabItem")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATabItemClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIATabItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UIATreeItemClick")]
    [Cmdlet("Click", "TreeItem")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemClickCommand : UIAutomation.Commands.InvokeUIAInvokePatternCommand
    { public InvokeUIATreeItemClickCommand() { } }
}