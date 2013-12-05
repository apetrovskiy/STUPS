/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:26 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    //using System.Runtime.InteropServices;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Description of HasScriptBlockCmdletBase.
    /// </summary>
    public class HasScriptBlockCmdletBase : CommonCmdletBase
    {
        #region Constructor
        public HasScriptBlockCmdletBase()
        {
            TestPassed = false;

            Highlight = Preferences.Highlight;
            HighlightParent = Preferences.HighlightParent;
//            this.HighlightFirstChild = Preferences.HighlightFirstChild;
            KnownIssue = false;
            Banner = string.Empty;
        }
        #endregion Constructor

        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter Highlight { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter HighlightParent { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter HighlightFirstChild { get; set; }
        // 20130322
        [Parameter(Mandatory = false)]
        public string Banner { get; set; }
        #endregion Parameters
        
        protected internal IMySuperWrapper ElementToSubscribe;
        // list of all subscribed events
        protected internal readonly List<AutomationEventHandler> SubscribedEvents =
            new List<AutomationEventHandler>();
        protected internal readonly List<AutomationEvent> SubscribedEventsIds =
            new List<AutomationEvent>();
        
        #region for script recording
        public List<List<string>> Recording =
            new List<List<string>>();
        #endregion for script recording
        
        #region get active window
        protected IMySuperWrapper GetActiveWindow()
        {
            IMySuperWrapper result = null;
            try {
                IntPtr hWnd = 
                    NativeMethods.GetForegroundWindow();
                WriteVerbose(this, 
                             "the handle to the active window is " + 
                             hWnd.ToInt32());
                            /*
                            _hWnd.ToInt32().ToString());
                            */
                if (hWnd == IntPtr.Zero) return result;
                // 20131109
                //result = 
                //    AutomationElement.FromHandle(_hWnd);
                // 20131112
                //result =
                //    new MySuperWrapper(AutomationElement.FromHandle(_hWnd));
                result =
                    AutomationFactory.GetMySuperWrapper(AutomationElement.FromHandle(hWnd));
                WriteVerbose(this, 
                             "the active window element is " + 
                             result.Current.Name);
            } catch (Exception e) {
                WriteVerbose(this, e.Message);
            }
            return result;
        }
        #endregion get active window
    }
}