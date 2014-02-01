using Intro.Contrib.Logger;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test.Extension.CallSite
{
    [TestClass]
    public class Tests
    {
        private static readonly MemoryAppender Appender = new MemoryAppender
        {
            Layout = new PatternLayout("[%type{1}.%method] %message%newline")
        };

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BasicConfigurator.Configure(Appender);
        }

        private readonly IExtendedLog log = ExtendedLogManager.GetLogger(typeof(Tests));

        [TestInitialize]
        public void TestInitialize()
        {
            log.Info("hello");
        }

        [TestMethod]
        public void Callsite_is_correct()
        {
            Assert.AreEqual("Intro.Test.Extension.CallSite.Tests", Appender.GetEvents()[0].LocationInformation.ClassName);
            Assert.AreEqual("TestInitialize", Appender.GetEvents()[0].LocationInformation.MethodName);
        }
    }
}