﻿(function () {
    define(["Modules/Offer", "knockout"], function (Offer, ko) {
        return {
            createViewmodel: function (params, componentInfo) {
                if (params instanceof Offer) {
                    return params;
                }
                return new Offer(params.title, params.properties);
            }
        };
    });
})();