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
    /// Description of InvokeUiaTransformPatternRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTransformPatternRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTransformPatternRotateCommand : PatternCmdletBase
    {
        public InvokeUiaTransformPatternRotateCommand()
        {
            WhatToDo = "TransformRotate";
            TransformRotateDegrees = 1;
            Child = this;
        }
        
        [UiaParameter][Parameter(Mandatory = true)]
        public double TransformRotateDegrees { get; set; }
    }
    
    /// <summary>
    /// Description of InvokeUiaCustomTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaCustomTransformRotateCommand() { } }

    /// <summary>
    /// Description of InvokeUiaHeaderTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaHeaderTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaHeaderItemTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderItemTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderItemTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaHeaderItemTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaMenuBarTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuBarTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuBarTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaMenuBarTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaPaneTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaPaneTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaPaneTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaPaneTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaThumbTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaThumbTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaThumbTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaThumbTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaToolBarTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToolBarTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaToolBarTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaToolBarTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaWindowTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWindowTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaWindowTransformRotateCommand : InvokeUiaTransformPatternRotateCommand
    { public InvokeUiaWindowTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaChildWindowTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaChildWindowTransformRotate")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaChildWindowTransformRotateCommand : InvokeUiaWindowTransformRotateCommand
    { public InvokeUiaChildWindowTransformRotateCommand() { } }
    
}