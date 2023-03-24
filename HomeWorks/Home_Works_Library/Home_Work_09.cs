using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library
{
    public class Home_Work_09
    {
        public static void Run()
        {
            Log log = new ApplicationLog();
            log.LogMessage = "This is log message";
            log.LogID = 111;

            log._registerLog = new MediaPlayerLogger();
            log.LogAppMessgae();

            log._registerLog = new DocumentReaderLoggger();
            log.LogAppMessgae();

            log._registerLog = new BrowserLogger();
            log.LogAppMessgae();

            Console.ReadLine();
        }
    }

    // 'Implementor' interface
    public interface IRegisterLog
    {
        void LogReport(string LogMessage, int LogID);
    }

    // ConcreteImplementor class
    class MediaPlayerLogger : IRegisterLog
    {
        public void LogReport(string LogMessage, int LogID)
        {
            Console.WriteLine("Media Player Logger: \n-Log Message: {0}; LogID: {1}\n", LogMessage, LogID);
        }
    }

    // ConcreteImplementor class
    class DocumentReaderLoggger : IRegisterLog
    {
        public void LogReport(string LogMessage, int LogID)
        {
            Console.WriteLine("Document Reader Logger: \n-Log Message: {0}; LogID: {1}\n", LogMessage, LogID);
        }
    }

    // ConcreteImplementor class
    class BrowserLogger : IRegisterLog
    {
        public void LogReport(string LogMessage, int LogID)
        {
            Console.WriteLine("Browser Logger: \n-Log Message: {0}; LogID: {1}\n", LogMessage, LogID);
        }
    }

    // 'Abstraction' abstract class
    abstract class Log
    {
        public IRegisterLog _registerLog;
        public string LogMessage;
        public int LogID;

        public abstract void LogAppMessgae();
    }


    // 'RefinedAbstraction' class
    class ApplicationLog : Log
    {
        public override void LogAppMessgae()
        {
            _registerLog.LogReport(LogMessage, LogID);
        }
    }
}
