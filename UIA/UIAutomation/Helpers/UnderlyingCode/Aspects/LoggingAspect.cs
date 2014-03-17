/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/14/2013
 * Time: 1:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using Castle.DynamicProxy;
	using PSTestLib;
    
    /// <summary>
    /// Description of LoggingAspect.
    /// </summary>
//    public class LoggingAspect : AbstractInterceptor
//    {
//        public override void Intercept(IInvocation invocation)
//        {
//            if (Preferences.Log) {
//                try {
//                    // 20140315
//                    // if (invocation.TargetType.IsSubclassOf(typeof(UiaCommand))) {
//                    if (invocation.TargetType.IsSubclassOf(typeof(AbstractCommand))) {
//                        var cmdlet =
//                            // 20140315
//                            // (invocation.InvocationTarget as UiaCommand).Cmdlet;
//                            (invocation.InvocationTarget as AbstractCommand).Cmdlet;
//                        var logger =
//                            // 20140315
//                            // AutomationFactory.GetLogHelper(string.Empty);
//                            ObjectFactory.GetLogHelper(string.Empty);
//                        logger.LogCmdlet(cmdlet);
//                    }
//                }
//                catch (Exception eLoggingAspect) {
//                    // Console.WriteLine(eLoggingAspect.Message);
//                }
//            }
//            
//            invocation.Proceed();
//        }
//    }
}
