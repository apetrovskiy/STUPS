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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using Helpers.Commands;
    
    /// <summary>
    /// Description of InvokeUiaControlContextMenuCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaControlContextMenu")]
    public class InvokeUiaControlContextMenuCommand : HasControlInputCmdletBase
    {
        // TEMPORARY!
        // 20140116
        public InvokeUiaControlContextMenuCommand()
        {
            X = Preferences.ClickOnControlByCoordX;
            Y = Preferences.ClickOnControlByCoordY;
        }
        
        // TEMPORARY!
        // 20140116
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public int X { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public int Y { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
//            foreach (IUiElement inputObject in InputObject) {
//                
//                try {
//                    var resultElement = inputObject.InvokeContextMenu(this, X, Y);
//                    // return the context menu window
//                    WriteObject(this, resultElement);
//                } catch {
//                    WriteError(
//                        this,
//                        "Failed to invoke context menu on this element",
//                        "couldNotClick",
//                        ErrorCategory.InvalidResult,
//                        true);
//                }
//                
//            }
            
            var command =
                AutomationFactory.GetCommand<InvokeControlContextMenuCommand>(this);
            command.Execute();
        }
    }
}
