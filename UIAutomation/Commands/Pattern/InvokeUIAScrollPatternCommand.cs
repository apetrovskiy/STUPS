/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/19/2012
 * Time: 10:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAScrollPatternCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAScrollPattern")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAScrollPatternCommand : PatternCmdletBase
    { public InvokeUIAScrollPatternCommand() 
      { 
            WhatToDo = "Scroll"; 
            this.Vertical = false;
            this.Horizontal = false;
            //this.Percent = 0;
            this.PassThru = true;
            base.Child = this;
      }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "Percent")]
        [ValidateRange(-1, 100)]
        public int HorizontalPercent { get; set; }
        [Parameter(Mandatory = true,
                   ParameterSetName = "Percent")]
        [ValidateRange(-1, 100)]
        public int VerticalPercent { get; set; }
                [Parameter(Mandatory = true,
                   ParameterSetName = "Amount")]
        public int HorizontalAmount { get; set; }
        [Parameter(Mandatory = true,
                   ParameterSetName = "Amount")]
        public int VerticalAmount { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Horizontal { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Vertical { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Large { get; set; }
        #endregion Parameters

    /// <summary>
    /// Description of InvokeUIACalendarScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACalendarScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACalendarScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIACalendarScrollCommand() { } }
        
    /// <summary>
    /// Description of InvokeUIAComboBoxScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAComboBoxScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAComboBoxScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIAComboBoxScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIACustomScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIACustomScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIACustomScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIACustomScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADataGridScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADataGridScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADataGridScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIADataGridScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIADocumentScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIADocumentScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIADocumentScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIADocumentScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAListScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAListScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAListScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIAListScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAPaneScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAPaneScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAPaneScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIAPaneScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIAScrollBarScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAScrollBarScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAScrollBarScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIAScrollBarScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATabScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATabScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATabScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIATabScrollCommand() { } }
    
    /// <summary>
    /// Description of InvokeUIATreeScrollCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIATreeScroll")]
    //[OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIATreeScrollCommand : InvokeUIAScrollPatternCommand
    { public InvokeUIATreeScrollCommand() { } }
        
    }
}
