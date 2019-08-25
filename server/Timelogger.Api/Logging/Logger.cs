using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api
{
    /// <summary>
    /// Logger class to handle the erro loging methods
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Log instance (log4net)
        /// </summary>
        private static ILog log = LogManager.GetLogger(typeof(Logger));

        /// <summary>
        /// Nethod to log the error message
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(Exception message)
        {
            log.Error(message);
        }

        /// <summary>
        /// Nethod to log the error message
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            log.Error(message);
        }
    }
}
