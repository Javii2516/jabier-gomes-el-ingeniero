var cartItems = JSON.parse(localStorage.getItem("cart"));

function eliminarDelCarrito(index) {
    cartItems.splice(index, 1);
    localStorage.setItem("cart", JSON.stringify(cartItems));
    showProductsInCart();
}

function calcularSumaTotal() {
    var total = 0;

    cartItems.forEach(function (product) {
        total += product.price;
    });

    return total; 
}

function showProductsInCart() {
    var cartTable = document.getElementById("cart-table");
    var totalPriceParagraph = document.getElementById("total-price");
    var comprarButton = document.getElementById("comprar-button");

    cartTable.innerHTML = "";

    cartItems.forEach(function (product, index) {
        var row = cartTable.insertRow();
        var nameCell = row.insertCell(0);
        var priceCell = row.insertCell(1);
        var deleteCell = row.insertCell(2);

        nameCell.textContent = product.name;
        priceCell.textContent = "$" + product.price;

        var deleteButton = document.createElement("button");
        deleteButton.textContent = "Eliminar";
        deleteButton.addEventListener("click", function () {
            eliminarDelCarrito(index);
        });
        deleteCell.appendChild(deleteButton);
    });

    totalPriceParagraph.textContent = "Total: $" + calcularSumaTotal();
     
        comprarButton.addEventListener("click", function () {
            var confirmCompra = window.confirm("¿Estás seguro que quieres comprar todo el carrito?");
            
            if (calcularSumaTotal() === 0) {
                window.alert("El carrito está vacío");
            }else{
                if (confirmCompra) {
                    window.alert("¡Se compró todo el carrito!");
                } 
            }
        });
}

window.addEventListener("load", function () {
    showProductsInCart();
});
