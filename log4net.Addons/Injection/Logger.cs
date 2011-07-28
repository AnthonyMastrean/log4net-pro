using System;

namespace log4net.Addons.Injection
{
    // NOTE: Remember to configure log4net at bootstrapping. There has to be a way to do this in the constructor, but there's not a commone configuration interface (to support a lambda).
    public class Logger : ILogger
    {
        // NOTE: This signature is easy to use, but verbose. I'd like to conventionally wire up a DefaultLogger<T>.
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