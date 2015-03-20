namespace Tmx.Server.Internal
{
    using System;
    using Nancy.TinyIoc;

    public class ServerObjectFactory
    {
        public static T Resolve<T>() where T : class
        {
            var typeToReturn = TinyIoCContainer.Current.Resolve<T>();
            if (null == typeToReturn)
                throw new Exception(string.Format("Unable to resolve type {0}", typeof(T).Name));

            return Proxify<T>(typeToReturn);
        }

        static T Proxify<T>(T typeToProxify)
        {
            // TODO: use Castle
            return typeToProxify;
        }
    }
}