using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Top.Api;

namespace Yimi.PublishManage.Service.Model
{
    public class GeAccessTokenRequest: DingTalkRequestBase
    {
        [JsonProperty("corpid")]
        public string CorpId { get; set; }
        [JsonProperty("corpsecret")]
        public string CorpSecret { get; set; }
        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary req = new TopDictionary();
            req.Add("corpid", CorpId);
            req.Add("corpsecret", CorpSecret);
            return req;
        }
    }
}
