/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/1/2014
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using Castle.DynamicProxy;
	using PSTestLib;
    
    /// <summary>
    /// Description of FaultInjectionAspect.
    /// </summary>
    public class FaultInjectionAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
