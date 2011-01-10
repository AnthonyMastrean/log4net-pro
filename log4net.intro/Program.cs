using System;
using Intro.Features;
using log4net;

namespace Intro
{
    /// <summary>
    /// This program is a poor shell for a "client" calling our expensive service. The lifecycle and dependency 
    /// resolution is poor and not to be copied!
    /// </summary>
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static readonly ExpensiveServiceProxyBuilder ProxyBuilder = new ExpensiveServiceProxyBuilder("ACME");

        /// <summary>
        /// Unhandled exceptions, of the variety that will crash the application, will be logged at an error level.
        /// </summary>
        static Program()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                                                              {
                                                                  Log.Error("An unhandled exception occurred. The application is shutting down.", e.ExceptionObject as Exception);
                                                                  Console.ReadLine();
                                                                  Environment.Exit(0);
                                                              };
        }

        public static void Main(params string[] args)
        {
            using (var proxy = ProxyBuilder.Build())
            {
                for (var i = 0; i < 100; i++)
                    proxy.DoSomethingInteresting();
            }

            Console.ReadLine();
        }
    }
}