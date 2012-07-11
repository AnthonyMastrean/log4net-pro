# Exception Message Match Filter
This is an appender filter that works on the _exception message_ of a logging event. If you need to [filter][l4n-filter] log messages that contain the default exception, message, & stacktrace format, you might want this filter.

    ERROR - Unexpected exception in SocketThreadWorker System.Net.Sockets.SocketException:
    An existing connection was forcibly closed by the remote host at System.Net.Sockets.Socket.EndReceive(IAsyncResult asyncResult)

You would add the reference to this library and then add the filter to your appender like this

    <filter type="log4net.ExceptionMessageMatch.ExceptionMessageMatchFilter, log4net.ExceptionMessageMatch">
        <stringToMatch value="An existing connection was forcibly closed by the remote host" />
        <acceptOnMatch value="false" />
    </filter>
    
There's a deeper explanation on this [StackOverflow question][so].

 [so]: http://stackoverflow.com/questions/5894291
 [l4n-filter]: http://logging.apache.org/log4net/release/manual/configuration.html#filters