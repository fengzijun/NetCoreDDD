using Newtonsoft.Json;

namespace Yimi.PublishManage.Core.Helper
{
    public static class JsonHelper
    {

        public static T GetTFromJson<T>(this string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
        public static string GetJsonFromobj(this object s)
        {
            return JsonConvert.SerializeObject(s);
        }
    }
}
