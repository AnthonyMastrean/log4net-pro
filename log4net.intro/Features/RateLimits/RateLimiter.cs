using System;

namespace Intro.Features.RateLimits
{
    public class RateLimiter
    {
        private readonly int allowedCalls;
        private readonly TimeSpan duration;
        private DateTime lastStartTime;
        private int actualCalls;

        public RateLimiter(int allowedCalls, TimeSpan duration)
        {
            this.allowedCalls = allowedCalls;
            this.duration = duration;
            Reset();
        }

        public bool IsOverThreshold()
        {
            return actualCalls > allowedCalls;
        }

        public void Increment()
        {
            if (IsCurrentDurationOver())
                Reset();

            IncrementActualCalls();
        }

        private bool IsCurrentDurationOver()
        {
            var now = DateTime.UtcNow;
            var interval = now - lastStartTime;
            return interval > duration;
        }

        private void Reset()
        {
            ResetLastStartTime();
            ResetActualCalls();
        }

        private void ResetLastStartTime()
        {
            lastStartTime = DateTime.UtcNow;
        }

        private void ResetActualCalls()
        {
            actualCalls = 0;
        }

        private void IncrementActualCalls()
        {
            actualCalls++;
        }
    }
}