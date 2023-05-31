function mostrarDescripcion(titulo, texto) {
    var overlay = document.getElementById('descripcion-overlay');
    var popup = document.getElementById('descripcion-popup');
    var tituloElemento = document.getElementById('descripcion-titulo');
    var imagenElemento = document.getElementById('descripcion-imagen');
    var textoElemento = document.getElementById('descripcion-texto');
  
    tituloElemento.textContent = titulo;
    imagenElemento.src = event.target.src;
    textoElemento.textContent = texto;
  
    overlay.style.display = 'block';
    popup.style.display = 'block';
  }
  
  function cerrarDescripcion() {
    var overlay = document.getElementById('descripcion-overlay');
    var popup = document.getElementById('descripcion-popup');
  
    overlay.style.display = 'none';
    popup.style.display = 'none';
  }
  