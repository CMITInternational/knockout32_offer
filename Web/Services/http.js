(function () {
    define(["jquery"], function (jQuery) {
        var ajax = function (type, url, data) {
            return jQuery.ajax({
                type: type,
                url: url,
                data: data,
                cache: false,
                contentType: 'application/json'
            });
        };

        return {
            get: function (url, data) {
                return ajax('GET', url, data);
            },
            put: function (url, data) {
                return ajax('PUT', url, data);
            },
            post: function (url, data) {
                return ajax('POST', url, data);
            },
            delete: function (url, data) {
                return ajax('DELETE', url, data);
            }
        };
    });
})();