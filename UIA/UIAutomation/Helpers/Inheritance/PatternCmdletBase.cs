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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    // using System.Windows.Automation.Text;
    // using classic.Text = UIANET::System.Windows.Automation.Text;
    using System.Linq;
    using System.Threading;
    using Commands;
    using Helpers.Commands;

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
        protected internal string WhatToDo { get; set; }
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
            

           var command =
               AutomationFactory.GetCommand<PatternCommand>(this);
           command.Execute();
        }
        
        internal void CallDockPatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                WriteObject(this, control.GetDockPosition());
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            //dockPattern.Current.DockPosition
//            try {
//                // 20131208
//                // DockPattern dockPattern = control.GetCurrentPattern(classic.DockPattern.Pattern) as DockPattern;
//                // DockPattern dockPattern = control.GetCurrentPattern<IDockPattern, DockPattern>(classic.DockPattern.Pattern) as DockPattern;
//                IDockPattern dockPattern = control.GetCurrentPattern<IDockPattern>(classic.DockPattern.Pattern);
//                if (null != dockPattern) {
//                    WriteObject(this, dockPattern.Current.DockPosition);
//                } else {
//                    WriteVerbose(this, "couldn't get DockPattern");
//                    WriteObject(this, false);
//                }
//            }
//            catch {
//                
//            }
        }
        
        internal void CallDockPatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject, classic.DockPosition position)
        {
//            try {
//                // 20131208
//                // DockPattern dockPattern = control.GetCurrentPattern(classic.DockPattern.Pattern) as DockPattern;
//                // DockPattern dockPattern = control.GetCurrentPattern<IDockPattern, DockPattern>(classic.DockPattern.Pattern) as DockPattern;
                // 20140102
            try {
                control.PerformSetDockPosition(position);
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            }
            catch {
                WriteObject(this, false);
            }
//                IDockPattern dockPattern = control.GetCurrentPattern<IDockPattern>(classic.DockPattern.Pattern);
//                if (null != dockPattern) {
//                    dockPattern.SetDockPosition(position);
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    WriteVerbose(this, "couldn't get DockPattern");
//                    WriteObject(this, false);
//                }
//            }
//            catch {
//                
//            }
        }
        
        internal void CallWindowPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // WindowPattern windowPattern = control.GetCurrentPattern(classic.WindowPattern.Pattern) as WindowPattern;
                // WindowPattern windowPattern = control.GetCurrentPattern<IWindowPattern, WindowPattern>(classic.WindowPattern.Pattern) as WindowPattern;
                // IWindowPattern windowPattern = control.GetCurrentPattern<IWindowPattern, WindowPattern>(); //WindowPattern.Pattern);
                IWindowPattern windowPattern = control.GetCurrentPattern<IWindowPattern>(classic.WindowPattern.Pattern);
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
                    
                    windowPattern.SetWindowVisualState(classic.WindowVisualState.Minimized);
                    Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(classic.WindowVisualState.Normal);
                    windowPattern.WaitForInputIdle(1000);
                    Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(classic.WindowVisualState.Minimized);
                    Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(classic.WindowVisualState.Normal);
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get WindowPattern");
                    WriteObject(this, false);
                }
            } catch (Exception) {
            }
        }
        
        internal void CallValuePatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                control.PerformSetValueValuePattern(((InvokeUiaValuePatternSetCommand)Child).Text);
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            }
            catch {
                WriteObject(this, false);
            }
//            try {
//                // IValuePattern valuePatternSet = control.GetValuePattern();
//                // IValuePattern valuePatternSet = control.GetCurrentPattern<IValuePattern, ValuePattern>(); //ValuePattern.Pattern);
//                IValuePattern valuePatternSet = control.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern);
//                if (valuePatternSet != null) {
//                    
//                    WriteVerbose(this, "using ValuePattern");
//                    valuePatternSet.SetValue(((InvokeUiaValuePatternSetCommand)Child).Text);
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    
//                    WriteVerbose(this, "couldn't get ValuePattern. SendKeys is used");
//                    control.SetFocus();
//                    SendKeys.SendWait(((InvokeUiaValuePatternSetCommand)Child).Text);
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                }
//            } catch (Exception eValueSetPatternException) {
//            }
        }
        
        internal void CallValuePatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                WriteObject(this, control.PerformGetValueValuePattern());
            }
            catch {
                WriteObject(this, string.Empty);
            }
