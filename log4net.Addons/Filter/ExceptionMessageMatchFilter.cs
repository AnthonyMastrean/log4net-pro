using System;
using log4net.Core;
using log4net.Filter;

namespace log4net.Addons.Filter
{
    public class ExceptionMessageMatchFilter : StringMatchFilter
    {
        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            if (loggingEvent == null)
                throw new ArgumentNullException("loggingEvent");

            if (loggingEvent.ExceptionObject == null)
                return FilterDecision.Neutral;

            var exceptionMessage = loggingEvent.GetExceptionString();

            if (m_regexToMatch != null)
            {
                if (!m_regexToMatch.Match(exceptionMessage).Success)
                    return FilterDecision.Neutral;

                return m_acceptOnMatch ? FilterDecision.Accept : FilterDecision.Deny;
            }

            if (m_stringToMatch == null || exceptionMessage.IndexOf(m_stringToMatch) == -1)
            {
                return FilterDecision.Neutral;
            }

            return m_acceptOnMatch ? FilterDecision.Accept : FilterDecision.Deny;
        }
    }
}