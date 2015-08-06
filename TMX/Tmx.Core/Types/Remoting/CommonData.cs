/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/16/2014
 * Time: 9:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.Remoting;

    /// <summary>
    /// Description of CommonData.
    /// </summary>
    public class CommonData : ICommonData
    {
        public CommonData()
        {
            Data = new Dictionary<string, object>();
        }
        
        public IDictionary<string, object> Data { get; set; }
        
        public void AddOrUpdateDataItem(ICommonDataItem commonDataItem)
        {
            if (Data.Keys.Any(key => key == commonDataItem.Key))
                UpdateExistingDataItem(commonDataItem);
            else
                AddNewDataItem(commonDataItem);
        }
        
        void AddNewDataItem(ICommonDataItem commonDataItem)
        {
            Data.Add(commonDataItem.Key, commonDataItem.Value);
        }
        
        void UpdateExistingDataItem(ICommonDataItem commonDataItem)
        {
            Data[commonDataItem.Key] = commonDataItem.Value;
        }
    }
}
