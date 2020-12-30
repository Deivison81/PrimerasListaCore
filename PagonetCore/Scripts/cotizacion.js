const HEADER_TABLA_COMPLETA = [
    "ID Número de Documento", "Número de Documento", "Número de Renglón", "ID Artículo", "Código Artículo",
    "Descripción Artículo", "Código Almacén", "Código Almacén", "Total Artículos", "Subtotal Artículos",
    "Código Unidad", "ID Precio Artículos", "Código Precios", "Precio de Venta", "Precio de Venta OM",
    "Tipo Impuesto", "Tipo Impuesto 2", "Tipo Impuesto 3", "Porcentaje Impuesto", "Porcentaje Impuesto 2",
    "Porcentaje Impuesto 3", "Monto Impuesto", "Monto Impuesto 2", "Monto Impuesto 3", "Renglón Neto",
    "Tipo de Documento", "Número de Documento", "¿Importado Web?", "¿Importado Profit?"
];

$("#dtfechainicio").datepicker(
    {
       dateFormat: "dd/mm/yy",
       changeMonth: true,
       changeYear: true
    }
)
$("#dtfechavenci").datepicker(
    {
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    }
)
$("#tdemisionpop").datepicker(
    {
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    }
)
$("#tdvencimipop").datepicker(
    {
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    }
)
$("#tdregispop").datepicker(
    {
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    }
)

listarr();

function listarr() {
    $.get("cotizacion/listarRenglones", function (data) {

        crearlistado(HEADER_TABLA_COMPLETA, data);

    });
}

$.get("Cotizacion/listarTransporte", function (data) {

   
    llenarCombo(data, document.getElementById("cbotransporte"), true);

});
$.get("Cotizacion/listarVendedor", function (data) {


    llenarCombo(data, document.getElementById("cbovendedor"), true);

});

$.get("Cotizacion/listarCliente", function (data) {


    llenarCombo(data, document.getElementById("cbocliente"), true);
   
});
$.get("cotizacion/listarCondicion", function (data) {


    llenarComboCond(data, document.getElementById("cbocondicion"), true);
   
});

$.get("cotizacion/listarCotizacion", function (data) {


    document.getElementById("txtnrocotizacion").value = data[0].id_doc_num;
    document.getElementById("dtfechainicio").value = data[0].FECHAINI;
    document.getElementById("dtfechavenci").value = data[0].FEVENC;
    
    
});


function crearlistado(arrayColumna, data) {
    var contenido = "";
    contenido += "<table id='tablas' class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";
    for (var i = 0; i < arrayColumna.length; i++) {
        contenido += "<td>";
        contenido += arrayColumna[i];
        contenido += "</td>";

    }

    contenido += "<td>Operaciones<td>";
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
        contenido += "<button class='btn btn-success' onclick='abrirModalr(" + data[i][llavesId] + ")' data-toggle='modal' data-target='#myModal2'><i class = 'glyphicon glyphicon-edit'></i></button> ";
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




function llenarCombo(data, control, primerelemento) {

    var contenido = "";

    if (primerelemento == true) {
        contenido += "<option value= ''>--selecione--</option>";

    }
    for (i = 0; i < data.length; i++) {
        contenido += "<option value ='" + data[i].IID + "'>";

        contenido += data[i].CODIGO;

        contenido += data[i].NOMBRE;

        contenido += "</option>";
    }
    control.innerHTML = contenido;
}

function llenarComboCond(data, control, primerelemento) {

    var contenido = "";

    if (primerelemento == true) {
        contenido += "<option value= ''>--selecione--</option>";

    }
    for (i = 0; i < data.length; i++) {
        contenido += "<option value ='" + data[i].IID + "'>";

        contenido += data[i].CODIGO;

        contenido += data[i].NOMBRE;

        contenido += data[i].DIAS;

        contenido += "</option>";
    }
    control.innerHTML = contenido;
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
        $.get("cotizacion/listarcotizacionid/?id=" + id, function (data) {
            document.getElementById("txtidcotipop").value = data[0].id_doc_num;
            document.getElementById("txtcodigpop").value = data[0].doc_num;
            document.getElementById("txtdescotipop").value = data[0].descrip;
            document.getElementById("txtidclientepop").value = data[0].id_clientes;
            document.getElementById("txtcoclipop").value = data[0].co_cli;
            document.getElementById("txtidtranspop").value = data[0].idtransporte;
            document.getElementById("txtcotranspop").value = data[0].co_tran;
            document.getElementById("txtcomonepop").value = data[0].co_mone;
            document.getElementById("txtidvendepop").value = data[0].id_vendedor;
            document.getElementById("txtcovendepop").value = data[0].co_ven;
            document.getElementById("txtidcondipop").value = data[0].id_condicion;
            document.getElementById("txtcocodipop").value = data[0].co_cond;
            document.getElementById("tdemisionpop").value = data[0].FECHAINI;
            document.getElementById("tdvencimipop").value = data[0].FEVENC;
            document.getElementById("tdregispop").value = data[0].FECREG;
            document.getElementById("txttbrutopop").value = data[0].total_bruto;
            document.getElementById("txtmontoivapop").value = data[0].monto_imp;
            document.getElementById("txtnetopop").value = data[0].total_neto;
        });

    }

}

