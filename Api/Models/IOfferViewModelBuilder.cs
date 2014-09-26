using Common.Models;

namespace Api.Models
{
    public interface IOfferViewModelBuilder
    {
        OfferViewModel Build(Offer offer);
    }
}