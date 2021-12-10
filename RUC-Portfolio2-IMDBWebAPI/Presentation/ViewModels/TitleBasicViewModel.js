define(["knockout", "TitleBasicModel"], function (ko, tbm) {

    let currentView = ko.observable("list");
    let title_basics = ko.observableArray([]);

    let deleteTitleBasic = title_basic => {
        title_basics.remove(title_basic);
        tbm.deleteTitleBasic(title_basic);
    }

    //let selectTconst = ko.observable();
    let selectTitleType = ko.observable();
    let selectPrimaryTitle = ko.observable();
    let selectOriginalTitle = ko.observable();
    let selectIsAdult = ko.observable();
    let selectStartYear = ko.observable();
    let selectEndYear = ko.observable();
    let selectRuntimeMinutes = ko.observable();


    let addTitleBasic = () => {
        console.log("addTitleBasic");
        let title_basic = {
            title_type: selectTitleType(),
            primary_title: selectPrimaryTitle(),
            original_title: selectOriginalTitle(),
            isadult: selectIsAdult(),
            start_year: selectStartYear(),
            end_year: selectEndYear(),
            runtime_minutes: selectRuntimeMinutes()
        };
        tbm.addTitleBasic(title_basic, newTitleBasic => {
            title_basics.push(newTitleBasic);
        });
        currentView("list");
    }


    return {
        deleteTitleBasic,
        addTitleBasic,
        currentView,
        title_basics,
        selectTitleType,
        selectPrimaryTitle,
        selectOriginalTitle,
        selectIsAdult,
        selectStartYear,
        selectEndYear,
        selectRuntimeMinutes
    }

    // let tconst = ko.observable();
    // let title_type = ko.observable();
    // let primary_title = ko.observable();
    // let original_title = ko.observable();
    // let isadult = ko.observable();
    // let start_year = ko.observable();
    // let end_year = ko.observable();
    // let runtime_minutes = ko.observable();

    // return {
    //     tconst,
    //     title_type,
    //     primary_title,
    //     original_title,
    //     isadult,
    //     start_year,
    //     end_year,
    //     runtime_minutes
    // }
});

