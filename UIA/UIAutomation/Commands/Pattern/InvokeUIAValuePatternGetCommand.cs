/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:37 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIAValuePatternGetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAValuePatternGet")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAValuePatternGetCommand : PatternCmdletBase
    { public InvokeUIAValuePatternGetCommand() 
        { 
            WhatToDo = "ValueGet"; 
            this.PassThru = false; 
        }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }

    /// <summary>
    /// Description of GetUIACalendarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACalendarValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACalendarValueCommand : InvokeUIAValuePatternGetCommand
    { public GetUIACalendarValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIAComboBoxTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAComboBoxText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAComboBoxTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIAComboBoxTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIACustomTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustomText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIACustomTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIADataItemTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataItemText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataItemTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIADataItemTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIAEditTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAEditText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAEditTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIAEditTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIATextBoxTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextBoxText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextBoxTextCommand : GetUIAEditTextCommand
    { public GetUIATextBoxTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIAHyperlinkTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHyperlinkText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHyperlinkTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIAHyperlinkTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIALinkLabelTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIALinkLabelText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIALinkLabelTextCommand : GetUIAHyperlinkTextCommand
    { public GetUIALinkLabelTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIAListItemTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAListItemText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListItemTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIAListItemTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIAProgressBarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAProgressBarValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAProgressBarValueCommand : InvokeUIAValuePatternGetCommand
    { public GetUIAProgressBarValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIASliderValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASliderValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASliderValueCommand : InvokeUIAValuePatternGetCommand
    { public GetUIASliderValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIASpinnerValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASpinnerValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASpinnerValueCommand : InvokeUIAValuePatternGetCommand
    { public GetUIASpinnerValueCommand() { } }
    
    /// <summary>
    /// Description of GetUIATextTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextTextCommand : InvokeUIAValuePatternGetCommand
    { public GetUIATextTextCommand() { } }
    
    /// <summary>
    /// Description of GetUIALabelTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIALabelText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIALabelTextCommand : GetUIATextTextCommand
    { public GetUIALabelTextCommand() { } }
}