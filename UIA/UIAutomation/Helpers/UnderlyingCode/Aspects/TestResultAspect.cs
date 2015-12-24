/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/12/2014
 * Time: 12:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of TestResultAspect.
    /// </summary>
    public class TestResultAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
