
    function AgregarAlCarrito(id) {
        $.ajax({
            url: '/Vender/SeleccionarProducto?id=' + id,
            type: 'POST',
            async: true,
            data: '',
            success: function (resultado) {
                if (resultado == true) {
                    alertify.success('Producto agregado exitosamente');
                }
            }

        });

    }