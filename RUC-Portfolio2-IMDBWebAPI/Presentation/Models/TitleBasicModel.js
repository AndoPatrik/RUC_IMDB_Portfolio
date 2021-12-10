// var tconst;
// var title_type;
// var primary_title;
// var original_title;
// var isadult;
// var start_year;
// var end_year;
// var runtime_minutes;

// function getTitleBasic(callback){
//     fetch("ap/titles",{method:'GET'})
//         .then(response => response.json())
//         .then(json =>{
//             callback(json);
//         });
// }

// getTitleBasic(function(TitleBasic){
//     console.log(TitleBasic);
// });


define([], () => {

    let getTitleBasic = (callback) =>{
        fetch("api/titlebasic")
            .then(response => response.json())
            .then(json =>callback(json));
    };

    let createTitleBasic = (title_basic, callback)=>{
        let param={
            mehtod="POST",
            body: JSON.stringify(title_basic),
            headers:{
                "Content-Type":"application/json"
            }
        }
        fetch("api/titlebasic",param)
            .then(response=>response.json())
            .then(json=>callback(json));
    };

    let deleteTitleBasic = title_basic =>{
        fetch(title_basic.url,{mehtod:"DELETE"})
            .then(response => console.log(response.status))
    };

    return{
        getTitleBasic,
        createTitleBasic,
        deleteTitleBasic
    }



});