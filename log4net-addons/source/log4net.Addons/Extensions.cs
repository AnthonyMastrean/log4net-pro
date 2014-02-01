using System;
using log4net.Repository.Hierarchy;

namespace log4net.Addons
{
    public static class Extensions
    {
        public static Logger GetLogger(this ILog log)
        {
            if (log == null)
                throw new ArgumentNullException("log");

            return (Logger)log.Logger;
        }
    }
}