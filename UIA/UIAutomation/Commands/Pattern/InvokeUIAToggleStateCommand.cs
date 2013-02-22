/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/22/2012
 * Time: 10:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAToggleStateGetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToggleStateGet")]
    public class InvokeUIAToggleStateGetCommand : PatternCmdletBase
    {
        public InvokeUIAToggleStateGetCommand()
        {
            WhatToDo = "ToggleStateGet";
        }
    }
    
    /// <summary>
    /// Description of GetUIAButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAButtonToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAButtonToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIAButtonToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUIACheckBoxToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACheckBoxToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACheckBoxToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIACheckBoxToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUIACustomToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustomToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIACustomToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUIADataItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataItemToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataItemToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIADataItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUIAListItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAListItemToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListItemToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIAListItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUIAMenuItemToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuItemToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuItemToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIAMenuItemToggleStateCommand() { } }
    
    /// <summary>
    /// Description of GetUIARadioButtonToggleStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIARadioButtonToggleState")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIARadioButtonToggleStateCommand : InvokeUIAToggleStateGetCommand 
    { public GetUIARadioButtonToggleStateCommand() { } }
}
