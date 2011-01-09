using System;
using System.Diagnostics;

namespace log4net.intro.Features.Performance
{
    public class PerformanceMonitor : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PerformanceMonitor));
        
        private readonly TimeSpan threshold;
        private readonly Stopwatch watch = Stopwatch.StartNew();

        public PerformanceMonitor(TimeSpan threshold)
        {
            this.threshold = threshold;
        }

        /// <summary>
        /// When the monitor is disposed, we assume the important call is over, and log the duration. If the threshold has
        /// been reached, it's important that we raise this as an issue.
        /// </summary>
        public void Dispose()
        {
            watch.Stop();
            Log.Debug(string.Format("{0} elapsed milliseconds", watch.ElapsedMilliseconds));

            if(DurationIsOverThreshold())
                Log.Warn(string.Format("Duration is over threshold at {0} elapsed milliseconds", watch.ElapsedMilliseconds));
        }

        private bool DurationIsOverThreshold()
        {
            return watch.ElapsedMilliseconds >= threshold.TotalMilliseconds;
        }
    }
}