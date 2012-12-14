/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2012
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of IRecordedDataItem.
    /// </summary>
    public interface IRecordedDataItem : IRecordedItem
    {
        System.Collections.Generic.Dictionary<string, object> UserData { get; set; }
    }
}
