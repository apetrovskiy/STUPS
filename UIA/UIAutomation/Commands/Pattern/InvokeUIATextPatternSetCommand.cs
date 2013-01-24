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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIATextPatternSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextPatternSet")]
    public class InvokeUIATextPatternSetCommand : PatternCmdletBase
    {
        public InvokeUIATextPatternSetCommand()
        {
            WhatToDo = "TextSet"; 
            //this.PassThru = false;
            //this.TextLength = -1;
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
        
        [Parameter]
        internal new SwitchParameter PassThru { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of SetUIADocumentRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIADocumentRangeText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIADocumentRangeTextCommand : InvokeUIATextPatternSetCommand
    { public SetUIADocumentRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAEditRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAEditRangeText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAEditRangeTextCommand : InvokeUIATextPatternSetCommand
    { public SetUIAEditRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIATextRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIATextRangeText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIATextRangeTextCommand : InvokeUIATextPatternSetCommand
    { public SetUIATextRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAToolTipRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAToolTipRangeText")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAToolTipRangeTextCommand : InvokeUIATextPatternSetCommand
    { public SetUIAToolTipRangeTextCommand() { } }
}
