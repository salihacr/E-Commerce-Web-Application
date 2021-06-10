$(document).ready(function () {
    $('#form-order-state').on('submit', function (event) {
        var formData = new FormData($('#form-order-state')[0]);
        $.ajax({
            type: 'POST',
            url: "/Admin/Order/EditOrderState",
            data: formData,
            contentType: false,
            processData: false,
            success: async function (res) {
                if (res.success) {
                    await Swal.fire(
                        'Kayıt Başarılı !',
                        `${res.message}`,
                        'success'
                    )
                    window.location.href = res.redirectUrl;
                } else {
                    Swal.fire(
                        'Kayıt Hatası !',
                        `${res.message}`,
                        'error'
                    )
                }
            },
            error: function (err) {
                toastr.error("Beklenmedik bir hata meydana geldi");
            }
        });
        return false;
    });
});