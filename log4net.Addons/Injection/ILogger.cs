using System;

namespace log4net.Addons.Injection
{
    public interface ILogger
    {
        ILog For<T>();
        ILog For(Type type);
    }
}