/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/13/2014
 * Time: 4:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of MyAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UiaParameterAttribute : Attribute
    {
        public UiaParameterAttribute()
        {
        }
    }
}
