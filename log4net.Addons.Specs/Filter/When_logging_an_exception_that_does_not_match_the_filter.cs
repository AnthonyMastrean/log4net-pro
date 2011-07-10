using System.Net.Sockets;
using log4net.Addons.Filter;
using log4net.Appender;
using log4net.Config;
using Machine.Specifications;

namespace log4net.Addons.Specs.Filter
{
    [Subject(typeof(ExceptionMessageMatchFilter))]
    public class When_logging_an_exception_that_does_not_match_the_filter
    {
        Establish context = () =>
        {
            BasicConfigurator.Configure(_appender);
            _appender.AddFilter(_filter);
        };

        Because of = () => _log.Error("There was an error.", new SocketException((int)SocketError.VersionNotSupported));

        It should_append_this_event = () => _appender.GetEvents().Length.ShouldEqual(1);

        private static readonly ILog _log = LogManager.GetLogger(typeof(ExceptionMessageMatchFilter));
        private static readonly MemoryAppender _appender = new MemoryAppender();
        private static readonly ExceptionMessageMatchFilter _filter = new ExceptionMessageMatchFilter
        {
            StringToMatch = "An existing connection was forcibly closed by the remote host",
            AcceptOnMatch = false,
        };
    }
}