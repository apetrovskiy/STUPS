/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 8:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using PSTestLib;
    
    /// <summary>
    /// Description of RecordedAction.
    /// </summary>
    public class RecordedAction : IRecordedActionItem
    {
        public RecordedAction()
        {
            this.ItemType = RecordingTypes.Action;
            this.UserData =
                new System.Collections.Generic.Dictionary<string, object>();
        }
        
        public bool Root { get; set; }
        public bool Final { get; set; }
        public RecordingTypes ItemType { get; set; }
        public System.Collections.Generic.Dictionary<string, object> UserData { get; set; }
        
        // Action type
        public ActionTypes ActionType { get; set; }
    }
}
