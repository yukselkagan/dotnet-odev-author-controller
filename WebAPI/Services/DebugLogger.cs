using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class DebugLogger : ILoggerService
    {
        public void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine("[DebugLogger] "+message);
        }
    }
}
