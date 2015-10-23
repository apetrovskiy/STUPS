/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/24/2012
 * Time: 4:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaTextPatternSetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaTextPatternSet")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTextPatternSet")]
    public class InvokeUiaTextPatternSetCommand : PatternCmdletBase
    {
        public InvokeUiaTextPatternSetCommand()
        {
            WhatToDo = "TextSet"; 
            //this.PassThru = false;
            //this.TextLength = -1;
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
        
        [Parameter]
        internal new SwitchParameter PassThru { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of SetUiaDocumentRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaDocumentRangeText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaDocumentRangeTextCommand : InvokeUiaTextPatternSetCommand
    { public SetUiaDocumentRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaEditRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaEditRangeText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaEditRangeTextCommand : InvokeUiaTextPatternSetCommand
    { public SetUiaEditRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaTextRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaTextRangeText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaTextRangeTextCommand : InvokeUiaTextPatternSetCommand
    { public SetUiaTextRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUiaToolTipRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaToolTipRangeText")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaToolTipRangeTextCommand : InvokeUiaTextPatternSetCommand
    { public SetUiaToolTipRangeTextCommand() { } }
}
