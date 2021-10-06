function myFunction() {
    var marc = document.getElementById("marca").value.trim();
    var model = document.getElementById("modelo").value.trim();
    if (marc == model) {
        alert("Son iguales");
    }

}