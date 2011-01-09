using System;
using log4net.intro.Concepts;
using log4net.intro.Features.RateLimits;

namespace log4net.intro.Features
{
    public class ExpensiveServiceProxyBuilder
    {
        private readonly ClientContext context;

        public ExpensiveServiceProxyBuilder(string name)
        {
            context = new ClientContext(name);
        }

        public ExpensiveService Build()
        {
            return new ExpensiveService(new RateLimiter(10, TimeSpan.FromMinutes(1)));
        }
    }
}