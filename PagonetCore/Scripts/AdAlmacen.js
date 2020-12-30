const HEADER_TABLA_COMPLETA = [
    "ID Almacén", "Código Almacén", "Descripción Almacén", "¿Web?",
    "Código de Usuario Profit", "¿Importado Web?", "¿Importado Profit?"
];

//cargar datos
listar();

function listar() {
    $.get("Almacen/listarAlmacen", function (data) {

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

//modal
function abrirModal(id) {
    var controlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorios.length;
    for (var i = 0; i < ncontroles; i++) {
        controlesObligatorios[i].parentNode.classList.remove("error");
    }

    if (id == 0) {
        borrarDatos();

    } else {
        $.get("Almacen/listarAlmacens/?id=" + id, function (data) {
            document.getElementById("txticod_almacen").value = data[0].cod_almacen;
            document.getElementById("txtco_alma").value = data[0].co_alma;
            document.getElementById("txtdes_alamacen").value = data[0].des_alamacen;
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

//Cargar Combos



function Agregar() {
    if (datosObligatorios() == true) {
        var frm = new FormData();
        var id = document.getElementById("txtzonatxticod_almacen").value;
        var codigo = document.getElementById("txtco_alma").value;
        var almacen = document.getElementById("txtdes_alamacen").value;
        frm.append("cod_almacen", id);
        frm.append("co_alma", codigo);
        frm.append("des_alamacen", almacen);
        frm.append("web", 1);
        frm.append("co_user_prof", 999);
        frm.append("importado_web", 1);
     

        if (confirm("Desea Realmente Guardar") == 1) {

            $.ajax({
                type: "POST",
                url: "Almacen/guardarDatos",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        listar();
                        alert("Se Agrego Correctamente");
                        document.getElementById("btnCancelar").click();
                    } else {
                        alert("Por favor Verifique sus datos");
                    }
                }
            });
        }
    } else {

        alert("LLENA LOS DATOS QUE FALTAN");
    }

}
