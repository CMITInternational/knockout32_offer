(function () {
    define(['/Services/http.js'], function (http) {
        var _url = "/api/Offers";

        return {
            setUrl: function (url) {
                _url = url;
            },
            index: function () {
                return http.get(_url, {});
            },
            offersForAccount: function (data) {
                return http.get(_url + '/' + data);
            }
        };
    });
})();