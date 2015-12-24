/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/19/2012
 * Time: 10:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaScrollPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaScrollPattern")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaScrollPatternCommand : PatternCmdletBase
    { public InvokeUiaScrollPatternCommand() 
      { 
            WhatToDo = "Scroll"; 
            Vertical = false;
            Horizontal = false;
            //this.Percent = 0;
            PassThru = true;
            Child = this;
      }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Percent")]
        [ValidateRange(-1, 100)]
        public int HorizontalPercent { get; set; }
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Percent")]
        [ValidateRange(-1, 100)]
        public int VerticalPercent { get; set; }
                [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Amount")]
        public int HorizontalAmount { get; set; }
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Amount")]
        public int VerticalAmount { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Horizontal { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Vertical { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public SwitchParameter Large { get; set; }
        #endregion Parameters

    /// <summary>
    /// Description of InvokeUiaCalendarScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCalendarScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCalendarScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaCalendarScrollCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaComboBoxScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaComboBoxScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaComboBoxScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaComboBoxScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaCustomScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaCustomScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDataGridScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDataGridScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDataGridScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaDataGridScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaDocumentScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDocumentScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaDocumentScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaDocumentScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaListScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaListScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaListScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaListScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaPaneScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaPaneScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaPaneScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaPaneScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaScrollBarScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaScrollBarScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaScrollBarScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaScrollBarScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTabScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTabScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTabScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaTabScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaTreeScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTreeScroll")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTreeScrollCommand : InvokeUiaScrollPatternCommand
    { public InvokeUiaTreeScrollCommand() { } }
        
    }
}
