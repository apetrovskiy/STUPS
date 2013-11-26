/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 11:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Automation;

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaDockPatternSetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaDockPattern")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDockPatternSet")]
    public class InvokeUiaDockPatternSetCommand : PatternCmdletBase
    {
        public InvokeUiaDockPatternSetCommand() { WhatToDo = "DockSet"; }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public DockPosition DockPosition { get; set; }
        #endregion Parameters
    }
    
    /// <summary>
    /// Description of SetUiaCustomDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaCustomDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaCustomDockPositionCommand : InvokeUiaDockPatternSetCommand
    { public SetUiaCustomDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUiaMenuBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaMenuBarDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaMenuBarDockPositionCommand : InvokeUiaDockPatternSetCommand
    { public SetUiaMenuBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUiaPaneDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaPaneDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaPaneDockPositionCommand : InvokeUiaDockPatternSetCommand
    { public SetUiaPaneDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUiaToolBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaToolBarDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaToolBarDockPositionCommand : InvokeUiaDockPatternSetCommand
    { public SetUiaToolBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of SetUiaWindowDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaWindowDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class SetUiaWindowDockPositionCommand : InvokeUiaDockPatternSetCommand
    { public SetUiaWindowDockPositionCommand() { } }
}
