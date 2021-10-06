
    function AgregarAlCarrito(id) {
        $.ajax({
            url: '/Carrito/SeleccionarProducto?id=' + id,
            type: 'POST',
            async: true,
            data: '',
            success: function (resultado) {
                if (resultado == true) {
                    alertify.success('Producto agregado exitosamente');
                } else {
                    alertify.success('No se pudo agregar alcarrito');
                }
            }

        });

    }