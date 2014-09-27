using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Builders;
using Api.Models;
using Common.Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Api.Tests.Builders
{
    [TestFixture]
    public class OfferViewModelBuilderTests
    {
        private OfferViewModelBuilder _builderUnderTest;
        private Offer _winningSportsBetOffer;
        private Offer _winningRacingBetOffer;
        private Offer _makeupSportsBetOffer;
        private Offer _makeupRacingBetOffer;

        [SetUp]
        public void Setup()
        {
            _builderUnderTest = new OfferViewModelBuilder();
            _winningSportsBetOffer = new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Winning,
                    betTrigger: new BetTrigger(
                        type: BetType.Sports,
                        amount: 10.00
                        )
                    )
                );
            _winningRacingBetOffer = new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Winning,
                    betTrigger: new BetTrigger(
                        type: BetType.Racing,
                        amount: 20.00
                        )
                    )
                );
            _makeupSportsBetOffer = new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Makeup,
                    betTrigger: new BetTrigger(
                        type: BetType.Sports,
                        amount: 10.00
                        )
                    )
                );
            _makeupRacingBetOffer = new Offer(
                accountNumber: "1234",
                campaign: new Campaign(
                    title: "Winning Sports Bet Offer",
                    quantifier: BetQuantifierType.Makeup,
                    betTrigger: new BetTrigger(
                        type: BetType.Racing,
                        amount: 20.00
                        )
                    )
                );
        }

        [Test]
        public void BuildShouldPopulateTitle()
        {
            //Act
            var result = _builderUnderTest.Build(offer: _winningSportsBetOffer);

            //Assert
            Assert.That(result.Title, Is.EqualTo("Winning Sports Bet Offer"));
        }

        [Test]
        public void BuildShouldPopulateBetType()
        {
            //Act
            var racing = _builderUnderTest.Build(offer: _winningRacingBetOffer);
            var sports = _builderUnderTest.Build(offer: _winningSportsBetOffer);

            //Assert
            Assert.That(racing.Properties, ContainsPair("Bet Type","Racing"));
            Assert.That(sports.Properties, ContainsPair("Bet Type","Sports"));
        }

        [Test]
        public void BuildShouldPopulateDescriptionAsWinningBetForWinningQualifier()
        {
            //Act
            var racing = _builderUnderTest.Build(offer: _winningRacingBetOffer);
            var sports = _builderUnderTest.Build(offer: _winningSportsBetOffer);

            //Assert
            Assert.That(racing.Properties, ContainsPair("Description", "Winning Bet"));
            Assert.That(sports.Properties, ContainsPair("Description", "Winning Bet"));
        }

        [Test]
        public void BuildShouldPopulateDescriptionAsAnyBetForMakeupQualifier()
        {
            //Act
            var racing = _builderUnderTest.Build(offer: _makeupRacingBetOffer);
            var sports = _builderUnderTest.Build(offer: _makeupSportsBetOffer);

            //Assert
            Assert.That(racing.Properties, ContainsPair("Description", "Any Bet"));
            Assert.That(sports.Properties, ContainsPair("Description", "Any Bet"));
        }

        [Test]
        public void BuildShouldPopulateAmount()
        {
            //Act
            var winningRacing = _builderUnderTest.Build(offer: _winningRacingBetOffer);
            var winningSports = _builderUnderTest.Build(offer: _winningSportsBetOffer);
            var makeupRacing = _builderUnderTest.Build(offer: _makeupRacingBetOffer);
            var makeupSports = _builderUnderTest.Build(offer: _makeupSportsBetOffer);

            //Assert
            Assert.That(winningRacing.Properties, ContainsPair("Amount", "$20.00"));
            Assert.That(winningSports.Properties, ContainsPair("Amount", "$10.00"));
            Assert.That(makeupRacing.Properties, ContainsPair("Amount", "$20.00"));
            Assert.That(makeupSports.Properties, ContainsPair("Amount", "$10.00"));
        }

        [Test]
        public void BuildShouldOnlyPopulateExpiryForMakeup()
        {
            //Act
            var winningRacing = _builderUnderTest.Build(offer: _winningRacingBetOffer);
            var winningSports = _builderUnderTest.Build(offer: _winningSportsBetOffer);
            var makeupRacing = _builderUnderTest.Build(offer: _makeupRacingBetOffer);
            var makeupSports = _builderUnderTest.Build(offer: _makeupSportsBetOffer);

            //Assert
            Assert.That(winningRacing.Properties, DoesNotContainKey("Expires"));
            Assert.That(winningSports.Properties, DoesNotContainKey("Expires"));
            Assert.That(makeupRacing.Properties, ContainsPair("Expires", "Very Soon"));
            Assert.That(makeupSports.Properties, ContainsPair("Expires", "Very Soon"));
        }

        private PredicateConstraint<Dictionary<string,string>> ContainsPair(string key, string value)
        {
            return new PredicateConstraint<Dictionary<string, string>>(p => p.Keys.Any(k => k.Equals(key) && p[key].Equals(value)));
        }

        private PredicateConstraint<Dictionary<string,string>> DoesNotContainKey(string key)
        {
            return new PredicateConstraint<Dictionary<string, string>>(p => p.ContainsKey(key) == false);
        }

        private PredicateConstraint<OfferViewModel> IsOfferViewModelMatching(string title, Dictionary<string, string> properties)
        {
            return new PredicateConstraint<OfferViewModel>(o => o.Title.Equals(title) && o.Properties.Keys.All(key => properties.ContainsKey(key) &&
                                                                                                                        properties[key].Equals(o.Properties[key])));
        }
    }
}
