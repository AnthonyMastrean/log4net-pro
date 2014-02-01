using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace Intro.Contrib.Appender
{
    public class MessageBoxAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            MessageBox.Show(loggingEvent.RenderedMessage, loggingEvent.Level.DisplayName);
        }
    }
}