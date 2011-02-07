using System;
using log4net;

namespace Intro.Contrib.Logger
{
    public interface IExtendedLog : ILog
    {
        bool IsDetailEnabled { get; }

        void Detail(object message);
        void Detail(object message, Exception exception);
        void DetailFormat(string format, params object[] args);
        void DetailFormat(IFormatProvider provider, string format, params object[] args);
    }
}