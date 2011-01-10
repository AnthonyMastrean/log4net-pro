using System;
using Intro.Concepts;
using Intro.Features.RateLimits;

namespace Intro.Features
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