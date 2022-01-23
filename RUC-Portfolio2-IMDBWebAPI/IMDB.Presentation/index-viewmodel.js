import { fetchData, postData, postDataBearer } from "./httpRequest.js";

var IndexViewModel = function () {
    var self = this;
    self.movies = ko.observableArray();
    self.nextLink = ko.observable();
    self.previousLink = ko.observable();
    self.userLoggedIn = ko.observable(false)

    self.handleBookmark = async function (tconst) {

        const payload = { tconst: tconst, uconst: "uconst" }

        console.log(JSON.parse(sessionStorage.getItem('CurrentUser')).token);

        var result = await postDataBearer('/TitleBookmarks/create', payload)

        if (result.data) { alert("Bookmark added") }
    }

    self.checkIfUserLoggedIn = function () {
        return sessionStorage.getItem('CurrentUser') ? self.userLoggedIn(true) : self.userLoggedIn(false)
    }

    self.handlePictureClick = function (tconst) {
        location.href = window.location.origin + `/RUC-Portfolio2-IMDBWebAPI/IMDB.Presentation/SingleMoviePage/item.html?title_id=${ tconst }`
    }

    self.fetchMovies = async function (path) {
        var result = await fetchData(path)
        self.movies(result.data)
        self.nextLink(result.nextPage)
        self.previousLink(result.previousPage)
        console.log(this.movies());
    }

    self.handleNext = function () {
        this.fetchMovies(self.nextLink());
    }

    self.handlePrevious = function () {
        this.fetchMovies(self.previousLink())
    }

    window.onload = () => {
        self.checkIfUserLoggedIn();
        self.fetchMovies("/Titles?PageNumber=1&PageSize=20");
    }
};

ko.applyBindings(new IndexViewModel());
