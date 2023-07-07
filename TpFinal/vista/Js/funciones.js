function guardarID(x) {
    sessionStorage.setItem('idProducto', x);
}

function ConfirmaEliminar() {
    window.alert("d");
    alert('d');
    var confirmar = sessionStorage.getItem('idProducto');
    location.href = 'ListaProductos.aspx?id=' + confirmar;

}

