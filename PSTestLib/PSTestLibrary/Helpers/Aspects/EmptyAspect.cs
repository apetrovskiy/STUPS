/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/16/2014
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of EmptyAspect.
    /// </summary>
    public class EmptyAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
