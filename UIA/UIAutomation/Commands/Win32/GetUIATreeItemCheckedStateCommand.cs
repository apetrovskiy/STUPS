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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaTreeItemCheckedStateCommand.
    /// </summary>
    // 20140210
    // [Cmdlet(VerbsCommon.Get, "UiaTreeItemCheckedState")]
    public class GetUiaTreeItemCheckedStateCommand : Win32CmdletBase
    {
        public GetUiaTreeItemCheckedStateCommand()
        {
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        // 20131222
        // internal string AutomaitonId { get; set; }
        internal new string AutomationId { get; set; }
        /*
        internal string AutomationId { get; set; }
        */
        /*
        internal new string AutomaitonId { get; set; }
        */

        [UiaParameter][Parameter(Mandatory = false)]
        internal new string Class { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        internal new string Value { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
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
