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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSelectionItemState")]
    public class InvokeUiaSelectionItemStateCommand : PatternCmdletBase
    {
        public InvokeUiaSelectionItemStateCommand()
        {
            WhatToDo = "SelectionItemState";
        }
    }
    
    /// <summary>
    /// Description of InvokeUiaCustomSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustomSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaCustomSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDataItemSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaDataItemSelectionItemStateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaImageSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaImageSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaImageSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaImageSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaListItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaListItemSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaListItemSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuItemSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaMenuItemSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaRadioButtonSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaRadioButtonSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaRadioButtonSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaRadioButtonSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTabItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTabItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTabItemSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaTabItemSelectionItemStateCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemSelectionItemStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTreeItemSelectionItemState")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTreeItemSelectionItemStateCommand : InvokeUiaSelectionItemStateCommand
    { public InvokeUiaTreeItemSelectionItemStateCommand() { } }
}