//            try {
//                // IValuePattern valuePatternGet = control.GetValuePattern();
//                // IValuePattern valuePatternGet = control.GetCurrentPattern<IValuePattern, ValuePattern>();
//                IValuePattern valuePatternGet = control.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern);
//                object result = null;
//                if (valuePatternGet != null) {
//                    result = valuePatternGet.Current.Value;
//                    WriteVerbose(this, "the result is " + result);
//                    WriteObject(this, result);
//                } else {
//                    WriteVerbose(this, "couldn't get ValuePattern");
//                    WriteObject(this, result);
//                }
//            } catch (Exception eValueGetPatternException) {
//            }
        }
        
        internal void CallTransformPatternForRotate(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                control.PerformRotate(((InvokeUiaTransformPatternRotateCommand)Child).TransformRotateDegrees);
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            try {
//                // 20131208
//                // TransformPattern transformRotatePattern = control.GetCurrentPattern(classic.TransformPattern.Pattern) as TransformPattern;
//                // TransformPattern transformRotatePattern = control.GetCurrentPattern<ITransformPattern, TransformPattern>(classic.TransformPattern.Pattern) as TransformPattern;
//                ITransformPattern transformRotatePattern = control.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern);
//                if (transformRotatePattern != null) {
//                    transformRotatePattern.Rotate(((InvokeUiaTransformPatternRotateCommand)Child).TransformRotateDegrees);
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    WriteVerbose(this, "couldn't get TransformPattern");
//                    WriteObject(this, false);
//                }
//            } catch (Exception eTransformRotatePatternException) {
//            }
        }
        
        internal void CallTransformPatternForResize(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                control.PerformResize(((InvokeUiaTransformPatternResizeCommand)Child).TransformResizeWidth, ((InvokeUiaTransformPatternResizeCommand)Child).TransformResizeHeight);
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            try {
//                // 20131208
//                // TransformPattern transformResizePattern = control.GetCurrentPattern(classic.TransformPattern.Pattern) as TransformPattern;
//                // TransformPattern transformResizePattern = control.GetCurrentPattern<ITransformPattern, TransformPattern>(classic.TransformPattern.Pattern) as TransformPattern;
//                ITransformPattern transformResizePattern = control.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern);
//                if (transformResizePattern != null) {
//                    transformResizePattern.Resize(((InvokeUiaTransformPatternResizeCommand)Child).TransformResizeWidth, ((InvokeUiaTransformPatternResizeCommand)Child).TransformResizeHeight);
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    WriteVerbose(this, "couldn't get TransformPattern");
//                    WriteObject(this, false);
//                }
//            } catch (Exception eTransformResizePatternException) {
//            }
        }
        
        internal void CallTransformPatternForMove(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                control.PerformMove(((InvokeUiaTransformPatternMoveCommand)Child).TransformMoveX, ((InvokeUiaTransformPatternMoveCommand)Child).TransformMoveY);
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            try {
//                // 20131208
//                // TransformPattern transformMovePattern = control.GetCurrentPattern(classic.TransformPattern.Pattern) as TransformPattern;
//                // TransformPattern transformMovePattern = control.GetCurrentPattern<ITransformPattern, TransformPattern>(classic.TransformPattern.Pattern) as TransformPattern;
//                ITransformPattern transformMovePattern = control.GetCurrentPattern<ITransformPattern>(classic.TransformPattern.Pattern);
//                if (transformMovePattern != null) {
//                    transformMovePattern.Move(((InvokeUiaTransformPatternMoveCommand)Child).TransformMoveX, ((InvokeUiaTransformPatternMoveCommand)Child).TransformMoveY);
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    WriteVerbose(this, "couldn't get TransformPattern");
//                    WriteObject(this, false);
//                }
//            } catch (Exception eTransformMovePatternException) {
//            }
        }
        
        internal void CallTogglePatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // WriteObject(this, control.GetToggleState());
                WriteObject(this, (control.GetToggleState() == classic.ToggleState.On));
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            try {
//                cmdlet.WriteVerbose(cmdlet, "trying to get TogglePattern");
//                // ITogglePattern togglePattern = control.GetTogglePattern();
//                // ITogglePattern togglePattern = control.GetCurrentPattern<ITogglePattern, TogglePattern>();
//                ITogglePattern togglePattern = control.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern);
//                if (togglePattern != null) {
//                    
//                    cmdlet.WriteVerbose(cmdlet, "TogglePattern != null");
//                    bool toggleState = togglePattern.Current.ToggleState == ToggleState.On;
//                    WriteObject(this, toggleState);
//                } else {
//                    WriteVerbose(this, "couldn't get TogglePattern");
//                    WriteObject(this, false);
//                }
//            } catch (Exception eToggleStatePatternException) {
//                cmdlet.WriteVerbose(eToggleStatePatternException.Message);
//            }
        }
        
        internal void CallTogglePatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject, bool on)
        {
            /*
            try {
                control.PerformToggle(on);
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
            */
            try {
                // ITogglePattern togglePattern1 = control.GetTogglePattern();
                // ITogglePattern togglePattern = control.GetCurrentPattern<ITogglePattern, TogglePattern>();
                ITogglePattern togglePattern = control.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern);
                if (togglePattern != null) {
                    if (togglePattern.Current.ToggleState == classic.ToggleState.On && on) {
                        // nothing to do
                        cmdlet.WriteVerbose(this, "the control is already ON");
                    } else if (togglePattern.Current.ToggleState == classic.ToggleState.Off && on) {
                        cmdlet.WriteVerbose(this, "setting the control ON");
                        togglePattern.Toggle();
                    } else if (togglePattern.Current.ToggleState == classic.ToggleState.On && !on) {
                        cmdlet.WriteVerbose(this, "setting the control OFF");
                        togglePattern.Toggle();
                    } else if (togglePattern.Current.ToggleState == classic.ToggleState.Off && !on) {
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
            } catch (Exception) {
                //!!!!!!!!!!!!
                if (Preferences.PerformWin32ClickOnFail) {

                    // 20131125
                    //ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                    // 20131230
                    // ClickControl(this, control, false, false, false, false, false, false, false, 0, 0,
                    //              0);
                    ClickControl(
                        this,
                        control,
                        new ClickSettings());
                    
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
                // ITogglePattern togglePattern = control.GetTogglePattern();
                // ITogglePattern togglePattern = control.GetCurrentPattern<ITogglePattern, TogglePattern>();
                ITogglePattern togglePattern = control.GetCurrentPattern<ITogglePattern>(classic.TogglePattern.Pattern);
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
            } catch (Exception) {
            }
        }
        
        internal void CallTextPatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TextPattern textPatternSet = control.GetCurrentPattern(classic.TextPattern.Pattern) as TextPattern;
                // TextPattern textPatternSet = control.GetCurrentPattern<ITextPattern, TextPattern>(classic.TextPattern.Pattern) as TextPattern;
                ITextPattern textPatternSet = control.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern);
                if (textPatternSet != null) {
                    textPatternSet.GetSelection().SetValue(((InvokeUiaTextPatternSetCommand)this).Text, 0);
                    WriteObject(this, true);
                } else {
                    WriteVerbose(this, "couldn't get TextPattern");
                    WriteObject(this, false);
                }
            } catch (Exception) {
            }
        }
        
        internal void CallTextPatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TextPattern textPatternGet = control.GetCurrentPattern(classic.TextPattern.Pattern) as TextPattern;
                // TextPattern textPatternGet = control.GetCurrentPattern<ITextPattern, TextPattern>(classic.TextPattern.Pattern) as TextPattern;
                ITextPattern textPatternGet = control.GetCurrentPattern<ITextPattern>(classic.TextPattern.Pattern);
                if (textPatternGet != null) {
                    int textLength = ((InvokeUiaTextPatternGetCommand)this).TextLength;
                    if (((InvokeUiaTextPatternGetCommand)this).VisibleArea)
                    {
                        classic.Text.TextPatternRange[] textRanges = textPatternGet.GetVisibleRanges();
                        foreach (classic.Text.TextPatternRange tpr in textRanges)
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
            } catch (Exception) {
            }
        }

        //tablePattern.GetItem
        
        internal void CallTablePattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TablePattern tablePattern = control.GetCurrentPattern(classic.TablePattern.Pattern) as TablePattern;
                // TablePattern tablePattern = control.GetCurrentPattern<ITablePattern, TablePattern>(classic.TablePattern.Pattern) as TablePattern;
                ITablePattern tablePattern = control.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern);
                if (tablePattern != null) {
                }
            } catch (Exception) {
            }
        }

        internal void CallTableItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // TableItemPattern tableItemPattern = control.GetCurrentPattern(classic.TableItemPattern.Pattern) as TableItemPattern;
                // TableItemPattern tableItemPattern = control.GetCurrentPattern<ITableItemPattern, TableItemPattern>(classic.TableItemPattern.Pattern) as TableItemPattern;
                ITableItemPattern tableItemPattern = control.GetCurrentPattern<ITableItemPattern>(classic.TableItemPattern.Pattern);
                if (tableItemPattern != null) {
                    //tableItemPattern.Current.
                }
            } catch (Exception) {
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
                // ISelectionPattern selPattern = control.GetSelectionPattern();
                // ISelectionPattern selPattern = control.GetCurrentPattern<ISelectionPattern, SelectionPattern>();
                ISelectionPattern selPattern = control.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern);
                if (selPattern != null) {
                    IUiElement[] selection = AutomationFactory.GetUiEltCollection(selPattern.Current.GetSelection()).Cast<UiElement>().ToArray();
                    WriteObject(this, selection);
                } else {
                    WriteVerbose(this, "couldn't get SelectionPattern");
                    WriteObject(this, false);
                }
            } catch (Exception) {
            }
        }
        
        internal void CallSelectedItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // ISelectionItemPattern selItemPattern = control.GetSelectionItemPattern();
                // ISelectionItemPattern selItemPattern = control.GetCurrentPattern<ISelectionItemPattern, SelectionItemPattern>();
                ISelectionItemPattern selItemPattern = control.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern);
                if (selItemPattern == null) return;
                if (selItemPattern.Current.IsSelected) {
                    WriteObject(this, InputObject);
                }
            } catch (Exception) {
            }
        }
        
        internal void CallSelectionItemPatternForState(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // ISelectionItemPattern selItemPattern = control.GetSelectionItemPattern();
                // ISelectionItemPattern selItemPattern = control.GetCurrentPattern<ISelectionItemPattern, SelectionItemPattern>();
                ISelectionItemPattern selItemPattern = control.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern);
                if (selItemPattern != null) {
                    WriteObject(this, selItemPattern.Current.IsSelected);
                } else {
                    WriteVerbose(this, "couldn't get SelectionItemPattern");
                    WriteObject(this, false);
                }
            } catch (Exception) {
            }
        }
        
        internal void CallSelectionItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // ISelectionItemPattern selItemPattern = control.GetSelectionItemPattern();
                // ISelectionItemPattern selItemPattern = control.GetCurrentPattern<ISelectionItemPattern, SelectionItemPattern>();
                ISelectionItemPattern selItemPattern = control.GetCurrentPattern<ISelectionItemPattern>(classic.SelectionItemPattern.Pattern);
                if (selItemPattern != null) {
                    selItemPattern.Select();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        try {
                            // 20131208
                            // SelectionPattern selPatternTemp = control.GetCurrentPattern(classic.SelectionPattern.Pattern) as SelectionPattern;
                            // SelectionPattern selPatternTemp = control.GetCurrentPattern<ISelectionItemPattern, SelectionItemPattern>(classic.SelectionPattern.Pattern) as SelectionPattern;
                            ISelectionPattern selPatternTemp = control.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern);
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
            } catch (Exception) {
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
                // ScrollPattern scPattern = control.GetCurrentPattern(classic.ScrollPattern.Pattern) as ScrollPattern;
                // ScrollPattern scPattern = control.GetCurrentPattern<IScrollPattern, ScrollPattern>(classic.ScrollPattern.Pattern) as ScrollPattern;
                // IScrollPattern scPattern = control.GetScrollPattern();
                // IScrollPattern scPattern = control.GetCurrentPattern<IScrollPattern, ScrollPattern>();
                IScrollPattern scPattern = control.GetCurrentPattern<IScrollPattern>(classic.ScrollPattern.Pattern);
                if (scPattern == null) return;
                try {
                    bool horizontal = ((InvokeUiaScrollPatternCommand)this).Horizontal;
                    bool vertical = ((InvokeUiaScrollPatternCommand)this).Vertical;
                    int horPercent = ((InvokeUiaScrollPatternCommand)this).HorizontalPercent;
                    int verPercent = ((InvokeUiaScrollPatternCommand)this).VerticalPercent;
                    classic.ScrollAmount horAmount = classic.ScrollAmount.NoAmount;
                    classic.ScrollAmount verAmount = classic.ScrollAmount.NoAmount;
                    horAmount = (classic.ScrollAmount)((InvokeUiaScrollPatternCommand)this).HorizontalAmount;
                    verAmount = (classic.ScrollAmount)((InvokeUiaScrollPatternCommand)this).VerticalAmount;
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
                control.PerformScrollIntoView();
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            try {
//                // 20131208
//                // ScrollItemPattern sciPattern = control.GetCurrentPattern(classic.ScrollItemPattern.Pattern) as ScrollItemPattern;
//                // ScrollItemPattern sciPattern = control.GetCurrentPattern<IScrollItemPattern, ScrollItemPattern>(classic.ScrollItemPattern.Pattern) as ScrollItemPattern;
//                // IScrollItemPattern sciPattern = control.GetScrollItemPattern();
//                // IScrollItemPattern sciPattern = control.GetCurrentPattern<IScrollItemPattern, ScrollItemPattern>();
//                IScrollItemPattern sciPattern = control.GetCurrentPattern<IScrollItemPattern>(classic.ScrollItemPattern.Pattern);
//                if (sciPattern == null) return;
//                try {
//                    sciPattern.ScrollIntoView();
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } catch {
//                    WriteObject(this, false);
//                }
//            } catch {
//                WriteObject(this, false);
//            }
        }
        
        internal void CallRangeValuePatternForSet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // RangeValuePattern rvPatternSet = control.GetCurrentPattern(classic.RangeValuePattern.Pattern) as RangeValuePattern;
                // RangeValuePattern rvPatternSet = control.GetCurrentPattern<IRangeValuePattern, RangeValuePattern>(classic.RangeValuePattern.Pattern) as RangeValuePattern;
                IRangeValuePattern rvPatternSet = control.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern);
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
            } catch (Exception) {
            }
        }
        
        internal void CallRangeValuePatternForGet(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // RangeValuePattern rvPatternGet = control.GetCurrentPattern(classic.RangeValuePattern.Pattern) as RangeValuePattern;
                // RangeValuePattern rvPatternGet = control.GetCurrentPattern<IRangeValuePattern, RangeValuePattern>(classic.RangeValuePattern.Pattern) as RangeValuePattern;
                IRangeValuePattern rvPatternGet = control.GetCurrentPattern<IRangeValuePattern>(classic.RangeValuePattern.Pattern);
                if (rvPatternGet != null) {
                    WriteObject(this, rvPatternGet.Current.Value);
                }
            } catch (Exception) {
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
                // IInvokePattern invokePattern = control.GetInvokePattern();
                // IInvokePattern invokePattern = control.GetCurrentPattern<IInvokePattern, InvokePattern>();
                IInvokePattern invokePattern = control.GetCurrentPattern<IInvokePattern>(classic.InvokePattern.Pattern);
                if (invokePattern != null) {
                    invokePattern.Invoke();
                    
                    if (PassThru && null != (inputObject as IUiElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    if (Preferences.PerformWin32ClickOnFail) {
                        
                        // 20131230
                        // ClickControl(this, control, false, false, false, false, false, false, false, 0, 0,
                        //              0);
                        ClickControl(
                            this,
                            control,
                            new ClickSettings());
                        
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
                    
                    // 20131230
                    // ClickControl(this, control, false, false, false, false, false, false, false, 0, 0,
                    //              0);
                    ClickControl(
                        this,
                        control,
                        new ClickSettings());

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
        // _control.GetCurrentPattern(classic.GridPattern.Pattern)
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
                // GridPattern gridPattern = control.GetCurrentPattern(classic.GridPattern.Pattern) as GridPattern;
                // GridPattern gridPattern = control.GetCurrentPattern<IGridPattern, GridPattern>(classic.GridPattern.Pattern) as GridPattern;
                IGridPattern gridPattern = control.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern);
                if (gridPattern != null) {
                }
            } catch (Exception) {
            }
        }

        //gridItemPattern.Current.

        // not yet implemented
        // GridItemPattern giPattern =
        // _control.GetCurrentPattern(classic.GridItemPattern.Pattern)
        // as GridItemPattern;
        // 
        // giPattern.Current.
        internal void CallGridItemPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                // 20131208
                // GridItemPattern gridItemPattern = control.GetCurrentPattern(classic.GridItemPattern.Pattern) as GridItemPattern;
                // GridItemPattern gridItemPattern = control.GetCurrentPattern<IGridItemPattern, GridItemPattern>(classic.GridItemPattern.Pattern) as GridItemPattern;
                IGridItemPattern gridItemPattern = control.GetCurrentPattern<IGridItemPattern>(classic.GridItemPattern.Pattern);
                if (gridItemPattern != null) {
                    //gridItemPattern.Current.
                }
            } catch (Exception eGridItemPatternException) {
            }
        }
        
        internal void CallCollapsePattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                control.PerformCollapse();
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            }
            catch {
                WriteObject(this, false);
            }
