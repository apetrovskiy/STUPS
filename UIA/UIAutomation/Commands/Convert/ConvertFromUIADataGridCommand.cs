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
    /// Description of ConvertFromUiaDataGridCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "UiaDataGrid")]
    
    public class ConvertFromUiaDataGridCommand : ConvertCmdletBase
    {
        #region Constructor
        // 20131105
        // refactoring
        /*
        public ConvertFromUiaDataGridCommand()
        {
        }
        */
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
    
                string strData = String.Empty;
                IUiElement currentControl = 
                    inputObject;
                // 20131208
                // GridPattern gridPattern = null;
                IGridPattern gridPattern = null;
    
                try {
                    gridPattern =
                        // 20131208
                        // inputObject.GetCurrentPattern(classic.GridPattern.Pattern)
                        // inputObject.GetCurrentPattern<IGridPattern, GridPattern>(classic.GridPattern.Pattern)
                        inputObject.GetCurrentPattern<IGridPattern>(classic.GridPattern.Pattern);
                        // as GridPattern;
                    
                
                    bool res1 = 
                        UiaHelper.GetHeaderItems(ref currentControl, out strData, Delimiter);
                    if (res1) {
                        // WriteObject(this, strData);
                        WriteObject(strData);
                    } else {
                        WriteVerbose(this, strData);
                    }
                        
                    // temporary!!!
                    // Selection
                    IUiElement[] selectedItems = null;
                    if (SelectedOnly) {
                        // if there's a selection, get items in the selection
                        try
                        {
                            // 20131208
                            // SelectionPattern selPattern = inputObject.GetCurrentPattern(
                            // SelectionPattern selPattern = inputObject.GetCurrentPattern<ISelectionPattern, SelectionPattern>(
                            ISelectionPattern selPattern = inputObject.GetCurrentPattern<ISelectionPattern>(classic.SelectionPattern.Pattern);
                                // SelectionPattern.Pattern)
                                // as SelectionPattern;
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
                                //new UiEltCollection(selPattern.Current.GetSelection()).Cast<IUiElement>().ToArray();
                                AutomationFactory.GetUiEltCollection(selPattern.Current.GetSelection()).Cast<IUiElement>().ToArray();
                        }
                        catch (Exception eSelection) {
                            WriteDebug(this, eSelection.Message);
                            WriteVerbose(this, "there wasn't a selection");
                        }
                    }
                        
                    // temporary!!!
                    // get rows
                    if (gridPattern != null && gridPattern.Current.RowCount <= 0) continue;
                    /*
                    if (gridPattern.Current.RowCount <= 0) continue;
                    */
                    // 20130318
                    //RunOnSuccessScriptBlocks(this);
                    RunOnSuccessScriptBlocks(this, null);
                    
                    for (int rowsCounter = 0;
                        rowsCounter<gridPattern.Current.RowCount;
                        rowsCounter++) {
                        
                            if (SelectedOnly && selectedItems.Length > 0) {
                                
                            } else {
                                // without a selection
                                string outString =
                                    // 20131208
                                    // UiaHelper.GetOutputStringUsingTableGridPattern<GridPattern>(
                                    UiaHelper.GetOutputStringUsingTableGridPattern<IGridPattern>(
                                        gridPattern,
                                        gridPattern.Current.ColumnCount,
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
                    if (gridPattern.Current.RowCount > 0) {
                        // 20130318
                        //RunOnSuccessScriptBlocks(this);
                        RunOnSuccessScriptBlocks(this, null);
                            for (int rowsCounter = 0;
                                 rowsCounter<gridPattern.Current.RowCount;
                                 rowsCounter++) {
                                if (this.SelectedOnly && selectedItems.Length > 0) {
                                } else {
                                    // without a selection
                                    string outString = 
                                        UiaHelper.GetOutputStringUsingTableGridPattern<System.Windows.Automation.GridPattern>(
                                            gridPattern,
                                            gridPattern.Current.ColumnCount,
                                            rowsCounter,
                                            this.Delimiter);
    // getOutputString(ref tblPattern,
    // rowsCounter);
                                    // output a row
                                    WriteObject(outString);
                                }
                            }
                        //}
                    }
                    */
    
                } catch (Exception) {
                    if (gridPattern != null) continue;
                    // WriteVerbose(this, "couldn't get TablePattern");
                    WriteVerbose(this, "couldn't get GridPattern");
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
                    // RunScriptBlocks(this);
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
                        // RunScriptBlocks(this);
                        // 20130318
                        //RunOnSuccessScriptBlocks(this);
                        RunOnSuccessScriptBlocks(this, null);
                        foreach (string row in rows) {
                            this.WriteObject(row);
                        }
                    }
                    */

                    /*
                    if (gridPattern == null)
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
                            // RunScriptBlocks(this);
                            // 20130318
                            //RunOnSuccessScriptBlocks(this);
                            RunOnSuccessScriptBlocks(this, null);
                            foreach (string row in rows) {
                                this.WriteObject(row);
                            }
                        }
                    }
                    */
                }
            } // 20120823
        }
    }
}
