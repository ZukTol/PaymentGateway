using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PaymentGateway.Api.Services.Impl
{
    internal class JsonService : IJsonService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonService()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, _jsonSerializerSettings);
        }

        public T Deserialize<T>(string s)
        {
            return JsonConvert.DeserializeObject<T>(s, _jsonSerializerSettings);
        }
    }
}
