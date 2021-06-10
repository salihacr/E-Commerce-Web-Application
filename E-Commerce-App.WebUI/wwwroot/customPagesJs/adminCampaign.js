$(document).ready(function () {
    $('#campaign-form').on('submit', function (event) {

        const REQUIRED_INPUT_MESSAGE = "Bu alanın doldurulması zorunludur.";

        $('#campaign-form').validate({
            rules: {
                "Name": {
                    required: true,
                    maxlength: 50,
                    minlength: 2
                },
                "ImageAltTag": {
                    required: true,
                    maxlength: 120,
                    minlength: 2
                },
                campainImage: {
                    required: ($("#campainImageId").val() === "" && $("#imgpreview").attr('src') === undefined),
                    extension: "png|jpg|JPEG|svg|JFIF|GIF",
                    maxsize: 200000,
                },
            },
            messages: {
                "Name": {
                    required: REQUIRED_INPUT_MESSAGE,
                },
                "ImageAltTag": {
                    required: REQUIRED_INPUT_MESSAGE,
                },
                campainImage: {
                    required: REQUIRED_INPUT_MESSAGE,
                    extension: "Bu alan yalnızca resim dosyalarını kabul etmektedir.",
                    maxsize: "Resim boyutu en fazla 2 MB olabilir",
                }
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

        if ($('#campaign-form').valid() === true) {

            var form = document.getElementById('campaign-form');
            var action = form.getAttribute("action");
            var formdata = new FormData($("#campaign-form")[0]);

            try {
                $.ajax({
                    type: 'POST',
                    url: action,
                    data: formdata,
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {
                            $('#view-all').html(res.html)
                            $('#form-modal .modal-body').html('');
                            $('#form-modal .modal-title').html('');
                            $('#form-modal').modal('hide');
                            Swal.fire(
                                'Kayıt Başarılı !',
                                `${res.message}`,
                                'success'
                            )
                        }
                        else
                            $('#form-modal .modal-body').html(res.html);
                    },
                    error: function (err) {
                    }
                })
                return false;
            } catch (ex) {
            }
        }
        return false;
    });
});
function showpreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imgpreview').css('display', 'block');
            $('#imgpreview').attr('src', e.target.result);
            $('#imgpreview').fadeIn(650);
        }
        reader.readAsDataURL(input.files[0]);
    }
}