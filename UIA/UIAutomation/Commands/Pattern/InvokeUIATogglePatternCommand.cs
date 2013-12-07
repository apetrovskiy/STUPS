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
    /// Description of InvokeUiaTogglePatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTogglePattern")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Invoke-UiaTogglePatternSet cmdlet")]
    public class InvokeUiaTogglePatternCommand : PatternCmdletBase
    { public InvokeUiaTogglePatternCommand() { WhatToDo = "Toggle"; }
    }
    
    /// <summary>
    /// Description of InvokeUiaButtonToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaButtonToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaButtonToggleState cmdlet")]
    public class InvokeUiaButtonToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaButtonToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaCheckBoxToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCheckBoxToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaCheckBoxToggleState cmdlet")]
    public class InvokeUiaCheckBoxToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaCheckBoxToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaCustomToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaCustomToggleState cmdlet")]
    public class InvokeUiaCustomToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaCustomToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataItemToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDataItemToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaDataItemToggleState cmdlet")]
    public class InvokeUiaDataItemToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaDataItemToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListItemToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListItemToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaListItemToggleState cmdlet")]
    public class InvokeUiaListItemToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaListItemToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaMenuItemToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuItemToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaMenuItemToggleState cmdlet")]
    public class InvokeUiaMenuItemToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaMenuItemToggleCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaRadioButtonToggleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaRadioButtonToggle")]
    //[OutputType(typeof(bool))]
    
    [Obsolete("This cmdlet is obsolete. Please use the Set-UiaRadioButtonToggleState cmdlet")]
    public class InvokeUiaRadioButtonToggleCommand : InvokeUiaTogglePatternCommand
    { public InvokeUiaRadioButtonToggleCommand() { } }
}
