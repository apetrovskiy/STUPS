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
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Description of HasScriptBlockCmdletBase.
    /// </summary>
    public class HasScriptBlockCmdletBase : CommonCmdletBase
    {
        #region Constructor
        public HasScriptBlockCmdletBase()
        {
            this.TestPassed = false;

            this.Highlight = Preferences.Highlight;
            this.HighlightParent = Preferences.HighlightParent;
//            this.HighlightFirstChild = Preferences.HighlightFirstChild;
            this.KnownIssue = false;
            this.Banner = string.Empty;
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
        
        // 20131109
        //protected internal AutomationElement ElementToSubscribe;
        protected internal IMySuperWrapper ElementToSubscribe;
        // list of all subscribed events
        protected internal System.Collections.ArrayList subscribedEvents = 
            new System.Collections.ArrayList();
        protected internal System.Collections.ArrayList subscribedEventsIds = 
            new System.Collections.ArrayList();
        
        #region for script recording
        public System.Collections.ArrayList Recording = 
            new System.Collections.ArrayList();
        #endregion for script recording
        
        #region get active window
        // 20131109
        //protected AutomationElement GetActiveWindow()
        protected IMySuperWrapper GetActiveWindow()
        {
            // 20131109
            //AutomationElement result = null;
            IMySuperWrapper result = null;
            try {
                IntPtr _hWnd = 
                    NativeMethods.GetForegroundWindow();
                WriteVerbose(this, 
                             "the handle to the active window is " + 
                             _hWnd.ToInt32().ToString());
                if (_hWnd == IntPtr.Zero) return result;
                // 20131109
                //result = 
                //    AutomationElement.FromHandle(_hWnd);
                result =
                    new MySuperWrapper(AutomationElement.FromHandle(_hWnd));
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