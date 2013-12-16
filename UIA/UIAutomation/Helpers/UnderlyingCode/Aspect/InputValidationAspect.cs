/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/14/2013
 * Time: 1:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of InputValidationAspect.
    /// </summary>
    public class InputValidationAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            foreach (var argument in invocation.Arguments) {
                // 
            }
            
            invocation.Proceed();
        }
    }
}
