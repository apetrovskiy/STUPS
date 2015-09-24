namespace Tmx.Server.Logic.Internal
{
    using System;
    using Core.Proxy;
    using Nancy.TinyIoc;

    public class ServerObjectFactory
    {
        public static T Resolve<T>() where T : class
        {
            var typeToReturn = TinyIoCContainer.Current.Resolve<T>();
            if (null == typeToReturn)
                throw new Exception(string.Format("Unable to resolve type {0}", typeof(T).Name));

            // return Proxify<T>(typeToReturn);
            return ProxyFactory.Proxify(typeToReturn);
        }
    }
}