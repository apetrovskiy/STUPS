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
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaValuePatternGetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaValuePatternGet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaValuePatternGet")]
    
    public class InvokeUiaValuePatternGetCommand : PatternCmdletBase
    { public InvokeUiaValuePatternGetCommand() 
        { 
            WhatToDo = "ValueGet"; 
            PassThru = false; 
        }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }

    /// <summary>
    /// Description of GetUiaCalendarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCalendarValue")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaCalendarValueCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaCalendarValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaComboBoxTextCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaComboBoxText")]
    [Cmdlet(VerbsCommon.Get, "UiaComboBoxValue")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaComboBoxTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaComboBoxTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaCustomTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaCustomText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaCustomTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaCustomTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaDataItemTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaDataItemText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaDataItemTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaDataItemTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaEditTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaEditText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaEditTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaEditTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTextBoxTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaTextBoxText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaTextBoxTextCommand : GetUiaEditTextCommand
    { public GetUiaTextBoxTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaHyperlinkTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaHyperlinkText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaHyperlinkTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaHyperlinkTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaLinkLabelTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaLinkLabelText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaLinkLabelTextCommand : GetUiaHyperlinkTextCommand
    { public GetUiaLinkLabelTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaListItemTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaListItemText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaListItemTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaListItemTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaProgressBarValueCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaProgressBarValue")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaProgressBarValueCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaProgressBarValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaSliderValueCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaSliderValue")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaSliderValueCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaSliderValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaSpinnerValueCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaSpinnerValue")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaSpinnerValueCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaSpinnerValueCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTextTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaTextText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaTextTextCommand : InvokeUiaValuePatternGetCommand
    { public GetUiaTextTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaLabelTextCommand.
    /// </summary>
    // 20131024
    [Cmdlet(VerbsCommon.Get, "UiaLabelText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaLabelTextCommand : GetUiaTextTextCommand
    { public GetUiaLabelTextCommand() { } }
}