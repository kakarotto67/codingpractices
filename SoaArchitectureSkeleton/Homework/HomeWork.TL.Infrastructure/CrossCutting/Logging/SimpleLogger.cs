using System;
using System.Diagnostics;
using HomeWork.TL.Core.Shared.Interfaces.InfrastructureModule.CrossCutting.Logging;

namespace HomeWork.TL.Infrastructure.CrossCutting.Logging
{
    public class SimpleLogger : ILogger
    {
        private readonly String AppName = "HomeWork.TL App";

        public void LogError(String message)
        {
            EventLog.WriteEntry(AppName, message, EventLogEntryType.Error);
        }

        public void LogMessage(String message)
        {
            EventLog.WriteEntry(AppName, message, EventLogEntryType.Information);
        }
    }
}
