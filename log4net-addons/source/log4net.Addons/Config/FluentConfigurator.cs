using System;

namespace log4net.Addons.Config
{
    public class FluentConfigurator
    {
        private static readonly string Default = AppDomain.CurrentDomain.FriendlyName;

        /// <summary>
        /// Configure a logger for this assembly.
        /// </summary>
        public LoggerLevelExpression Logger()
        {
            return Logger(Default);
        }

        /// <summary>
        ///  Configure a named logger.
        /// </summary>
        public LoggerLevelExpression Logger(string name)
        {
            return new LoggerLevelExpression(new LoggerExpression(LogManager.GetLogger(name)));
        }

        /// <summary>
        /// Configure a logger for this hierarchy.
        /// </summary>
        public LoggerLevelExpression Logger<T>()
        {
            return Logger(typeof(T));
        }

        /// <summary>
        /// Configure a logger for this hierarchy.
        /// </summary>
        public LoggerLevelExpression Logger(Type type)
        {
            return new LoggerLevelExpression(new LoggerExpression(LogManager.GetLogger(type)));
        }
    }
}