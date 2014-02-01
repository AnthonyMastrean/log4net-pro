using log4net.Appender;

namespace log4net.Addons.Config
{
    public class LoggerAppenderExpression
    {
        private readonly LoggerExpression _expr;

        public LoggerAppenderExpression(LoggerExpression expr)
        {
            _expr = expr;
        }

        public LoggerExpression AddAppender(IAppender appender)
        {
            _expr.AddAppender(appender);
            return _expr;
        }
    }
}