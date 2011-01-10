using log4net;

namespace Intro.Concepts
{
    public class ClientContext
    {
        public string Name { get; private set; }

        /// <summary>
        /// The creation of a Client Context is going to push the user's name to the log4net logical
        /// thread context, so that it can be used in the logs to differentiate our customers.
        /// </summary>
        /// <param name="name"></param>
        public ClientContext(string name)
        {
            Name = name;
            LogicalThreadContext.Properties["Client"] = Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}