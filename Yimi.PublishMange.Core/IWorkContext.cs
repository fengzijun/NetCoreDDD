using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core.Domain;

namespace Yimi.PublishManage.Core
{
    public interface IWorkContext
    {
        User CurrentUser { get; set; }

    }
}
