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
            MethodCallTarget target = new MethodCallTarget();
            target.ClassName = typeof(Program).AssemblyQualifiedName;
            target.MethodName = "LogMethod";
            target.Parameters.Add(new MethodCallParameter("${level}"));
            target.Parameters.Add(new MethodCallParameter("${message}"));

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

            Logger logger = LogManager.GetLogger("Program");
            logger.Debug("log message");
            logger.Error("error message");

            Console.ReadLine();
        }
    }
}
