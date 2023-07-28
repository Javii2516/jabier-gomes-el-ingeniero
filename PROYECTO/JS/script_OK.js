document.getElementById("product-details-button").addEventListener("click", function() {
    const purchaseButton = document.getElementById("product-details-button");

    const okButton = document.getElementById("ok-button");

    const purchasePopup = document.getElementById("purchase-popup");

    purchaseButton.addEventListener("click", function () {
    purchasePopup.style.display = "flex";
    });

    okButton.addEventListener("click", function () {
    purchasePopup.style.display = "none";
    });
    console.log("¡Botón Comprar funciona correctamente!");
});
