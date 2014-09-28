using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.UI.WebControls;

namespace Api.Models
{
    [DataContract]
    public class OfferViewModel
    {
        [DataMember]
        public string Title { get; private set; }
        [DataMember]
        public Dictionary<string,string> Properties { get; private set; }

        public OfferViewModel(string title, Dictionary<string, string> properties)
        {
            Title = title;
            Properties = properties;
        }
    }
}