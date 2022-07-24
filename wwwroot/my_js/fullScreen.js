$(document).ready(function () {
    $(document).on('fullscreenchange', function (e) {
        if (!document.fullscreen) (dotNetHelper) => { return dotNetHelper.invokeMethodAsync('closeWindow'); }
    });
});

var enableFullScreen = function () {
    document.body.requestFullscreen();
};

var disableFullScreen = function () {
    document.exitFullscreen();
}