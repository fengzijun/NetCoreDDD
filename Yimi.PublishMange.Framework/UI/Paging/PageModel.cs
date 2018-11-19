using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Framework.UI.Paging
{
    public class PageModel
    {

        public int PageIndex { get; set; }

        public string Url { get; set; }

        public int PageCount { get; set; }

        public string GenerateUrl(int page)
        {
          
            if (Url.Contains("?"))
                return Url + "&pageindex=" + page;
            return Url + "?pageindex=" + page;
        }
    }
}
