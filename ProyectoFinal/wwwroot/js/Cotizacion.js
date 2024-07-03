
let datatable;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar pagina _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Cotizacions/ObtenerTodos"
        },
        "columns": [
            { "data": "nombre", "width": "20%" },
            { "data": "correo", "width": "40%" },
            { "data": "tema", "width": "40%" },
            {
                "data": "presupuesto", 

                "render": function (data) {

                    var ann = data.toLocaleString('en-US', { style: 'decimal', maximumFractionDigits: 0, minimumFractionDigits: 0, useGrouping: true });
                    return ann;
                },


            },
            { "data": "mensaje", "width": "40%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == null) {
                        return "Por Revisar";
                    }
                    else {
                        return "Revisado";
                    }
                }, "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div>
                            <a href="/Cotizacions/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                            <i class="bi bi-pencil-square"></i>
                            </a>
                            <a onclick=Delete("/Cotizacions/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                            <i class="bi bi-trash3-fill"></i>
                            </a>
                        </div>
                    `;
                }, "width": "20%"
            }
        ]
    });
}




function Delete(url) {

    swal({
        title: "Esta seguro de eliminar el cotizacion",
        text: "Este registro no se podra recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
