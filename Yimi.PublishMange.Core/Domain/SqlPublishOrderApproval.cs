using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class SqlPublishOrderApproval : BaseEntity 
    {
        public string OrderId { get; set; }

        public virtual SqlPublishOrder SqlPublishOrder { get; set; }

        public string LeaderId { get; set; }

        public virtual User Leader { get; set; }

        public SqlPublishOrderApprovalStatues Approvalstatues { get; set; }


    }
}
