using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.IO;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;
using LogForU.Core.Utils;
using LogForU.CustomLayouts;

var xmlLayout = new XmlLayout();
var consoleAppender = new ConsoleAppender(xmlLayout);

var file = new LogFile("test", "xml", Directory.GetCurrentDirectory());
var fileAppender = new FileAppender(xmlLayout, file);

var logger = new Logger(consoleAppender, fileAppender);

logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
