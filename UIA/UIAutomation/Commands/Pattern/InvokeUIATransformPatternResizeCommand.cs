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
    /// Description of InvokeUiaTransformPatternResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaTransformPatternResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaTransformPatternResizeCommand : PatternCmdletBase
    {    
        public InvokeUiaTransformPatternResizeCommand()
        {
            WhatToDo = "TransformResize";
            TransformResizeWidth = 1;
            TransformResizeHeight = 1;
            Child = this;
        }
        
        [UiaParameter][Parameter(Mandatory = true)]
        public double TransformResizeWidth { get; set; }
        [UiaParameter][Parameter(Mandatory = true)]
        public double TransformResizeHeight { get; set; }
    }
    
    /// <summary>
    /// Description of InvokeUiaCustomTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaCustomTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaCustomTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaCustomTransformResizeCommand() { } }

    /// <summary>
    /// Description of InvokeUiaHeaderTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaHeaderTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaHeaderItemTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaHeaderItemTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaHeaderItemTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaHeaderItemTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaMenuBarTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaMenuBarTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaMenuBarTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaMenuBarTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaPaneTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaPaneTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaPaneTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaPaneTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaThumbTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaThumbTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaThumbTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaThumbTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaToolBarTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaToolBarTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaToolBarTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaToolBarTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaWindowTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaWindowTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaWindowTransformResizeCommand : InvokeUiaTransformPatternResizeCommand
    { public InvokeUiaWindowTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUiaChildWindowTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaChildWindowTransformResize")]
    //[OutputType(typeof(bool))]
    
    public class InvokeUiaChildWindowTransformResizeCommand : InvokeUiaWindowTransformResizeCommand
    { public InvokeUiaChildWindowTransformResizeCommand() { } }
    
}