using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Appender.Filter.Level
{
    [TestClass]
    [DeploymentItem(@"Intro.Test\Appender\Filter\Level\config.log4net")]
    public class Tests
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Tests));
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
        public void Only_debug_appender_has_this_statement()
        {
            var message = "Entered method Test()";
            Log.Debug(message);
            
            Assert.AreEqual(message, Appenders["Debugging"].GetEvents()[0].MessageObject);

            Assert.AreEqual(1, Appenders["Debugging"].GetEvents().Count());
            Assert.AreEqual(0, Appenders["Lifecycle"].GetEvents().Count());
            Assert.AreEqual(0, Appenders["Critical"].GetEvents().Count());
        }

        [TestMethod]
        public void Only_lifecycle_appender_has_these_statements()
        {
            Log.Info("Starting Test");
            Log.Warn("Warning! Warning! Warning!");
            Log.Error("Test failed");
            Assert.AreEqual(0, Appenders["Debugging"].GetEvents().Count());
            Assert.AreEqual(3, Appenders["Lifecycle"].GetEvents().Count());
            Assert.AreEqual(0, Appenders["Critical"].GetEvents().Count());
        }

        [TestMethod]
        public void Only_critical_appender_has_this_statement()
        {
            Log.Fatal(".NET is crashing, ruuun!");
            Assert.AreEqual(0, Appenders["Debugging"].GetEvents().Count());
            Assert.AreEqual(0, Appenders["Lifecycle"].GetEvents().Count());
            Assert.AreEqual(1, Appenders["Critical"].GetEvents().Count());
        }
    }
}