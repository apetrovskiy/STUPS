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
    /// Description of InvokeUiaRangeValuePatternGetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaRangeValuePatternGet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaRangeValuePatternGet")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUiaRangeValuePatternGetCommand : PatternCmdletBase
    { public InvokeUiaRangeValuePatternGetCommand() { WhatToDo = "RangeValueGet"; this.PassThru = false; }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }
    
    /// <summary>
    /// Description of GetUiaCustomRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustomRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaCustomRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaCustomRangeValueCommand() { } }

    /// <summary>
    /// Description of GetUiaEditRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaEditRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaEditRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaEditRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTextBoxRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTextBoxRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaTextBoxRangeValueCommand : GetUiaEditRangeValueCommand
    { public GetUiaTextBoxRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaProgressBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaProgressBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaProgressBarRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaProgressBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaScrollBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaScrollBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaScrollBarRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaScrollBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaSliderRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSliderRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaSliderRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaSliderRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaSpinnerRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSpinnerRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaSpinnerRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaSpinnerRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTextRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTextRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaTextRangeValueCommand : InvokeUiaRangeValuePatternGetCommand
    { public GetUiaTextRangeValueCommand() { } }
}