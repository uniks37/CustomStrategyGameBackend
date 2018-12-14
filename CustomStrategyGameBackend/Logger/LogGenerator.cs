using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomStrategyGameBackend.Enums;

namespace CustomStrategyGameBackend.Logger
{
    public class Log
    {
        private string msg;
        private int status_code;
        private bool isException;
        private TimeSpan timespan;

        public bool IsException { get => isException; set => isException = value; }
        public string Msg { get => msg; set => msg = value; }
        public int Status_code { get => status_code; set => status_code = value; }
        public TimeSpan Timespan { get => timespan; set => timespan = value; }
    }

    public static class LogGenerator
    {
        private static List<Log> logManager = new List<Log>();
        public static void GenerateLog(Log log)
        {
            logManager.Add(log);
        }
    }
}