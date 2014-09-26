using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Api.Models
{
    public class OfferViewModel
    {
        public string Title { get; private set; }
        public Dictionary<string,string> Properties { get; private set; }

        public OfferViewModel(string title, Dictionary<string, string> properties)
        {
            Title = title;
            Properties = properties;
        }
    }
}