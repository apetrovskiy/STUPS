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
    /// Description of InvokeUIAValuePatternSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAValuePatternSet")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAValuePatternSetCommand : PatternCmdletBase
    {
        public InvokeUIAValuePatternSetCommand()
        {
            WhatToDo = "ValueSet";
            Text = String.Empty;
            base.Child = this;
            
            this.PassThru = false;
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
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
    /// Description of SetUIACalendarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIACalendarValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIACalendarValueCommand : InvokeUIAValuePatternSetCommand
    { public SetUIACalendarValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIAComboBoxTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAComboBoxText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAComboBoxTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIAComboBoxTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIACustomTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIACustomText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIACustomTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIACustomTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIADataItemTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIADataItemText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIADataItemTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIADataItemTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAEditTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAEditText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAEditTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIAEditTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIATextBoxTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIATextBoxText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIATextBoxTextCommand : SetUIAEditTextCommand
    { public SetUIATextBoxTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAHyperlinkTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAHyperlinkText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAHyperlinkTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIAHyperlinkTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIALinkLabelTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIALinkLabelText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIALinkLabelTextCommand : SetUIAHyperlinkTextCommand
    { public SetUIALinkLabelTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAListItemTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAListItemText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAListItemTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIAListItemTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAProgressBarValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAProgressBarValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAProgressBarValueCommand : InvokeUIAValuePatternSetCommand
    { public SetUIAProgressBarValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIASliderValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIASliderValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIASliderValueCommand : InvokeUIAValuePatternSetCommand
    { public SetUIASliderValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIASpinnerValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIASpinnerValue")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIASpinnerValueCommand : InvokeUIAValuePatternSetCommand
    { public SetUIASpinnerValueCommand() { } }
    
    /// <summary>
    /// Description of SetUIATextTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIATextText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIATextTextCommand : InvokeUIAValuePatternSetCommand
    { public SetUIATextTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIALabelTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIALabelText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIALabelTextCommand : SetUIATextTextCommand
    { public SetUIALabelTextCommand() { } }
}