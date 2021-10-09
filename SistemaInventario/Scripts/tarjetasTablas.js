/*Mostrar tabla y ocultar tarjetas */
function mostrarTabla() {
    var tabla = document.getElementById("tabla");
    var tarjeta = document.getElementById("tarjetas");
    tabla.style.display = "block";
    tarjeta.style.display = "none";
    //Almacenar los datossobre "style.display" de la tabla y 
    //de las tarjetas de manera local
    localStorage.setItem("estadoTabla", tabla.style.display);
    localStorage.setItem("estadoTarjeta", tarjeta.style.display);

}
//Mostrar tarjetas y ocultar tabla
function mostrarTarjeta() {
    var tabla = document.getElementById("tabla");
    var tarjeta = document.getElementById("tarjetas");
    tabla.style.display = "none";
    tarjeta.style.display = "flex";
    //Almacenar datos de manera local
    localStorage.setItem("estadoTabla", tabla.style.display);
    localStorage.setItem("estadoTarjeta", tarjeta.style.display);
}

window.onload = function () {
    //Al recargar la pagina se leeran los datos almacenados en las 
    //variables locales "localStorage.setItem"
    if (localStorage.getItem("estadoTabla") != null) {
        estadoT = localStorage.getItem("estadoTabla");
        document.getElementById('tabla').style.display = estadoT;
    }

    if (localStorage.getItem("estadoTarjeta") != null) {
        estadoTj = localStorage.getItem("estadoTarjeta");
        document.getElementById('tarjetas').style.display = estadoTj;
    }
}