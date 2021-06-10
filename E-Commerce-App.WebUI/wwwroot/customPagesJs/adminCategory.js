$(document).ready(function () {

    // Category Url Creator
    $('#categoryName').keyup(function () {
        const trCharsMap = {
            Ç: 'C', Ö: 'O', Ş: 'S', İ: 'I', I: 'i', Ü: 'U', Ğ: 'G',
            ç: 'c', ö: 'o', ş: 's', ı: 'i', ü: 'u', ğ: 'g'
        };

        var text = $('#categoryName').val();

        for (var char in trCharsMap) {
            text = text.replace(new RegExp('[' + char + ']', 'g'), trCharsMap[char]);
        }
        var url = text.replace(/[^-a-zA-Z0-9\s]+/ig, '')
            .replace(/\s/gi, "-")
            .replace(/[-]+/gi, "-")
            .toLowerCase();

        $('#categoryUrl').val(url);
    });

    // Submit category add edit form
    $('#category-form').on('submit', function (event) {

        const REQUIRED_INPUT_MESSAGE = "Bu alanın doldurulması zorunludur."

        $('#category-form').validate({
            rules: {
                "Name": {
                    required: true,
                    maxlength: 50,
                    minlength: 2
                },
            },
            messages: {
                "Name": {
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

        if ($('#category-form').valid() === true) {
            var form = document.getElementById('category-form');
            var action = form.getAttribute("action");
            var formdata = new FormData($("#category-form")[0]);
            try {
                $.ajax({
                    type: 'POST',
                    url: action,
                    data: formdata,
                    contentType: false,
                    processData: false,
                    success: async function (res) {
                        if (res.isValid) {
                            $('#view-all').html(res.html)
                            $('#form-modal .modal-body').html('');
                            $('#form-modal .modal-title').html('');
                            $('#form-modal').modal('hide');
                            await Swal.fire(
                                'Kayıt Başarılı !',
                                `${res.message}`,
                                'success'
                            )
                            window.location.reload();
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
        event.preventDefault();
        return false;
    });
});