function abrirModalr(id) {
    var controlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorios.length;
    for (var i = 0; i < ncontroles; i++) {
        controlesObligatorios[i].parentNode.classList.remove("error");
    }

    if (id == 0) {
        borrarDatos();

    } else {
        $.get("cotizacion/listarRenglonesid/?id=" + id, function (data) {
            document.getElementById("txtidcotipoop").value = data[0].id_doc_num;
            document.getElementById("txtcodigpoop").value = data[0].doc_num;
            document.getElementById("txtrenglonpop").value = data[0].reng_num;
            document.getElementById("txtidarticulopop").value = data[0].id_art;
            document.getElementById("txtcoartpop").value = data[0].co_art;
            document.getElementById("txtartdescripop").value = data[0].art_des;
            document.getElementById("txtcodalmapop").value = data[0].cod_almacen;
            document.getElementById("txtcodalmapropop").value = data[0].co_alma;
            document.getElementById("txtcatidadpop").value = data[0].total_art;
            document.getElementById("txtcantidadacumpop").value = data[0].stotal_art;
            document.getElementById("txtcounipop").value = data[0].cod_unidad;
            document.getElementById("txtidpreciospop").value = data[0].id_preciosart;
            document.getElementById("txtcopreciopop").value = data[0].co_precios;
            document.getElementById("txtpreciospop").value = data[0].prec_vta;
            document.getElementById("txtpreciosompop").value = data[0].prec_vta_om;
            document.getElementById("txtporcentajepop").value = data[0].porc_imp;
            document.getElementById("txtmontopop").value = data[0].monto_imp;
            document.getElementById("txttotalrenglonpop").value = data[0].reng_neto;
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

//agregar

function Agregar() {
    if (datosObligatorios() == true) {
        var frm = new FormData();
        var id = document.getElementById("txtidcotipop").value;
        var codigoc = document.getElementById("txtcodigpop").value;
        var descrip = document.getElementById("txtdescotipop").value;
        var idcliente = document.getElementById("txtidclientepop").value;
        

        var codigocl = document.getElementById("txtcoclipop").value;
        var idtransporte = document.getElementById("txtidtranspop").value;
        var cotransporte = document.getElementById("txtcotranspop").value;
        var codigomoneda = document.getElementById("txtcomonepop").value;
        var idvendedor = document.getElementById("txtidvendepop").value;
        var covendedor = document.getElementById("txtcovendepop").value;
        var idcondicion = document.getElementById("txtidcondipop").value;
        var cocondicion = document.getElementById("txtcocodipop").value;
        var fechainicio = document.getElementById("tdemisionpop").value;
        

        var fechavencimiento = document.getElementById("tdvencimipop").value;
        var fecharegistro = document.getElementById("tdregispop").value;
        var bruto = document.getElementById("txttbrutopop").value;
        var IVA = document.getElementById("txtmontoivapop").value;
        var Total = document.getElementById("txttbrutopop").value;

        frm.append("id_doc_num", id);
        frm.append("doc_num", codigoc);
        frm.append("descrip", descrip);
        frm.append("id_clientes", idcliente);
        frm.append("co_cli", codigocl);
        frm.append("idtransporte", idtransporte);
        frm.append("co_tran", cotransporte);
        frm.append("co_mone", codigomoneda);
        frm.append("id_vendedor", idvendedor);
        frm.append("co_ven", covendedor);
        frm.append("id_condicion", idcondicion);
        frm.append("co_cond", cocondicion);
        frm.append("FECHAINI", fechainicio);
        frm.append("FEVENC", fechavencimiento);
        frm.append("FECREG", fecharegistro);
        frm.append("anulado", 0);
        frm.append("status", 0);
        frm.append("total_bruto", bruto);
        frm.append("monto_imp", IVA);
        frm.append("monto_imp2", 0);
        frm.append("monto_imp3", 0);
        frm.append("total_neto", Total);
        frm.append("saldo", Total);
        frm.append("importado_web", 1);
        frm.append("importado_pro", 0);
        frm.append("Diasvencimiento", 3);
        frm.append("nro_pedido", 0);
        frm.append("vencida", 0);
        
        
        if (confirm("Desea Realmente Guardar") == 1) {

            $.ajax({
                type: "POST",
                url: "cotizacion/guardarDatos",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        //listar();
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

//Agregar renglones

function Agregarr() {
    
        var frm = new FormData();
        var id = document.getElementById("txtidcotipoop").value;
        
        var codigocoti = document.getElementById("txtcodigpoop").value;
        
        var nrorenglon = document.getElementById("txtcodigpoop").value;
        var idarticulo = document.getElementById("txtidarticulopop").value;
        var codart = document.getElementById("txtcoartpop").value;
        var desart = document.getElementById("txtartdescripop").value;
        var idalma = document.getElementById("txtcodalmapop").value;
        var coalma = document.getElementById("txtcodalmapropop").value;
        var cantidad = document.getElementById("txtcatidadpop").value;
        var cantidadreng = document.getElementById("txtcantidadacumpop").value;
        var counidad = document.getElementById("txtcounipop").value;
        var idprecios = document.getElementById("txtidpreciospop").value;
        var codprecio = document.getElementById("txtcopreciopop").value;
        var precio = document.getElementById("txtpreciospop").value;
        var precioom = document.getElementById("txtpreciosompop").value;
        var porcentajeiva = document.getElementById("txtporcentajepop").value;
        var IVA = document.getElementById("txtmontopop").value;
        var TotalR = document.getElementById("txttotalrenglonpop").value;

        frm.append("id_doc_num", id);
        frm.append("doc_num", codigocoti);
        frm.append("reng_num", nrorenglon);
        frm.append("id_art", idarticulo);
        frm.append("co_art", codart);
        frm.append("art_des", desart);
        frm.append("cod_almacen", idalma);
        frm.append("co_alma", coalma);
        frm.append("total_art", cantidad);
        frm.append("stotal_art", cantidadreng);
        frm.append("cod_unidad", counidad);
        frm.append("id_preciosart", idprecios);
        frm.append("co_precios", codprecio);
        frm.append("prec_vta", precio);
        frm.append("prec_vta_om", precioom);
        frm.append("tipo_imp", 1);
        frm.append("tipo_imp2", 0);
        frm.append("tipo_imp3", 0);
        frm.append("porc_imp", porcentajeiva);
        frm.append("porc_imp2", 0);
        frm.append("porc_imp3", 0);
        frm.append("monto_imp", IVA);
        frm.append("monto_imp2", 0);
        frm.append("monto_imp3", 0);
        frm.append("reng_neto", TotalR);
        frm.append("tipo_doc", 0);
        frm.append("num_doc", 0);
        frm.append("importado_web", 1);
        frm.append("importado_pro", 0);
        


        if (confirm("Desea Realmente Guardar") == 1) {

            $.ajax({
                type: "POST",
                url: "cotizacion/guardarDatosreng",
                data: frm,
                contentType: false,
                processData: false,
                
                success: function (data) {
                    
                    if (data != 0) {
                        
                        alert("Se Agrego Correctamente");
                        document.getElementById("btnCancelar").click();
                    } else {
                        alert("Por favor Verifique sus datos");
                    }
                }
            });
        }
    

}

