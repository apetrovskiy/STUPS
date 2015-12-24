/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/6/2012
 * Time: 11:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaTextPatternGetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaTextPatternGet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTextPatternGet")]
    public class InvokeUiaTextPatternGetCommand : PatternCmdletBase
    { public InvokeUiaTextPatternGetCommand() 
        { 
            WhatToDo = "TextGet"; 
            PassThru = false;
            TextLength = -1;
        }
        
        [UiaParameter][Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public int TextLength { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter VisibleArea { get; set; }
    }
    
    // 20131024
    /// <summary>
    /// Description of GetUiaCustomRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustomRangeText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaCustomRangeTextCommand : InvokeUiaTextPatternGetCommand
    { public GetUiaCustomRangeTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaDocumentRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDocumentRangeText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaDocumentRangeTextCommand : InvokeUiaTextPatternGetCommand
    { public GetUiaDocumentRangeTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaEditRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaEditRangeText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaEditRangeTextCommand : InvokeUiaTextPatternGetCommand
    { public GetUiaEditRangeTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaTextRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTextRangeText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaTextRangeTextCommand : InvokeUiaTextPatternGetCommand
    { public GetUiaTextRangeTextCommand() { } }
    
    /// <summary>
    /// Description of GetUiaToolTipRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaToolTipRangeText")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaToolTipRangeTextCommand : InvokeUiaTextPatternGetCommand
    { public GetUiaToolTipRangeTextCommand() { } }
}
