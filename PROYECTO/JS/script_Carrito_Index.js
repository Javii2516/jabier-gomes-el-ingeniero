function mostrarCarrito() {
    var carritoLista = document.getElementById("carrito-lista");
    carritoLista.innerHTML = ""; 
    var carrito = JSON.parse(localStorage.getItem("carrito") || "[]");

    carrito.forEach(function(product) {
        var listItem = document.createElement("li");
        listItem.textContent = product.name;
                
        var deleteButton = document.createElement("button");
        deleteButton.textContent = "Eliminar";
        deleteButton.addEventListener("click", function() {
        eliminarProducto(product);
        });

        listItem.appendChild(deleteButton);
        carritoLista.appendChild(listItem);
    });
}

function eliminarProducto(product) {
    var carrito = JSON.parse(localStorage.getItem("carrito") || "[]");

    var index = carrito.findIndex(function(item) {
        return item.name === product.name;
    });

    if (index !== -1) {
        carrito.splice(index, 1);
        localStorage.setItem("carrito", JSON.stringify(carrito));
        mostrarCarrito();
        }
}

function limpiarCarrito() {
    localStorage.removeItem("carrito");
    mostrarCarrito();
}

mostrarCarrito();

var limpiarCarritoButton = document.getElementById("limpiar-carrito");
limpiarCarritoButton.addEventListener("click", limpiarCarrito);

    buyButton.addEventListener("click", function() {
        console.log("¡Producto comprado!");

        var carrito = JSON.parse(localStorage.getItem("carrito") || "[]");
        carrito.push(product);

        localStorage.setItem("carrito", JSON.stringify(carrito));
    });

