using System;
using System.Threading;

namespace log4net.intro
{
    /// <summary>
    /// We have created and hosted some expensive business service. Our customers are calling this service to do important
    /// things. This is the service that differentiates us from our competitors.
    /// </summary>
    public class ExpensiveService
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(ExpensiveService));

        /// <summary>
        /// We want to know every time an expensive service is created so that we can make projections and track usage 
        /// of the service. Maybe we're thinking of changing the payment model from subscription to per-use and we need
        /// data to make the right decision.
        /// </summary>
        public ExpensiveService()
        {
            Log.Info("Expensive service created");
        }

        /// <summary>
        /// We want to keep a close eye on the interesting call. Maybe the length of the service call is related to its 
        /// expensiveness and we want to keep an eye on things. We want to know when the duration exceeds some critical 
        /// threshold.
        /// </summary>
        public void DoSomethingInteresting()
        {
            using (new PerformanceMonitor(threshold: TimeSpan.FromSeconds(5)))
            {
                // ... doing something interesting on our expensive service...
                Thread.Sleep(700);
            }
        }
    }
}