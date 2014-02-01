using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Appender.Filter.Logger
{
    /// <summary>
    /// Examples of negative filtering by Logger [http://www.claassen.net/geek/blog/2009/06/log4net-filtering-by-logger.html].
    /// </summary>
    [TestClass]
    [DeploymentItem(@"Intro.Test\Appender\Filter\Logger\config.log4net")]
    public class Tests
    {
        private static readonly ILog LoggerA = LogManager.GetLogger("Tests.Appenders.A");
        private static readonly ILog LoggerB = LogManager.GetLogger("Tests.Appenders.B");
        
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

        [TestMethod]
        public void Appenders_capture_correct_events()
        {
            SayHello();
            
            Assert.AreEqual(2, Appenders["Parent"].GetEvents().Count());
            Assert.AreEqual("Logger A says Hello!", Appenders["Parent"].GetEvents()[0].MessageObject);
            Assert.AreEqual("Logger B says Hello!", Appenders["Parent"].GetEvents()[1].MessageObject);

            Assert.AreEqual(1, Appenders["A"].GetEvents().Count());
            Assert.AreEqual("Logger A says Hello!", Appenders["A"].GetEvents()[0].MessageObject);

            Assert.AreEqual(1, Appenders["B"].GetEvents().Count());
            Assert.AreEqual("Logger B says Hello!", Appenders["B"].GetEvents()[0].MessageObject);
        }

        private void SayHello()
        {
            LoggerA.Info("Logger A says Hello!");
            LoggerB.Info("Logger B says Hello!");
        }
    }
}