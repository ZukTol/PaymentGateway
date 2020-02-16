using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PaymentGateway.Api.Services.Impl
{
    internal static class JsonHelper
    {
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static T Deserialize<T>(string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}
