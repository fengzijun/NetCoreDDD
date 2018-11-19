using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Framework.UI
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public int ErrorCode { get; set; }
    }


    public abstract class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
