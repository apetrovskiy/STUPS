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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    //using System.Xml.Serialization.Configuration;

    /// <summary>
    /// Description of GetUiaTreeItemCheckedStateCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTreeItemCheckedState")]
    public class GetUiaTreeItemCheckedStateCommand : Win32CmdletBase //GetControlCmdletBase
    {
        public GetUiaTreeItemCheckedStateCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal string AutomaitonId { get; set; }
        /*
        internal new string AutomaitonId { get; set; }
        */

        [Parameter(Mandatory = false)]
        internal new string Class { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Value { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IUiElement inputObject in InputObject) {
            
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
    
                if (PassThru) {

                    WriteObject(this, inputObject);
                } else {
                    WriteObject(this, true);
                }
                
            } // 20120823
        }
    }
}
