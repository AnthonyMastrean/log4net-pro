using log4net.Addons.Injection;
using log4net.Appender;
using log4net.Config;
using Machine.Specifications;

namespace log4net.Addons.Specs.Injection
{
    [Subject(typeof(Logger))]
    public class When_using_an_injectable_logger
    {
        Establish context = () =>
        {
            BasicConfigurator.Configure(_appender);
        };

        Because of = () => _logger.For<Logger>().Info("hello");

        It should_log_to_the_configured_appender = () => _appender.GetEvents().Length.ShouldEqual(1);
        It should_log_from_the_right_type = () => _appender.GetEvents()[0].LoggerName.ShouldEqual("log4net.Addons.Injection.Logger");

        private static Logger _logger = new Logger();
        private static MemoryAppender _appender = new MemoryAppender();
    }
}