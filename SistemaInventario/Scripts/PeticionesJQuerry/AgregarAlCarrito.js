
    function AgregarAlCarrito(id) {
        $.ajax({
            url: '/Carrito/SeleccionarProducto?id=' + id,
            type: 'POST',
            async: true,
            data: '',
            success: function (resultado) {
                if (resultado == true) {
                    alertify.success('Producto agregado exitosamente');
                    window.location.reload(true);
                } else if (resultado == "Ya existe") {
                    alertify.success('Ya existe en carrito');
                }
            }

        });

    }