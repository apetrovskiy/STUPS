/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/17/2014
 * Time: 1:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of UiaSpecialBindingAttribute.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class UiaSpecialBindingAttribute : System.Attribute
    {
        public UiaSpecialBindingAttribute()
        {
        }
    }
}
