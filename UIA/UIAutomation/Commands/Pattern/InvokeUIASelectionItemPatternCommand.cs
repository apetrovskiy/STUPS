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
    /// Description of InvokeUiaSelectionItemPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaSelectionItemPattern")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaSelectionItemPatternCommand : PatternCmdletBase
    { public InvokeUiaSelectionItemPatternCommand() { WhatToDo = "SelectionItem"; }
        
        #region Parameters
        // 20130507
        // 20130508
        [Obsolete("This parameter does nothing and serves only for the compatibility purpose")]
        [UiaParameter][Parameter(Mandatory = false,
                   Position = 0)]
        public string[] ItemName { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = true,
//                   // 20130105
//                   Position = 0)]
//        public string[] ItemName { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of InvokeUiaCustomSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaCustomSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDataItemSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDataItemSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaDataItemSelectItemCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaImageSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaImageSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaImageSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaImageSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListItemSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaListItemSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaListItemSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuItemSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuItemSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaMenuItemSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaRadioButtonSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaRadioButtonSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaRadioButtonSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaRadioButtonSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTabItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTabItemSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTabItemSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaTabItemSelectItemCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeItemSelectItemCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTreeItemSelectItem")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTreeItemSelectItemCommand : InvokeUiaSelectionItemPatternCommand
    { public InvokeUiaTreeItemSelectItemCommand() { } }

}
