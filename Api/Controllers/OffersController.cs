using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using Api.Builders;
using Api.Models;
using Common.Models;
using Common.Repositories;

namespace Api.Controllers
{
    [Route("api/offers")]
    public class OffersController : ApiController
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IOfferViewModelBuilder _offerViewModelBuilder;

        public OffersController(IOfferRepository offerRepository, IOfferViewModelBuilder offerViewModelBuilder)
        {
            _offerRepository = offerRepository;
            _offerViewModelBuilder = offerViewModelBuilder;
        }

        [Route("api/offers")]
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>
            {
                "1234"
            };
        }
        
        [Route("api/offers/{accountNumber}")]
        [HttpGet]
        public List<OfferViewModel> GetOffers(string accountNumber)
        {
            var offers = _offerRepository.GetOffers(accountNumber);

            return offers.Select(delegate(Offer offer)
            {
                OfferViewModel offerViewModel = _offerViewModelBuilder.Build(offer);
                return offerViewModel;
            }).ToList();
        }
    }
}
