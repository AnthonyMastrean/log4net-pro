using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intro.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Loggers_by_name_are_same_ref()
        {
            var log1 = LogManager.GetLogger("Intro.Test.Tests");
            var log2 = LogManager.GetLogger("Intro.Test.Tests");
            Assert.AreSame(log1, log2, log1.Logger.Name);
        }

        [TestMethod]
        public void Logger_by_type_is_same_as_by_string()
        {
            var log1 = LogManager.GetLogger(typeof (Tests));
            var log2 = LogManager.GetLogger("Intro.Test.Tests");
            Assert.AreSame(log1, log2, log1.Logger.Name);
        }

        [TestMethod]
        public void Loggers_by_type_are_the_same_ref()
        {
            var log1 = LogManager.GetLogger(typeof (Tests));
            var log2 = LogManager.GetLogger(typeof (Tests));
            Assert.AreSame(log1, log2, log1.Logger.Name);
        }
    }
}