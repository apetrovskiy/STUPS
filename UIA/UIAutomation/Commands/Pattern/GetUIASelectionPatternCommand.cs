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
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaSelectionPatternCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaSelectionPattern")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaSelectionPattern")]
    public class InvokeUiaSelectionPatternCommand : PatternCmdletBase
    { public InvokeUiaSelectionPatternCommand() { WhatToDo = "Selection"; PassThru = false; }
        
        [Parameter]
        internal new SwitchParameter PassThru {get; set; }
    }
    
    /// <summary>
    /// Description of GetUiaCalendarSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCalendarSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaCalendarSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaCalendarSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaComboBoxSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaComboBoxSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaComboBoxSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaComboBoxSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaCustomSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustomSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaCustomSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaCustomSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaDataGridSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataGridSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaDataGridSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaDataGridSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaListSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaListSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaListSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaListSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaSliderSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSliderSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaSliderSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaSliderSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaSpinnerSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSpinnerSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaSpinnerSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaSpinnerSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTabSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTabSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaTabSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaTabSelectionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTreeSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTreeSelection")]
    ////[OutputType(typeof(bool))]
    public class GetUiaTreeSelectionCommand : InvokeUiaSelectionPatternCommand 
    { public GetUiaTreeSelectionCommand() { } }
}