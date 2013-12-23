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
    extern alias UIANET;
    
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    
    
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUiaControlContextMenuCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaControlContextMenu")]
    
    public class GetUiaControlContextMenuCommand : HasControlInputCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {
                
                try {
                // InvokeContextMenu(inputObject);
                inputObject.InvokeContextMenu(this);
                } catch {
                    WriteError(
                        this,
                        "Couldn't click on this control",
                        "couldNotClick",
                        ErrorCategory.InvalidResult,
                        true);
                }
                
            } // 20120823
        }

        
//============================================================================================================
//IUiElement resultElement = null;
//            
//            // preform a right click on the control
//            if (!ClickControl(this,
//                               inputObject,
//                               true,
//                               false,
//                               false,
//                               false,
//                               false,
//                               false,
//                               false,
//                               0,
//                               Preferences.ClickOnControlByCoordX,
//                               Preferences.ClickOnControlByCoordY)) {
//                
//                WriteError(
//                    this,
//                    "Couldn't click on this control",
//                    "couldNotClick",
//                    ErrorCategory.InvalidResult,
//                    true);
//                
//            } else {
//                WriteVerbose(this, "clicked on " + inputObject.Current.Name);
//            }
//            
//            // System.Threading.Thread.Sleep(1000);
//            
//            // get the cursor coordinates
//            int x = 
//                Cursor.Position.X;
//            int y = 
//                Cursor.Position.Y;
//            
//            WriteVerbose(this, "cursor coordinate X = " + x.ToString(CultureInfo.InvariantCulture));
//            WriteVerbose(this, "cursor coordinate Y = " + y.ToString(CultureInfo.InvariantCulture));
//            /*
//            WriteVerbose(this, "cursor coordinate X = " + x.ToString());
//            WriteVerbose(this, "cursor coordinate Y = " + y.ToString());
//            */
//
//            // get the context menu window
//            int processId = 
//                // 20120823
//                //this.InputObject.Current.ProcessId;
//                inputObject.Current.ProcessId;
//            WriteVerbose(this, "process Id = " + processId.ToString());
//            // 20131109
//            //AutomationElementCollection windowsByPID = null;
//            IUiEltCollection windowsByPid = null;
//            StartDate = DateTime.Now;
//            bool breakSearch = false;
//            do {
//                // getting all menus in this process
//                if (processId != 0) {
//                    windowsByPid =
//                        // 20131109
//                        //AutomationElement.RootElement.FindAll(TreeScope.Children,
//                        // 20131215
//                        UiElement.RootElement.FindAll(TreeScope.Children,
//                        // UiElement.RootElement().FindAll(TreeScope.Children,
//                                                              new AndCondition(
//                                                                  new PropertyCondition(
//                                                                      AutomationElement.ProcessIdProperty,
//                                                                      processId),
//                                                                  // 20130312
//                                                                  //new OrCondition(
//                                                                  //    new PropertyCondition(
//                                                                  //        AutomationElement.ControlTypeProperty,
//                                                                  //        ControlType.Window),
//                                                                  //    // 20130312 // temporary
//                                                                  //    new PropertyCondition(
//                                                                  //        AutomationElement.ControlTypeProperty,
//                                                                  //        ControlType.Pane),
//                                                                  //    new PropertyCondition(
//                                                                  //        AutomationElement.ControlTypeProperty,
//                                                                  //        ControlType.Menu)
//                                                                  //)));
//                                                                  new PropertyCondition(
//                                                                      AutomationElement.ControlTypeProperty,
//                                                                      ControlType.Menu)));
//                }
//                
//                // 
//                if (windowsByPid != null && windowsByPid.Count <= 0) continue;
//                /*
//                if (windowsByPID.Count <= 0) continue;
//                */
//                WriteVerbose(this, 
//                    "there are " +
//                    windowsByPid.Count.ToString() + 
//                    //" windows running within the process");
//                    " menus running within the process");
//                // 20130312
////                    if (1 < windowsByPID.Count) {
////                        foreach (AutomationElement windowInTheSameProcess in windowsByPID) {
////                            this.WriteVerbose(
////                                this,
////                                windowInTheSameProcess.Current.Name +
////                                "\t" +
////                                windowInTheSameProcess.Current.AutomationId +
////                                "\t" +
////                                windowInTheSameProcess.Current.ClassName);
////                        }
////                    }
//                    
//                DateTime nowDate = 
//                    DateTime.Now;
//                if ((nowDate - StartDate).TotalSeconds > 3) {
//                    breakSearch = true;
//                    break;
//                }
//                // 20130312
//                //if (windowsByPID.Count == 1) {
//                if (windowsByPid.Count == 0) {
//                        
//                    WriteVerbose(this, "sleeping");
//                    Thread.Sleep(200);
//                    continue;
//                }
//                
//                // 20131109
//                //foreach (AutomationElement element in windowsByPID) {
//                foreach (IUiElement element in windowsByPid) {
//                    
//                    WriteVerbose(this, element.Current.Name);
//                    WriteVerbose(this, element.Current.BoundingRectangle.ToString());
//                    try {
//                        // 20130312
//                        //if (element.Current.BoundingRectangle.X == x &&
//                        //    element.Current.BoundingRectangle.Y == y) {
////                            if ((element.Current.BoundingRectangle.X + 5 <= x || element.Current.BoundingRectangle.X - 5 >= x) &&
////                                (element.Current.BoundingRectangle.Y + 5 <= y || element.Current.BoundingRectangle.Y -5 >= y)) {
//                        WriteVerbose(this, 
//                            "the element " +
//                            element.Current.Name + 
//                            //" is what has been searching for");
//                            // 20130312
//                            " is what we've been searching for");
//                        resultElement = element;
//                        breakSearch = true;
//                        break;
////                            }
//                    }catch {
//                            
//                    }
//                }
//
//                /*
//                if (windowsByPID.Count > 0) {
//                    WriteVerbose(this, 
//                                 "there are " +
//                                 windowsByPID.Count.ToString() + 
//                                 //" windows running within the process");
//                                 " menus running within the process");
//                    // 20130312
////                    if (1 < windowsByPID.Count) {
////                        foreach (AutomationElement windowInTheSameProcess in windowsByPID) {
////                            this.WriteVerbose(
////                                this,
////                                windowInTheSameProcess.Current.Name +
////                                "\t" +
////                                windowInTheSameProcess.Current.AutomationId +
////                                "\t" +
////                                windowInTheSameProcess.Current.ClassName);
////                        }
////                    }
//                    
//                    System.DateTime nowDate = 
//                        System.DateTime.Now;
//                    if ((nowDate - StartDate).TotalSeconds > 3) {
//                        breakSearch = true;
//                        break;
//                    }
//                    // 20130312
//                    //if (windowsByPID.Count == 1) {
//                    if (windowsByPID.Count == 0) {
//                        
//                        this.WriteVerbose(this, "sleeping");
//                        System.Threading.Thread.Sleep(200);
//                        continue;
//                    }
//                    foreach (AutomationElement element in windowsByPID) {
//                        WriteVerbose(this, element.Current.Name);
//                        WriteVerbose(this, element.Current.BoundingRectangle.ToString());
//                        try {
//                            // 20130312
//                            //if (element.Current.BoundingRectangle.X == x &&
//                            //    element.Current.BoundingRectangle.Y == y) {
////                            if ((element.Current.BoundingRectangle.X + 5 <= x || element.Current.BoundingRectangle.X - 5 >= x) &&
////                                (element.Current.BoundingRectangle.Y + 5 <= y || element.Current.BoundingRectangle.Y -5 >= y)) {
//                                WriteVerbose(this, 
//                                             "the element " +
//                                             element.Current.Name + 
//                                             //" is what has been searching for");
//                                             // 20130312
//                                             " is what we've been searching for");
//                                resultElement = element;
//                                breakSearch = true;
//                                break;
////                            }
//                        }catch {
//                            
//                        }
//                    }
//                }
//                */
//
//            } while (!breakSearch);
//            
//            // return the context menu window
//            //if (resultElement != null && (int)resultElement.Current.ProcessId > 0) {
//                WriteObject(this, resultElement);
//            //} else {
//            //  //WriteObject(this, null);
//            // WriteObject(this, false);
//            //}
//            
//            // 20131119
//            // disposal
//            windowsByPid.Dispose();
//            windowsByPid = null;
//============================================================================================================
        
        
        

        // preform a right click on the control



        // System.Threading.Thread.Sleep(1000);

        // get the cursor coordinates
