using System.Linq;
using Intro.Contrib.Logger;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Extension.Filter
{
    [TestClass]
    public class Tests
    {
        private static readonly MemoryAppender Appender = new MemoryAppender();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Appender.AddFilter(new LevelMatchFilter { LevelToMatch = new Level(35000, "DETAIL") });
            Appender.AddFilter(new DenyAllFilter());

            BasicConfigurator.Configure(Appender);
        }

        private readonly IExtendedLog log = ExtendedLogManager.GetLogger(typeof(Extension.Tests));

        [TestInitialize]
        public void TestInitialize()
        {
            log.Debug("This level is too low.");
            log.Info("This level is too high.");
            log.Detail("This level is just right.");
        }

        [TestMethod]
        public void Can_filter_on_Detail()
        {
            Assert.AreEqual(1, Appender.GetEvents().Count());
        }
    }
}