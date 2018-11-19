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
    public class QuoteService: IQuoteService
    {
        private readonly IRepository<Quote> _quoteRepository;

        public QuoteService(IRepository<Quote> quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public IPagedList<Quote> GetQuotes(int pageindex = 0, int pagesize = int.MaxValue)
        {
            var query = _quoteRepository.Table;
         
            query = query.OrderByDescending(s => s.Id);

            return new PagedList<Quote>(query, pageindex, pagesize);
        }

        public void AddQuote(Quote quote)
        {
            quote.Createtime = DateTime.Now;
            quote.Updatetime = DateTime.Now;

            _quoteRepository.Insert(quote);
        }
    }
}
