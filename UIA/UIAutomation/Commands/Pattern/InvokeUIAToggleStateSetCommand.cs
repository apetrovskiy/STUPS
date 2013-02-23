/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2013
 * Time: 7:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIAToggleStateSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAToggleStateSet")]
    public class InvokeUIAToggleStateSetCommand : PatternCmdletBase
    {
        public InvokeUIAToggleStateSetCommand()
        {
            WhatToDo = "ToggleStateSet";
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public bool On { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of SetUIAButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAButtonToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAButtonToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIAButtonToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUIACheckBoxToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIACheckBoxToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIACheckBoxToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIACheckBoxToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUIACustomToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIACustomToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIACustomToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIACustomToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUIADataItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIADataItemToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIADataItemToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIADataItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUIAListItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAListItemToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAListItemToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIAListItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUIAMenuItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAMenuItemToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAMenuItemToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIAMenuItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of SetUIARadioButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIARadioButtonToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIARadioButtonToggleStateCommand : InvokeUIAToggleStateSetCommand 
    { public SetUIARadioButtonToggleStateCommand() { } }
}
