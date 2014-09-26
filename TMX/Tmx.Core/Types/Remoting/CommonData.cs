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
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of CommonData.
    /// </summary>
    public static class CommonData // : ICommonData
    {
        static CommonData()
        {
            Data = new Dictionary<string, string>();
        }
        
        // TODO: convert to a singleton
        public static Dictionary<string, string> Data { get; set; }
    }
}
