let bootstrapString = localStorage.getItem('bootstrap');
if (bootstrapString == null) {
    bootstrapString = document.querySelector('#bootstrap').href = '/bootstrap/css/bootstrap.min.css';
    localStorage.setItem('bootstrap', bootstrapString);
} else if (document.querySelector('#bootstrap') != bootstrapString) {
    bootstrapString = document.querySelector('#bootstrap').href = localStorage.getItem('bootstrap');
}