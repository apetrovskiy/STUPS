/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/02/2012
 * Time: 07:53 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of ULtraGridCmdletBase.
    /// </summary>
    public class ULtraGridCmdletBase : HasControlInputCmdletBase
    {
        public ULtraGridCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public string[] ItemName { get; set; }
        [Parameter(Mandatory = false)]
        public int Count { get; set; }
        #endregion Parameters
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "if")]
        protected void ifUltraGridProcessing(
            ifUltraGridOperations operation)
        {
            
            // colleciton of the selected rows
            System.Collections.Generic.List<AutomationElement> selectedItems = 
                new System.Collections.Generic.List<AutomationElement>();
            
            try {
                
                foreach (AutomationElement inputObject in this.InputObject) {
                
            AutomationElementCollection tableItems = 
                // 20120824
                //this.InputObject.FindAll(TreeScope.Children,
                inputObject.FindAll(
                    TreeScope.Children,
                             new PropertyCondition(
                                 AutomationElement.ControlTypeProperty,
                                 ControlType.Custom));
            
            if (tableItems.Count > 0) {
                // bool notTheFirstChild = false;
                int currentRowNumber = 0;
                bool notTheLastChild = true;
                foreach (AutomationElement child in tableItems) {
                    currentRowNumber++;
                    if (currentRowNumber == tableItems.Count) notTheLastChild = false;
// if (child.Current.Name.Contains("row") || 
// child.Current.Name.Contains("Row")) {
                        AutomationElementCollection row = 
                            child.FindAll(TreeScope.Children,
                                          new PropertyCondition(
                                              AutomationElement.ControlTypeProperty,
                                              ControlType.Custom));
                        bool alreadyFoundInTheRow = false;
                        int counter = 0;
                        foreach (AutomationElement grandchild in row) {
                            
                            string strValue = String.Empty;
// switch (operation) {
// case ifUltraGridOperations.selectItems:
// case ifUltraGridOperations.getItems:
                                    // WriteVerbose(this, "select items");
                                    ValuePattern valPattern = null;
                                    try {
                                        valPattern =
                                            grandchild.GetCurrentPattern(ValuePattern.Pattern)
                                            as ValuePattern;
                                        WriteVerbose(this, 
                                                     "getting the valuePattern of the control");
                                    } catch {
                                        WriteVerbose(this,
                                                      "unable to get ValuePattern of " + 
                                                      grandchild.Current.Name);
                                    }
                                    // string strValue = String.Empty;
                                    try {
                                        strValue = 
                                            valPattern.Current.Value;
                                        WriteVerbose(this,
                                                     "valuePattern of " + 
                                                     grandchild.Current.Name + 
                                                     " = " + 
                                                     strValue);
                                                     
                                    } catch {
                                        WriteVerbose(this,
                                                      "unable to get ValuePattern.Current.Value of " + 
                                                      grandchild.Current.Name);
                                    }
                                    
                                    
                                    
        // if (strValue == clickString ||
        // strValue == clickString2) {
                                    if (!alreadyFoundInTheRow && IsInTheList(strValue)) {
                                        alreadyFoundInTheRow = true;
                                        counter++;
                                        // grandchild.SetFocus(); // fail
                                        // child.SetFocus();//fail
        // InvokePattern invPattern = null;
        // try {
        // invPattern = 
        // child.GetCurrentPattern(InvokePattern.Pattern)
        // as InvokePattern;
        // invPattern.Invoke();
        //  // System.Windows.Forms.SendKeys.SendWait(" "); // QMM
        // WriteVerbose(this, strValue + " selected");
        // } catch {
        //  // System.Windows.Forms.SendKeys.SendWait("+ "); // PowerGUI doesn’t react
        // }
                                        
                                        WriteVerbose(this,
                                                     "this control is of requested value: " + 
                                                     strValue + 
                                                     ", sending a Ctrl+Click to it");
                                        
        
                                        switch (operation) {
                                            case ifUltraGridOperations.selectItems:
                                                // in case of this operation is a selection of items
                                                // clicks are needed
                                                // otherwise, just return the set of rows found
                                                if (ClickControl(this,
                                                                  child,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  true, // notTheFirstChild,
                                                                  false, // notTheLastChild, // true,
                                                                  false,
                                                                  Preferences.ClickOnControlByCoordX,
                                                                  Preferences.ClickOnControlByCoordY)) {
                                                    selectedItems.Add(child);
                                                    WriteVerbose(this, 
                                                                 "the " + child.Current.Name + 
                                                                 " added to the output collection");
                                                }
                                                // System.Windows.Point p = child.GetClickablePoint();//fail
                                                // System.Windows.Point p = grandchild.GetClickablePoint();//fail
                                                
                                                // keybd_event((byte)VK_LCONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                                                uint pressed = 0x8000;
                                                if ((NativeMethods.GetKeyState(NativeMethods.VK_LCONTROL) & pressed) > 0) {
                                                    NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                }
                                                if ((NativeMethods.GetKeyState(NativeMethods.VK_RCONTROL) & pressed) > 0) {
                                                    NativeMethods.keybd_event((byte)NativeMethods.VK_RCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                }
                                                if ((NativeMethods.GetKeyState(NativeMethods.VK_CONTROL) & pressed) > 0) {
                                                    NativeMethods.keybd_event((byte)NativeMethods.VK_CONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                }
                                                break;
                                            case ifUltraGridOperations.getItems:
                                                selectedItems.Add(child);
                                                WriteVerbose(this, 
                                                             "the " + child.Current.Name + 
                                                             " added to the output collection");
                                                break;
                                            case ifUltraGridOperations.getSelection:
                                                if (GetColorProbe(this,
                                                                  child)) {
                                                    selectedItems.Add(child);
                                                    WriteVerbose(this, 
                                                                 "the " + child.Current.Name + 
                                                                 " added to the output collection");
                                                }
                                                break;
                                        }
                                        if (this.Count > 0 && counter == this.Count) {
                                            break;
                                        }
                                    }
// break;
// case ifUltraGridOperations.getSelection:
//  // WriteVerbose(this, "get the selection");
// 
// 
// 
// break;
// default:
// WriteVerbose(this, "default");
// break;
// }
                            WriteVerbose(this, "working with " + 
                                         grandchild.Current.Name + "\t" + strValue);
                        }
// }
                    
                }
                // WriteObject(this, true);
                WriteObject(this, selectedItems);
            } else {
                WriteVerbose(this, "no elements of type ControlType.Custom were found under the input control");
            }
            
            } // 20120824
            
            } catch (Exception ee) {
                ErrorRecord err = 
                    new ErrorRecord(
                        ee,
                        "ExceptionInSectingItems",
                        ErrorCategory.InvalidOperation,
                        this.InputObject);
                err.ErrorDetails = new ErrorDetails("Exception were thrown during the cycle of selecting items.");
                WriteObject(this, false);
            }            
            // return result;
        }
        
        private bool IsInTheList(string strValue)
        {
            bool result = false;
            foreach (string strItem in this.ItemName) {
                if (strValue == strItem) {
                    result = true;
                    break;
                }
            }
            return result;
        }
        
    }
    
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "if")]
    public enum ifUltraGridOperations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "unknown")]
        unknown = 0,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "select")]
        selectItems = 1,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        getSelection = 2,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        getItems = 3
    }
}
