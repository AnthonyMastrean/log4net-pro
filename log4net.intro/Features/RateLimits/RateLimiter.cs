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

        public bool IsOverThreshold()
        {
            return actual > limit;
        }

        public void Increment()
        {
            actual++;
        }

        public void Reset()
        {
            actual = 0;
        }
    }
}