using System;
using Intro.Features;
using log4net;

namespace Intro
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static readonly ExpensiveServiceProxyBuilder ProxyBuilder = new ExpensiveServiceProxyBuilder("ACME");

        static Program()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                                                              {
                                                                  Log.Error("An unhandled exception occurred. The application is shutting down.", e.ExceptionObject as Exception);
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