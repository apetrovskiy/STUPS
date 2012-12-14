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
    /// Description of InvokeUIATransformPatternMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATransformPatternMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATransformPatternMoveCommand : PatternCmdletBase
    {
        public InvokeUIATransformPatternMoveCommand()
        {
            WhatToDo = "TransformMove";
            TransformMoveX = 1;
            TransformMoveY = 1;
            base.Child = this;
        }
        
        [Parameter(Mandatory = true)]
        public double TransformMoveX { get; set; }
        [Parameter(Mandatory = true)]
        public double TransformMoveY { get; set; }
        
    }

    /// <summary>
    /// Description of InvokeUIACustomTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIACustomTransformMoveCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAHeaderTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAHeaderTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAHeaderItemTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHeaderItemTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAHeaderItemTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAHeaderItemTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAMenuBarTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAMenuBarTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAMenuBarTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAMenuBarTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAPaneTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAPaneTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAPaneTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAPaneTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAThumbTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAThumbTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAThumbTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAThumbTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAToolBarTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAToolBarTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAToolBarTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAToolBarTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAWindowTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWindowTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAWindowTransformMoveCommand : InvokeUIATransformPatternMoveCommand
    { public InvokeUIAWindowTransformMoveCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAChildWindowTransformMoveCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAChildWindowTransformMove")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAChildWindowTransformMoveCommand : InvokeUIAWindowTransformMoveCommand
    { public InvokeUIAChildWindowTransformMoveCommand() { } }
    
}