using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Service.Model
{
    public class GetAccessTokenResponse: DingTalkResponseBase
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
