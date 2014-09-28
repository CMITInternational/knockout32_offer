using System.Collections.Generic;
using Common.Models;

namespace Common.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        public List<Offer> GetOffers(string accountNumber)
        {
            return new List<Offer>
            {
            new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Winning,
                    betTrigger: new BetTrigger(
                        type: BetType.Sports,
                        amount: 10.00
                        )
                    )
                ),
            new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Winning,
                    betTrigger: new BetTrigger(
                        type: BetType.Racing,
                        amount: 20.00
                        )
                    )
                ),
            new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Makeup,
                    betTrigger: new BetTrigger(
                        type: BetType.Sports,
                        amount: 10.00
                        )
                    )
                ),
            new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Makeup,
                    betTrigger: new BetTrigger(
                        type: BetType.Racing,
                        amount: 20.00
                        )
                    )
                )
            };
        }
    }
}