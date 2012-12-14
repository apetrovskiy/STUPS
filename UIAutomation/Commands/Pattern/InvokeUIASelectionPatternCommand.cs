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
    /// Description of InvokeUIASelectionPatternCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASelectionPattern")]
    ////[OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIASelectionPatternCommand : PatternCmdletBase
    { public InvokeUIASelectionPatternCommand() { WhatToDo = "Selection"; this.PassThru = false; }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }
    
    /// <summary>
    /// Description of GetUIACalendarSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACalendarSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACalendarSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIACalendarSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIAComboBoxSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAComboBoxSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAComboBoxSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIAComboBoxSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIACustomSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustomSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIACustomSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIADataGridSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataGridSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataGridSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIADataGridSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIAListSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAListSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIAListSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIASliderSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASliderSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASliderSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIASliderSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIASpinnerSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASpinnerSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASpinnerSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIASpinnerSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIATabSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATabSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATabSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIATabSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUIATreeSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATreeSelection")]
    ////[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATreeSelectionCommand : InvokeUIASelectionPatternCommand 
    { public GetUIATreeSelectionCommand() { } }
}