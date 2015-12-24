/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 28.01.2012
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using Helpers.Commands;

    /// <summary>
    /// Description of InvokeUiaControlClickCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaControlClick")]
    public class InvokeUiaControlClickCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public InvokeUiaControlClickCommand()
        {
            RightClick = false;
            MidClick = false;
            Alt = false;
            Shift = false;
            Ctrl = false;
            DoubleClick = false;
            
            X = -1000000;
            Y = -1000000;
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter RightClick { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter MidClick { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Alt { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Shift { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Ctrl { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter DoubleClick { get; set; }
        // 20131125
        [UiaParameter][Parameter(Mandatory = false)]
        public int DoubleClickInterval { get; set; }
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
//                ClickControl(
//                    this,
//                    inputObject,
//                    new ClickSettings {
//                        RightClick = this.RightClick,
//                        MidClick = this.MidClick,
//                        Alt = this.Alt,
//                        Shift = this.Shift,
//                        Ctrl = this.Ctrl,
//                        // inSequence = this.ins
//                        DoubleClick = this.DoubleClick,
//                        DoubleClickInterval = this.DoubleClickInterval,
//                        RelativeX = this.X,
//                        RelativeY = this.Y
//                    });
//                
//                if (PassThru) {
//
//                    WriteObject(this, inputObject);
//                } else {
//                    WriteObject(this, true);
//                }
//                
//            }
            
            var command =
                AutomationFactory.GetCommand<InvokeControlClickCommand>(this);
            command.Execute();
        }
    }
}
