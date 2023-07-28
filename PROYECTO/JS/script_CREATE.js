function validateForm() {
    var nombres = document.getElementById("nombres");
    var apellidos = document.getElementById("apellidos");
    var correo = document.getElementById("correo");
    var telefono = document.getElementById("telefono");

    var contrasena = document.getElementById("contrasena").value;
    var confirmarContrasena = document.getElementById("confirmar-contrasena").value;

    var isValid = true;

    if (nombres.value === "") {
        nombres.setCustomValidity("Completa este campo");
        isValid = false;
    } else {
        nombres.setCustomValidity("");
    }

    if (apellidos.value === "") {
        apellidos.setCustomValidity("Completa este campo");
        isValid = false;
    } else {
        apellidos.setCustomValidity("");
    }

    if (correo.value === "") {
        correo.setCustomValidity("Completa este campo");
        isValid = false;
    } else {
        correo.setCustomValidity("");
    }

    if (telefono.value === "") {
        telefono.setCustomValidity("Completa este campo");
        isValid = false;
    } else {
        telefono.setCustomValidity("");
    }

    var espacios = false;
    var cont = 0;

    while (!espacios && (cont < contrasena.length)) {
        
        if (contrasena.charAt(cont) == " "){
            espacios = true;
            cont++;
        }   
    }
    
    if (espacios) {
        alert ("La contraseña no puede contener espacios en blanco");
        return false;
    }

    if (contrasena.length == 0 || confirmarContrasena.length == 0) {
        alert("Los campos de la password no pueden quedar vacios");
        return false;
    }

    if (contrasena != confirmarContrasena) {
        alert("Las passwords deben de coincidir");
        return false;
    }

    return isValid;
}