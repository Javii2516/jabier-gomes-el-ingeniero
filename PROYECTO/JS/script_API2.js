        document.getElementById('comprar-button').addEventListener('click', function () {
            var totalCompra = 100; 

            paypal.Buttons({
                createOrder: function (data, actions) {
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: totalCompra
                            }
                        }]
                    });
                },
                onApprove: function (data, actions) {
                    alert('¡Gracias por tu compra! Tu pago ha sido procesado correctamente.');
                },
                onError: function (err) {
                    alert('Ocurrió un error al procesar el pago con PayPal. Por favor, intenta nuevamente.');
                }
            }).render('#comprar-button');
        });