using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Core
{
    public interface IUserAgentHelper
    {
        /// <summary>
        /// Get a value indicating whether the request is made by search engine (web crawler)
        /// </summary>
        /// <returns>Result</returns>
        bool IsSearchEngine();
    }
}