//        private void InvokeContextMenu(IUiElement inputObject)
//        {
//            IUiElement resultElement = null;
//            if (!ClickControl(this, inputObject, true, false, false, false, false, false, false, 0,
//                              Preferences.ClickOnControlByCoordX, Preferences.ClickOnControlByCoordY)) {
//                WriteError(this, "Couldn't click on this control", "couldNotClick", ErrorCategory.InvalidResult, true);
//            } else {
//                WriteVerbose(this, "clicked on " + inputObject.Current.Name);
//            }
//            int x = Cursor.Position.X;
//            int y = Cursor.Position.Y;
//
//            WriteVerbose(this, "cursor coordinate X = " + x.ToString(CultureInfo.InvariantCulture));
//            WriteVerbose(this, "cursor coordinate Y = " + y.ToString(CultureInfo.InvariantCulture));
//
//            // get the context menu window
//            int processId = inputObject.Current.ProcessId;
//            WriteVerbose(this, "process Id = " + processId.ToString());
//            IUiEltCollection windowsByPid = null;
//            StartDate = DateTime.Now;
//            bool breakSearch = false;
//            do {
//                // getting all menus in this process
//                if (processId != 0) {
//                    windowsByPid =
//                        UiElement.RootElement.FindAll(
//                            TreeScope.Children,
//                            new AndCondition(
//                                new PropertyCondition(
//                                    AutomationElement.ProcessIdProperty,
//                                    processId),
//                                new PropertyCondition(
//                                    AutomationElement.ControlTypeProperty,
//                                    ControlType.Menu)));
//                }
//                
//                if (windowsByPid != null && windowsByPid.Count <= 0)
//                    continue;
//                
//                WriteVerbose(this, "there are " + windowsByPid.Count.ToString() + " menus running within the process");
//                
//                DateTime nowDate = DateTime.Now;
//                if ((nowDate - StartDate).TotalSeconds > 3) {
//                    breakSearch = true;
//                    break;
//                }
//                
//                if (windowsByPid.Count == 0) {
//
//                    WriteVerbose(this, "sleeping");
//                    Thread.Sleep(200);
//                    continue;
//                }
//                
//                foreach (IUiElement element in windowsByPid) {
//
//                    WriteVerbose(this, element.Current.Name);
//                    WriteVerbose(this, element.Current.BoundingRectangle.ToString());
//                    try {
//                        WriteVerbose(this, "the element " + element.Current.Name + " is what we've been searching for");
//                        resultElement = element;
//                        breakSearch = true;
//                        break;
//                        //                            }
//                    } catch {
//                    }
//
//                }
//                
//            }	 while (!breakSearch);
//
//            // return the context menu window
//            WriteObject(this, resultElement);
//            
//            // 20131119
//            // disposal
//            windowsByPid.Dispose();
//            windowsByPid = null;
//        }
    }
}
