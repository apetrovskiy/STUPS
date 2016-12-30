namespace Tmx.Core.Aspects
{
    using System;
    using Castle.DynamicProxy;
    using NLog;

    public class ErrorHandlingAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception eErrorHandling)
            {
                var logger = LogManager.GetLogger(Resources.LogName);
                logger.Error(eErrorHandling);
            }
        }
    }
}