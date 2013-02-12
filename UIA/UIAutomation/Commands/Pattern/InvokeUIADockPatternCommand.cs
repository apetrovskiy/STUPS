/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 11:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIADockPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADockPattern")]
    public class InvokeUIADockPatternCommand : PatternCmdletBase
    {
        public InvokeUIADockPatternCommand() { WhatToDo = "DockSet"; }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public System.Windows.Automation.DockPosition DockPosition { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of SetUIACustomDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIACustomDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIACustomDockPositionCommand : InvokeUIADockPatternCommand
    { public SetUIACustomDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAMenuBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAMenuBarDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAMenuBarDockPositionCommand : InvokeUIADockPatternCommand
    { public SetUIAMenuBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAPaneDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAPaneDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAPaneDockPositionCommand : InvokeUIADockPatternCommand
    { public SetUIAPaneDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAToolBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAToolBarDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAToolBarDockPositionCommand : InvokeUIADockPatternCommand
    { public SetUIAToolBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAWindowDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAWindowDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAWindowDockPositionCommand : InvokeUIADockPatternCommand
    { public SetUIAWindowDockPositionCommand() { } }
}
