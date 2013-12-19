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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;
    using System.Collections;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using UIAutomation.Commands;

    /// <summary>
    /// Description of PatternCmdletBase.
    /// </summary>
    //[Cmdlet(VerbsCommon.Set, "PatternCmdletBase")]
    //[Cmdlet]
    // 20130204
    public class PatternCmdletBase : HasControlInputCmdletBase
    {
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
            if (!CheckAndPrepareInput(this)) { return; }
            
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
            
            // 20131109
            //System.Windows.Automation.AutomationElement _control = null;
            /*
            IUiElement _control = null;
            */
            
            foreach (IUiElement inputObject in InputObject) {
                IUiElement control = null;
                try {
                    control =
                        inputObject;
                } catch (Exception eControlTypeException) {
                    WriteVerbose(this, "PatternCmdletBase: Control is not an AutomationElement");
                    WriteVerbose(this, "PatternCmdletBase: " + eControlTypeException.Message);
                    WriteObject(this, false);
                    return;
                }
                switch (WhatToDo)
                {
                    case "DockSet":
                        CallDockPatternForSet(this, control, inputObject, ((InvokeUiaDockPatternSetCommand)this).DockPosition);
                        break;
                    case "DockGet":
                        CallDockPatternForGet(this, control, inputObject);
                        break;
                    case "Expand":
                        CallExpandPattern(this, control, inputObject);
                        break;
                    case "Collapse":
                        CallCollapsePattern(this, control, inputObject);
                        break;
                    case "GridItem":
                        CallGridItemPattern(this, control, inputObject);
                        break;
                        // not yet implemented
                    case "Grid":
                        CallGridPattern(this, control, inputObject);
                        break;
                    case "Invoke":
                        CallInvokePattern(this, control, inputObject);
                        break;
                        // not yet implemented
                        // case "MultipleView":
                        // pattern =
                        // (System.Windows.Automation.MultipleViewPattern)pt;
                        // break;
                    case "RangeValueGet":
                        CallRangeValuePatternForGet(this, control, inputObject);
                        break;
                    case "RangeValueSet":
                        CallRangeValuePatternForSet(this, control, inputObject);
                        break;
                    case "ScrollItem":
                        CallScrollItemPattern(this, control, inputObject);
                        break;
                    case "Scroll":
                        CallScrollPattern(this, control, inputObject);
                        break;
                    case "SelectionItem":
                        CallSelectionItemPattern(this, control, inputObject);
                        break;
                    case "SelectionItemState":
                        CallSelectionItemPatternForState(this, control, inputObject);
                        break;
                    case "SelectedItem": // return only elements that are selected
                        CallSelectedItemPattern(this, control, inputObject);
                        break;
                    case "Selection":
                        CallSelectionPattern(this, control, inputObject);
                        break;
                        // not yet implemented
                    case "TableItem":
                        CallTableItemPattern(this, control, inputObject);
                        break;
                        // not yet implemented
                    case "Table":
                        CallTablePattern(this, control, inputObject);
                        // pattern =
                        // (System.Windows.Automation.TablePattern)pt;
                        break;
                        // not yet implemented
                        //case "Text":
                    case "TextGet":
                        // pattern =
                        // (System.Windows.Automation.TextPattern)pt;
                        // break;
                        CallTextPatternForGet(this, control, inputObject);
                        break;
                    case "TextSet":
                        CallTextPatternForSet(this, control, inputObject);
                        break;
                    case "Toggle":
                        CallTogglePatternMethod(this, control, inputObject);
                        break;
                    case "ToggleStateGet":
                        CallTogglePatternForGet(this, control, inputObject);
                        break;
                    case "ToggleStateSet":
                        CallTogglePatternForSet(this, control, inputObject, ((InvokeUiaToggleStateSetCommand)this).On);
                        break;
                    case "TransformMove":
                        CallTransformPatternForMove(this, control, inputObject);
                        break;
                    case "TransformResize":
                        CallTransformPatternForResize(this, control, inputObject);
                        break;
                    case "TransformRotate":
                        CallTransformPatternForRotate(this, control, inputObject);
                        break;
                    case "ValueGet":
                        CallValuePatternForGet(this, control, inputObject);
                        break;
                    case "ValueSet":
                        CallValuePatternForSet(this, control, inputObject);
                        break;
                    case "Window":
                        CallWindowPattern(this, control, inputObject);
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
        
        internal void CallDockPatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            //dockPattern.Current.DockPosition
            try {
                // 20131208
                // DockPattern dockPattern = control.GetCurrentPattern(DockPattern.Pattern) as DockPattern;
                // DockPattern dockPattern = control.GetCurrentPattern<IMySuperDockPattern, DockPattern>(DockPattern.Pattern) as DockPattern;
                IMySuperDockPattern dockPattern = control.GetCurrentPattern<IMySuperDockPattern>(DockPattern.Pattern);
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
        
        internal void CallDockPatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject, DockPosition position)
        {
            try {
                // 20131208
                // DockPattern dockPattern = control.GetCurrentPattern(DockPattern.Pattern) as DockPattern;
                // DockPattern dockPattern = control.GetCurrentPattern<IMySuperDockPattern, DockPattern>(DockPattern.Pattern) as DockPattern;
                IMySuperDockPattern dockPattern = control.GetCurrentPattern<IMySuperDockPattern>(DockPattern.Pattern);
                if (null != dockPattern) {
                    dockPattern.SetDockPosition(position);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallWindowPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // WindowPattern windowPattern = control.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                // WindowPattern windowPattern = control.GetCurrentPattern<IMySuperWindowPattern, WindowPattern>(WindowPattern.Pattern) as WindowPattern;
                // IMySuperWindowPattern windowPattern = control.GetCurrentPattern<IMySuperWindowPattern, WindowPattern>(); //WindowPattern.Pattern);
                IMySuperWindowPattern windowPattern = control.GetCurrentPattern<IMySuperWindowPattern>(WindowPattern.Pattern);
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
                    Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                    windowPattern.WaitForInputIdle(1000);
                    Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                    Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallValuePatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperValuePattern valuePatternSet = control.GetValuePattern();
                // IMySuperValuePattern valuePatternSet = control.GetCurrentPattern<IMySuperValuePattern, ValuePattern>(); //ValuePattern.Pattern);
                IMySuperValuePattern valuePatternSet = control.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern);
                if (valuePatternSet != null) {
                    
                    WriteVerbose(this, "using ValuePattern");
                    valuePatternSet.SetValue(((InvokeUiaValuePatternSetCommand)Child).Text);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    
                    WriteVerbose(this, "couldn't get ValuePattern. SendKeys is used");
                    control.SetFocus();
                    SendKeys.SendWait(((InvokeUiaValuePatternSetCommand)Child).Text);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                }
            } catch (Exception eValueSetPatternException) {
            }
        }
        
        internal void CallValuePatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperValuePattern valuePatternGet = control.GetValuePattern();
                // IMySuperValuePattern valuePatternGet = control.GetCurrentPattern<IMySuperValuePattern, ValuePattern>();
                IMySuperValuePattern valuePatternGet = control.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern);
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
        
        internal void CallTransformPatternForRotate(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TransformPattern transformRotatePattern = control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                // TransformPattern transformRotatePattern = control.GetCurrentPattern<IMySuperTransformPattern, TransformPattern>(TransformPattern.Pattern) as TransformPattern;
                IMySuperTransformPattern transformRotatePattern = control.GetCurrentPattern<IMySuperTransformPattern>(TransformPattern.Pattern);
                if (transformRotatePattern != null) {
                    transformRotatePattern.Rotate(((InvokeUiaTransformPatternRotateCommand)Child).TransformRotateDegrees);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallTransformPatternForResize(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TransformPattern transformResizePattern = control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                // TransformPattern transformResizePattern = control.GetCurrentPattern<IMySuperTransformPattern, TransformPattern>(TransformPattern.Pattern) as TransformPattern;
                IMySuperTransformPattern transformResizePattern = control.GetCurrentPattern<IMySuperTransformPattern>(TransformPattern.Pattern);
                if (transformResizePattern != null) {
                    transformResizePattern.Resize(((InvokeUiaTransformPatternResizeCommand)Child).TransformResizeWidth, ((InvokeUiaTransformPatternResizeCommand)Child).TransformResizeHeight);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallTransformPatternForMove(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TransformPattern transformMovePattern = control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                // TransformPattern transformMovePattern = control.GetCurrentPattern<IMySuperTransformPattern, TransformPattern>(TransformPattern.Pattern) as TransformPattern;
                IMySuperTransformPattern transformMovePattern = control.GetCurrentPattern<IMySuperTransformPattern>(TransformPattern.Pattern);
                if (transformMovePattern != null) {
                    transformMovePattern.Move(((InvokeUiaTransformPatternMoveCommand)Child).TransformMoveX, ((InvokeUiaTransformPatternMoveCommand)Child).TransformMoveY);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallTogglePatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                cmdlet.WriteVerbose(cmdlet, "trying to get TogglePattern");
                // IMySuperTogglePattern togglePattern = control.GetTogglePattern();
                // IMySuperTogglePattern togglePattern = control.GetCurrentPattern<IMySuperTogglePattern, TogglePattern>();
                IMySuperTogglePattern togglePattern = control.GetCurrentPattern<IMySuperTogglePattern>(TogglePattern.Pattern);
                if (togglePattern != null) {
                    
                    cmdlet.WriteVerbose(cmdlet, "TogglePattern != null");
                    bool toggleState = togglePattern.Current.ToggleState == ToggleState.On;
                    WriteObject(this, toggleState);
                } else {
                    WriteVerbose(this, "couldn't get TogglePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eToggleStatePatternException) {
                cmdlet.WriteVerbose(eToggleStatePatternException.Message);
            }
        }
        
        internal void CallTogglePatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject, bool on)
        {
            try {
                // IMySuperTogglePattern togglePattern1 = control.GetTogglePattern();
                // IMySuperTogglePattern togglePattern = control.GetCurrentPattern<IMySuperTogglePattern, TogglePattern>();
                IMySuperTogglePattern togglePattern = control.GetCurrentPattern<IMySuperTogglePattern>(TogglePattern.Pattern);
                if (togglePattern != null) {
                    if (togglePattern.Current.ToggleState == ToggleState.On && on) {
                        // nothing to do
                        cmdlet.WriteVerbose(this, "the control is already ON");
                    } else if (togglePattern.Current.ToggleState == ToggleState.Off && on) {
                        cmdlet.WriteVerbose(this, "setting the control ON");
                        togglePattern.Toggle();
                    } else if (togglePattern.Current.ToggleState == ToggleState.On && !on) {
                        cmdlet.WriteVerbose(this, "setting the control OFF");
                        togglePattern.Toggle();
                    } else if (togglePattern.Current.ToggleState == ToggleState.Off && !on) {
                        cmdlet.WriteVerbose(this, "the control is already OF");
                        // nothing to do
                    }
//                    if (ToggleState.On == togglePattern1.Current.ToggleState) {
//                        toggleState = true;
//                    }
//                    WriteObject(this, toggleState);
                    if (PassThru && null != (inputObject as IUiElement)) {
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

                    // 20131125
                    //ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                    ClickControl(this, control, false, false, false, false, false, false, false, 0, 0,
                                 0);
                    
                    // 20131109
                    if (PassThru && null != (inputObject as IUiElement)) {
                    //if (this.PassThru && null != (inputObject as AutomationElement)) {

                        WriteObject(this, inputObject);

                    } else {

                        WriteObject(this, true);

                    }
                }
            }
        }
        
        internal void CallTogglePatternMethod(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperTogglePattern togglePattern = control.GetTogglePattern();
                // IMySuperTogglePattern togglePattern = control.GetCurrentPattern<IMySuperTogglePattern, TogglePattern>();
                IMySuperTogglePattern togglePattern = control.GetCurrentPattern<IMySuperTogglePattern>(TogglePattern.Pattern);
                if (togglePattern != null) {
                    togglePattern.Toggle();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallTextPatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TextPattern textPatternSet = control.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                // TextPattern textPatternSet = control.GetCurrentPattern<IMySuperTextPattern, TextPattern>(TextPattern.Pattern) as TextPattern;
                IMySuperTextPattern textPatternSet = control.GetCurrentPattern<IMySuperTextPattern>(TextPattern.Pattern);
                if (textPatternSet != null) {
                    textPatternSet.GetSelection().SetValue(((InvokeUiaTextPatternSetCommand)this).Text, 0);
                    WriteObject(this, true);
                } else {
                    WriteVerbose(this, "couldn't get TextPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTextSetPatternException) {
            }
        }
        
        internal void CallTextPatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TextPattern textPatternGet = control.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                // TextPattern textPatternGet = control.GetCurrentPattern<IMySuperTextPattern, TextPattern>(TextPattern.Pattern) as TextPattern;
                IMySuperTextPattern textPatternGet = control.GetCurrentPattern<IMySuperTextPattern>(TextPattern.Pattern);
                if (textPatternGet != null) {
                    int textLength = ((InvokeUiaTextPatternGetCommand)this).TextLength;
                    if (((InvokeUiaTextPatternGetCommand)this).VisibleArea)
                    {
                        TextPatternRange[] textRanges = textPatternGet.GetVisibleRanges();
                        foreach (TextPatternRange tpr in textRanges)
                        {
                            WriteObject(this, tpr);
                        }
                    }
                    else {
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
        
        internal void CallTablePattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TablePattern tablePattern = control.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                // TablePattern tablePattern = control.GetCurrentPattern<IMySuperTablePattern, TablePattern>(TablePattern.Pattern) as TablePattern;
                IMySuperTablePattern tablePattern = control.GetCurrentPattern<IMySuperTablePattern>(TablePattern.Pattern);
                if (tablePattern != null) {
                }
            } catch (Exception eTablePatternException) {
            }
        }

        internal void CallTableItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TableItemPattern tableItemPattern = control.GetCurrentPattern(TableItemPattern.Pattern) as TableItemPattern;
                // TableItemPattern tableItemPattern = control.GetCurrentPattern<IMySuperTableItemPattern, TableItemPattern>(TableItemPattern.Pattern) as TableItemPattern;
                IMySuperTableItemPattern tableItemPattern = control.GetCurrentPattern<IMySuperTableItemPattern>(TableItemPattern.Pattern);
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
        internal void CallSelectionPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperSelectionPattern selPattern = control.GetSelectionPattern();
                // IMySuperSelectionPattern selPattern = control.GetCurrentPattern<IMySuperSelectionPattern, SelectionPattern>();
                IMySuperSelectionPattern selPattern = control.GetCurrentPattern<IMySuperSelectionPattern>(SelectionPattern.Pattern);
                if (selPattern != null) {
                    IUiElement[] selection = AutomationFactory.GetUiEltCollection(selPattern.Current.GetSelection()).Cast<UiElement>().ToArray();
                    WriteObject(this, selection);
                } else {
                    WriteVerbose(this, "couldn't get SelectionPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSelectionPatternException) {
            }
        }
        
        internal void CallSelectedItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperSelectionItemPattern selItemPattern = control.GetSelectionItemPattern();
                // IMySuperSelectionItemPattern selItemPattern = control.GetCurrentPattern<IMySuperSelectionItemPattern, SelectionItemPattern>();
                IMySuperSelectionItemPattern selItemPattern = control.GetCurrentPattern<IMySuperSelectionItemPattern>(SelectionItemPattern.Pattern);
                if (selItemPattern == null) return;
                if (selItemPattern.Current.IsSelected) {
                    WriteObject(this, InputObject);
                }
            } catch (Exception eSeleItemStatePatternException) {
            }
        }
        
        internal void CallSelectionItemPatternForState(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperSelectionItemPattern selItemPattern = control.GetSelectionItemPattern();
                // IMySuperSelectionItemPattern selItemPattern = control.GetCurrentPattern<IMySuperSelectionItemPattern, SelectionItemPattern>();
                IMySuperSelectionItemPattern selItemPattern = control.GetCurrentPattern<IMySuperSelectionItemPattern>(SelectionItemPattern.Pattern);
                if (selItemPattern != null) {
                    WriteObject(this, selItemPattern.Current.IsSelected);
                } else {
                    WriteVerbose(this, "couldn't get SelectionItemPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSeleItemStatePatternException) {
            }
        }
        
        internal void CallSelectionItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperSelectionItemPattern selItemPattern = control.GetSelectionItemPattern();
                // IMySuperSelectionItemPattern selItemPattern = control.GetCurrentPattern<IMySuperSelectionItemPattern, SelectionItemPattern>();
                IMySuperSelectionItemPattern selItemPattern = control.GetCurrentPattern<IMySuperSelectionItemPattern>(SelectionItemPattern.Pattern);
                if (selItemPattern != null) {
                    selItemPattern.Select();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        try {
                            // 20131208
                            // SelectionPattern selPatternTemp = control.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
                            // SelectionPattern selPatternTemp = control.GetCurrentPattern<IMySuperSelectionItemPattern, SelectionItemPattern>(SelectionPattern.Pattern) as SelectionPattern;
                            IMySuperSelectionPattern selPatternTemp = control.GetCurrentPattern<IMySuperSelectionPattern>(SelectionPattern.Pattern);
                            if (selPatternTemp != null) {
                                // 20131208
                                // IUiElement[] selection = AutomationFactory.GetUiEltCollection(selPatternTemp.Current.GetSelection()).Cast<UiElement>().ToArray();
                                IUiElement[] selection = AutomationFactory.GetUiEltCollection(selPatternTemp.Current.GetSelection()).ToArray();
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

        //                                if (((InvokeUiaScrollPatternCommand)this).Large) {
        //                                    System.Windows.Automation.ScrollAmount.LargeIncrement = (System.Windows.Automation.ScrollAmount)10;
        //                                } else {
        //                                    System.Windows.Automation.ScrollAmount.SmallIncrement = (System.Windows.Automation.ScrollAmount)1;
        //                                }
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void CallScrollPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // ScrollPattern scPattern = control.GetCurrentPattern(ScrollPattern.Pattern) as ScrollPattern;
                // ScrollPattern scPattern = control.GetCurrentPattern<IMySuperScrollPattern, ScrollPattern>(ScrollPattern.Pattern) as ScrollPattern;
                // IMySuperScrollPattern scPattern = control.GetScrollPattern();
                // IMySuperScrollPattern scPattern = control.GetCurrentPattern<IMySuperScrollPattern, ScrollPattern>();
                IMySuperScrollPattern scPattern = control.GetCurrentPattern<IMySuperScrollPattern>(ScrollPattern.Pattern);
                if (scPattern == null) return;
                try {
                    bool horizontal = ((InvokeUiaScrollPatternCommand)this).Horizontal;
                    bool vertical = ((InvokeUiaScrollPatternCommand)this).Vertical;
                    int horPercent = ((InvokeUiaScrollPatternCommand)this).HorizontalPercent;
                    int verPercent = ((InvokeUiaScrollPatternCommand)this).VerticalPercent;
                    ScrollAmount horAmount = ScrollAmount.NoAmount;
                    ScrollAmount verAmount = ScrollAmount.NoAmount;
                    horAmount = (ScrollAmount)((InvokeUiaScrollPatternCommand)this).HorizontalAmount;
                    verAmount = (ScrollAmount)((InvokeUiaScrollPatternCommand)this).VerticalAmount;
                    // for refactoring
                    //System.Windows.Automation.ScrollAmount horAmount, verAmount = System.Windows.Automation.ScrollAmount.NoAmount;
                    //horAmount = (System.Windows.Automation.ScrollAmount)((InvokeUiaScrollPatternCommand)this).HorizontalAmount;
                    //verAmount = (System.Windows.Automation.ScrollAmount)((InvokeUiaScrollPatternCommand)this).VerticalAmount;
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
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } catch {
                    WriteObject(this, false);
                }

                /*
                if (scPattern != null) {
                    try {
                        bool horizontal = ((InvokeUiaScrollPatternCommand)this).Horizontal;
                        bool vertical = ((InvokeUiaScrollPatternCommand)this).Vertical;
                        int horPercent = ((InvokeUiaScrollPatternCommand)this).HorizontalPercent;
                        int verPercent = ((InvokeUiaScrollPatternCommand)this).VerticalPercent;
                        System.Windows.Automation.ScrollAmount horAmount, verAmount = System.Windows.Automation.ScrollAmount.NoAmount;
                        horAmount = (System.Windows.Automation.ScrollAmount)((InvokeUiaScrollPatternCommand)this).HorizontalAmount;
                        verAmount = (System.Windows.Automation.ScrollAmount)((InvokeUiaScrollPatternCommand)this).VerticalAmount;
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
                */
            } catch {
                WriteObject(this, false);
            }
        }
        
        internal void CallScrollItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // ScrollItemPattern sciPattern = control.GetCurrentPattern(ScrollItemPattern.Pattern) as ScrollItemPattern;
                // ScrollItemPattern sciPattern = control.GetCurrentPattern<IMySuperScrollItemPattern, ScrollItemPattern>(ScrollItemPattern.Pattern) as ScrollItemPattern;
                // IMySuperScrollItemPattern sciPattern = control.GetScrollItemPattern();
                // IMySuperScrollItemPattern sciPattern = control.GetCurrentPattern<IMySuperScrollItemPattern, ScrollItemPattern>();
                IMySuperScrollItemPattern sciPattern = control.GetCurrentPattern<IMySuperScrollItemPattern>(ScrollItemPattern.Pattern);
                if (sciPattern == null) return;
                try {
                    sciPattern.ScrollIntoView();
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } catch {
                    WriteObject(this, false);
                }
            } catch {
                WriteObject(this, false);
            }
        }
        
        internal void CallRangeValuePatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // RangeValuePattern rvPatternSet = control.GetCurrentPattern(RangeValuePattern.Pattern) as RangeValuePattern;
                // RangeValuePattern rvPatternSet = control.GetCurrentPattern<IMySuperRangeValuePattern, RangeValuePattern>(RangeValuePattern.Pattern) as RangeValuePattern;
                IMySuperRangeValuePattern rvPatternSet = control.GetCurrentPattern<IMySuperRangeValuePattern>(RangeValuePattern.Pattern);
                if (rvPatternSet == null) return;
                try {
                    rvPatternSet.SetValue(((InvokeUiaRangeValuePatternSetCommand)Child).Value);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } catch {
                    WriteObject(this, false);
                }
            } catch (Exception eRVSetPatternException) {
            }
        }
        
        internal void CallRangeValuePatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // RangeValuePattern rvPatternGet = control.GetCurrentPattern(RangeValuePattern.Pattern) as RangeValuePattern;
                // RangeValuePattern rvPatternGet = control.GetCurrentPattern<IMySuperRangeValuePattern, RangeValuePattern>(RangeValuePattern.Pattern) as RangeValuePattern;
                IMySuperRangeValuePattern rvPatternGet = control.GetCurrentPattern<IMySuperRangeValuePattern>(RangeValuePattern.Pattern);
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
        // 20131109
        //internal void InvokeInvoke(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        internal void CallInvokePattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperInvokePattern invokePattern = control.GetInvokePattern();
                // IMySuperInvokePattern invokePattern = control.GetCurrentPattern<IMySuperInvokePattern, InvokePattern>();
                IMySuperInvokePattern invokePattern = control.GetCurrentPattern<IMySuperInvokePattern>(InvokePattern.Pattern);
                if (invokePattern != null) {
                    invokePattern.Invoke();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    if (Preferences.PerformWin32ClickOnFail) {
                        
                        ClickControl(this, control, false, false, false, false, false, false, false, 0, 0,
                                     0);
                        
                        if (PassThru && null != (inputObject as IUiElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } else {
                        WriteVerbose(this, "couldn't get InvokePattern");
                        WriteObject(this, false);
                    }
                }
            } catch (Exception eInvokePatternException) {
                
                WriteVerbose(this, eInvokePatternException.Message + "\r\n" + eInvokePatternException.GetType().Name);
                if (Preferences.PerformWin32ClickOnFail &&
                    "ElementNotAvailableException" != eInvokePatternException.GetType().Name) {
                    
                    ClickControl(this, control, false, false, false, false, false, false, false, 0, 0,
                                 0);

                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
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
        internal void CallGridPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // GridPattern gridPattern = control.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
                // GridPattern gridPattern = control.GetCurrentPattern<IMySuperGridPattern, GridPattern>(GridPattern.Pattern) as GridPattern;
                IMySuperGridPattern gridPattern = control.GetCurrentPattern<IMySuperGridPattern>(GridPattern.Pattern);
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
        internal void CallGridItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // GridItemPattern gridItemPattern = control.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
                // GridItemPattern gridItemPattern = control.GetCurrentPattern<IMySuperGridItemPattern, GridItemPattern>(GridItemPattern.Pattern) as GridItemPattern;
                IMySuperGridItemPattern gridItemPattern = control.GetCurrentPattern<IMySuperGridItemPattern>(GridItemPattern.Pattern);
                if (gridItemPattern != null) {
                    //gridItemPattern.Current.
                }
            } catch (Exception eGridItemPatternException) {
            }
        }
        
        internal void CallCollapsePattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperExpandCollapsePattern collapsePattern = control.GetExpandCollapsePattern();
                // IMySuperExpandCollapsePattern collapsePattern = control.GetCurrentPattern<IMySuperExpandCollapsePattern, ExpandCollapsePattern>();
                IMySuperExpandCollapsePattern collapsePattern = control.GetCurrentPattern<IMySuperExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
                if (collapsePattern != null) {
                    collapsePattern.Collapse();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
        
        internal void CallExpandPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // IMySuperExpandCollapsePattern expandPattern = control.GetExpandCollapsePattern();
                // IMySuperExpandCollapsePattern expandPattern = control.GetCurrentPattern<IMySuperExpandCollapsePattern, ExpandCollapsePattern>();
                IMySuperExpandCollapsePattern expandPattern = control.GetCurrentPattern<IMySuperExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
                if (expandPattern != null) {
                    expandPattern.Expand();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
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
            Child = null;
        }
    }
}
