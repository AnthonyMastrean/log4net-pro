using log4net.Core;

namespace log4net.Addons.Config
{
    public class LoggerLevelExpression
    {
        private readonly LoggerExpression _expr;

        public LoggerLevelExpression(LoggerExpression expr)
        {
            _expr = expr;
        }

        public LoggerExpression Off()
        {
            _expr.SetLevel(Level.Off);
            return _expr;
        }

        private LoggerAppenderExpression SetLevel(Level level)
        {
            _expr.SetLevel(level);
            return new LoggerAppenderExpression(_expr);
        }

        public LoggerAppenderExpression All()
        {
            return SetLevel(Level.All);
        }

        public LoggerAppenderExpression Debug()
        {
            return SetLevel(Level.Debug);
        }

        public LoggerAppenderExpression Info()
        {
            return SetLevel(Level.Info);
        }

        public LoggerAppenderExpression Warn()
        {
            return SetLevel(Level.Warn);
        }

        public LoggerAppenderExpression Error()
        {
            return SetLevel(Level.Error);
        }

        public LoggerAppenderExpression Fatal()
        {
            return SetLevel(Level.Fatal);
        }
    }
}