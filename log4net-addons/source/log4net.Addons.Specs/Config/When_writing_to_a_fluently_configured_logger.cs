using log4net.Addons.Config;
using log4net.Appender;
using log4net.Config;
using Machine.Specifications;

namespace log4net.Addons.Specs.Config
{
    [Subject(typeof(FluentConfigurator))]
    public class When_writing_to_a_fluently_configured_logger
    {
        Establish context = () =>
        {
            BasicConfigurator.Configure();

            _log = new FluentConfigurator()
                .Logger()
                .All()
                .AddAppender(_appender)
                .Configure();
        };

        Because of = () => _log.Info("INFO");

        It should_log_one_message_to_the_appender = () => _appender.GetEvents().Length.ShouldEqual(1);

        private static ILog _log;
        private static readonly MemoryAppender _appender = new MemoryAppender();
    }
}