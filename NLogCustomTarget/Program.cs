using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogCustomTarget
{
    public class Program
    {
        public static void LogMethod(string level, string message)
        {
            Console.WriteLine("l: {0} m: {1}", level, message);
        }
        static void Main(string[] args)
        {
            //MethodCallTarget target = new MethodCallTarget();
            //target.ClassName = typeof(Program).AssemblyQualifiedName;
            //target.MethodName = "LogMethod";
            //target.Parameters.Add(new MethodCallParameter("${level}"));
            //target.Parameters.Add(new MethodCallParameter("${message}"));

            //NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

            //Logger logger = LogManager.GetLogger("Program");
            Logger logger = LogManager.GetCurrentClassLogger();

            //very detailed logs, which may include high-volume information such as protocol payloads.
            //This log level is typically only enabled during development
            logger.Trace("Trace");
            //debugging information, less detailed than trace, typically not enabled in production environment.
            logger.Debug("Debug");
            //information messages, which are normally enabled in production environment
            logger.Info("Info");
            //warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
            logger.Warn("Warn");
            //error messages - most of the time these are Exceptions
            logger.Error("Error");
            //very serious errors!
            logger.Fatal("Fatal");            

            Console.ReadLine();
        }
    }
}
