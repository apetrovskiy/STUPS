/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/22/2012
 * Time: 10:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIASelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASelectionItemState")]
    public class InvokeUIASelectionItemStateCommand : PatternCmdletBase
    {
        public InvokeUIASelectionItemStateCommand()
        {
            WhatToDo = "SelectionItemState";
        }
    }
    
    /// <summary>
    /// Description of InvokeUIACustomSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustomSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIACustomSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataItemSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIADataItemSelectionItemStateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAImageSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAImageSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAImageSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIAImageSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAListItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIAListItemSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIAMenuItemSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIARadioButtonSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIARadioButtonSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIARadioButtonSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIARadioButtonSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATabItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATabItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATabItemSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIATabItemSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATreeItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemSelectionItemStateCommand : InvokeUIASelectionItemStateCommand
    { public InvokeUIATreeItemSelectionItemStateCommand() { } }
}
