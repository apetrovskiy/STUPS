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
    /// Description of InvokeUIADockPatternSetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsLifecycle.Invoke, "UIADockPattern")]
    [Cmdlet(VerbsLifecycle.Invoke, "UIADockPatternSet")]
    public class InvokeUIADockPatternSetCommand : PatternCmdletBase
    {
        public InvokeUIADockPatternSetCommand() { WhatToDo = "DockSet"; }
        
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
    public class SetUIACustomDockPositionCommand : InvokeUIADockPatternSetCommand
    { public SetUIACustomDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAMenuBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAMenuBarDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAMenuBarDockPositionCommand : InvokeUIADockPatternSetCommand
    { public SetUIAMenuBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAPaneDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAPaneDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAPaneDockPositionCommand : InvokeUIADockPatternSetCommand
    { public SetUIAPaneDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAToolBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAToolBarDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAToolBarDockPositionCommand : InvokeUIADockPatternSetCommand
    { public SetUIAToolBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUIAWindowDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAWindowDockPosition")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SetUIAWindowDockPositionCommand : InvokeUIADockPatternSetCommand
    { public SetUIAWindowDockPositionCommand() { } }
}
