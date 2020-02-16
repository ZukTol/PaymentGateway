using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PaymentGateway.Api.Services.Impl
{
    internal static class JsonHelper
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings;

        static JsonHelper()
        {
            //_jsonSerializerSettings = new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};
        }

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
