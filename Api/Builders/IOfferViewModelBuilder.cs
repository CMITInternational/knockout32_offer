using Api.Models;
using Common.Models;

namespace Api.Builders
{
    public interface IOfferViewModelBuilder
    {
        OfferViewModel Build(Offer offer);
    }
}