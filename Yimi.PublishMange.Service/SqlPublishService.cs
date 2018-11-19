using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Data;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Service.IService;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Data.SqlClient;

namespace Yimi.PublishManage.Service
{
    public class SqlPublishService : ISqlPublishService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<SqlPublishOrder> _sqlpublishorderRepository;
        private readonly IRepository<SqlPublishOrderApproval> _sqlpublishorderapprovalRepository;
        private readonly IRepository<YimiSqlProvider> _yimisqlproviderRepository;
        public SqlPublishService(IRepository<User> userRepository, IRepository<SqlPublishOrder> sqlpublishorderRepository, IRepository<SqlPublishOrderApproval> sqlpublishorderapprovalRepository, IRepository<YimiSqlProvider> yimisqlproviderRepository)
        {
            _userRepository = userRepository;
            _sqlpublishorderRepository = sqlpublishorderRepository;
            _sqlpublishorderapprovalRepository = sqlpublishorderapprovalRepository;
            _yimisqlproviderRepository = yimisqlproviderRepository;
        }

        public IPagedList<SqlPublishOrder> GetSQLPublishOrders(string userid = "", SqlPublishOrderApprovalStatues? statues = SqlPublishOrderApprovalStatues.Audit , int pageindex = 0, int pagesize = int.MaxValue)
        {
            var query = _sqlpublishorderRepository.Table;
            if (!string.IsNullOrEmpty(userid))
                query = query.Where(s => s.UserId == userid);
            if (statues.HasValue)
                query = query.Where(s => s.Approvalstatues == statues);

            query = query.Where(s => s.Deleted == false);

            query = query.OrderByDescending(s => s.Createtime);

            return new PagedList<SqlPublishOrder>(query, pageindex, pagesize);
        }

        public SqlPublishOrder AddSQLPublishOrder(SqlPublishOrder sqlPublishOrder)
        {
            sqlPublishOrder.Createtime = DateTime.Now;
            sqlPublishOrder.Updatetime = DateTime.Now;
            sqlPublishOrder.Deleted = false;
          

            return _sqlpublishorderRepository.Insert(sqlPublishOrder);
        }

        public void UpdateSQLPublishOrder(SqlPublishOrder sqlPublishOrder)
        {
            _sqlpublishorderRepository.Update(sqlPublishOrder);
        }

        public SqlPublishOrder GetSQLPublishOrder(string id)
        {
            return _sqlpublishorderRepository.Table.FirstOrDefault(s => s.Id == id);
        }



        public IPagedList<YimiSqlProvider> GetYimiSqlProviders(string name, int pageindex = 0, int pagesize = int.MaxValue)
        {
            var query = _yimisqlproviderRepository.Table;
            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name == name);

            query = query.Where(s => s.Deleted == false);

            return new PagedList<YimiSqlProvider>(query, pageindex, pagesize);
        }

        public YimiSqlProvider AddYimiSqlProvider(YimiSqlProvider yimiSqlProvider)
        {
            yimiSqlProvider.Createtime = DateTime.Now;
            yimiSqlProvider.Updatetime = DateTime.Now;
            yimiSqlProvider.Deleted = false;


            return _yimisqlproviderRepository.Insert(yimiSqlProvider);
        }

        public void UpdateYimiSqlProvider(YimiSqlProvider yimiSqlProvider)
        {
            _yimisqlproviderRepository.Update(yimiSqlProvider);
        }


        public YimiSqlProvider GetYimiSqlProvider(string id)
        {
            return _yimisqlproviderRepository.Table.FirstOrDefault(s => s.Id == id);
        }


        public IPagedList<SqlPublishOrderApproval> GetSqlPublishOrderApprovals(string userid, int pageindex = 0, int pagesize = int.MaxValue)
        {
            var query = _sqlpublishorderapprovalRepository.Table;
            if (!string.IsNullOrEmpty(userid))
                query = query.Where(s => s.LeaderId == userid);

            query = query.Where(s => s.Deleted == false);

            return new PagedList<SqlPublishOrderApproval>(query, pageindex, pagesize);
        }

        public SqlPublishOrderApproval AddSqlPublishOrderApproval(SqlPublishOrderApproval sqlPublishOrderApproval)
        {
            sqlPublishOrderApproval.Createtime = DateTime.Now;
            sqlPublishOrderApproval.Updatetime = DateTime.Now;
            sqlPublishOrderApproval.Deleted = false;


            return _sqlpublishorderapprovalRepository.Insert(sqlPublishOrderApproval);
        }

        public void UpdateSqlPublishOrderApprovalr(SqlPublishOrderApproval sqlPublishOrderApproval)
        {
            _sqlpublishorderapprovalRepository.Update(sqlPublishOrderApproval);
        }


        public SqlPublishOrderApproval GetSqlPublishOrderApproval(string id)
        {
            return _sqlpublishorderapprovalRepository.Table.FirstOrDefault(s => s.Id == id);
        }

        public SqlPublishOrderApproval GetSqlPublishOrderApprovalByOrderId(string orderid)
        {
            return _sqlpublishorderapprovalRepository.Table.FirstOrDefault(s => s.OrderId == orderid);
        }


        public Tuple<bool, string> Run(string id)
        {
            var model = _sqlpublishorderRepository.Table.FirstOrDefault(s => s.Id == id);
            model.IsRunning = true;
            model.Result = "Running";
            _sqlpublishorderRepository.Update(model);

            try
            {
                if (model.YimiSqlProvider.SqlProviderType == SqlProviderType.MsSql)
                {
                    using (SqlConnection conn = new SqlConnection(model.YimiSqlProvider.Connectstring))
                    {
                        conn.Open();
                        //string sql = $"Use [{model.YimiSqlProvider.DbName}]" + System.Environment.NewLine;
                        //sql += model.SqlText + System.Environment.NewLine;
                        //sql += "go";

                        SqlCommand sqlCommand = conn.CreateCommand();
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 1000;
                        sqlCommand.CommandText = model.SqlText;

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(model.YimiSqlProvider.Connectstring))
                    {
                        conn.Open();
                        var sqlCommand = conn.CreateCommand();
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 1000;
                        sqlCommand.CommandText = model.SqlText;

                        sqlCommand.ExecuteNonQuery();

                    }
                }


                model.IsRunning = false;
                model.IsPublished = true;
                model.Result = "Run Successfully!";
                _sqlpublishorderRepository.Update(model);
                return new Tuple<bool, string>(true, "");
            }
            catch(Exception ex)
            {

                model.IsRunning = false;

                model.Result = ex.Message;
                _sqlpublishorderRepository.Update(model);

                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}
