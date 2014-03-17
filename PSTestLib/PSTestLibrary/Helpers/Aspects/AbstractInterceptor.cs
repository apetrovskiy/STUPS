/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/16/2014
 * Time: 1:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of CentralAbstractInterceptor.
    /// </summary>
    public abstract class AbstractInterceptor : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);
    }
}
