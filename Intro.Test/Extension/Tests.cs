using System.Linq;
using Intro.Contrib.Logger;
using log4net.Appender;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Extension
{
    [TestClass]
    public class Tests
    {
        private static readonly MemoryAppender Appender = new MemoryAppender();
        private static readonly IExtendedLog Log = ExtendedLogManager.GetLogger(typeof(Tests));

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BasicConfigurator.Configure(Appender);
        }

        [TestMethod]
        public void Detail_Level_is_enabled()
        {
            Assert.IsTrue(Log.IsDetailEnabled);
        }

        [TestMethod]
        public void Detail_Level_can_log()
        {
            Log.Detail("Entered Detail_Level_can_log");
            var loggingEvent = Appender.GetEvents().ToList().Last();
            Assert.AreEqual("DETAIL", loggingEvent.Level.Name);
            Assert.AreEqual(typeof(Tests).FullName, loggingEvent.LoggerName);
            Assert.AreEqual("Entered Detail_Level_can_log", loggingEvent.RenderedMessage);
        }
    }
}