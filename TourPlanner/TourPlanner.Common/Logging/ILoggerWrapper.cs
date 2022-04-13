using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Common.Logging
{
    public interface ILoggerWrapper
    {
        void Info(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Warn(string message);
    }
}
