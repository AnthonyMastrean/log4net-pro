using System;

namespace Intro.Features.RateLimit
{
    public class RateLimitExceededException : Exception
    {
        public RateLimitExceededException()
        {
        }

        public RateLimitExceededException(string message)
            : base(message)
        {
        }

        public RateLimitExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}