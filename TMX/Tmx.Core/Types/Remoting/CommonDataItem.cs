/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 4:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of CommonDataItem.
    /// </summary>
    public class CommonDataItem : ICommonDataItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
