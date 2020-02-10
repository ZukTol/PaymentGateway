namespace PaymentGateway.Api.Services
{
    public interface IJsonService
    {
        string Serialize(object o);
        T Deserialize<T>(string s);
    }
}
