using Microsoft.AspNetCore.Mvc;

namespace Yimi.PublishManage.Framework.Mvc
{
    public class NullJsonResult : JsonResult
    {
        public NullJsonResult() : base(null)
        {
        }
    }
}
