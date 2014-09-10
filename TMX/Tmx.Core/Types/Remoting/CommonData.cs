/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 9:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
	using System.Collections.Generic;
	using TMX.Interfaces.Remoting;
    
    /// <summary>
    /// Description of CommonData.
    /// </summary>
    public class CommonData : ICommonData
    {
        public CommonData()
        {
            if (null == Data)
                Data = new Dictionary<string, object>();
        }
        
        // TODO: convert to singleton
        public static Dictionary<string, object> Data { get; set; }
    }
}
