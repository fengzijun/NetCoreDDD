using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Service.Model
{
    public class DingTalkResponseBase
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        public bool IsSuccess
        {
            get
            {
                return ErrCode == 0;
            }
        }
    }
}
