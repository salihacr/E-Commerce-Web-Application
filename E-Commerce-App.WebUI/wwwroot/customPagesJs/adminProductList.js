$(document).ready(function () {
    $("#products-table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["excel", "csv"]
    }).buttons().container().appendTo('#products-table_wrapper .col-md-6:eq(0)');
});

function removeProduct(id) {
    Swal.fire({
        title: "Silmek istediğinizden emin misiniz ?",
        text: 'Silinen veri geri kullanılamaz!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil !',
        cancelButtonText: 'İptal !'
    }).then((data) => {
        console.log(data);
        try {
            if (data.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: "/Admin/Product/DeleteProduct/" + id,
                    data: "{id:'" + id + "'}",
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        console.log(res);
                        await Swal.fire(
                            'Silme Başarılı !',
                            `${res.message}`,
                            'success'
                        )
                        window.location.reload();
                    },
                    error: function (err) {
                        console.log(err.responseText);
                        Swal.fire(
                            'Silme Hatası !',
                            `${err}`,
                            'error'
                        )
                    }
                })
            }
        } catch (ex) {
        }
    });
}