/*
Run this tes using
==================
node_modules\.bin\jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

var lockfile = require('lockfile');

lockfile.lock('test.lock', { retries: 200, retryWait: 20 }, function (err) {
    if (!err) {
        console.log('lock obtained for http.spec');

        require.config({
            baseUrl: '../',
            paths: {
                'jquery': 'Specs/jquery-mock',
                'Services/http': 'Services/http'
            }
        });

        console.log('require.undef -> [' + require.undef + ']');

        require(['Services/http', 'jquery'], function (http, jQuery) {
            describe('http', function() {
                it('get should use url in jquery ajax GET', function(done) {
                    http.get("url", { stuff: "data" });
                    expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("GET");
                    expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
                    done();
                });
                it('put should use url and data in jquery ajax PUT', function(done) {
                    var data = { stuff: "data" };
                    http.put("url", data);
                    expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("PUT");
                    expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
                    expect(jQuery.ajax.mostRecentCall.args[0]["data"]).toEqual(data);
                    done();
                });
                it('post should use url and data in jquery ajax POST', function(done) {
                    var data = { stuff: "data" };
                    http.post("url", data);
                    expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("POST");
                    expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
                    expect(jQuery.ajax.mostRecentCall.args[0]["data"]).toEqual(data);
                    done();
                });
                it('delete should use url and data in jquery ajax DELETE', function(done) {
                    var data = { stuff: "data" };
                    http.delete("url", data);
                    expect(jQuery.ajax.mostRecentCall.args[0]["type"]).toEqual("DELETE");
                    expect(jQuery.ajax.mostRecentCall.args[0]["url"]).toEqual("url");
                    expect(jQuery.ajax.mostRecentCall.args[0]["data"]).toEqual(data);
                    done();
                });
                lockfile.unlock('test.lock', function (err) {
                    if (err) {
                        console.log('unlock failed in http.spec with ' + err);
                    }
                });
            });
        });
    } else {
        console.log('lock failed in http.spec with ' + err);
    }
});
