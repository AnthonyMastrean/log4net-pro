# Fluent Configurator
A fluent configurator for programmatically creating, configuring, and accessing loggers at runtime.

# Exception Message Match Filter
An appender filter that works on the exception message of a logging event.

# ReSharper Live Templates
I'm using ReSharper live templates to assist with the noisy reflection and long type names.

configurator

    log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));

logger

    private static readonly ILog Log = LogManager.GetLogger(typeof($CLASSNAME$));