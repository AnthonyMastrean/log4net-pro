using System;

namespace log4net.Addons.Injection
{
    // NOTE: Remember to configure log4net at bootstrapping.
    // There has to be a way to do this in the constructor, but there's not a 
    // common configuration interface (to support a configuration lambda).
    public class Logger : ILogger
    {
        public ILog For<T>()
        {
            return For(typeof(T));
        }

        public ILog For(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}