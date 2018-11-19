using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Domain;

namespace Yimi.PublishManage.Service.IService
{
    public interface ISqlPublishService
    {
        IPagedList<SqlPublishOrder> GetSQLPublishOrders(string userid = "", SqlPublishOrderApprovalStatues? statues = SqlPublishOrderApprovalStatues.Audit, int pageindex = 0, int pagesize = int.MaxValue);

        SqlPublishOrder AddSQLPublishOrder(SqlPublishOrder sqlPublishOrder);

        void UpdateSQLPublishOrder(SqlPublishOrder sqlPublishOrder);

        SqlPublishOrder GetSQLPublishOrder(string id);



        IPagedList<YimiSqlProvider> GetYimiSqlProviders(string Name, int pageindex = 0, int pagesize = int.MaxValue);

        YimiSqlProvider AddYimiSqlProvider(YimiSqlProvider yimiSqlProvider);

        void UpdateYimiSqlProvider(YimiSqlProvider yimiSqlProvider);

        YimiSqlProvider GetYimiSqlProvider(string id);


        IPagedList<SqlPublishOrderApproval> GetSqlPublishOrderApprovals(string userid, int pageindex = 0, int pagesize = int.MaxValue);

        SqlPublishOrderApproval AddSqlPublishOrderApproval(SqlPublishOrderApproval sqlPublishOrderApproval);

        void UpdateSqlPublishOrderApprovalr(SqlPublishOrderApproval sqlPublishOrderApproval);


        SqlPublishOrderApproval GetSqlPublishOrderApproval(string id);

        SqlPublishOrderApproval GetSqlPublishOrderApprovalByOrderId(string orderid);

        Tuple<bool, string> Run(string id);
    }
}
