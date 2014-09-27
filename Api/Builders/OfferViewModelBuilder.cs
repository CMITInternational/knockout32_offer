using System;
using System.Collections.Generic;
using Api.Models;
using Common.Models;

namespace Api.Builders
{
    public class OfferViewModelBuilder : IOfferViewModelBuilder
    {
        public OfferViewModel Build(Offer offer)
        {
            var properties = new Dictionary<string, string>();

            properties.Add("Bet Type",offer.Campaign.BetTrigger.Type.ToString());

            switch (offer.Campaign.Quantifier)
            {
                case BetQuantifierType.Winning:
                {
                    properties.Add("Description","Winning Bet");
                    break;
                }
            }

            return new OfferViewModel(title: offer.Campaign.Title, properties: properties);
        }
    }
}