$(document).ready(function () {
    $("#orders-table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["excel", "csv"]
    }).buttons().container().appendTo('#orders-table_wrapper .col-md-6:eq(0)');
});