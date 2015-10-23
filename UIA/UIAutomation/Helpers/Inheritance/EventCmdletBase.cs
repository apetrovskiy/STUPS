/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:29 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;
    using Helpers.Commands;

    /// <summary>
    /// Description of HasScriptBlockCmdletBase.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Register, "UiaDummyEvent")]
    public class EventCmdletBase : HasControlInputCmdletBase
    {
        #region Constructor
        public EventCmdletBase()
        {
            InputObject =
                new[] { CurrentData.CurrentWindow };
            AutomationEventType = null;
            AutomationProperty = null;
            AutomationEventHandler = null;
            AutomationPropertyChangedEventHandler = null;
            StructureChangedEventHandler = null;
        }
        #endregion Constructor

        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        //public override SwitchParameter OnErrorScreenShot { get; set; }
        internal new SwitchParameter OnErrorScreenShot { get; set; }
        /*
        internal SwitchParameter OnErrorScreenShot { get; set; }
        */
        // internal new SwitchParameter OnErrorScreenShot { get; set; }

        [UiaParameter][Parameter(Mandatory = false)]
        public Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
        
        #region Properties
        #endregion Properties
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (InputObject == null) return;
            
            var command =
                AutomationFactory.GetCommand<EventCommand>(this);
            command.Execute();
        }
    }
}