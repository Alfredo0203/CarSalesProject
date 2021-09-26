function AlertDelete() {
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