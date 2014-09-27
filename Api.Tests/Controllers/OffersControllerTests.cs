using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Api.Builders;
using Api.Controllers;
using Api.Models;
using Common.Models;
using Common.Repositories;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Api.Tests.Controllers
{
    [TestFixture]
    public class OffersControllerTests
    {
        private OffersController _controllerUnderTest;
        private IOfferRepository _offerRepository;
        private IOfferViewModelBuilder _offerViewModelBuilder;

        [SetUp]
        public void Setup()
        {
            _offerRepository = Substitute.For<IOfferRepository>();
            _offerViewModelBuilder = Substitute.For<IOfferViewModelBuilder>();
            _controllerUnderTest = new OffersController(_offerRepository, _offerViewModelBuilder);
        }

        [Test]
        public void GetOffersShouldReturneOffersForAccount()
        {
            //Arrange
            const string accountNumber = "3103132";
            var offers = new List<Offer>
            {
                new Offer(accountNumber: accountNumber, campaign: new Campaign(title: "offer one", quantifier: BetQuantifierType.Winning, betTrigger: new BetTrigger(type: BetType.Sports, amount: 20.00))),
                new Offer(accountNumber: accountNumber, campaign: new Campaign(title: "offer two", quantifier: BetQuantifierType.Makeup, betTrigger: new BetTrigger(type: BetType.Racing, amount: 10.00))),
            };
            var offerOneProps = new Dictionary<string,string>
            {
                {"Description", "Winning Bet"},
                {"Bet Type", "Sports"},
                {"Amount", "$20.00"}
            };
            var offerTwoProps = new Dictionary<string,string>
            {
                {"Description", "Any Bet"},
                {"Bet Type", "Racing"},
                {"Amount", "$10.00"},
                {"Expires", "Very Soon"}
            };
            _offerRepository.GetOffers(accountNumber).Returns(offers);
            _offerViewModelBuilder.Build(Arg.Is(OfferMatching(title: "offer one")))
                .Returns(new OfferViewModel(title: "offer one", properties: offerOneProps));
            _offerViewModelBuilder.Build(Arg.Is(OfferMatching(title: "offer two")))
                .Returns(new OfferViewModel(title: "offer two", properties: offerTwoProps));

            //Act
            var offerViewModels = _controllerUnderTest.GetOffers(accountNumber);

            //Assert
            Assert.That(offerViewModels.Count, Is.EqualTo(2));
            Assert.That(offerViewModels, ContainsOfferViewModelMatching(title: "offer one", properties: offerOneProps));
            Assert.That(offerViewModels, ContainsOfferViewModelMatching(title: "offer two", properties: offerTwoProps));
        }

        private Expression<Predicate<Offer>> OfferMatching(string title)
        {
            return o => o.Campaign.Title.Equals(title);
        }

        private PredicateConstraint<List<OfferViewModel>> ContainsOfferViewModelMatching(string title, Dictionary<string, string> properties)
        {
            return new PredicateConstraint<List<OfferViewModel>>(l => l.Any(o => o.Title.Equals(title) && o.Properties.Keys.All(key =>   properties.ContainsKey(key) && 
                                                                                                                        properties[key].Equals(o.Properties[key]))));
        }
    }
}
