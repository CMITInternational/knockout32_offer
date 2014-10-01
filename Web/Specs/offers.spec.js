/*
Run this tes using
==================
node_modules\.bin\jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

var lockfile = require('lockfile');

lockfile.lock('test.lock', {retries:200,retryWait:20}, function(err) {
    if (!err) {
        //console.log('lock obtained for offers.spec');

        require.undef('Services/http');
        require.undef('Services/offers');

        require.config({
            baseUrl: '../',
            paths: {
                'Services/http': 'Specs/http-mock',
                'Services/offers': 'Services/offers'
            }
        });

        require(['Services/offers', 'Services/http'], function(offers, http) {
            describe('offers', function() {
                it('index should perform http get', function() {
                    offers.index();
                    expect(http.get).toHaveBeenCalled();
                });
                it('play should perform http get', function() {
                    offers.offersForAccount();
                    expect(http.get).toHaveBeenCalled();
                });
                lockfile.unlock('test.lock', function(err) {
                    if (err) {
                        console.log('unlock failed in offers.spec with ' + err);
                    }
                });
            });
        });
    } else {
        console.log('lock failed in offers.spec with ' + err);
    }
});
