using log4net.Addons.Config;
using log4net.Core;
using Machine.Specifications;

namespace log4net.Addons.Specs.Config
{
    [Subject(typeof(FluentConfigurator))]
    public class When_configuring_a_default_logger_with_no_appenders
    {
        Because of = () => _log = new FluentConfigurator()
                                      .Logger()
                                      .Off()
                                      .Configure();

        It should_not_be_null = () => _log.ShouldNotBeNull();
        It should_have_the_current_assembly_name = () => _log.Logger.Name.ShouldEqual("IsolatedAppDomainHost: log4net.Addons.Specs");
        It should_be_off = () => _log.GetLogger().Level.ShouldEqual(Level.Off);

        private static ILog _log;
    }
}