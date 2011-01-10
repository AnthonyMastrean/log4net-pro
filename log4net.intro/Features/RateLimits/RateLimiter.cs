namespace Intro.Features.RateLimits
{
    public class RateLimiter
    {
        private readonly int limit;
        private int actual;

        public RateLimiter(int limit)
        {
            this.limit = limit;
            Reset();
        }

        private void IncrementActual()
        {
            actual++;
        }

        private bool IsOverThreshold()
        {
            return actual > limit;
        }

        public void Increment()
        {
            IncrementActual();
            if(IsOverThreshold())
                throw new RateLimitExceededException(string.Format("The API call rate limit was reached at {0} calls.", limit));
        }

        public void Reset()
        {
            actual = 0;
        }
    }
}