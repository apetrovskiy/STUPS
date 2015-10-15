/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2012
 * Time: 2:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using PSTestLib;
    
    /// <summary>
    /// Description of RecordedData.
    /// </summary>
    public class RecordedData : IRecordedDataItem
    {
        public RecordedData()
        {
            ItemType = RecordingTypes.Data;
            UserData =
                new System.Collections.Generic.Dictionary<string, object>();
        }
        
        public bool Root { get; set; }
        public bool Final { get; set; }
        public RecordingTypes ItemType { get; set; }
        public System.Collections.Generic.Dictionary<string, object> UserData { get; set; }
    }
}
