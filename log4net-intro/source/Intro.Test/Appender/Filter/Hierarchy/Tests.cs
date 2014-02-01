using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Appender.Filter.Hierarchy
{
    [TestClass]
    [DeploymentItem(@"Intro.Test\Appender\Filter\Hierarchy\config.log4net")]
    public class Tests
    {
        private static readonly ILog LoggerLearn = LogManager.GetLogger("Intro");
        private static readonly ILog LoggerAppenders = LogManager.GetLogger("Intro.Appenders");
        private static readonly ILog LoggerIgnoreMe = LogManager.GetLogger("Intro.Appenders.IgnoreMe");
        private static readonly ILog LoggerImportant = LogManager.GetLogger("Intro.Appenders.Important");

        private static readonly Dictionary<string, MemoryAppender> Appenders = new Dictionary<string, MemoryAppender>();

        static Tests()
        {
            XmlConfigurator.Configure(new FileInfo("config.log4net"));
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            foreach (var appender in LogManager.GetRepository().GetAppenders().Cast<MemoryAppender>())
                Appenders.Add(appender.Name, appender);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            foreach (var appender in Appenders.Values)
                appender.Clear();
        }

        [TestMethod]
        public void Appenders_logger_cannot_log_below_info()
        {
            LoggerAppenders.Debug("This message will not log.");
            Assert.AreEqual(0, Appenders["Default"].GetEvents().Count());
        }

        [TestMethod]
        public void Appenders_logger_can_log_above_info()
        {
            LoggerAppenders.Info("This message is logged.");
            LoggerAppenders.Warn("So is this one.");
            Assert.AreEqual(2, Appenders["Default"].GetEvents().Count());
        }

        [TestMethod]
        public void Ignored_logger_cannot_log_at_all()
        {
            LoggerIgnoreMe.Info("Hello!");
            LoggerIgnoreMe.Warn("Hello?");
            LoggerIgnoreMe.Fatal("Help!");
            Assert.AreEqual(0, Appenders["Default"].GetEvents().Count());
        }

        [TestMethod]
        public void Important_logger_writes_to_both_appenders_at_fatal()
        {
            LoggerImportant.Fatal("This is an important message");
            Assert.AreEqual(1, Appenders["Default"].GetEvents().Count());
            Assert.AreEqual(1, Appenders["Important"].GetEvents().Count());
        }
    }
}