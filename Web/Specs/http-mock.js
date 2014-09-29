(function () {
    define([], function () {
        return jasmine.createSpyObj('http', ['get','put','post','delete']);
    });
})
();
