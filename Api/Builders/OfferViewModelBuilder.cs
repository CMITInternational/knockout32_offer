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
            var properties = new Dictionary<string, string>
            {
                {"Bet Type", offer.Campaign.BetTrigger.Type.ToString()},
                {"Amount", String.Format("{0:C}", offer.Campaign.BetTrigger.Amount)}
            };

            switch (offer.Campaign.Quantifier)
            {
                case BetQuantifierType.Winning:
                {
                    properties.Add("Description","Winning Bet");
                    break;
                }
                case BetQuantifierType.Makeup:
                {
                    properties.Add("Description","Any Bet");
                    properties.Add("Expires","Very Soon");
                    break;
                }
            }

            return new OfferViewModel(title: offer.Campaign.Title, properties: properties);
        }
    }
}