/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2013
 * Time: 7:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaToggleStateSetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Set, "UiaToggleStateSet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToggleStateSet")]
    public class InvokeUiaToggleStateSetCommand : PatternCmdletBase
    {
        public InvokeUiaToggleStateSetCommand()
        {
            WhatToDo = "ToggleStateSet";
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   Position = 0)]
        // 20130803
        //public bool On { get; set; }
        public SwitchParameter On { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of SetUiaButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaButtonToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaButtonToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaButtonToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUiaCheckBoxToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCheckBoxToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaCheckBoxToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaCheckBoxToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUiaCustomToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCustomToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaCustomToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaCustomToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUiaDataItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaDataItemToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaDataItemToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaDataItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUiaListItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaListItemToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaListItemToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaListItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUiaMenuItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaMenuItemToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaMenuItemToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaMenuItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUiaRadioButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaRadioButtonToggleState")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaRadioButtonToggleStateCommand : InvokeUiaToggleStateSetCommand 
    { public SetUiaRadioButtonToggleStateCommand() { } }
}
