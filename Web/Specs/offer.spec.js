/*
Run this tes using
==================
node_modules\.bin\jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

var lockfile = require('lockfile');

lockfile.lock('test.lock', { retries: 200, retryWait: 20 }, function (err) {
    if (!err) {
        //console.log('lock obtained for offer.spec');

        require.undef('knockout');
        require.undef('Modules/Offer');

        require.config({
            baseUrl: '../',
            paths: {
                'knockout': 'Scripts/knockout-3.2.0.debug',
                'Modules/Offer': 'Modules/Offer'
            }
        });

        require(['Modules/Offer', 'knockout'], function(Offer, ko) {
            describe('Offer', function() {
                it('Should populate title', function(done) {
                    var offerUnderTest = new Offer('title', []);
                    expect(offerUnderTest.title()).toBe('title');
                    done();
                });
                lockfile.unlock('test.lock', function(err) {
                    if (err) {
                        console.log('unlock failed in offer.spec with ' + err);
                    }
                });
            });
        });
    } else {
        console.log('lock failed in offer.spec with ' + err);
    }
});

