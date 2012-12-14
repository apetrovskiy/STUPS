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
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIATransformPatternResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATransformPatternResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATransformPatternResizeCommand : PatternCmdletBase
    {    
        public InvokeUIATransformPatternResizeCommand()
        {
            WhatToDo = "TransformResize";
            TransformResizeWidth = 1;
            TransformResizeHeight = 1;
            base.Child = this;
        }
        
        [Parameter(Mandatory = true)]
        public double TransformResizeWidth { get; set; }
        [Parameter(Mandatory = true)]
        public double TransformResizeHeight { get; set; }
    }
    
    /// <summary>
    /// Description of InvokeUIACustomTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIACustomTransformResizeCommand() { } }

    /// <summary>
    /// Description of InvokeUIAHeaderTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAHeaderTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAHeaderItemTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderItemTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderItemTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAHeaderItemTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAMenuBarTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuBarTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuBarTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAMenuBarTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAPaneTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAPaneTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAPaneTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAPaneTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAThumbTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAThumbTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAThumbTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAThumbTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAToolBarTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAToolBarTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAToolBarTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAToolBarTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAWindowTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWindowTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAWindowTransformResizeCommand : InvokeUIATransformPatternResizeCommand
    { public InvokeUIAWindowTransformResizeCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAChildWindowTransformResizeCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAChildWindowTransformResize")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAChildWindowTransformResizeCommand : InvokeUIAWindowTransformResizeCommand
    { public InvokeUIAChildWindowTransformResizeCommand() { } }
    
}