function EditarCantidadCarrito(id) {
    var SelectId = 'SeleccionarCantidad' + ' ' + id // Se crea el id del select para cantidad, uniendo la palabra SeleccionarCantidad con el id del producto
    var cantidad = document.getElementById(SelectId).value // Se optiene el valor del select y se almacena en cantidad
    $.ajax({
        url: '/Carrito/EditarCantidad?id=' + id + '&cantidad=' + cantidad, // Se envía la petición alcontrolador con los dos parametros (id del auto y cantidad)
        type: 'POST',
        async: true,
        data: '',
        success: function (resultado) {
            if (resultado != true) {
                alertify.success('No se pudo actualizar cantidad');
            }
        }

    });

}