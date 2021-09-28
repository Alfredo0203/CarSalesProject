function AlertaDelete(url, cantidad=0) {
    if (cantidad == 0) {
        Swal.fire({
            title: '¿Esta seguro que desea eliminar este dato?',
            showCancelButton: true,
            icon: 'warning',
            confirmButtonText: 'Aceptar',
            confirmButtonPosition: 'center',
            confirmButtonColor: 'green',
            backgroundColor: 'red',
            toast: 'true',
            timer: 10000,

        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: url,
                    type: 'POST',
                    async: true,
                    data: '',
                })
                Swal.fire('El elemento fue eliminado satiscatoriamente')
                window.location.reload(true)

            }

        })
    }
    else {
        Swal.fire({
            title: '¡Acción no permitida!',
            text: "No puede eliminar autos con cantidad mayor a cero",
            icon: 'error',
            confirmButtonText: 'OK',
            confirmButtonPosition: 'center',
            confirmButtonColor: '#0067b8',
            toast: 'true',
            timer: 5000,
        })
    }
}
