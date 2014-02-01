using System.Threading;
using log4net.Appender;
using log4net.Core;

namespace Intro.Contrib.Appender
{
    /// <summary>
    /// An asynchronous appender for log4net that forwards to any appender.
    /// </summary>
    /// <devdoc>
    /// This isn't as straightforward as it seems..
    /// 
    ///     1. To be based on the ForwardingAppender, async needs to make sense for every appender.
    ///        The ConsoleAppender, MemoryAppender, and others just don't make sense with async.
    ///        [http://www.l4ndash.com/Log4NetMailArchive/tabid/70/forumid/1/postid/15068/view/topic/Default.aspx]
    ///        
    ///     2. Threads are heavy-weight for just running appenders. IO completion ports should be 
    ///        used, but they're hard! And they may not make sense for every appender (MemoryAppender, 
    ///        BufferedForwardingAppender).
    ///        [http://marcgravell.blogspot.com/2009/02/async-without-pain.html]
    ///        
    ///     3. An easier solution would be to send logging events to a shared resource that manages
    ///        calling log4net on a background thread.
    ///        [http://www.mail-archive.com/log4net-user@logging.apache.org/msg02168.html]
    /// </devdoc>
    public class AsyncForwardingAppender : ForwardingAppender
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            ThreadPool.QueueUserWorkItem(o => Append(loggingEvent));
        }

        protected override void Append(LoggingEvent[] loggingEvents)
        {
            ThreadPool.QueueUserWorkItem(o => Append(loggingEvents));
        }
    }
}