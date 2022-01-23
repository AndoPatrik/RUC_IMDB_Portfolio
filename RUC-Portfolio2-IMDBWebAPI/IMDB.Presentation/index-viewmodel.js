import { fetchData } from "./httpRequest.js";

var IndexViewModel = function () {
    var self = this;
    self.movies = ko.observableArray();
    self.nextLink = ko.observable();
    self.previousLink = ko.observable();

    self.fetchMovies = async function (path) {
        var result = await fetchData(path)
        self.movies(result.data)
        self.nextLink(result.nextPage)
        self.previousLink(result.previousPage)
    }

    self.handleNext = function () {
        this.fetchMovies(self.nextLink());
    }

    self.handlePrevious = function () {
        this.fetchMovies(self.previousLink())
    }

    window.onload = this.fetchMovies("https://localhost:7167/api/Titles?PageNumber=1&PageSize=20");
};

ko.applyBindings(new IndexViewModel());
