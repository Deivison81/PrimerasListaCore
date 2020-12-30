const HEADER_TABLA_COMPLETA = [
	"ID Condición", "Código Condición", "Descripción", "Días de Crédito", "¿Importado Web?", "¿Importado Profit?", "Operaciones"
];

function listar() {
	$.get("Condicion/listarCondiciones", function (data) {
		crearlistado(HEADER_TABLA_COMPLETA, data);
	});
}

function crearlistado(columnas, data) {
	var tabla = document.createElement("table");
	tabla.id = "tabla";
	tabla.classList.add("table", "table-bordered", "table-striped");

	var thead = document.createElement("thead");
	var tr = document.createElement("tr");

	for (var i = 0; i < columnas.length; i++) {
		var td = document.createElement("td");
		td.innerHTML = columnas[i];
		tr.appendChild(td);
	}

	thead.appendChild(tr);
	tabla.appendChild(thead);

	var tbody = document.createElement("tbody");
	var llaves = Object.keys(data[0]);

	for (var i = 0; i < data.length; i++) {
		var tr = document.createElement("tr");
		for (var j = 0; j < llaves.length; j++) {
			var td = document.createElement("td");
			var valorllaves = llaves[j];
			td.innerHTML = data[i][valorllaves];
			tr.appendChild(td);
		}
		
		var llavesId = llaves[0];
		var td = document.createElement("td");

		// Botón Modificar.
		var botonModificar = document.createElement("button");
		botonModificar.classList.add("btn", "btn-primary");
		botonModificar.onclick = abrirModal(data[i][llavesId]);
		botonModificar.setAttribute("data-toggle", "modal");
		botonModificar.setAttribute("data-target", "#myModal");
		var iconoModificar = document.createElement("i");
		iconoModificar.classList.add("far", "fa-edit");
		botonModificar.appendChild(iconoModificar);

		// Botón Eliminar.
		var botonEliminar = document.createElement("button");
		botonEliminar.classList.add("btn", "btn-danger");
		// TODO: Cambiar función para eliminar.
		// botonEliminar.onclick = eliminar(data[i][llavesId]);
		botonEliminar.setAttribute("data-toggle", "modal");
		botonEliminar.setAttribute("data-target", "#myModal");
		var iconoEliminar = document.createElement("i");
		iconoEliminar.classList.add("far", "fa-trash-alt");
		botonEliminar.appendChild(iconoEliminar);

		td.appendChild(botonModificar);
		td.appendChild(botonEliminar);

		tr.appendChild(td);

		tbody.appendChild(tr);
	}

	tabla.appendChild(tbody);

	document.getElementById("contenedor-tabla").appendChild(tabla);
	$("#tabla").dataTable(
		{
			searching: false
		}
	);
}

// TODO: No considera el caso de los <select>.
function borrarDatos() {
	var controles = document.getElementsByClassName("borrar");
	var ncontroles = controles.length;
	for (var i = 0; i < ncontroles; i++) {
		controles[i].value = "";
	}
}

function abrirModal(id = null) {
	var campos = obtenerCamposFormulario();

	for (var clave in campos) {
		campos[clave].classList.remove("is-invalid");
	}

	if (id === null) {
		borrarDatos();

		// Cambiar botón (Agregar o Modificar) según se requiera.
		// En este caso, se oculta el de Modificar y se muestra el de Agregar.
		var modalHeader = document.querySelector("#modal-header > .modal-title");
		modalHeader.innerHTML = "Agregar Condición de Pago";
		document.querySelector("#boton-agregar").style.display = "inline";
		document.querySelector("#boton-modificar").style.display = "none";
	} else {
		borrarDatos();

		if (Number.isNaN(id)) {
			console.error("El id proporcionado no es válido. ID Proporcionado: ", id);
			return;
		}

		$.get("Condicion/listarCondicion/?id=" + id, function (data) {
			document.getElementById("id-condicion-pago").value = data[0].id_condicion;
			document.getElementById("codigo-condicion-pago").value = data[0].co_cond;
			document.getElementById("descripcion-condicion-pago").value = data[0].cond_des;
			document.getElementById("dias-credito").value = data[0].dias_cred;
			document.getElementById("importado-web").value = data[0].importado_web;
			document.getElementById("importado-profit").value = data[0].importado_pro;
		});

		// Cambiar botón (Agregar o Modificar) según se requiera.
		// En este caso, se oculta el de Agregar y se muestra el de Modificar.
		var modalHeader = document.querySelector("#modal-header > .modal-title");
		modalHeader.innerHTML = "Modificar Condición de Pago";
		document.querySelector("#boton-agregar").style.display = "none";
		document.querySelector("#boton-modificar").style.display = "inline";
	}
};

