/*
Run this tes using
==================
node_modules\.bin\jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

require.config({
    baseUrl: '../',
    paths: {
        'jquery': 'Specs/jquery-mock'
    }
});

require(['Services/http', 'jquery'], function (http, jQuery) {
    describe('http', function () {
        it('get should use url in jquery ajax GET', function () {
            http.get("url", { stuff: "data" });
            expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("GET");
            expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
        });
        it('put should use url and data in jquery ajax PUT', function () {
            var data = { stuff: "data" };
            http.put("url", data);
            expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("PUT");
            expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
            expect(jQuery.ajax.mostRecentCall.args[0]["data"]).toEqual(data);
        });
        it('post should use url and data in jquery ajax POST', function () {
            var data = { stuff: "data" };
            http.post("url", data);
            expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("POST");
            expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
            expect(jQuery.ajax.mostRecentCall.args[0]["data"]).toEqual(data);
        });
        it('delete should use url and data in jquery ajax DELETE', function () {
            var data = { stuff: "data" };
            http.delete("url", data);
            expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("DELETE");
            expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
            expect(jQuery.ajax.mostRecentCall.args[0]["data"]).toEqual(data);
        });
    });
});