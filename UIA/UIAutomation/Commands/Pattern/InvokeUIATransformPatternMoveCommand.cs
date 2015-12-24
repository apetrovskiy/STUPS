/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaTransformPatternMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTransformPatternMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTransformPatternMoveCommand : PatternCmdletBase
    {
        public InvokeUiaTransformPatternMoveCommand()
        {
            WhatToDo = "TransformMove";
            TransformMoveX = 1;
            TransformMoveY = 1;
            Child = this;
        }
        
        [UiaParameter][Parameter(Mandatory = true)]
        public double TransformMoveX { get; set; }
        [UiaParameter][Parameter(Mandatory = true)]
        public double TransformMoveY { get; set; }
        
    }

    /// <summary>
    /// Description of InvokeUiaCustomTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaCustomTransformMoveCommand() { } }
    
    /// <summary>
    /// Description of InvokeUiaHeaderTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaHeaderTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaHeaderItemTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderItemTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderItemTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaHeaderItemTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaMenuBarTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuBarTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuBarTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaMenuBarTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaPaneTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaPaneTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaPaneTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaPaneTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaThumbTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaThumbTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaThumbTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaThumbTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaToolBarTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToolBarTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaToolBarTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaToolBarTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaWindowTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWindowTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaWindowTransformMoveCommand : InvokeUiaTransformPatternMoveCommand
    { public InvokeUiaWindowTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaChildWindowTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaChildWindowTransformMove")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaChildWindowTransformMoveCommand : InvokeUiaWindowTransformMoveCommand
    { public InvokeUiaChildWindowTransformMoveCommand() { } }
    
}