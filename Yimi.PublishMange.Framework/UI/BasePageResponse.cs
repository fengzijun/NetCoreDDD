using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Framework.UI
{
    public abstract class BasePageResponse : BaseResponse
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }
    }

    public abstract class BasePageResponse<T> : BasePageResponse
    {
        T Data { get; set; }
    }
}
