(function () {
    define(["knockout", "/Modules/Offer.js", "/Services/offers.js","underscore"], function (ko, Offer, offers) {
        return function () {
            var self = this;

            self.offers = ko.observableArray([]);

            offers.setUrl('http://localhost:58176/api/Offers');
            offers.offersForAccount("1234")
                .success(function(data) {
                    data.forEach(function(offerData) {
                        self.offers.push(new Offer(offerData.Title, _.pairs(offerData.Properties)));
                    });
                })
                .error(function(error) {
                alert(error);
            });
        };
    });
})();