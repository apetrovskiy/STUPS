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
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaDockPatternGetCommand.
    /// </summary>
    // 20131024
    //[Cmdlet(VerbsCommon.Get, "UiaDockPosition")]
    //[Cmdlet(VerbsLifecycle.Invoke, "UiaDockPosition")]
    [Cmdlet(VerbsLifecycle.Invoke, "UiaDockPatternGet")]
    //public class GetUiaDockPositionCommand : PatternCmdletBase
    public class InvokeUiaDockPatternGetCommand : PatternCmdletBase
    {
        public InvokeUiaDockPatternGetCommand() { WhatToDo = "DockGet"; }
    }
    
    /// <summary>
    /// Description of GetUiaCustomDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustomDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaCustomDockPositionCommand : InvokeUiaDockPatternGetCommand
    { public GetUiaCustomDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaMenuBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuBarDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaMenuBarDockPositionCommand : InvokeUiaDockPatternGetCommand
    { public GetUiaMenuBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaPaneDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaPaneDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaPaneDockPositionCommand : InvokeUiaDockPatternGetCommand
    { public GetUiaPaneDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaToolBarDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaToolBarDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaToolBarDockPositionCommand : InvokeUiaDockPatternGetCommand
    { public GetUiaToolBarDockPositionCommand() { } }
    
    /// <summary>
    /// Description of GetUiaWindowDockPositionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaWindowDockPosition")]
    //[OutputType(typeof(bool))]
    
    public class GetUiaWindowDockPositionCommand : InvokeUiaDockPatternGetCommand
    { public GetUiaWindowDockPositionCommand() { } }
}
