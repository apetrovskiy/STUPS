/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2014
 * Time: 9:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of PsTestLibParameterAttribute.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class PsTestLibParameterAttribute : Attribute
    {
        public PsTestLibParameterAttribute()
        {
        }
    }
}
