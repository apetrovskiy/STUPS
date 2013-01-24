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
    /// Description of InvokeUIARangeValuePatternSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIARangeValuePatternSet")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIARangeValuePatternSetCommand : PatternCmdletBase
    {
        public InvokeUIARangeValuePatternSetCommand()
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
    /// Description of SetUIACustomRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIACustomRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIACustomRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIACustomRangeValueCommand() { } }

    /// <summary>
    /// Description of SetUIAEditRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAEditRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAEditRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIAEditRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIATextBoxRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIATextBoxRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIATextBoxRangeValueCommand : SetUIAEditRangeValueCommand
    { public SetUIATextBoxRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIAProgressBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAProgressBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAProgressBarRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIAProgressBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIAScrollBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAScrollBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAScrollBarRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIAScrollBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIASliderRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIASliderRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIASliderRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIASliderRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIASpinnerRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIASpinnerRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIASpinnerRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIASpinnerRangeValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIATextRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIATextRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIATextRangeValueCommand : InvokeUIARangeValuePatternSetCommand
    { public SetUIATextRangeValueCommand() { } }
}
