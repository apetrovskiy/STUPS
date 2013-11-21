/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 22/12/2011
 * Time: 06:46 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaRangeValuePatternSetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Set, "UiaRangeValuePatternSet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaRangeValuePatternSet")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaRangeValuePatternSetCommand : PatternCmdletBase
    {
        public InvokeUiaRangeValuePatternSetCommand()
        {
            WhatToDo = "RangeValueGet";
            Value = 0;
            base.Child = this;
            
            this.PassThru = false;
        }
        
        [Parameter(Mandatory = true)]
        public int Value { get; set; }
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }
    
    /// <summary>
    /// Description of SetUiaCustomRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCustomRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaCustomRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaCustomRangeValueCommand() { } }

    /// <summary>
    /// Description of SetUiaEditRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaEditRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaEditRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaEditRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaTextBoxRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaTextBoxRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaTextBoxRangeValueCommand : SetUiaEditRangeValueCommand
    { public SetUiaTextBoxRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaProgressBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaProgressBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaProgressBarRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaProgressBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaScrollBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaScrollBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaScrollBarRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaScrollBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaSliderRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaSliderRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaSliderRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaSliderRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaSpinnerRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaSpinnerRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaSpinnerRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaSpinnerRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaTextRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaTextRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUiaTextRangeValueCommand : InvokeUiaRangeValuePatternSetCommand
    { public SetUiaTextRangeValueCommand() { } }
}
