window.addEventListener('DOMContentLoaded', function() {
    var firstName = sessionStorage.getItem('firstName');
    var lastName = sessionStorage.getItem('lastName');
    var userInfo = document.getElementById('user-info');
            
    if (firstName && lastName) {
        userInfo.textContent = `Bienvenido, ${firstName} ${lastName}`;
        document.getElementById('login-button').style.display = 'none';
    }
});