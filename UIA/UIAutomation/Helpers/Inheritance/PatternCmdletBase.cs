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
    // 20130204
    using System.Collections;

    /// <summary>
    /// Description of PatternCmdletBase.
    /// </summary>
    //[Cmdlet(VerbsCommon.Set, "PatternCmdletBase")]
    //[Cmdlet]
    // 20130204
    public class PatternCmdletBase : HasControlInputCmdletBase // 20130204 GetControlCmdletBase // HasControlInputCmdletBase
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
            
            // 20130204
            // search for controls to apply the pattern to
#region "Pattern + search"
//            if ((null != this.ContainsText && string.Empty != this.ContainsText) ||
//                (null != this.Name && string.Empty != this.Name) ||
//                (null != this.AutomationId && string.Empty != this.AutomationId) ||
//                (null != this.Class && string.Empty != this.Class) ||
//                (null != this.Value && string.Empty != this.Value)) {
//                
//                if (! this.GetType().Name.ToUpper().Contains("INVOKEPATTERN")) {
//                    
//                    this.ControlType =
//                        this.GetType().Name.Replace("GetUIA", string.Empty).Replace("Command", string.Empty);
//                }
//                
//                ArrayList returnCollection =
//                    getControl(this);
//                
//                if (null == returnCollection || 0 == returnCollection.Count) {
//                    
//                    //
//                }
//                
//                this.InputObject = (AutomationElement[])returnCollection.ToArray(typeof(AutomationElement));
//            }
#endregion "Pattern + search"
            
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
                    case "DockSet":
                        InvokeDockSet(_control, inputObject, ((InvokeUIADockPatternCommand)this).DockPosition);
                        break;
                    case "DockGet":
                        InvokeDockGet(_control, inputObject);
                        break;
                    case "Expand":
                        InvokeExpand(_control, inputObject);
                        break;
                    case "Collapse":
                        InvokeCollapse(_control, inputObject);
                        break;
                    case "GridItem":
                        InvokeGridItem(_control, inputObject);
                        break;
                        // not yet implemented
                    case "Grid":
                        InvokeGrid(_control, inputObject);
                        break;
                    case "Invoke":
                        InvokeInvoke(_control, inputObject);
                        break;
                        // not yet implemented
                        // case "MultipleView":
                        // pattern =
                        // (System.Windows.Automation.MultipleViewPattern)pt;
                        // break;
                    case "RangeValueGet":
                        InvokeRangeValueGet(_control, inputObject);
                        break;
                    case "RangeValueSet":
                        InvokeRangeValueSet(_control, inputObject);
                        break;
                    case "ScrollItem":
                        InvokeScrollItem(_control, inputObject);
                        break;
                    case "Scroll":
                        InvokeScroll(_control, inputObject);
                        break;
                    case "SelectionItem":
                        InvokeSelectionItem(_control, inputObject);
                        break;
                    case "SelectionItemState":
                        InvokeSelectionItemState(_control, inputObject);
                        break;
                        // 20130108
                    case "SelectedItem": // return only elements that are selected
                        InvokeSelectedItem(_control, inputObject);
                        break;
                    case "Selection":
                        InvokeSelection(_control, inputObject);
                        break;
                        // not yet implemented
                    case "TableItem":
                        InvokeTableItem(_control, inputObject);
                        // pattern =
                        // (System.Windows.Automation.TableItemPattern)pt;
                        break;
                        // not yet implemented
                    case "Table":
                        InvokeTable(_control, inputObject);
                        // pattern =
                        // (System.Windows.Automation.TablePattern)pt;
                        break;
                        // not yet implemented
                        //case "Text":
                    case "TextGet":
                        // pattern =
                        // (System.Windows.Automation.TextPattern)pt;
                        // break;
                        InvokeTextGet(_control, inputObject);
                        break;
                    case "TextSet":
                        InvokeTextSet(_control, inputObject);
                        break;
                    case "Toggle":
                        InvokeToggle(_control, inputObject);
                        break;
                    case "ToggleStateGet":
                        InvokeToggleStateGet(_control, inputObject);
                        break;
                    case "ToggleStateSet":
                        InvokeToggleStateSet(_control, inputObject, ((InvokeUIAToggleStateSetCommand)this).On);
                        break;
                    case "TransformMove":
                        InvokeTransformMove(_control, inputObject);
                        break;
                    case "TransformResize":
                        InvokeTransformResize(_control, inputObject);
                        break;
                    case "TransformRotate":
                        InvokeTransformRotate(_control, inputObject);
                        break;
                    case "ValueGet":
                        InvokeValueGet(_control, inputObject);
                        break;
                    case "ValueSet":
                        InvokeValueSet(_control, inputObject);
                        break;
                    case "Window":
                        InvokeWindow(_control, inputObject);
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
        
        internal void InvokeDockGet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            //dockPattern.Current.DockPosition
            try {
                DockPattern dockPattern = _control.GetCurrentPattern(DockPattern.Pattern) as DockPattern;
                if (null != dockPattern) {
                    WriteObject(this, dockPattern.Current.DockPosition);
                } else {
                    WriteVerbose(this, "couldn't get DockPattern");
                    WriteObject(this, false);
                }
            }
            catch {
                
            }
        }
        
        internal void InvokeDockSet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject, DockPosition position)
        {
            try {
                DockPattern dockPattern = _control.GetCurrentPattern(DockPattern.Pattern) as DockPattern;
                if (null != dockPattern) {
                    dockPattern.SetDockPosition(position);
                    
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get DockPattern");
                    WriteObject(this, false);
                }
            }
            catch {
                
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeWindow(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                WindowPattern windowPattern = _control.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                if (windowPattern != null) {

                    // Close windowPattern.Close
                    // get windowPattern.Current.CanMaximize
                    // get windowPattern.Current.CanMinimize
                    // get windowPattern.Current.IsModal
                    // get windowPattern.Current.IsTopmost
                    // get windowPattern.Current.WindowInteractionState
                    // get windowPattern.Current.WindowVisualState
                    // set windowPattern.SetWindowVisualState(WindowVisualState.Maximized
                    // set windowPattern.SetWindowVisualState(WindowVisualState.Mini
                    // set windowPattern.SetWindowVisualState(WindowVisualState.Normal
                    // invoke windowPattern.WaitForInputIdle(int ms)
                    
                    windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                    System.Threading.Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                    windowPattern.WaitForInputIdle(1000);
                    System.Threading.Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                    System.Threading.Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get WindowPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eWindowPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeValueSet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ValuePattern valuePatternSet = _control.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                if (valuePatternSet != null) {
                    
                    this.WriteVerbose(this, "using ValuePattern");
                    valuePatternSet.SetValue(((Commands.InvokeUIAValuePatternSetCommand)Child).Text);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    
                    WriteVerbose(this, "couldn't get ValuePattern. SendKeys is used");
                    _control.SetFocus();
                    System.Windows.Forms.SendKeys.SendWait(((Commands.InvokeUIAValuePatternSetCommand)Child).Text);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                }
            } catch (Exception eValueSetPatternException) {
            }
        }

        //if (this.PassThru && CheckControl(this)) {
        //    WriteObject(this, inputObject);
        //} else {
        //    //WriteObject(this, true);
        //}
        //writev
        internal void InvokeValueGet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ValuePattern valuePatternGet = _control.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                object result = null;
                if (valuePatternGet != null) {
                    result = valuePatternGet.Current.Value;
                    WriteVerbose(this, "the result is " + result);
                    WriteObject(this, result);
                } else {
                    WriteVerbose(this, "couldn't get ValuePattern");
                    WriteObject(this, result);
                }
            } catch (Exception eValueGetPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeTransformRotate(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TransformPattern transformRotatePattern = _control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                if (transformRotatePattern != null) {
                    transformRotatePattern.Rotate(((Commands.InvokeUIATransformPatternRotateCommand)Child).TransformRotateDegrees);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TransformPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTransformRotatePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeTransformResize(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TransformPattern transformResizePattern = _control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                if (transformResizePattern != null) {
                    transformResizePattern.Resize(((Commands.InvokeUIATransformPatternResizeCommand)Child).TransformResizeWidth, ((Commands.InvokeUIATransformPatternResizeCommand)Child).TransformResizeHeight);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TransformPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTransformResizePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeTransformMove(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TransformPattern transformMovePattern = _control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                if (transformMovePattern != null) {
                    transformMovePattern.Move(((Commands.InvokeUIATransformPatternMoveCommand)Child).TransformMoveX, ((Commands.InvokeUIATransformPatternMoveCommand)Child).TransformMoveY);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TransformPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTransformMovePatternException) {
            }
        }

        //writev
        internal void InvokeToggleStateGet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TogglePattern togglePattern1 = _control.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (togglePattern1 != null) {
                    bool toggleState = false;
                    if (togglePattern1.Current.ToggleState == ToggleState.On) {
                        toggleState = true;
                    }
                    WriteObject(this, toggleState);
                } else {
                    WriteVerbose(this, "couldn't get TogglePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eToggleStatePatternException) {
            }
        }
        
        internal void InvokeToggleStateSet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject, bool on)
        {
            try {
                TogglePattern togglePattern1 = _control.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (togglePattern1 != null) {
                    //bool toggleState = false;
                    if (togglePattern1.Current.ToggleState == ToggleState.On && on) {
                        // nothing to do
                    } else if (togglePattern1.Current.ToggleState == ToggleState.Off && on) {
                        togglePattern1.Toggle();
                    } else if (togglePattern1.Current.ToggleState == ToggleState.On && !on) {
                        togglePattern1.Toggle();
                    } else if (togglePattern1.Current.ToggleState == ToggleState.Off && !on) {
                        // nothing to do
                    }
//                    if (ToggleState.On == togglePattern1.Current.ToggleState) {
//                        toggleState = true;
//                    }
//                    WriteObject(this, toggleState);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TogglePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eToggleStatePatternException) {
                //!!!!!!!!!!!!
                if (Preferences.PerformWin32ClickOnFail) {

                    ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                                 0);

                    if (this.PassThru && null != (inputObject as AutomationElement)) {

                        this.WriteObject(this, inputObject);

                    } else {

                        this.WriteObject(this, true);

                    }
                }
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeToggle(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TogglePattern togglePattern = _control.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (togglePattern != null) {
                    togglePattern.Toggle();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TogglePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTogglePatternException) {
            }
        }

        //writev
        internal void InvokeTextSet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TextPattern textPatternSet = _control.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                if (textPatternSet != null) {
                    textPatternSet.GetSelection().SetValue(((Commands.InvokeUIATextPatternSetCommand)this).Text, 0);
                    WriteObject(this, true);
                } else {
                    WriteVerbose(this, "couldn't get TextPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTextSetPatternException) {
            }
        }

        // textPattern.DocumentRange.// temporarily
        //string resultText = string.Empty;
        //writev
        internal void InvokeTextGet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TextPattern textPatternGet = _control.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                if (textPatternGet != null) {
                    int textLength = ((Commands.InvokeUIATextPatternGetCommand)this).TextLength;
                    if (((Commands.InvokeUIATextPatternGetCommand)this).VisibleArea) {
                        TextPatternRange[] textRanges = textPatternGet.GetVisibleRanges();
                        for (int i = 0; i < textRanges.Length; i++) {
                            WriteObject(this, textRanges[i]);
                        }
                    } else {
                        string resultText = textPatternGet.DocumentRange.GetText(textLength);
                        WriteObject(this, resultText);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TextPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTextGetPatternException) {
            }
        }

        //tablePattern.GetItem

        internal void InvokeTable(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TablePattern tablePattern = _control.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                if (tablePattern != null) {
                }
            } catch (Exception eTablePatternException) {
            }
        }

        //tableItemPattern.Current.

        internal void InvokeTableItem(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TableItemPattern tableItemPattern = _control.GetCurrentPattern(TableItemPattern.Pattern) as TableItemPattern;
                if (tableItemPattern != null) {
                    //tableItemPattern.Current.
                }
            } catch (Exception eTableItemPatternException) {
            }
        }

        // 20130108
        // deleted as useless
        //                            if (this.PassThru && CheckControl(this)) {
        //                                WriteObject(this, inputObject);
        //                            //} else {
        //                            // WriteObject(this, true);
        //                            }
        //writev
        internal void InvokeSelection(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionPattern selPattern = _control.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
                if (selPattern != null) {
                    System.Windows.Automation.AutomationElement[] selection = selPattern.Current.GetSelection();
                    WriteObject(this, selection);
                } else {
                    WriteVerbose(this, "couldn't get SelectionPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSelectionPatternException) {
            }
        }

        //WriteObject(this, selItemPattern1.Current.IsSelected);
        //                        else{
        //                            WriteVerbose(this, "couldn't get SelectionItemPattern");
        //                            WriteObject(this, false);
        //                        }
        //writev
        internal void InvokeSelectedItem(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionItemPattern selItemPattern1 = _control.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (selItemPattern1 != null) {
                    if (selItemPattern1.Current.IsSelected) {
                        WriteObject(this, InputObject);
                    }
                }
            } catch (Exception eSeleItemStatePatternException) {
            }
        }

        //writev
        internal void InvokeSelectionItemState(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionItemPattern selItemPattern1 = _control.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (selItemPattern1 != null) {
                    WriteObject(this, selItemPattern1.Current.IsSelected);
                } else {
                    WriteVerbose(this, "couldn't get SelectionItemPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSeleItemStatePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeSelectionItem(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionItemPattern selItemPattern = _control.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (selItemPattern != null) {
                    selItemPattern.Select();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        try {
                            SelectionPattern selPatternTemp = _control.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
                            if (selPatternTemp != null) {
                                AutomationElement[] selection = selPatternTemp.Current.GetSelection();
                                WriteObject(this, selection);
                            } else {
                                WriteObject(this, true);
                            }
                        } catch {
                        }
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get SelectionItemPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSelePatternException) {
            }
        }

        //                                if (((InvokeUIAScrollPatternCommand)this).Large) {
        //                                    System.Windows.Automation.ScrollAmount.LargeIncrement = (System.Windows.Automation.ScrollAmount)10;
        //                                } else {
        //                                    System.Windows.Automation.ScrollAmount.SmallIncrement = (System.Windows.Automation.ScrollAmount)1;
        //                                }
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void InvokeScroll(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ScrollPattern scPattern = _control.GetCurrentPattern(ScrollPattern.Pattern) as ScrollPattern;
                if (scPattern != null) {
                    try {
                        bool horizontal = ((InvokeUIAScrollPatternCommand)this).Horizontal;
                        bool vertical = ((InvokeUIAScrollPatternCommand)this).Vertical;
                        int horPercent = ((InvokeUIAScrollPatternCommand)this).HorizontalPercent;
                        int verPercent = ((InvokeUIAScrollPatternCommand)this).VerticalPercent;
                        System.Windows.Automation.ScrollAmount horAmount, verAmount = System.Windows.Automation.ScrollAmount.NoAmount;
                        horAmount = (System.Windows.Automation.ScrollAmount)((InvokeUIAScrollPatternCommand)this).HorizontalAmount;
                        verAmount = (System.Windows.Automation.ScrollAmount)((InvokeUIAScrollPatternCommand)this).VerticalAmount;
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
                        if (this.PassThru && null != (inputObject as AutomationElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } catch {
                        WriteObject(this, false);
                    }
                }
            } catch {
                WriteObject(this, false);
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void InvokeScrollItem(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ScrollItemPattern sciPattern = _control.GetCurrentPattern(ScrollItemPattern.Pattern) as ScrollItemPattern;
                if (sciPattern != null) {
                    try {
                        sciPattern.ScrollIntoView();
                        if (this.PassThru && null != (inputObject as AutomationElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } catch {
                        WriteObject(this, false);
                    }
                }
            } catch {
                WriteObject(this, false);
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeRangeValueSet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                RangeValuePattern rvPatternSet = _control.GetCurrentPattern(RangeValuePattern.Pattern) as RangeValuePattern;
                if (rvPatternSet != null) {
                    try {
                        rvPatternSet.SetValue(((Commands.InvokeUIARangeValuePatternSetCommand)Child).Value);
                        if (this.PassThru && null != (inputObject as AutomationElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } catch {
                        WriteObject(this, false);
                    }
                }
            } catch (Exception eRVSetPatternException) {
            }
        }

        // if (this.PassThru && CheckControl(this)) {
        // WriteObject(inputObject);
        //} else {
        // WriteObject(true);
        //}
        //writev
        internal void InvokeRangeValueGet(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                RangeValuePattern rvPatternGet = _control.GetCurrentPattern(RangeValuePattern.Pattern) as RangeValuePattern;
                if (rvPatternGet != null) {
                    WriteObject(this, rvPatternGet.Current.Value);
                }
            } catch (Exception eRVGetPatternException) {
            }
        }


        // 20130109
        //if (this.PassThru && CheckControl(this)) {



        // 20130105

        //this.RightClick,
        //this.MidClick,
        //this.Alt,
        //this.Shift,
        //this.Ctrl,
        //this.DoubleClick,
        //this.X,
        //this.Y);
        //if (this.PassThru) {
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        // 20130105
        //this.WriteObject(this, this.InputObject);




        //this.RightClick,
        //this.MidClick,
        //this.Alt,
        //this.Shift,
        //this.Ctrl,
        //this.DoubleClick,
        //this.X,
        //this.Y);
        //if (this.PassThru) {
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void InvokeInvoke(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                InvokePattern invokePattern = _control.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                if (invokePattern != null) {

                    invokePattern.Invoke();

                    if (this.PassThru && null != (inputObject as AutomationElement)) {

                        WriteObject(this, inputObject);

                    } else {

                        WriteObject(this, true);

                    }
                } else {

                    if (Preferences.PerformWin32ClickOnFail) {

                        ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                                     0);

                        if (this.PassThru && null != (inputObject as AutomationElement)) {

                            this.WriteObject(this, inputObject);

                        } else {

                            this.WriteObject(this, true);

                        }
                    } else {

                        WriteVerbose(this, "couldn't get InvokePattern");

                        WriteObject(this, false);

                    }
                }
            } catch (Exception eInvokePatternException) {

                this.WriteVerbose(this, eInvokePatternException.Message + "\r\n" + eInvokePatternException.GetType().Name);
                if (Preferences.PerformWin32ClickOnFail &&
                    "ElementNotAvailableException" != eInvokePatternException.GetType().Name) {

                    ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                                 0);

                    if (this.PassThru && null != (inputObject as AutomationElement)) {

                        this.WriteObject(this, inputObject);

                    } else {

                        this.WriteObject(this, true);

                    }
                } else {

                }
                // no reaction

            }
        }

        //gridPattern.GetItem

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
        internal void InvokeGrid(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                GridPattern gridPattern = _control.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
                if (gridPattern != null) {
                }
            } catch (Exception eGridPatternException) {
            }
        }

        //gridItemPattern.Current.

        // not yet implemented
        // GridItemPattern giPattern =
        // _control.GetCurrentPattern(GridItemPattern.Pattern)
        // as GridItemPattern;
        // 
        // giPattern.Current.
        internal void InvokeGridItem(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                GridItemPattern gridItemPattern = _control.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
                if (gridItemPattern != null) {
                    //gridItemPattern.Current.
                }
            } catch (Exception eGridItemPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeCollapse(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ExpandCollapsePattern collapsePattern = _control.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                if (collapsePattern != null) {
                    collapsePattern.Collapse();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get ExpandCollapsePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eCollPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        //writev
        internal void InvokeExpand(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ExpandCollapsePattern expandPattern = _control.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                if (expandPattern != null) {
                    expandPattern.Expand();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get ExpandCollapsePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eExpPatternException) {
            }
        }
        
        protected override void EndProcessing()
        {
            this.Child = null;
        }
    }
}
