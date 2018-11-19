using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Domain;

namespace Yimi.PublishManage.Service.IService
{
    public interface IQuoteService
    {
        IPagedList<Quote> GetQuotes(int pageindex = 0, int pagesize = int.MaxValue);

        void AddQuote(Quote  quote);
    }
}
