removeCampaign = form => {
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
        try {
            if (data.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        $('#view-all').html(res.html);
                        await Swal.fire(
                            'Silme Başarılı !',
                            `${res.message}`,
                            'success'
                        )
                        window.location.reload();
                    },
                    error: function (err) {
                    }
                })
            }
        } catch (ex) {
        }
    });
    return false;
}