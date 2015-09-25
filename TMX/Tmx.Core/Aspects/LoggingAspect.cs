namespace Tmx.Core.Aspects
{
    using System.Linq;
    using Castle.DynamicProxy;
    using NLog;

    public class LoggingAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            var logger = LogManager.GetLogger(Tmx_Core_Resources.LogName);
            var loggingString = invocation.TargetType.Namespace + "." + invocation.TargetType.Name + "." + invocation.Method.Name + "(";
            invocation.Arguments.ToList().ForEach(arg =>
            // invocation.Arguments.ForEach(arg =>
            {
                loggingString += arg.ToString();
                loggingString += ", ";
            });
            if (loggingString.Substring(loggingString.Length - 2) == ", ")
                loggingString = loggingString.Substring(0, loggingString.Length - 2);
            loggingString += ")";
            logger.Info(loggingString);
            invocation.Proceed();
        }
    }
}