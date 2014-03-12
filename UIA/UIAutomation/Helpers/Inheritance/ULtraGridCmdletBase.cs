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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Description of ULtraGridCmdletBase.
    /// </summary>
    public class ULtraGridCmdletBase : HasControlInputCmdletBase
    {
        public ULtraGridCmdletBase()
        {
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true)]
        public string[] ItemName { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public int Count { get; set; }
        #endregion Parameters
        
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "if")]
        protected void ifUltraGridProcessing(
            ifUltraGridOperations operation)
        {
            
            // collection of the selected rows
            // 20131109
            //System.Collections.Generic.List<AutomationElement> selectedItems = 
            //    new System.Collections.Generic.List<AutomationElement>();
            List<IUiElement> selectedItems = 
                new List<IUiElement>();
            
            try {
                
                // 20131109
                //foreach (AutomationElement inputObject in this.InputObject) {
                foreach (IUiElement inputObject in InputObject) {
                    
                    // 20131109
                    //AutomationElementCollection tableItems = 
                    IUiEltCollection tableItems =
                        inputObject.FindAll(
                            classic.TreeScope.Children,
                                     new classic.PropertyCondition(
                                         classic.AutomationElement.ControlTypeProperty,
                                         classic.ControlType.Custom));
                
//                foreach (AutomationElementCollection tableItems in ((IAutomationElementCollection)this.InputObject).Select(inputObject => inputObject.FindAll(
//                    classic.TreeScope.Children,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.Custom))))
//                {
                    if (tableItems.Count > 0) {
                        int currentRowNumber = 0;
                        bool notTheLastChild = true;
                        // 20131109
                        //foreach (AutomationElement child in tableItems) {
                        foreach (IUiElement child in tableItems) {
                            currentRowNumber++;
                            if (currentRowNumber == tableItems.Count) notTheLastChild = false;
                            // 20131109
                            //AutomationElementCollection row = 
                            IUiEltCollection row =
                                child.FindAll(classic.TreeScope.Children,
                                    new classic.PropertyCondition(
                                        classic.AutomationElement.ControlTypeProperty,
                                        classic.ControlType.Custom));
                            bool alreadyFoundInTheRow = false;
                            int counter = 0;
                            // 20131109
                            //foreach (AutomationElement grandchild in row) {
                            foreach (IUiElement grandchild in row) {
                            
                                string strValue = String.Empty;
                                // 20131208
                                // ValuePattern valPattern = null;
                                IValuePattern valPattern = null;
                                try {
                                    valPattern =
                                        // 20131208
                                        // grandchild.GetCurrentPattern(classic.ValuePattern.Pattern)
                                        // grandchild.GetCurrentPattern<IValuePattern, ValuePattern>(classic.ValuePattern.Pattern)
                                        //    as ValuePattern;
                                        grandchild.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern);
                                    WriteVerbose(this, 
                                        "getting the valuePattern of the control");
                                } catch {
                                    WriteVerbose(this,
                                        "unable to get ValuePattern of " +
                                        // 20140312
                                        // grandchild.Current.Name);
                                        grandchild.GetCurrent().Name);
                                }
                                // string strValue = String.Empty;
                                try {
                                    strValue = 
                                        valPattern.Current.Value;
                                    WriteVerbose(this,
                                        "valuePattern of " +
                                        // 20140312 
                                        // grandchild.Current.Name +
                                        grandchild.GetCurrent().Name + 
                                        " = " + 
                                        strValue);
                                                     
                                } catch {
                                    WriteVerbose(this,
                                        "unable to get ValuePattern.Current.Value of " +
                                        // 20140312 
                                        // grandchild.Current.Name);
                                        grandchild.GetCurrent().Name);
                                }
                                    
                                    
                                    
                                if (!alreadyFoundInTheRow && IsInTheList(strValue)) {
                                    alreadyFoundInTheRow = true;
                                    counter++;
                                        
                                    WriteVerbose(this,
                                        "this control is of requested value: " + 
                                        strValue + 
                                        ", sending a Ctrl+Click to it");
                                        
        
                                    switch (operation) {
                                        case ifUltraGridOperations.SelectItems:
                                            // in case of this operation is a selection of items
                                            // clicks are needed
                                            // otherwise, just return the set of rows found
                                            if (ClickControl(this,
                                                child,
                                                new ClickSettings() {
                                                    Ctrl = true,
                                                    RelativeX = Preferences.ClickOnControlByCoordX,
                                                    RelativeY = Preferences.ClickOnControlByCoordY
                                                })) {
                                                
                                                /*
                                                false,
                                                false,
                                                false,
                                                false,
                                                true, // notTheFirstChild,
                                                false, // notTheLastChild, // true,
                                                false,
                                                // 20131125
                                                0,
                                                Preferences.ClickOnControlByCoordX,
                                                Preferences.ClickOnControlByCoordY)) {
                                                */
                                                    selectedItems.Add(child);
                                                    WriteVerbose(this,
                                                        // 20140312
                                                        // "the " + child.Current.Name +
                                                        "the " + child.GetCurrent().Name + 
                                                        " added to the output collection");
                                                }
                                                
                                            const uint pressed = 0x8000;
                                            // uint pressed = 0x8000;
                                            if ((NativeMethods.GetKeyState(NativeMethods.VK_LCONTROL) & pressed) > 0) {
                                                NativeMethods.keybd_event(NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                /*
                                                NativeMethods.keybd_event((byte)NativeMethods.VK_LCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                */
                                            }
                                            if ((NativeMethods.GetKeyState(NativeMethods.VK_RCONTROL) & pressed) > 0) {
                                                NativeMethods.keybd_event(NativeMethods.VK_RCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                /*
                                                NativeMethods.keybd_event((byte)NativeMethods.VK_RCONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                */
                                            }
                                            if ((NativeMethods.GetKeyState(NativeMethods.VK_CONTROL) & pressed) > 0) {
                                                NativeMethods.keybd_event(NativeMethods.VK_CONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                /*
                                                NativeMethods.keybd_event((byte)NativeMethods.VK_CONTROL, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                                                */
                                            }
                                            break;
                                        case ifUltraGridOperations.GetItems:
                                            selectedItems.Add(child);
                                            WriteVerbose(this,
                                                // 20140312
                                                // "the " + child.Current.Name +
                                                "the " + child.GetCurrent().Name + 
                                                " added to the output collection");
                                            break;
                                        case ifUltraGridOperations.GetSelection:
                                            if (GetColorProbe(this,
                                                child)) {
                                                    selectedItems.Add(child);
                                                    WriteVerbose(this,
                                                        // 20140312
                                                        // "the " + child.Current.Name +
                                                    "the " + child.GetCurrent().Name + 
                                                        " added to the output collection");
                                                }
                                            break;
                                    }
                                    if (Count > 0 && counter == Count) {
                                        break;
                                    }
                                }
                                WriteVerbose(this, "working with " +
                                    // 20140312
                                                   // grandchild.Current.Name + "\t" + strValue);
                                    grandchild.GetCurrent().Name + "\t" + strValue);
                            }
                    
                        }
                
                        WriteObject(this, selectedItems);
                    } else {
                        WriteVerbose(this, "no elements of type ControlType.Custom were found under the input control");
                    }
                }

                /*
                    foreach (AutomationElement inputObject in this.InputObject) {
                
                AutomationElementCollection tableItems = 
                    inputObject.FindAll(
                        classic.TreeScope.Children,
                                 new PropertyCondition(
                                     AutomationElement.ControlTypeProperty,
                                     ControlType.Custom));
            
                if (tableItems.Count > 0) {
                    int currentRowNumber = 0;
                    bool notTheLastChild = true;
                    foreach (AutomationElement child in tableItems) {
                        currentRowNumber++;
                        if (currentRowNumber == tableItems.Count) notTheLastChild = false;
                            AutomationElementCollection row = 
                                child.FindAll(TreeScope.Children,
                                              new PropertyCondition(
                                                  AutomationElement.ControlTypeProperty,
                                                  ControlType.Custom));
                            bool alreadyFoundInTheRow = false;
                            int counter = 0;
                            foreach (AutomationElement grandchild in row) {
                            
                                string strValue = String.Empty;
                                        ValuePattern valPattern = null;
                                        try {
                                            valPattern =
                                                grandchild.GetCurrentPattern(classic.ValuePattern.Pattern)
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
                                    
                                    
                                    
                                        if (!alreadyFoundInTheRow && IsInTheList(strValue)) {
                                            alreadyFoundInTheRow = true;
                                            counter++;
                                        
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
                                WriteVerbose(this, "working with " + 
                                             grandchild.Current.Name + "\t" + strValue);
                            }
                    
                    }
                
                    WriteObject(this, selectedItems);
                } else {
                    WriteVerbose(this, "no elements of type ControlType.Custom were found under the input control");
                }
            
                } // 20120824
                */

            } catch (Exception ee) {
                ErrorRecord err = 
                    new ErrorRecord(
                        ee,
                        "ExceptionInSectingItems",
                        ErrorCategory.InvalidOperation,
                        InputObject);
                err.ErrorDetails = new ErrorDetails("Exception were thrown during the cycle of selecting items.");
                WriteObject(this, false);
                
//                this.WriteError(
//                    this,
//                    "",
//                    "",
                    

                // TODO
                // this.WriteError();
            }            
            // return result;
        }
        
        private bool IsInTheList(string strValue)
        {
            return ItemName.Any(strItem => strValue == strItem);
        }
    }
    
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "if")]
    public enum ifUltraGridOperations
    {
        Unknown,
        SelectItems,
        GetSelection,
        GetItems
        /*
        Unknown = 0,
        SelectItems = 1,
        GetSelection = 2,
        GetItems = 3
        */
    }
}
