var _modal;

var Show_album = function (modal) {    
    _modal = modal;
    document.getElementById(modal).requestFullscreen();
    $("#" + modal).modal('show');
    //Android.showSystemBars();
};
var Hidden_album = function (modal) {
    Android.hideSystemBars();
    document.exitFullscreen();
    $("#" + modal).modal('hide');
    //Android.hideSystemBars();
};
$(document).on('fullscreenchange', function () {
    if (!document.fullscreenElement) {
        document.exitFullscreen();
        Hidden_album(_modal);
    }
});

function show() {
    return new Promise(function (resolve, reject){
        _modal = "modal_album";
        document.getElementById("modal_album").requestFullscreen();
        $("#modal_album").modal('show');
    }
)};


var Show_Ask_remove_album = function (modal_remove) {
    $("#" + modal_remove).modal('show');
};
var Hide_Ask_remove_album = function (modal_remove) {
    $("#" + modal_remove).modal('hide');
}

var showAndroidSystemBars = function () {
    //return Android.showSystemBars();
};

var hideAndroidSystemBars = function () {
    //return Android.hideSystemBars();
};