namespace Tmx.Core.Proxy
{
    using System;
    using Aspects;
    using Castle.DynamicProxy;
    using NLog;

    public class ProxyFactory
    {
        static ProxyGenerator _generator;
        static bool _alreadyInitialized;

        public static void Init()
        {
            if (_alreadyInitialized)
                return;

            _generator = new ProxyGenerator(new PersistentProxyBuilder());
            _alreadyInitialized = true;
        }

        public static T Get<T>(params object[] parameters)
        {
            Init();
            T proxiedObject = default(T);

            try
            {
                if (null == parameters || 0 == parameters.Length)
                    proxiedObject =
                        (T)_generator.CreateClassProxy(
                            typeof(T),
                            new LoggingAspect(), new ErrorHandlingAspect());
                else
                {
                    proxiedObject =
                        (T)_generator.CreateClassProxy(
                            typeof(T),
                            parameters,
                            new LoggingAspect(), new ErrorHandlingAspect());
                }
            }
            catch (Exception eProxification)
            {
                var logger = LogManager.GetLogger(Tmx_Core_Resources.LogName);
                logger.Error("Failed to proxify type {0}", typeof(T).Name);
                logger.Error(eProxification);
            }

            return proxiedObject;
        }

        public static T Proxify<T>(T objectToBeProxified, params object[] parameters) where T : class
        {
            Init();
            T proxiedObject = default(T);

            try
            {
                if (null == parameters)
                    proxiedObject =
                        _generator.CreateClassProxyWithTarget(
                            objectToBeProxified,
                            ProxyGenerationOptions.Default,
                            new LoggingAspect(), new ErrorHandlingAspect());
                else
                    proxiedObject =
                        (T)_generator.CreateClassProxyWithTarget(
                            typeof(T),
                            new Type[] { },
                            objectToBeProxified,
                            ProxyGenerationOptions.Default,
                            parameters,
                            new LoggingAspect(), new ErrorHandlingAspect());
            }
            catch (Exception eProxification)
            {
                var logger = LogManager.GetLogger(Tmx_Core_Resources.LogName);
                logger.Error("Failed to proxify type {0}", typeof(T).Name);
                logger.Error(eProxification);
            }

            return proxiedObject;
        }
    }
}