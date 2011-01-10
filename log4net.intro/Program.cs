using Intro.Features;

namespace Intro
{
    /// <summary>
    /// log4net @ [http://logging.apache.org/log4net/index.html]
    /// </summary>
    public class Program
    {
        private static readonly ExpensiveServiceProxyBuilder ProxyBuilder = new ExpensiveServiceProxyBuilder("ACME");

        public static void Main(params string[] args)
        {
            using (var proxy = ProxyBuilder.Build())
            {
                proxy.DoSomethingInteresting();
            }
        }
    }
}