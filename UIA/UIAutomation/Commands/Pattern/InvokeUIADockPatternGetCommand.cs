/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIADockPatternGetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UIADockPosition")]
    //[Cmdlet(VerbsLifecycle.Invoke, "UIADockPosition")]
    [Cmdlet(VerbsLifecycle.Invoke, "UIADockPatternGet")]
    //public class GetUIADockPositionCommand : PatternCmdletBase
    public class InvokeUIADockPatternGetCommand : PatternCmdletBase
    {
        public InvokeUIADockPatternGetCommand() { WhatToDo = "DockGet"; }
    }
    
    /// <summary>
    /// Description of GetUIACustomDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustomDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomDockPositionCommand : InvokeUIADockPatternGetCommand
    { public GetUIACustomDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUIAMenuBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuBarDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuBarDockPositionCommand : InvokeUIADockPatternGetCommand
    { public GetUIAMenuBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUIAPaneDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAPaneDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAPaneDockPositionCommand : InvokeUIADockPatternGetCommand
    { public GetUIAPaneDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUIAToolBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToolBarDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAToolBarDockPositionCommand : InvokeUIADockPatternGetCommand
    { public GetUIAToolBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUIAWindowDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAWindowDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAWindowDockPositionCommand : InvokeUIADockPatternGetCommand
    { public GetUIAWindowDockPositionCommand() { } }
}
