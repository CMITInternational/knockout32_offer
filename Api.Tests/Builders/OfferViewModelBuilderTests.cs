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
                        amount: 20.00
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
            Assert.That(racing.Properties.ContainsKey("Bet Type"), Is.True);
            Assert.That(racing.Properties["Bet Type"], Is.EqualTo("Racing"));
            Assert.That(sports.Properties.ContainsKey("Bet Type"), Is.True);
            Assert.That(sports.Properties["Bet Type"], Is.EqualTo("Sports"));
        }

        [Test]
        public void BuildShouldPopulateDescriptionAsWinningBetForWinningQualifier()
        {
            //Act
            var racing = _builderUnderTest.Build(offer: _winningRacingBetOffer);
            var sports = _builderUnderTest.Build(offer: _winningSportsBetOffer);

            //Assert
            Assert.That(racing.Properties.ContainsKey("Description"), Is.True);
            Assert.That(racing.Properties["Description"], Is.EqualTo("Winning Bet"));
            Assert.That(sports.Properties.ContainsKey("Description"), Is.True);
            Assert.That(sports.Properties["Description"], Is.EqualTo("Winning Bet"));
        }

        private PredicateConstraint<OfferViewModel> IsOfferViewModelMatching(string title, Dictionary<string, string> properties)
        {
            return new PredicateConstraint<OfferViewModel>(o => o.Title.Equals(title) && o.Properties.Keys.All(key => properties.ContainsKey(key) &&
                                                                                                                        properties[key].Equals(o.Properties[key])));
        }
    }
}
