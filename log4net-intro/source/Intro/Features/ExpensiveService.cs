using System;
using System.Threading;
using Intro.Features.Performance;
using Intro.Features.RateLimit;
using log4net;

namespace Intro.Features
{
    /// <summary>
    /// We have created and hosted some expensive business service. Our customers are calling this service to do important
    /// things. This is the service that differentiates us from our competitors.
    /// </summary>
    public class ExpensiveService : IDisposable
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(ExpensiveService));
        private readonly RateLimiter limiter;
        private readonly Random random = new Random();

        /// <summary>
        /// We want to know every time an expensive service is created so that we can make projections and track usage 
        /// of the service. Maybe we're thinking of changing the payment model from subscription to per-use and we need
        /// data to make the right decision.
        /// </summary>
        public ExpensiveService(RateLimiter limiter)
        {
            this.limiter = limiter;
            Log.Info("Expensive service created");
        }

        /// <summary>
        /// We want to keep a close eye on the interesting call. Maybe the length of the service call is related to its 
        /// expensiveness and we want to keep an eye on things. We want to know when the duration exceeds some critical 
        /// threshold.
        /// </summary>
        public void DoSomethingInteresting()
        {
            limiter.Increment();
            using (new PerformanceMonitor(threshold: TimeSpan.FromSeconds(3)))
            {
                #region ... doing something interesting on our expensive service...
                Thread.Sleep(random.Next(1 * 1000, 5 * 1000));
                #endregion
            }
        }

        public void Dispose()
        {
        }
    }
}