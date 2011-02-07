using System;
using System.Globalization;
using log4net.Core;
using log4net.Repository;
using log4net.Util;

namespace Intro.Contrib.Logger
{
    public class ExtendedLogImpl : LogImpl, IExtendedLog
    {
        /// <summary>
        /// The fully qualified name of this declaring type not the type of any subclass.
        /// </summary>
        private static readonly Type ThisDeclaringType = typeof(ExtendedLogImpl);

        /// <summary>
        /// The default value for the DETAIL level
        /// </summary>
        private static readonly Level DefaultLevelDetail = new Level(35000, "DETAIL");

        /// <summary>
        /// The current value for the PERFORMANCE level
        /// </summary>
        private Level levelDetail;

        public bool IsDetailEnabled
        {
            get { return Logger.IsEnabledFor(levelDetail); }
        }

        public ExtendedLogImpl(ILogger logger)
            : base(logger)
        {
        }

        public void Detail(object message)
        {
            Logger.Log(ThisDeclaringType, levelDetail, message, null);
        }

        public void Detail(object message, Exception exception)
        {
            Logger.Log(ThisDeclaringType, levelDetail, message, exception);
        }

        public void DetailFormat(string format, params object[] args)
        {
            if (IsDetailEnabled)
                Logger.Log(ThisDeclaringType, levelDetail, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        public void DetailFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (IsDetailEnabled)
                Logger.Log(ThisDeclaringType, levelDetail, new SystemStringFormat(provider, format, args), null);
        }

        /// <summary>
        /// Lookup the current value of the DETAIL level
        /// </summary>
        protected override void ReloadLevels(ILoggerRepository repository)
        {
            base.ReloadLevels(repository);
            levelDetail = repository.LevelMap.LookupWithDefault(DefaultLevelDetail);
        }
    }
}