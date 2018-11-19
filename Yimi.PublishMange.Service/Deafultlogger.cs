using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Service
{
    public class Deafultlogger : Yimi.PublishManage.Core.ILogger
    {

        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <param name="customer">The customer to associate log record with</param>
        /// <returns>A log item</returns>
        public void Writelog(LogLevel logLevel, string msg)
        {
            if(logLevel == LogLevel.Information)
            {
                logger.Info(msg);
            }
            else if(logLevel == LogLevel.Warning)
            {
                logger.Warn(msg);
            }
            else if(logLevel == LogLevel.Error)
            {
                logger.Error(msg);
            }
            else if(logLevel == LogLevel.Debug)
            {
                logger.Debug(msg);
            }
            else if(logLevel == LogLevel.Trace)
            {
                logger.Debug(msg);
            }
            else if (logLevel == LogLevel.Critical)
            {
                logger.Fatal(msg);
            }

        }


        public void Writelog(string msg)
        {
            logger.Info(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void WriteError(Exception ex)
        {
            logger.Error(null, ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void WriteError(string message, Exception ex)
        {
            logger.Error(message, ex);
        }
    }
}
