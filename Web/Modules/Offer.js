(function () {
    define(["knockout"], function (ko) {
        return function (title, properties) {
            var self = this;

            self.title = ko.observable(title);
            self.properties = ko.observableArray(properties);
        };
    });
})();