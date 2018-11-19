using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Core
{
    public interface ILogger
    {
        
        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <param name="customer">The customer to associate log record with</param>
        /// <returns>A log item</returns>
        void Writelog(Microsoft.Extensions.Logging.LogLevel logLevel, string msg);


        /// <summary>
        /// /
        /// </summary>
        /// <param name="msg"></param>
        void Writelog(string msg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        void WriteError(Exception ex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        void WriteError(string message, Exception ex);
    }
}
