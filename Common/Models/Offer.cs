namespace Common.Models
{
    public class Offer
    {
        public string AccountNumber { get; private set; }
        public Campaign Campaign { get; private set; }

        public Offer(string accountNumber, Campaign campaign)
        {
            AccountNumber = accountNumber;
            Campaign = campaign;
        }
    }
}