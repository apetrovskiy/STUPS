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
    using System.Runtime.InteropServices;
    using System.Windows.Automation;

    /// <summary>
    /// Description of ConvertFromUIADataGridCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "UIADataGrid")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ConvertFromUIADataGridCommand : ConvertCmdletBase
    {
        #region Constructor
        public ConvertFromUIADataGridCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        // private bool SelectedOnly { get; set; }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {

            string strData = String.Empty;
            System.Windows.Automation.AutomationElement _control = 
                // 20120823
                //this.InputObject;
                inputObject;
            GridPattern gridPattern = null;

            try {
                gridPattern = 
                    //_control.GetCurrentPattern(GridPattern.Pattern)
                    // 20120823
                    //this.InputObject.GetCurrentPattern(GridPattern.Pattern)
                    inputObject.GetCurrentPattern(GridPattern.Pattern)
                    as GridPattern;
                
            
                    bool res1 = 
                        UIAHelper.GetHeaderItems(ref _control, out strData, this.Delimiter);
                    if (res1) {
                        // WriteObject(this, strData);
                        this.WriteObject(strData);
                    } else {
                        this.WriteVerbose(this, strData);
                    }
                    
                    // temporary!!!
                    // Selection
                    System.Windows.Automation.AutomationElement[] selectedItems = null;
                    if (this.SelectedOnly) {
                        // if there's a selection, get items in the selection
                        try {
                            System.Windows.Automation.SelectionPattern selPattern;
                            selPattern = 
                                // 20120823
                                //this.InputObject.GetCurrentPattern(
                                inputObject.GetCurrentPattern(
                                    System.Windows.Automation.SelectionPattern.Pattern)
                                    as System.Windows.Automation.SelectionPattern;
                            selectedItems = 
                                selPattern.Current.GetSelection();
                        } catch (Exception eSelection) {
                            this.WriteDebug(this, eSelection.Message);
                            this.WriteVerbose(this, "there wasn't a selection");
                        }
                    }
                    
                    
                    // temporary!!!
                    // get rows
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
                                        UIAHelper.GetOutputStringUsingTableGridPattern<System.Windows.Automation.GridPattern > (
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
            
            
            } catch {

            
                if (gridPattern == null)
                {
                    this.WriteVerbose(this, "couldn't get TablePattern");
                    this.WriteVerbose(this, "trying to enumerate columns and rows");
                    
                    
                    bool res2 = 
                        UIAHelper.GetHeaders(ref _control, out strData, this.Delimiter);
                    if (res2) {
                        this.WriteObject(strData);
                    } else {
                        this.WriteVerbose(this, strData);
                    }
                    
                    
                    System.Collections.Generic.List<string >  rows = 
                        // 20120823
                        //UIAHelper.GetOutputStringUsingItemsValuePattern(this.InputObject,
                        UIAHelper.GetOutputStringUsingItemsValuePattern(inputObject,
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
            }
            
        } // 20120823
            
            
        }
    }
}
