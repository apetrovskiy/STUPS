/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Linq;

    /// <summary>
    /// Description of ConvertFromUiaTableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "UiaTable")]
    
    public class ConvertFromUiaTableCommand : ConvertCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IUiElement inputObject in InputObject) {
                
                string strData = String.Empty;
                // 20131109
                //System.Windows.Automation.AutomationElement _control = 
                IUiElement currentControl =
                    // 20120823
                    //this.InputObject;
                    inputObject;
                // 20131208
                // TablePattern tblPattern = null;
                ITablePattern tblPattern = null;
                
                try {
                    tblPattern =
                        // 20120823
                        //this.InputObject.GetCurrentPattern(classic.TablePattern.Pattern)
                        // 20131208
                        // inputObject.GetCurrentPattern(classic.TablePattern.Pattern)
                        // inputObject.GetCurrentPattern<ITablePattern, TablePattern>(classic.TablePattern.Pattern)
                        // as TablePattern;
                        inputObject.GetCurrentPattern<ITablePattern>(classic.TablePattern.Pattern);
                    
                    bool res1 = 
                        UiaHelper.GetHeaderItems(ref currentControl, out strData, Delimiter);
                    
                    if (res1) {
                        WriteObject(strData);
                    } else {
                        WriteVerbose(this, strData);
                    }
                    
                    // temporary!!!
                    // Selection
                    // 20131109
                    //System.Windows.Automation.AutomationElement[] selectedItems = null;
                    IUiElement[] selectedItems = null;
                    if (SelectedOnly) {
                        
                        // if there's a selection, get items in the selection
                        try
                        {
                            // 20131208
                            // SelectionPattern selPattern = inputObject.GetCurrentPattern(
                            // SelectionPattern selPattern = inputObject.GetCurrentPattern<ISelectionPattern, SelectionPattern>(
                                // SelectionPattern.Pattern)
                                // as SelectionPattern;
                            // SelectionPattern selPattern = inputObject.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern);
                            ISelectionPattern selPattern = inputObject.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern);
                            
                            /*
                            System.Windows.Automation.SelectionPattern selPattern;
                            selPattern = 
                                // 20120823
                                //this.InputObject.GetCurrentPattern(
                                inputObject.GetCurrentPattern(
                                    System.Windows.Automation.SelectionPattern.Pattern)
                                    as System.Windows.Automation.SelectionPattern;
                            */
                            selectedItems =
                                // 20131109
                                //selPattern.Current.GetSelection();
                                // 20131119
                                //new UiEltCollection(selPattern.Current.GetSelection()).Cast<UiElement>().ToArray();
                                AutomationFactory.GetUiEltCollection(selPattern.Current.GetSelection()).Cast<UiElement>().ToArray();
                        }
                        catch (Exception eSelection) {
                            WriteDebug(this, eSelection.Message);
                            WriteVerbose(this, "there wasn't a selection");
                        }
                    }
                    
                    
                    // temporary!!!
                    // get rows
                    if (tblPattern != null && tblPattern.Current.RowCount <= 0) continue;
                    /*
                    if (tblPattern.Current.RowCount <= 0) continue;
                    */
                    // 20130318
                    //RunOnSuccessScriptBlocks(this);
                    RunOnSuccessScriptBlocks(this, null);
                    
                    for (int rowsCounter = 0;
                        rowsCounter < tblPattern.Current.RowCount;
                        rowsCounter++) {
                        
                            if (SelectedOnly && selectedItems.Length > 0) {
                                
                            } else {
                                
                                // without a selection
                                string outString =
                                    // 20131208
                                    // UiaHelper.GetOutputStringUsingTableGridPattern<TablePattern>(
                                    UiaHelper.GetOutputStringUsingTableGridPattern<ITablePattern>(
                                        tblPattern,
                                        tblPattern.Current.ColumnCount,
                                        rowsCounter,
                                        Delimiter);
    // getOutputString(ref tblPattern,
    // rowsCounter);
                                // output a row
                                WriteObject(outString);
                            }
                        }
                    //}
    
                    /*
                    if (tblPattern.Current.RowCount > 0) {
                        // 20130318
                        //RunOnSuccessScriptBlocks(this);
                        RunOnSuccessScriptBlocks(this, null);
                            for (int rowsCounter = 0;
                                 rowsCounter<tblPattern.Current.RowCount;
                                 rowsCounter++) {
                                if (this.SelectedOnly && selectedItems.Length > 0) {
                                } else {
                                    // without a selection
                                    string outString = 
                                        UiaHelper.GetOutputStringUsingTableGridPattern<System.Windows.Automation.TablePattern>(
                                            tblPattern,
                                            tblPattern.Current.ColumnCount,
                                            rowsCounter,
                                            this.Delimiter);
    // getOutputString(ref tblPattern,
    // rowsCounter);
                                    // output a row
                                    this.WriteObject(outString);
                                }
                            }
                        //}
                    }
                    */
                } catch {
                    if (tblPattern != null) continue;
                    WriteVerbose(this, "couldn't get TablePattern");
                    WriteVerbose(this, "trying to enumerate columns and rows");
                        
                        
                    bool res2 = 
                        UiaHelper.GetHeaders(ref currentControl, out strData, Delimiter);
                    if (res2) {
                        WriteObject(strData);
                    } else {
                        WriteVerbose(this, strData);
                    }
                        
                    List<string> rows = 
                        // 20120823
                        //UiaHelper.GetOutputStringUsingItemsValuePattern(this.InputObject,
                        UiaHelper.GetOutputStringUsingItemsValuePattern(inputObject,
                            Delimiter);
                    if (rows.Count <= 0) continue;
                    // 20130318
                    //RunOnSuccessScriptBlocks(this);
                    RunOnSuccessScriptBlocks(this, null);
                    foreach (string row in rows) {
                        WriteObject(row);
                    }
                    
                    // 20131119
                    // disposal
                    rows = null;
                    
                    /*
                    if (rows.Count > 0) {
                        // 20130318
                        //RunOnSuccessScriptBlocks(this);
                        RunOnSuccessScriptBlocks(this, null);
                        foreach (string row in rows) {
                            this.WriteObject(row);
                        }
                    }
                    */

                    // WriteObject(this, false);
                    // return;
    
                    /*
                    if (tblPattern == null)
                    {
                        this.WriteVerbose(this, "couldn't get TablePattern");
                        this.WriteVerbose(this, "trying to enumerate columns and rows");
                        
                        
                        bool res2 = 
                            UiaHelper.GetHeaders(ref _control, out strData, this.Delimiter);
                        if (res2) {
                            this.WriteObject(strData);
                        } else {
                            this.WriteVerbose(this, strData);
                        }
                        
                        System.Collections.Generic.List<string> rows = 
                            // 20120823
                            //UiaHelper.GetOutputStringUsingItemsValuePattern(this.InputObject,
                            UiaHelper.GetOutputStringUsingItemsValuePattern(inputObject,
                                                                            this.Delimiter);
                        if (rows.Count > 0) {
                            // 20130318
                            //RunOnSuccessScriptBlocks(this);
                            RunOnSuccessScriptBlocks(this, null);
                            foreach (string row in rows) {
                                this.WriteObject(row);
                            }
                        }
                        // WriteObject(this, false);
                        // return;
                    }
                    */
                }
            
            } // 20120823

        }
    }
}
