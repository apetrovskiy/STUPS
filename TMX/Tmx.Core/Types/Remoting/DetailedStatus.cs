/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/5/2014
 * Time: 5:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    
    /// <summary>
    /// Description of DetailedStatus.
    /// </summary>
    public class DetailedStatus
    {
        public DetailedStatus()
        {
            
        }
        
        public DetailedStatus(string status)
        {
            Status = status;
        }
        
        public string Status { get; set; }
    }
}
