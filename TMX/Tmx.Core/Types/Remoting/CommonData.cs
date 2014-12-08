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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tmx.Core;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of CommonData.
    /// </summary>
    public class CommonData : ICommonData
    {
        public CommonData()
        {
            Data = new Dictionary<string, string>();
        }
        
        public Dictionary<string, string> Data { get; set; }
        
        public void AddOrUpdateDataItem(ICommonDataItem commonDataItem)
        {
            if (Data.Keys.Any(key => key == commonDataItem.Key))
                updateExistingDataItem(commonDataItem);
            else
                addNewDataItem(commonDataItem);
        }
        
        void addNewDataItem(ICommonDataItem commonDataItem)
        {
            Data.Add(commonDataItem.Key, commonDataItem.Value);
        }
        
        void updateExistingDataItem(ICommonDataItem commonDataItem)
        {
            Data[commonDataItem.Key] = commonDataItem.Value;
        }
    }
}
