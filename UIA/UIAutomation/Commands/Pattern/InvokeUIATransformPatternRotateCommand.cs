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
    /// Description of InvokeUIATransformPatternRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATransformPatternRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATransformPatternRotateCommand : PatternCmdletBase
    {
        public InvokeUIATransformPatternRotateCommand()
        {
            WhatToDo = "TransformRotate";
            TransformRotateDegrees = 1;
            base.Child = this;
        }
        
        [Parameter(Mandatory = true)]
        public double TransformRotateDegrees { get; set; }
    }
    
    /// <summary>
    /// Description of InvokeUIACustomTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIACustomTransformRotateCommand() { } }

    /// <summary>
    /// Description of InvokeUIAHeaderTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAHeaderTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAHeaderItemTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderItemTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderItemTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAHeaderItemTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAMenuBarTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuBarTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuBarTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAMenuBarTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAPaneTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAPaneTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAPaneTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAPaneTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAThumbTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAThumbTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAThumbTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAThumbTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAToolBarTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAToolBarTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAToolBarTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAToolBarTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAWindowTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWindowTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAWindowTransformRotateCommand : InvokeUIATransformPatternRotateCommand
    { public InvokeUIAWindowTransformRotateCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAChildWindowTransformRotateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAChildWindowTransformRotate")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAChildWindowTransformRotateCommand : InvokeUIAWindowTransformRotateCommand
    { public InvokeUIAChildWindowTransformRotateCommand() { } }
    
}