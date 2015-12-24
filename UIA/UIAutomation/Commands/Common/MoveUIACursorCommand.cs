/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Drawing;
using System.Windows.Forms;

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of MoveUiaCursorCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "UiaCursor")]
    public class MoveUiaCursorCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public MoveUiaCursorCommand()
        {
            X = 0;
            Y = 0;
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true)]
        public int X { get; set; }
        [UiaParameter][Parameter(Mandatory = true)]
        public int Y { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            foreach (IUiElement inputObject in InputObject) {
            
            if (!CheckAndPrepareInput(this)) { // return;
                // move to a position that is relative to the desktop
                Cursor.Position = 
                    new Point(
                            // 20140312
//                        ((int)UiElement.RootElement.Current.BoundingRectangle.Left + X),
//                        ((int)UiElement.RootElement.Current.BoundingRectangle.Top + Y));
                            ((int)UiElement.RootElement.GetCurrent().BoundingRectangle.Left + X),
                            ((int)UiElement.RootElement.GetCurrent().BoundingRectangle.Top + Y));
                WriteObject(this, true);
            }
            else {
                Cursor.Position = 
                    new Point(
                            // 20140312
//                        ((int)inputObject.Current.BoundingRectangle.Left + X),
//                        ((int)inputObject.Current.BoundingRectangle.Top + Y));
                            ((int)inputObject.GetCurrent().BoundingRectangle.Left + X),
                            ((int)inputObject.GetCurrent().BoundingRectangle.Top + Y));
                if (PassThru) {
                    WriteObject(this, inputObject);
                } else {
                    WriteObject(this, true);
                }
            }
                
            } // 20120823
                
            //return;
            
//            var command = 
//                AutomationFactory.GetCommand<MoveCursorCommand>(this);
//            command.Execute();
        }
    }
}