/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 7:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of IRecordedActionItem.
    /// </summary>
    public interface IRecordedActionItem : IRecordedItem
    {
        System.Collections.Generic.Dictionary<string, object> UserData { get; set; }
    }
}
