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
                throw new RateLimitExceededException();
        }

        public void Reset()
        {
            actual = 0;
        }
    }
}