//            try {
//                // IExpandCollapsePattern collapsePattern = control.GetExpandCollapsePattern();
//                // IExpandCollapsePattern collapsePattern = control.GetCurrentPattern<IExpandCollapsePattern, ExpandCollapsePattern>();
//                IExpandCollapsePattern collapsePattern = control.GetCurrentPattern<IExpandCollapsePattern>(classic.ExpandCollapsePattern.Pattern);
//                if (collapsePattern != null) {
//                    collapsePattern.Collapse();
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    WriteVerbose(this, "couldn't get ExpandCollapsePattern");
//                    WriteObject(this, false);
//                }
//            } catch (Exception eCollPatternException) {
//            }
        }
        
        internal void CallExpandPattern(PatternCmdletBase cmdlet, IUiElement control, IUiElement inputObject)
        {
            try {
                control.PerformExpand();
                if (PassThru) {
                    WriteObject(this, control);
                } else {
                    WriteObject(this, true);
                }
            } catch (Exception) {
                WriteObject(this, false);
                // throw;
            }
//            try {
//                // IExpandCollapsePattern expandPattern = control.GetExpandCollapsePattern();
//                // IExpandCollapsePattern expandPattern = control.GetCurrentPattern<IExpandCollapsePattern, ExpandCollapsePattern>();
//                IExpandCollapsePattern expandPattern = control.GetCurrentPattern<IExpandCollapsePattern>(classic.ExpandCollapsePattern.Pattern);
//                if (expandPattern != null) {
//                    expandPattern.Expand();
//                    
//                    if (PassThru && null != (inputObject as IUiElement)) {
//                        WriteObject(this, inputObject);
//                    } else {
//                        WriteObject(this, true);
//                    }
//                } else {
//                    WriteVerbose(this, "couldn't get ExpandCollapsePattern");
//                    WriteObject(this, false);
//                }
//            } catch (Exception eExpPatternException) {
//            }
        }
        
        protected override void EndProcessing()
        {
            Child = null;
        }
    }
}
