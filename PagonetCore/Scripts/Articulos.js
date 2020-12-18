const HEADER_TABLA_COMPLETA = [
    "ID Producto", "Código Producto", "Descripción", "Artículo de Referencia", "Unidad", "ID Precio", "Código Precio Profit", "Precio desde",
    "Precio hasta", "Monto Precio", "Precio 1", "Precio 2", "Precio 3", "Precio 4", "Precio 5", "Precio OM", "ID Imagen", "Ad tip",
    "Nombre Imagen", "Ruta", "Código Almacén", "Almacén Profit", "Descripción Almacén", "Código Artículo Profit", "Tipo de Stock",
    "Cantidades", "Página Web"
];

listar();

function listar() {
    $.get("Articulo/listarartweb", function (data) {

        crearlistado(HEADER_TABLA_COMPLETA, data);   
    });
}

function crearlistado(arrayColumna, data) {
    var contenido = "";
    contenido += "<table id='tablas' class='table table-bordered table-striped'>";
    contenido += "<thead>";
    contenido += "<tr>";
    for (var i = 0; i < arrayColumna.length; i++) {
        contenido += "<td>";
        contenido += arrayColumna[i];
        contenido += "</td>";

    }

    contenido += "<td>Operaciones</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    var llaves = Object.keys(data[0]);
    contenido += "<tbody>";
    for (var i = 0; i < data.length; i++) {
        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {

            var valorllaves = llaves[j];
            contenido += "<td>";

            contenido += data[i][valorllaves];

            contenido += "</td>";

        }
        var llavesId = llaves[0];
        contenido += "<td>";
        contenido += "<button class='btn btn-primary' onclick='abrirModal(" + data[i][llavesId] + ")' data-toggle='modal' data-target='#myModal'><i class = 'glyphicon glyphicon-edit'></i></button> ";
        contenido += "<button class='btn btn-danger' onclick='eliminar(" + data[i][llavesId] + ")'><i class = 'glyphicon glyphicon-trash'></i></button> ";
        contenido += "</td>";
        contenido += "</tr>";
    }


    contenido += "</tbody>";

    contenido += "</table>";
    document.getElementById("tabla").innerHTML = contenido;
    $("#tablas").dataTable(
        {
            searching: false
        });
}
