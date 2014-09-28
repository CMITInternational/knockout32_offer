(function () {
    define(["knockout", "/Modules/Offer.js", "/Services/offers.js"], function (ko, Offer, offers) {
        return function () {
            var self = this;

            self.offers = [];

            offers.offersForAccount("1234")
                .sucess(function(data) {
                    data.forEach(function(offerData) {
                        self.offers.push(new Offer(offerData.Title, offerData.Properties));
                    });
                })
                .error(function(error) {
                alert(error);
            });
        };
    });
})();