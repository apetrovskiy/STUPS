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
    /// Description of MoveUIACursorCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "UIACursor")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class MoveUIACursorCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public MoveUIACursorCommand()
        {
            this.X = 0;
            this.Y = 0;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public int X { get; set; }
        [Parameter(Mandatory = true)]
        public int Y { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {
            
            if (!this.CheckControl(this)) { // return;
                // move to a position that is relative to the desktop
                System.Windows.Forms.Cursor.Position = 
                    new System.Drawing.Point(
                        ((int)AutomationElement.RootElement.Current.BoundingRectangle.Left + this.X),
                        ((int)AutomationElement.RootElement.Current.BoundingRectangle.Top + this.Y));
                this.WriteObject(this, true);
            }
            else {
                System.Windows.Forms.Cursor.Position = 
                    new System.Drawing.Point(
                        // 20120823
                        //((int)InputObject.Current.BoundingRectangle.Left + this.X),
                        ((int)inputObject.Current.BoundingRectangle.Left + this.X),
                        // 20120823
                        //((int)InputObject.Current.BoundingRectangle.Top + this.Y));
                        ((int)inputObject.Current.BoundingRectangle.Top + this.Y));
                if (this.PassThru) {
                    // 20130105
                    //this.WriteObject(this, this.InputObject);
                    this.WriteObject(this, inputObject);
                } else {
                    this.WriteObject(this, true);
                }
            }
                
            } // 20120823
                
            return;
        }
    }
}