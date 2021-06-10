$(document).ready(function () {

    $('#user-account-form').on('submit', function (event) {
        const REQUIRED_INPUT_MESSAGE = "Bu alanın doldurulması zorunludur."

        $('#user-account-form').validate({
            rules: {
                "FullName": {
                    required: true,
                    maxlength: 50,
                    minlength: 2
                },
                "NewPassword": {
                    maxlength: 30,
                    minlength: 8
                },
                "RePassword": {
                    maxlength: 30,
                    minlength: 8,
                    equalTo: "#password"
                },
            },
            messages: {
                "FullName": {
                    required: REQUIRED_INPUT_MESSAGE,
                    maxlength: "Bu alan en fazla 50 karakterden oluşabilir",
                    minlength: "Bu alan en az 2 karakterden oluşabilir",
                },
                "NewPassword": {
                    maxlength: "Bu alan en fazla 30 karakterden oluşabilir",
                    minlength: "Bu alan en az 8 karakterden oluşabilir",
                },
                "RePassword": {
                    maxlength: "Bu alan en fazla 30 karakterden oluşabilir",
                    minlength: "Bu alan en az 8 karakterden oluşabilir",
                    equalTo: "Şifreler eşleşmiyor"
                },

            },
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.form-group').append(error);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('is-invalid');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).removeClass('is-invalid');
            }
        });

        if ($('#user-account-form').valid() === true) {
            var form = document.getElementById('user-account-form');
            var action = form.getAttribute("action");
            var formdata = new FormData($("#user-account-form")[0]);
            try {
                $.ajax({
                    type: 'POST',
                    url: action,
                    data: formdata,
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
                            toastr.warning(res.message);
                            setTimeout(() => { window.location.href = res.redirectUrl; }, 2000);
                        }
                    },
                    error: function (err) {
                        Swal.fire('Kayıt Hatası !', 'error')
                    }
                })
                return false;
            } catch (ex) {
                Swal.fire('Kayıt Hatası !', 'error')
            }
        }
        return false;
    });
});