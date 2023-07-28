var codigoAleatorio = Math.floor(100000 + Math.random() * 900000);
        
alert('El número aleatorio generado es: ' + codigoAleatorio);

document.querySelector('form').addEventListener('submit', function(e) {
    e.preventDefault();
    var codigoIngresado = document.querySelector('input[name="codigo"]').value;
    
    if (codigoIngresado === codigoAleatorio.toString()) {
        window.location.href = "../HTML/index.html";
    } else {
        alert('Código inválido. Inténtalo de nuevo.');
    }
});