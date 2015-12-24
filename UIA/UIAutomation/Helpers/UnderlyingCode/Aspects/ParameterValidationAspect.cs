/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/14/2013
 * Time: 1:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of ParameterValidationAspect.
    /// </summary>
    public class ParameterValidationAspect : AbstractInterceptor
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
