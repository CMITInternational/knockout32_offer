/*
Run this tes using
==================
node_modules\.bin\jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

require.config({
    baseUrl: '../',
    paths: {
        'Services/http': 'Specs/http-mock'
    }
});

require(['Services/http', 'Services/offers'], function (http, offers) {
    describe('offers', function() {
        it('index should perform http get', function () {
            offers.index();
            expect(http.get).toHaveBeenCalled();
        });
        it('play should perform http get', function () {
            offers.offersForAccount();
            expect(http.get).toHaveBeenCalled();
        });
    });
});