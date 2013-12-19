/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/16/2013
 * Time: 12:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of AbstractInterceptor.
    /// </summary>
    public abstract class AbstractInterceptor : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);
    }
}