function obtenerCamposFormulario() {
	var codigo = document.getElementById("codigo-condicion-pago");
	var descripcion = document.getElementById("descripcion-condicion-pago");
	var diasCredito = document.getElementById("dias-credito");
	var importadoWeb = document.getElementById("importado-web");
	var importadoProfit = document.getElementById("importado-profit");

	return {
		codigo,
		descripcion,
		diasCredito,
		importadoWeb,
		importadoProfit
	};
}

function obtenerDatosFormulario() {
	var id = document.getElementById("id-condicion-pago").value;
	var codigo = document.getElementById("codigo-condicion-pago").value;
	var descripcion = document.getElementById("descripcion-condicion-pago").value;
	var diasCredito = document.getElementById("dias-credito").value;
	var importadoWeb = document.getElementById("importado-web").value;
	var importadoProfit = document.getElementById("importado-profit").value;

	return {
		id,
		codigo,
		descripcion,
		diasCredito,
		importadoWeb,
		importadoProfit
	};
}

function crearFormData() {
	var frm = new FormData();
	var camposFormulario = obtenerDatosFormulario();

	frm.append("id_condicion", camposFormulario.id);
	frm.append("co_cond", camposFormulario.codigo);
	frm.append("cond_des", camposFormulario.descripcion);
	frm.append("dias_cred", camposFormulario.diasCredito);
	frm.append("importado_web", camposFormulario.importadoWeb);
	frm.append("importado_pro", camposFormulario.importadoProfit);

	return frm;
}

function formularioEsValido() {
	var esValido = true;
	var campos = obtenerCamposFormulario();

	for (var clave in campos) {
		if (campos[clave].value.length === 0) {
			esValido = false;
			campos[clave].classList.add("is-invalid");
		} else {
			campos[clave].classList.remove("is-invalid");
			campos[clave].classList.add("is-valid");
		}
	}

	return esValido;
}

function Agregar() {
	if (formularioEsValido() === true) {
		formulario.classList.add('was-validated');

		var frm = crearFormData();

		if (confirm("Desea Realmente Guardar") == 1) {
			$.ajax({
				type: "POST",
				url: "Condicion/guardarDatos",
				data: frm,
				contentType: false,
				processData: false,
				success: function (data) {
					if (data != 0) {
						listar();
						alert("Se Agregó Correctamente");
						document.getElementById("btnCancelar").click();
					} else {
						alert("prueba");
					}
				}
			});
		}
	}
}

function Modificar() {
	if (formularioEsValido() === true) {
		var frm = crearFormData();

		// TODO: Debería hacerse con PUT en vez de POST.
		if (confirm("Desea Realmente Guardar") == 1) {
			$.ajax({
				type: "POST",
				url: "Condicion/modificarDatos",
				data: frm,
				contentType: false,
				processData: false,
				success: function (data) {
					if (data != 0) {
						listar();
						alert("Se Modificó Correctamente");
						document.getElementById("btnCancelar").click();
					} else {
						alert("prueba");
					}
				}
			});
		}
	}
}

// Llamada cuando se carga del script.
listar();
