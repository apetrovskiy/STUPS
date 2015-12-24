/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/22/2012
 * Time: 10:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaToggleStateGetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaToggleStateGet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToggleStateGet")]
    public class InvokeUiaToggleStateGetCommand : PatternCmdletBase
    {
        public InvokeUiaToggleStateGetCommand()
        {
            WhatToDo = "ToggleStateGet";
        }
    }
    
    /// <summary>
    /// Description of GetUiaButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaButtonToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaButtonToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaButtonToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUiaCheckBoxToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCheckBoxToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaCheckBoxToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaCheckBoxToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUiaCustomToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustomToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaCustomToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaCustomToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUiaDataItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataItemToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaDataItemToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaDataItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUiaListItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaListItemToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaListItemToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaListItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUiaMenuItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuItemToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaMenuItemToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaMenuItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUiaRadioButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaRadioButtonToggleState")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaRadioButtonToggleStateCommand : InvokeUiaToggleStateGetCommand 
    { public GetUiaRadioButtonToggleStateCommand() { } }
}
