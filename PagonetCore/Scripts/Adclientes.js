const HEADER_TABLA_COMPLETA = [
    "ID Cliente", "Código Cliente", "ID Tipo Cliente", "Tipo Cliente", "Descripción Cliente",
    "Dirección 1", "Dirección 2", "Teléfono", "¿Inactivo?", "Responsable", "ID Zona",
    "Código Zona", "ID Segmento", "Código Segmento", "ID Vendedor", "Código Vendedor",
    "ID Ingresoe", "Código Cuenta Ingreso/Egreso", "RIF", "E-mail", "¿Jurídico?",
    "Ciudad", "ZIP", "Código País", "TIP", "Código Comercio", "¿Importado Web?", "¿Importado Profit?"
];

const HEADER_TABLA_CODIGO = [
    "ID Cliente", "Código Cliente"
];

listar();

function listar() {
    $.get("Cliente/listaCliente", function (data) {

        crearlistado(HEADER_TABLA_COMPLETA, data);

    });
}

function listarcodigos(){
    $.get("Cliente/Validacodigo", function (data) {

        crearlistado(HEADER_TABLA_CODIGO, data);

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

function abrirModal(id) {
    var controlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorios.length;
    for (var i = 0; i < ncontroles; i++) {
        controlesObligatorios[i].parentNode.classList.remove("error");
    }

    if (id == 0) {
        borrarDatos();

    } else {
        $.get("Cliente/listaClientes/?id=" + id, function (data) {
            document.getElementById("txtidclientes").value = data[0].id_clientes;
            document.getElementById("txtcodigoZ").value = data[0].co_zon;
            document.getElementById("txtzonades").value = data[0].zon_des;
        });

    }

}

function borrarDatos() {
    var controles = document.getElementsByClassName("borrar");
    var ncontroles = controles.length;
    for (var i = 0; i < ncontroles; i++) {
        controles[i].value = "";
    }
}

function datosObligatorios() {

    var exito = true;
    var controlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorios.length;

    for (var i = 0; i < ncontroles; i++) {
        if (controlesObligatorios[i].value == "") {
            exito = false;
            controlesObligatorios[i].parentNode.classList.add("error");
        } else {
            controlesObligatorios[i].parentNode.classList.remove("error");
        }
    }
    return exito;
}

function Agregar() {
    if (datosObligatorios() == true) {
        var frm = new FormData();
        var id = document.getElementById("txtzona").value;
        var codigo = document.getElementById("txtcodigoZ").value;
        var zona = document.getElementById("txtzonades").value;
        frm.append("id_zona", id);
        frm.append("co_zon", codigo);
        frm.append("zon_des", zona);
        frm.append("importado_web", 1);

        if (confirm("Desea Realmente Guardar") == 1) {

            $.ajax({
                type: "POST",
                url: "Zona/guardarDatos",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        listar();
                        alert("Se Agrego Correctamente");
                        document.getElementById("btnCancelar").click();
                    } else {
                        alert("prueba");
                    }
                }
            });
        }
    } else {

        alert("LLENA LOS DATOS QUE FALTAN");
    }

}

