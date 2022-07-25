using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILoggerManager
    {
        void LogDebug(string message);
        void LogWarn(string message);
        void LogInfo(string message);
        void LogError(string message);
    }
}
