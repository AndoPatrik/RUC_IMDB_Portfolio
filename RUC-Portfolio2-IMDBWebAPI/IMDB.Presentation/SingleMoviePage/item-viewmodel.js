window.onload = function () {
  //var title_id = getParameters();
  title_id = 'tt10850402'
};

var title_id = ""

function getParameters () {
  let urlString = window.location.href;
  let paramString = urlString.split("?")[1];
  let queryString = new URLSearchParams(paramString);
  for (let pair of queryString.entries()) {
    var title_id = pair[1];
  }
  return title_id;
}

function titleModel (result) {
  var self = this;
  if (result == undefined) {
  } else {
    this.PrimaryTitle = ko.observable(result.primarytitle);
    this.TitleType = ko.observable(result.titletype);
    this.OriginalTitle = ko.observable(result.originaltitle);
    this.StartYear = ko.observable(result.startyear);
    this.EndYear = ko.observable(result.endyear);
    this.IsAdult = ko.observable(result.isadult);
    this.TConst = ko.observable(result.tconst);
    this.Plot = ko.observable(result.omdbDatum.plot);
    this.Awards = ko.observable(result.omdbDatum.awards);
    this.Poster = ko.observable(result.omdbDatum.poster);
  }
}

var result;
function TitleDetailViewModel (result) {
  self = this;
  self.title = ko.observable(new titleModel(result));
}
var mainTitleDetailViewModel = new TitleDetailViewModel(result);

ko.applyBindings(mainTitleDetailViewModel);

$.ajax({
  type: "GET",
  dataType: "JSON",
  url: "https://localhost:7167/api/Titles/" + title_id,
  data: JSON.stringify(),
  success: function (data) {
    result = data.data;
    mainTitleDetailViewModel.title(new titleModel(result));
  },
  error: function (error) {
    jsonValue = jQuery.parseJSON(error.responseText);
  },
});
