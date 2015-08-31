/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaValuePatternSetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Set, "UiaValuePatternSet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaValuePatternSet")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaValuePatternSetCommand : PatternCmdletBase
    {
        public InvokeUiaValuePatternSetCommand()
        {
            WhatToDo = "ValueSet";
            Text = String.Empty;
            Child = this;
            
            PassThru = false;
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            WriteVerbose(this, "Text = " + Text);
        }
    }

    /// <summary>
    /// Description of SetUiaCalendarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCalendarValue")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaCalendarValueCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaCalendarValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaComboBoxTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaComboBoxText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaComboBoxTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaComboBoxTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaCustomTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCustomText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaCustomTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaCustomTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaDataItemTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaDataItemText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaDataItemTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaDataItemTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaEditTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaEditText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaEditTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaEditTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaTextBoxTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaTextBoxText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaTextBoxTextCommand : SetUiaEditTextCommand
    { public SetUiaTextBoxTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaHyperlinkTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaHyperlinkText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaHyperlinkTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaHyperlinkTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaLinkLabelTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaLinkLabelText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaLinkLabelTextCommand : SetUiaHyperlinkTextCommand
    { public SetUiaLinkLabelTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaListItemTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaListItemText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaListItemTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaListItemTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaProgressBarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaProgressBarValue")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaProgressBarValueCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaProgressBarValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaSliderValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaSliderValue")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaSliderValueCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaSliderValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaSpinnerValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaSpinnerValue")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaSpinnerValueCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaSpinnerValueCommand() { } }
    
    /// <summary>
    /// Description of SetUiaTextTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaTextText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaTextTextCommand : InvokeUiaValuePatternSetCommand
    { public SetUiaTextTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaLabelTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaLabelText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaLabelTextCommand : SetUiaTextTextCommand
    { public SetUiaLabelTextCommand() { } }
}