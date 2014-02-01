using log4net.Addons.Config;
using log4net.Appender;
using log4net.Core;
using Machine.Specifications;

namespace log4net.Addons.Specs.Config
{
    [Subject(typeof(FluentConfigurator))]
    public class When_configuring_a_logger_with_custom_name_and_level
    {
        Because of = () => _log = new FluentConfigurator()
                                      .Logger("debugger")
                                      .Debug()
                                      .AddAppender(new MemoryAppender())
                                      .Configure();

        It should_not_be_null = () => _log.ShouldNotBeNull();
        It should_have_the_given_name = () => _log.Logger.Name.ShouldEqual("debugger");
        It should_be_configured_for_the_debug_level = () => _log.GetLogger().Level.ShouldEqual(Level.Debug);
        It should_have_a_memory_appender_attached = () => _log.GetLogger().Appenders[0].ShouldBeOfType<MemoryAppender>();

        private static ILog _log;
    }
}