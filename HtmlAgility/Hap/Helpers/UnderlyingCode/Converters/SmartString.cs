/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 9:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap
{
    using System;
    
    /// <summary>
    /// Description of SmartString.
    /// </summary>
    public class SmartString
    {
        public string Data { get; set; }
        
        public SmartString(object inputObject)
        {
            Data = inputObject.ToString();
        }
    }
}
