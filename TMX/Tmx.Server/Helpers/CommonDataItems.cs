/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/16/2014
 * Time: 9:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Linq;
    using Tmx.Core;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of CommonDataItems.
    /// </summary>
    public class CommonDataItems
    {
        public void AddOrUpdateDataItem(ICommonDataItem commonDataItem)
        {
            if (CommonData.Data.Keys.Any(key => key == commonDataItem.Key))
                updateExistingDataItem(commonDataItem);
            else
                addNewDataItem(commonDataItem);
        }
        
        void addNewDataItem(ICommonDataItem commonDataItem)
        {
            CommonData.Data.Add(commonDataItem.Key, commonDataItem.Value);
        }
        
        void updateExistingDataItem(ICommonDataItem commonDataItem)
        {
            CommonData.Data[commonDataItem.Key] = commonDataItem.Value;
        }
    }
}
