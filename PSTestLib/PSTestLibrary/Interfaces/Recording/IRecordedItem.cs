/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 7:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of IRecordedItem.
    /// </summary>
    public interface IRecordedItem
    {
        RecordingTypes ItemType { get; set; }
        bool Final { get; set; }
        bool Root { get; set; }
    }
}
