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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Collections;

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
        [My][Parameter(Mandatory = false)]
        //public override SwitchParameter OnErrorScreenShot { get; set; }
        internal new SwitchParameter OnErrorScreenShot { get; set; }
        /*
        internal SwitchParameter OnErrorScreenShot { get; set; }
        */
        // internal new SwitchParameter OnErrorScreenShot { get; set; }

        [My][Parameter(Mandatory = false)]
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
            
            foreach (IUiElement inputObject in InputObject) {
                
                SubscribeToEvents(this,
                                  inputObject,
                                  AutomationEventType,
                                  AutomationProperty);
                
            }
        }
    }
}