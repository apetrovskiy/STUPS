namespace Tmx.Core.Aspects
{
    using Castle.DynamicProxy;

    public abstract class AbstractInterceptor : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);
    }
}