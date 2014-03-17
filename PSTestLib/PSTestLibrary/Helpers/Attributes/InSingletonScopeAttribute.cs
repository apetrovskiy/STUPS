/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2014
 * Time: 11:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of InSingletonScopeAttribute.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class InSingletonScopeAttribute : Attribute
    {
        public InSingletonScopeAttribute()
        {
        }
    }
}
