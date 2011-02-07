using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intro.Contrib.Logger;
using log4net;
using log4net.Appender;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Extension.Filter.Advanced
{
    [TestClass]
    [DeploymentItem(@"Intro.Test\Extension\Filter\Advanced\config.log4net")]
    public class Tests
    {
        private static readonly IExtendedLog Log = ExtendedLogManager.GetLogger(typeof(Tests));
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
        public void Debug_messages_do_not_log()
        {
            Log.Debug("This is a debugging message.");
            Assert.AreEqual(1, Appenders["Default"].GetEvents().Count());
            Assert.AreEqual(0, Appenders["Detail"].GetEvents().Count());
        }

        [TestMethod]
        public void Info_messages_do_not_log()
        {
            Log.Info("This is an informational message.");
            Assert.AreEqual(1, Appenders["Default"].GetEvents().Count());
            Assert.AreEqual(0, Appenders["Detail"].GetEvents().Count());
        }

        [TestMethod]
        public void Can_filter_on_Detail()
        {
            Log.Detail("This is a detail message.");
            Assert.AreEqual(1, Appenders["Default"].GetEvents().Count());
            Assert.AreEqual(1, Appenders["Default"].GetEvents().Count());
        }
    }
}