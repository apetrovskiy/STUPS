/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/26/2014
 * Time: 1:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of PlaceholderType.
    /// </summary>
    public class PlaceholderType
    {
        public DateTime ScopeStartTime { get; set; }
        
        public PlaceholderType()
        {
            ScopeStartTime = DateTime.Now;
        }
    }
}
