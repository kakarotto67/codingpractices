using System;

namespace HomeWork.TL.Core.Shared.Interfaces.InfrastructureModule.CrossCutting.Logging
{
    public interface ILogger
    {
        void LogError(String message);
        void LogMessage(String message);
    }
}
