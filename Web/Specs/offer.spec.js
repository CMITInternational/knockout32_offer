/*
Run this tes using
==================
node_modules\.bin\jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

require.config({
    baseUrl: '../',
    paths: {
        'knockout': 'Scripts/knockout-3.2.0.debug',
    }
});

require(['Modules/Offer', 'knockout'], function (Offer, ko) {
    describe('Offer',function() {
        it('Should populate title', function () {
            var offerUnderTest = new Offer('title', ko.observableArray([]));
            expect(offerUnderTest.name()).toBe('title');
        });
    });
});