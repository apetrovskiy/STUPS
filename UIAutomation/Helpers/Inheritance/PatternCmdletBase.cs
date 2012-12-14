using UIAutomation.Commands;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;

    /// <summary>
    /// Description of PatternCmdletBase.
    /// </summary>
    //[Cmdlet(VerbsCommon.Set, "PatternCmdletBase")]
    //[Cmdlet]
    public class PatternCmdletBase : HasControlInputCmdletBase
    {
        #region Constructor
        public PatternCmdletBase()
        {
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters
        
        #region Properties
        protected string WhatToDo { get; set; }
        protected new PatternCmdletBase Child { get; set; }
        #endregion Properties
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            
            System.Windows.Automation.AutomationElement _control = null;
            
            // 20120824
            foreach (AutomationElement inputObject in this.InputObject) {
            
            try {
                _control = 
                    // 20120824
                    //(System.Windows.Automation.AutomationElement)InputObject;
                    //(AutomationElement)InputObject[0];
                    inputObject;
            } catch (Exception eControlTypeException) {
                WriteDebug("PatternCmdletBase: Control is not an AutomationElement");
                WriteDebug("PatternCmdletBase: " + eControlTypeException.Message);
                WriteObject(this, false);
                return;
            }
            switch (WhatToDo)
            {
// not yet implemented
// case "Dock":
// pattern = 
// (System.Windows.Automation.DockPattern)pt;
// break;
                case "Expand":
                    try {
                        ExpandCollapsePattern expandPattern = 
                            _control.GetCurrentPattern(ExpandCollapsePattern.Pattern)
                            as ExpandCollapsePattern;
                        if (expandPattern != null)
                        {
                            expandPattern.Expand();
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get ExpandCollapsePattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eExpPatternException) {
                        //writev
                        //writev
                    }
                    break;
                case "Collapse":
                    try {
                        ExpandCollapsePattern collapsePattern = 
                            _control.GetCurrentPattern(ExpandCollapsePattern.Pattern)
                            as ExpandCollapsePattern;
                        if (collapsePattern != null)
                        {
                            collapsePattern.Collapse();
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get ExpandCollapsePattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eCollPatternException) {
                        //writev
                    }
                    break;
                case "GridItem":
                    try {
                        GridItemPattern gridItemPattern =
                            _control.GetCurrentPattern(GridItemPattern.Pattern)
                            as GridItemPattern;
                        if (gridItemPattern != null) {
                            //gridItemPattern.Current.
                        }
                    }
                    catch (Exception eGridItemPatternException) {
                        
                    }
// not yet implemented
// GridItemPattern giPattern =
// _control.GetCurrentPattern(GridItemPattern.Pattern)
// as GridItemPattern;
// 
// giPattern.Current.
                    
                    break;
// not yet implemented
                case "Grid":
                    try {
                        GridPattern gridPattern =
                            _control.GetCurrentPattern(GridPattern.Pattern)
                            as GridPattern;
                        if (gridPattern != null) {
                            //gridPattern.GetItem
                        }
                    }
                    catch (Exception eGridPatternException) {
                        
                    }
// GridPattern gridPattern = 
// _control.GetCurrentPattern(GridPattern.Pattern)
// as GridPattern;
// if (gridPattern != null)
// {
//  // invokePattern.Invoke();
//  // gridPattern.Current.RowCount
//  // gridPattern.Current.ColumnCount
//  // gridPattern.GetItem(int row, int column);
// WriteObject(true);
// }
// else{
// WriteVerbose(this, "couldn't get GridPattern");
// WriteObject(false);
// }
                    break;
                case "Invoke":
                    try {
                        InvokePattern invokePattern = 
                            _control.GetCurrentPattern(InvokePattern.Pattern)
                            as InvokePattern;
                        if (invokePattern != null)
                        {
                            invokePattern.Invoke();
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get InvokePattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eInvokePatternException) {
                        //writev
                    }
                    break;
// not yet implemented
// case "MultipleView":
// pattern = 
// (System.Windows.Automation.MultipleViewPattern)pt;
// break;
                case "RangeValueGet":
                    try {
                        RangeValuePattern rvPatternGet = 
                            _control.GetCurrentPattern(RangeValuePattern.Pattern)
                            as RangeValuePattern;
                        if (rvPatternGet != null)
                        {
                            WriteObject(this, rvPatternGet.Current.Value);
                            // if (this.PassThru && CheckControl(this)) {
                            // WriteObject(inputObject);
                            //} else {
                            // WriteObject(true);
                            //}
                        }
                    }
                    catch (Exception eRVGetPatternException) {
                        //writev
                    }
                    break;
                case "RangeValueSet":
                    try {
                        RangeValuePattern rvPatternSet = 
                            _control.GetCurrentPattern(RangeValuePattern.Pattern)
                            as RangeValuePattern;
                        if (rvPatternSet != null)
                        {
                            try {
                                rvPatternSet.SetValue(
                                    ((Commands.InvokeUIARangeValuePatternSetCommand)Child).Value);
                                if (this.PassThru && CheckControl(this)) {
                                    WriteObject(this, inputObject);
                                } else {
                                    WriteObject(this, true);
                                }
                            }
                            catch {
                                WriteObject(this, false);
                            }
                        }
                    }
                    catch (Exception eRVSetPatternException) {
                        //writev
                    }
                    break;
				case "ScrollItem":
                    try {
					   ScrollItemPattern sciPattern = 
					       _control.GetCurrentPattern(ScrollItemPattern.Pattern)
                            as ScrollItemPattern;
					   if (sciPattern != null) {
					       try {
					           sciPattern.ScrollIntoView();
                                if (this.PassThru && CheckControl(this)) {
                                    WriteObject(this, inputObject);
                                } else {
                                    WriteObject(this, true);
                                }
					       }
					       catch {
					           WriteObject(this, false);
					       }
					   }
                    }
                    catch {
                        WriteObject(this, false);
                    }
                    break;
				case "Scroll":
                    try {
                        ScrollPattern scPattern =
    						_control.GetCurrentPattern(ScrollPattern.Pattern)
                            as ScrollPattern;
                        if (scPattern != null) {
                            try {
                                bool horizontal = ((InvokeUIAScrollPatternCommand)this).Horizontal;
                                bool vertical = ((InvokeUIAScrollPatternCommand)this).Vertical;
                                int horPercent = ((InvokeUIAScrollPatternCommand)this).HorizontalPercent;
                                int verPercent = ((InvokeUIAScrollPatternCommand)this).VerticalPercent;
                                System.Windows.Automation.ScrollAmount horAmount, verAmount = System.Windows.Automation.ScrollAmount.NoAmount;
                                horAmount = (System.Windows.Automation.ScrollAmount)((InvokeUIAScrollPatternCommand)this).HorizontalAmount;
                                verAmount = (System.Windows.Automation.ScrollAmount)((InvokeUIAScrollPatternCommand)this).VerticalAmount;
//                                if (((InvokeUIAScrollPatternCommand)this).Large) {
//                                    System.Windows.Automation.ScrollAmount.LargeIncrement = (System.Windows.Automation.ScrollAmount)10;
//                                } else {
//                                    System.Windows.Automation.ScrollAmount.SmallIncrement = (System.Windows.Automation.ScrollAmount)1;
//                                }
                                 if ((horPercent + verPercent) > 0) {
                                     scPattern.SetScrollPercent(horPercent, verPercent);
                                 }
                                 if (horizontal) {
                                     if (horAmount > 0) {
                                         scPattern.ScrollHorizontal(horAmount);
                                     }
                                 }
                                 if (vertical) {
                                     if (verAmount > 0) {
                                         scPattern.ScrollVertical(verAmount);
                                     }
                                 }
                                if (this.PassThru && CheckControl(this)) {
                                    WriteObject(this, inputObject);
                                } else {
                                    WriteObject(this, true);
                                }
                            }
                            catch {
                                WriteObject(this, false);
                            }
                        }
                    }
                    catch {
                        WriteObject(this, false);
                    }
					break;
                case "SelectionItem":
                    try {
                        SelectionItemPattern selItemPattern = 
                            _control.GetCurrentPattern(SelectionItemPattern.Pattern)
                            as SelectionItemPattern;
                        if (selItemPattern != null) {
                            selItemPattern.Select();
                            if (this.PassThru && CheckControl(this)) {
                                try {
                                    SelectionPattern selPatternTemp = 
                                        _control.GetCurrentPattern(SelectionPattern.Pattern)
                                        as SelectionPattern;
                                    if (selPatternTemp != null) {
                                        AutomationElement[] selection = 
                                            selPatternTemp.Current.GetSelection();
                                        WriteObject(this, selection);
                                    } else {
                                        WriteObject(this, true);
                                    }
                                } 
                                catch {}
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get SelectionItemPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eSelePatternException) {
                        //writev
                    }
                    break;
                case "SelectionItemState":
                    try {
                        SelectionItemPattern selItemPattern1 = 
                            _control.GetCurrentPattern(SelectionItemPattern.Pattern)
                            as SelectionItemPattern;
                        if (selItemPattern1 != null) {
                            WriteObject(this, selItemPattern1.Current.IsSelected);
                        }
                        else{
                            WriteVerbose(this, "couldn't get SelectionItemPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eSeleItemStatePatternException) {
                        //writev
                    }
                    break;
                case "Selection":
                    try {
                        SelectionPattern selPattern = 
                            _control.GetCurrentPattern(SelectionPattern.Pattern)
                            as SelectionPattern;
                        if (selPattern != null)
                        {
                            System.Windows.Automation.AutomationElement[] selection =
                                selPattern.Current.GetSelection();
                            WriteObject(this, selection);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            //} else {
                            // WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get SelectionPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eSelectionPatternException) {
                        //writev
                    }
                    break;
// not yet implemented
                case "TableItem":
                    try {
                        TableItemPattern tableItemPattern =
                            _control.GetCurrentPattern(TableItemPattern.Pattern)
                            as TableItemPattern;
                        if (tableItemPattern != null) {
                            //tableItemPattern.Current.
                        }
                    }
                    catch (Exception eTableItemPatternException) {
                        
                    }
// pattern = 
// (System.Windows.Automation.TableItemPattern)pt;
                    break;
// not yet implemented
                case "Table":
                    try {
                        TablePattern tablePattern =
                            _control.GetCurrentPattern(TablePattern.Pattern)
                            as TablePattern;
                        if (tablePattern != null) {
                            //tablePattern.GetItem
                        }
                    }
                    catch (Exception eTablePatternException) {
                        
                    }
// pattern = 
// (System.Windows.Automation.TablePattern)pt;
                    break;
// not yet implemented
                //case "Text":
                case "TextGet":
// pattern = 
// (System.Windows.Automation.TextPattern)pt;
// break;
                    try {
                        TextPattern textPatternGet = 
                            _control.GetCurrentPattern(TextPattern.Pattern)
                            as TextPattern;
                        if (textPatternGet != null) {
                            // textPattern.DocumentRange.// temporarily 
                            int textLength =
                                ((Commands.InvokeUIATextPatternGetCommand)this).TextLength;
                            //string resultText = string.Empty;
                            if (((Commands.InvokeUIATextPatternGetCommand)this).VisibleArea) {
                                TextPatternRange[] textRanges =
                                    textPatternGet.GetVisibleRanges();
                                for (int i = 0; i < textRanges.Length; i++) {
                                    WriteObject(this, textRanges[i]);
                                }
                            } else {
                                string resultText = 
                                    textPatternGet.DocumentRange.GetText(textLength);
                                WriteObject(this, resultText);
                            }
                        }
                        else {
                            WriteVerbose(this, "couldn't get TextPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eTextGetPatternException) {
                        //writev
                    }
                    break;
                case "TextSet":
                    try {
                        TextPattern textPatternSet = 
                            _control.GetCurrentPattern(TextPattern.Pattern)
                            as TextPattern;
                        if (textPatternSet != null) {
                            textPatternSet.GetSelection().SetValue(
                                ((Commands.InvokeUIATextPatternSetCommand)this).Text,
                                0);
                            WriteObject(this, true);
                        }
                        else {
                            WriteVerbose(this, "couldn't get TextPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eTextSetPatternException) {
                        //writev
                    }
                    break;
                case "Toggle":
                    try {
                        TogglePattern togglePattern = 
                            _control.GetCurrentPattern(TogglePattern.Pattern)
                            as TogglePattern;
                        if (togglePattern != null)
                        {
                            togglePattern.Toggle();
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get TogglePattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eTogglePatternException) {
                        //writev
                    }
                    break;
                case "ToggleState":
                    try {
                        TogglePattern togglePattern1 = 
                            _control.GetCurrentPattern(TogglePattern.Pattern)
                            as TogglePattern;
                        if (togglePattern1 != null)
                        {
                            bool toggleState = false;
                            if (togglePattern1.Current.ToggleState == ToggleState.On) {
                                toggleState = true;
                            }
                            WriteObject(this, toggleState);
                        }
                        else{
                            WriteVerbose(this, "couldn't get TogglePattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eToggleStatePatternException) {
                        //writev
                    }
                    break;
                case "TransformMove":
                    try {
                        TransformPattern transformMovePattern = 
                            _control.GetCurrentPattern(TransformPattern.Pattern)
                            as TransformPattern;
                        if (transformMovePattern != null)
                        {
                            transformMovePattern.Move(
                                ((Commands.InvokeUIATransformPatternMoveCommand)Child).TransformMoveX, 
                                ((Commands.InvokeUIATransformPatternMoveCommand)Child).TransformMoveY);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get TransformPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eTransformMovePatternException) {
                        //writev
                    }
                    break;
                case "TransformResize":
                    try {
                        TransformPattern transformResizePattern = 
                            _control.GetCurrentPattern(TransformPattern.Pattern)
                            as TransformPattern;
                        if (transformResizePattern != null)
                        {
                            transformResizePattern.Resize(
                                ((Commands.InvokeUIATransformPatternResizeCommand)Child).TransformResizeWidth, 
                                ((Commands.InvokeUIATransformPatternResizeCommand)Child).TransformResizeHeight);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get TransformPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eTransformResizePatternException) {
                        //writev
                    }
                    break;
                case "TransformRotate":
                    try {
                        TransformPattern transformRotatePattern = 
                            _control.GetCurrentPattern(TransformPattern.Pattern)
                            as TransformPattern;
                        if (transformRotatePattern != null)
                        {
                            transformRotatePattern.Rotate(
                                ((Commands.InvokeUIATransformPatternRotateCommand)Child).TransformRotateDegrees);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get TransformPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eTransformRotatePatternException) {
                        //writev
                    }
                    break;
                case "ValueGet":
                    try {
                        ValuePattern valuePatternGet = 
                            _control.GetCurrentPattern(ValuePattern.Pattern)
                            as ValuePattern;
                        object result = null;
                        if (valuePatternGet != null)
                        {
                            result = valuePatternGet.Current.Value;
                            WriteVerbose(this, "the result is " + result);
                            //if (this.PassThru && CheckControl(this)) {
                            //    WriteObject(this, inputObject);
                            //} else {
                            //    //WriteObject(this, true);
                                WriteObject(this, result);
                            //}
                        }
                        else{
                            WriteVerbose(this, "couldn't get ValuePattern");
                            WriteObject(this, result);
                        }
                    }
                    catch (Exception eValueGetPatternException) {
                        //writev
                    }
                    break;
                case "ValueSet":
                    try {
                        ValuePattern valuePatternSet = 
                            _control.GetCurrentPattern(ValuePattern.Pattern)
                            as ValuePattern;
                        if (valuePatternSet != null)
                        {
                            valuePatternSet.SetValue(
                                ((Commands.InvokeUIAValuePatternSetCommand)Child).Text);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get ValuePattern. SendKeys is used");
                            _control.SetFocus();
                            System.Windows.Forms.SendKeys.SendWait(
                                ((Commands.InvokeUIAValuePatternSetCommand)Child).Text);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                    }
                    catch (Exception eValueSetPatternException) {
                        //writev
                    }
                    break;
                case "Window":
                    try {
                        WindowPattern windowPattern = 
                            _control.GetCurrentPattern(WindowPattern.Pattern)
                            as WindowPattern;
                        if (windowPattern != null)
                        {
                            windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                            System.Threading.Thread.Sleep(1000);
                            windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                            windowPattern.WaitForInputIdle(1000);
                            System.Threading.Thread.Sleep(1000);
                            windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                            System.Threading.Thread.Sleep(1000);
                            windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                            if (this.PassThru && CheckControl(this)) {
                                WriteObject(this, inputObject);
                            } else {
                                WriteObject(this, true);
                            }
                        }
                        else{
                            WriteVerbose(this, "couldn't get WindowPattern");
                            WriteObject(this, false);
                        }
                    }
                    catch (Exception eWindowPatternException) {
                        //writev
                    }
                    break;
                case "Annotation":
                    WriteVerbose(this, "Annotation");
                    break;
                case "Drag":
                    WriteVerbose(this, "Drag");
                    break;
                case "DropTarget":
                    WriteVerbose(this, "DropTarget");
                    break;
                case "ItemContainer":
                    WriteVerbose(this, "ItemContainer");
                    break;
                case "LegacyIAccessible":
                    WriteVerbose(this, "LegacyIAccessible");
                    break;
                case "ObjectModel":
                    WriteVerbose(this, "ObjectModel");
                    break;
                case "Spreadsheet":
                    WriteVerbose(this, "Spreadsheet");
                    break;
                case "SpreadsheetItem":
                    WriteVerbose(this, "SpreadsheetItem");
                    break;
                case "Styles":
                    WriteVerbose(this, "Styles");
                    break;
                case "SynchronizedInput":
                    WriteVerbose(this, "SynchronizedInput");
                    break;
                case "TextChild":
                    WriteVerbose(this, "TextChild");
                    break;
                case "VirtualizedItem":
                    WriteVerbose(this, "VirtualizedItem");
                    break;
            }
            ////return;
            
            
            // 2012/04/10
//            Annotation Control Pattern
//            Dock Control Pattern
//            Drag Control Pattern
//            DropTarget Control Pattern
//            ExpandCollapse Control Pattern
//            Grid Control Pattern
//            GridItem Control Pattern
//            Invoke Control Pattern
//            ItemContainer Control Pattern
//            LegacyIAccessible Control Pattern
//            MultipleView Control Pattern
//            ObjectModel Control Pattern
//            RangeValue Control Pattern
//            Scroll Control Pattern
//            ScrollItem Control Pattern
//            Selection Control Pattern
//            SelectionItem Control Pattern
//            Spreadsheet Control Pattern
//            SpreadsheetItem Control Pattern
//            Styles Control Pattern
//            SynchronizedInput Control Pattern
//            Table Control Pattern
//            TableItem Control Pattern
//            Text and TextRange Control Patterns
//            TextChild Control Pattern
//            Toggle Control Pattern
//            Transform Control Pattern
//            Value Control Pattern
//            VirtualizedItem Control Pattern
//            Window Control Pattern
            
            
            } //20120824
        }
        
        protected override void EndProcessing()
        {
            this.Child = null;
        }
    }
}
