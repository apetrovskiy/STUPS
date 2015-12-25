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
    using System.Management.Automation;

//    /// <summary>
//    /// Description of InvokeUiaInvokePatternCommand.
//    /// </summary>
//    [Cmdlet(VerbsLifecycle.Invoke, "UiaInvokePattern")]
//    [OutputType(typeof(bool))]
//    
//    public class InvokeUiaInvokePatternCommand : PatternCmdletBase
//    {
//        public InvokeUiaInvokePatternCommand() { WhatToDo = "Invoke"; }
//    }

    /// <summary>
    /// Description of InvokeUiaButtonClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaButtonClick")]
    [Cmdlet("Click", "Button")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaButtonClickCommand : UIAutomation.Commands.InvokeUiaButtonClickCommand
    { public InvokeUiaButtonClickCommand() { } }
    
    //===========================================================================
    /// <summary>
    /// Description of InvokeUiaButtonClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaButtonClick")]
    [Cmdlet(@"Кликнуть", @"ПоКнопке")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaButtonClickCommand1 : UIAutomation.Commands.InvokeUiaButtonClickCommand
    { public InvokeUiaButtonClickCommand1() { } }
    //===========================================================================
    
    /// <summary>
    /// Description of InvokeUiaCustomClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaCustomClick")]
    [Cmdlet("Click", "Custom")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaCustomClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaCustomClickCommand() { } }

    /// <summary>
    /// Description of InvokeUiaHeaderItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderItemClick")]
    [Cmdlet("Click", "HeaderItem")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderItemClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaHeaderItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaLinkLabelClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaLinkLabelClick")]
    [Cmdlet("Click", "LinkLabel")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaLinkLabelClickCommand : UIAutomation.Commands.InvokeUiaHyperlinkClickCommand
    { public InvokeUiaLinkLabelClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaHyperlinkClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaHyperlinkClick")]
    [Cmdlet("Click", "Hyperlink")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaHyperlinkClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaHyperlinkClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaImageClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaImageClick")]
    [Cmdlet("Click", "Image")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaImageClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaImageClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaListItemClick")]
    [Cmdlet("Click", "ListItem")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaListItemClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaListItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaMenuItemClick")]
    [Cmdlet("Click", "MenuItem")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaMenuItemClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaMenuItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaSplitButtonClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaSplitButtonClick")]
    [Cmdlet("Click", "SplitButton")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaSplitButtonClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaSplitButtonClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTabItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaTabItemClick")]
    [Cmdlet("Click", "TabItem")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaTabItemClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaTabItemClickCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemClickCommand.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaTreeItemClick")]
    [Cmdlet("Click", "TreeItem")]
    [OutputType(typeof(bool))]
    
    public class InvokeUiaTreeItemClickCommand : UIAutomation.Commands.InvokeUiaInvokePatternCommand
    { public InvokeUiaTreeItemClickCommand() { } }
}