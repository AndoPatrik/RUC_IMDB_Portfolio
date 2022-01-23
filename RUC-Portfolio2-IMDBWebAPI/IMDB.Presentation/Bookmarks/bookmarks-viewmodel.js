import { fetchDataBearer, fetchData } from "../httpRequest.js";

var BookmarksViewModel = function () {
    var self = this
    self.bookmarks = ko.observableArray()
    self.isLoggedIn = ko.observable(() => sessionStorage.getItem('CurrentUser') ? true : false)

    self.loadBookmarks = async function () {
        var result = await fetchDataBearer('/TitleBookmarks')
        if (!result.data) return

        result.data.forEach(async bookmark => {
            var result = await fetchData(`/Titles/${ bookmark.tconst }`)
            if (result.data) self.bookmarks().push(result.data)
        });

        console.log(self.bookmarks());
    }

    window.onload = async () => {
        await self.loadBookmarks()
    }
};

ko.applyBindings(new BookmarksViewModel());
