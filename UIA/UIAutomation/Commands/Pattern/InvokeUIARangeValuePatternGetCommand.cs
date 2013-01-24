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
    /// Description of InvokeUIARangeValuePatternGetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIARangeValuePatternGet")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIARangeValuePatternGetCommand : PatternCmdletBase
    { public InvokeUIARangeValuePatternGetCommand() { WhatToDo = "RangeValueGet"; this.PassThru = false; }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }
    
    /// <summary>
    /// Description of GetUIACustomRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustomRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIACustomRangeValueCommand() { } }

    /// <summary>
    /// Description of GetUIAEditRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAEditRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAEditRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIAEditRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIATextBoxRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextBoxRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextBoxRangeValueCommand : GetUIAEditRangeValueCommand
    { public GetUIATextBoxRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIAProgressBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAProgressBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAProgressBarRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIAProgressBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIAScrollBarRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAScrollBarRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAScrollBarRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIAScrollBarRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIASliderRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASliderRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASliderRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIASliderRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIASpinnerRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASpinnerRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASpinnerRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIASpinnerRangeValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIATextRangeValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextRangeValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextRangeValueCommand : InvokeUIARangeValuePatternGetCommand
    { public GetUIATextRangeValueCommand() { } }
}