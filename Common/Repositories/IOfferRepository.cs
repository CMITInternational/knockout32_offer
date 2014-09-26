using System.Collections.Generic;
using Common.Models;

namespace Common.Repositories
{
    public interface IOfferRepository
    {
        List<Offer> GetOffers(string accountNumber);
    }
}