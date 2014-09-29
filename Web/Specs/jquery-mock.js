(function() {
    define([], function() {
        return jasmine.createSpyObj('jquery',['ajax']);
    });
})
();
