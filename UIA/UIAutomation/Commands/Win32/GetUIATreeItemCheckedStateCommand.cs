/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/6/2013
 * Time: 1:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    //using System.Xml.Serialization.Configuration;

    /// <summary>
    /// Description of GetUIATreeItemCheckedStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATreeItemCheckedState")]
    public class GetUIATreeItemCheckedStateCommand : Win32CmdletBase //GetControlCmdletBase
    {
        public GetUIATreeItemCheckedStateCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string AutomaitonId { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Class { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Value { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {
            
//                ClickControl(
//                    this,
//                    inputObject,
//                    this.RightClick,
//                    this.MidClick,
//                    this.Alt,
//                    this.Shift,
//                    this.Ctrl,
//                    false,
//                    this.DoubleClick,
//                    this.X,
//                    this.Y);
    
                if (this.PassThru) {

                    this.WriteObject(this, inputObject);
                } else {
                    this.WriteObject(this, true);
                }
                
            } // 20120823
        }
    }
}
