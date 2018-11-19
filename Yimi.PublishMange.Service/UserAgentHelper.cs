using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Service
{
    public class UserAgentHelper : IUserAgentHelper
    {
        public bool IsSearchEngine()
        {
            return false;
        }
    }
}
