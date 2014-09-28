(function () {
    define(["knockout"], function (ko) {
        return function (title, properties) {
            var self = this;

            self.title = title;
            self.properties = properties;
        };
    });
})();