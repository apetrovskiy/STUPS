/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 03/02/2012
 * Time: 09:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Security.Principal;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUIAControlContextMenuCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAControlContextMenu")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlContextMenuCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public GetUIAControlContextMenuCommand()
        {
        }
        #endregion Constructor
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {

            AutomationElement resultElement = null;
            
            // preform a right click on the control
            if (!ClickControl(this,
                               // 20120823
                               //this.InputObject,
                               inputObject,
                               true,
                               false,
                               false,
                               false,
                               false,
                               false,
                               false,
                               Preferences.ClickOnControlByCoordX,
                               Preferences.ClickOnControlByCoordY)) {
                
                // 20130312
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("Couldn't click on this control"),
//                        "couldNotClick",
//                        ErrorCategory.InvalidResult,
//                        //this.InputObject);
//                        inputObject);
//                err.ErrorDetails = 
//                    new ErrorDetails("Could not click on the control");
//// 20120209 
//// WriteError(this, err);
//// return;
//                WriteError(this, err, true);
                
                this.WriteError(
                    this,
                    "Couldn't click on this control",
                    "couldNotClick",
                    ErrorCategory.InvalidResult,
                    true);
                
            } else {
                // 20120823
                //WriteVerbose(this, "clicked on " + this.InputObject.Current.Name);
                this.WriteVerbose(this, "clicked on " + inputObject.Current.Name);
            }
            
            // System.Threading.Thread.Sleep(1000);
            
            // get the cursor coordinates
            int x = 
                System.Windows.Forms.Cursor.Position.X;
            int y = 
                System.Windows.Forms.Cursor.Position.Y;
            
            WriteVerbose(this, "cursor coordinate X = " + x.ToString());
            WriteVerbose(this, "cursor coordinate Y = " + y.ToString());
            
            // get the context menu window
            int processId = 
                // 20120823
                //this.InputObject.Current.ProcessId;
                inputObject.Current.ProcessId;
            WriteVerbose(this, "process Id = " + processId.ToString());
            AutomationElementCollection windowsByPID = null;
            StartDate = System.DateTime.Now;
            bool breakSearch = false;
            do {
                // getting all menus in this process
                if (processId != 0) {
                    windowsByPID = 
                        AutomationElement.RootElement.FindAll(TreeScope.Children,
                                                              new AndCondition(
                                                                  new PropertyCondition(
                                                                      AutomationElement.ProcessIdProperty,
                                                                      processId),
                                                                  // 20130312
                                                                  //new OrCondition(
                                                                  //    new PropertyCondition(
                                                                  //        AutomationElement.ControlTypeProperty,
                                                                  //        ControlType.Window),
                                                                  //    // 20130312 // temporary
                                                                  //    new PropertyCondition(
                                                                  //        AutomationElement.ControlTypeProperty,
                                                                  //        ControlType.Pane),
                                                                  //    new PropertyCondition(
                                                                  //        AutomationElement.ControlTypeProperty,
                                                                  //        ControlType.Menu)
                                                                  //)));
                                                                  new PropertyCondition(
                                                                      AutomationElement.ControlTypeProperty,
                                                                      ControlType.Menu)));
                }
                
                // 
                if (windowsByPID.Count > 0) {
                    WriteVerbose(this, 
                                 "there are " +
                                 windowsByPID.Count.ToString() + 
                                 //" windows running within the process");
                                 " menus running within the process");
                    // 20130312
//                    if (1 < windowsByPID.Count) {
//                        foreach (AutomationElement windowInTheSameProcess in windowsByPID) {
//                            this.WriteVerbose(
//                                this,
//                                windowInTheSameProcess.Current.Name +
//                                "\t" +
//                                windowInTheSameProcess.Current.AutomationId +
//                                "\t" +
//                                windowInTheSameProcess.Current.ClassName);
//                        }
//                    }
                    
                    System.DateTime nowDate = 
                        System.DateTime.Now;
                    if ((nowDate - StartDate).TotalSeconds > 3) {
                        breakSearch = true;
                        break;
                    }
                    // 20130312
                    //if (windowsByPID.Count == 1) {
                    if (windowsByPID.Count == 0) {
                        
                        this.WriteVerbose(this, "sleeping");
                        System.Threading.Thread.Sleep(200);
                        continue;
                    }
                    foreach (AutomationElement element in windowsByPID) {
                        WriteVerbose(this, element.Current.Name);
                        WriteVerbose(this, element.Current.BoundingRectangle.ToString());
                        try {
                            // 20130312
                            //if (element.Current.BoundingRectangle.X == x &&
                            //    element.Current.BoundingRectangle.Y == y) {
//                            if ((element.Current.BoundingRectangle.X + 5 <= x || element.Current.BoundingRectangle.X - 5 >= x) &&
//                                (element.Current.BoundingRectangle.Y + 5 <= y || element.Current.BoundingRectangle.Y -5 >= y)) {
                                WriteVerbose(this, 
                                             "the element " +
                                             element.Current.Name + 
                                             //" is what has been searching for");
                                             // 20130312
                                             " is what we've been searching for");
                                resultElement = element;
                                breakSearch = true;
                                break;
//                            }
                        }catch {
                            
                        }
                    }
                }
            } while (!breakSearch);
            
            // return the context menu window
            //if (resultElement != null && (int)resultElement.Current.ProcessId > 0) {
                this.WriteObject(this, resultElement);
            //} else {
            //  //WriteObject(this, null);
            // WriteObject(this, false);
            //}
            
            } // 20120823
        }
    }
}
