using System;
using log4net;
using log4net.Appender;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.ExceptionFormat
{
    [TestClass]
    public class Tests
    {
        private static readonly MemoryAppender Appender = new MemoryAppender();
        private static readonly ILog Log = LogManager.GetLogger(typeof(Tests));

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BasicConfigurator.Configure(Appender);
        }

        [TestMethod]
        public void StackTraceIsFormatted()
        {
            try
            {
                new WrappingType();
            }
            catch (Exception e)
            {
                Log.Error("Caught an exception.", e);
            }

            Assert.Inconclusive(Appender.GetEvents()[0].GetExceptionString());
        }
    }
}