let changeBootstrap = function (el) {
    if (localStorage.getItem('bootstrap') == '/bootstrap/css/bootstrap.min.css') {
        el.href = '/bootstrap/css/invert/bootstrap.min.css';
        localStorage.setItem('bootstrap', '/bootstrap/css/invert/bootstrap.min.css');
    } else {
        el.href = '/bootstrap/css/bootstrap.min.css';
        localStorage.setItem('bootstrap', '/bootstrap/css/bootstrap.min.css');
    }
}

// Функция для андройд
let setLightTheme = function () {
    if (document.querySelector('#bootstrap').href != "/bootstrap/css/bootstrap.min.css") {
        document.querySelector('#bootstrap').href = "/bootstrap/css/bootstrap.min.css";
        localStorage.setItem('bootstrap', '/bootstrap/css/bootstrap.min.css');
    }

}
let setDarkTheme = function () {
    if (document.querySelector('#bootstrap').href != "/bootstrap/css/invert/bootstrap.min.css") {
        document.querySelector('#bootstrap').href = "/bootstrap/css/invert/bootstrap.min.css";
        localStorage.setItem('bootstrap', '/bootstrap/css/invert/bootstrap.min.css');
    }

}