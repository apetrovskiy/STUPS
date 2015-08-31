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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class UiaSpecialBindingAttribute : Attribute
    {
        public UiaSpecialBindingAttribute()
        {
        }
    }
}
