using System.Collections.Generic;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace log4net.Addons.Config
{
    public class LoggerExpression
    {
        private readonly ILog _log;
        private readonly Logger _logger;
        private readonly List<IAppender> _appenders = new List<IAppender>();
        private Level _level = Level.All;

        public LoggerExpression(ILog log)
        {
            _log = log;
            _logger = log.GetLogger();
        }

        public void SetLevel(Level level)
        {
            _level = level;
        }

        public void AddAppender(IAppender appender)
        {
            _appenders.Add(appender);
        }

        public ILog Configure()
        {
            _logger.Level = _logger.Hierarchy.LevelMap[_level.Name];
            _appenders.ForEach(_logger.AddAppender);

            return _log;
        }
    }
}