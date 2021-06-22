$(document).ready(function () {

    const REQUIRED_INPUT_MESSAGE = "Bu alanın doldurulması zorunludur.";
    // Validate comment form
    $('#comment-form').validate({
        rules: {
            "Rating.Comment": {
                required: true,
                maxlength: 120,
                minlength: 2
            },
            "Rating.Point": {
                required: true,
            },
        },
        messages: {
            "Rating.Comment": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "Rating.Point": {
                required: REQUIRED_INPUT_MESSAGE,
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

    $('#comment-form').on('submit', function (event) {

        if ($('#comment-form').valid() === true) {
            var form = document.getElementById('comment-form');
            var action = form.getAttribute("action");
            var formdata = new FormData($("#comment-form")[0]);

            try {
                $.ajax({
                    type: 'POST',
                    url: action,
                    data: formdata,
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        if (res.isValid) {
                            $('#form-modal .modal-body').html('');
                            $('#form-modal .modal-title').html('');
                            $('#form-modal').modal('hide');
                            toastr.success(res.message);
                            setTimeout(() => { window.location.href = res.redirectUrl; }, 1000)
                        }
                        else
                            $('#form-modal .modal-body').html(res.html);
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