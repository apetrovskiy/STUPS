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
    /// Description of InvokeUIASelectionItemPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIASelectionItemPattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIASelectionItemPatternCommand : PatternCmdletBase
    { public InvokeUIASelectionItemPatternCommand() { WhatToDo = "SelectionItem"; }
        
        #region Parameters
        // 20130507
        // 20130508
        [Obsolete("This parameter does nothing and serves only for the compatibility purpose")]
        [Parameter(Mandatory = false,
                   Position = 0)]
        public string[] ItemName { get; set; }
//        [Parameter(Mandatory = true,
//                   // 20130105
//                   Position = 0)]
//        public string[] ItemName { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of InvokeUIACustomSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIACustomSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADataItemSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataItemSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIADataItemSelectItemCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAImageSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAImageSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAImageSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIAImageSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListItemSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListItemSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIAListItemSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAMenuItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuItemSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuItemSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIAMenuItemSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIARadioButtonSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIARadioButtonSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIARadioButtonSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIARadioButtonSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATabItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATabItemSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATabItemSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIATabItemSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATreeItemSelectItem")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeItemSelectItemCommand : InvokeUIASelectionItemPatternCommand
    { public InvokeUIATreeItemSelectItemCommand() { } }

}
