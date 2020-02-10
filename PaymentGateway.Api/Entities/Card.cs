namespace PaymentGateway.Api.Entities
{
    public class Card
    {
        public string Number { get; set; }
        public string ValidThru { get; set; }
        public int Cvv { get; set; }
    }
}
