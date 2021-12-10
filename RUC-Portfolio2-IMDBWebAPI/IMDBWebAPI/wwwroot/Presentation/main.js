require.config({
    baseUrl: 'js',
    paths: {
        jquery: "../lib/js/lib/jquery/jquery.min",
        knockout: "../lib/js/lib/knockout/knockout-latest.debug",
        Models: "ViewModels/TitleBasicViewModel"
        //require:"../lib/js/lib/require.js/require"
    }
});

require(["knockout", "TitleBasicViewModel"], function (ko, vm) {
    ko.applyBindings(vm);
});