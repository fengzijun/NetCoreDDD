using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Core.Domain
{
    public enum SqlPublishOrderApprovalStatues
    {
        Success, // 审核成功
        Failed, // 审核失败
        Audit, // 审核中
        None,
    }
}
