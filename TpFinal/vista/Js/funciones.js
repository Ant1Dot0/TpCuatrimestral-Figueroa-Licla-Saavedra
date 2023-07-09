function guardarID(x) {
    sessionStorage.setItem('idProducto', x);
}

function ConfirmaEliminar() {
    var confirmar = sessionStorage.getItem('idProducto');
    location.href = 'ListaProductos.aspx?id=' + confirmar;

}

