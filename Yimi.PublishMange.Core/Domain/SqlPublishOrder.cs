using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class SqlPublishOrder : BaseEntity
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsPublished { get; set; }

        public bool IsRunning { get; set; }

        public string Result { get; set; }

        public string Name { get; set; }

        public SqlPublishOrderApprovalStatues Approvalstatues { get; set; }

        public string SqlText { get; set; }

        public SqlPublishEnvironment SqlPublishEnvironment { get; set; }

        public DateTime Publishtime { get; set; }

        public string SqlProviderId { get; set; }

        public virtual YimiSqlProvider YimiSqlProvider { get; set; }


    }
}
