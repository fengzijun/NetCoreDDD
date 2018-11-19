using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Framework.Mvc.Filters;
using Yimi.PublishManage.Framework.Security;

namespace Yimi.PublishManage.Framework.Controllers
{
    //[HttpsRequirement(SslRequirement.NoMatter)]
    //[WwwRequirement]
    //[CheckAccessPublicStore]
    //[CheckAccessClosedStore]
    //[CheckLanguageSeoCode]
    //[CheckAffiliate]
    public abstract  class BasePublicController : BaseController
    {

    }
}
