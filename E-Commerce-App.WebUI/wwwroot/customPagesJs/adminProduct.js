$(document).ready(function () {

    // Trumbowyg language
    $('#html-editor').trumbowyg({
        lang: 'tr'
    });

    // Url creator
    $('#productName').keyup(function () {

        const trCharsMap = {
            Ç: 'C', Ö: 'O', Ş: 'S', İ: 'I', I: 'i', Ü: 'U', Ğ: 'G',
            ç: 'c', ö: 'o', ş: 's', ı: 'i', ü: 'u', ğ: 'g'
        };

        var text = $('#productName').val();

        for (var char in trCharsMap) {
            text = text.replace(new RegExp('[' + char + ']', 'g'), trCharsMap[char]);
        }
        var url = text.replace(/[^-a-zA-Z0-9\s]+/ig, '')
            .replace(/\s/gi, "-")
            .replace(/[-]+/gi, "-")
            .toLowerCase();

        $('#productUrl').val(url);
    });

    const REQUIRED_INPUT_MESSAGE = "Bu alanın doldurulması zorunludur.";

    $('#product-form').validate({
        rules: {
            "ProductDto.Name": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "ProductDto.Price": {
                required: true,
                minlength: 1,
                maxlength: 100000,
            },
            "ProductDto.Discount": {
                minlength: 1,
                maxlength: 95,
            },
            "ProductDto.ShortDescription": {
                required: true,
            },
            mainImage: {
                required: $("#mainImageId").val() === "" && $("#imgpreview").attr('src') === undefined,
                extension: "png|jpg|JPEG|svg|"
            },
            "allImages[]": {
                extension: "png|jpg|JPEG|svg|JFIF|GIF",
                maxsize: 20971520,
            },
        },
        messages: {
            "ProductDto.Name": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "ProductDto.Price": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "Ürün fiyatı en az 1₺ olabilir.",
                maxlength: "Ürün fiyatı en fazla 100000₺ olabilir.",
            },
            "ProductDto.Discount": {
                minlength: "İndirim bedeli en az % 1 olabilir.",
                maxlength: "Ürün fiyatı en fazla % 95 olabilir.",
            },
            "ProductDto.ShortDescription": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            mainImage: {
                required: REQUIRED_INPUT_MESSAGE,
                extension: "Yalnızca resim formatında ekleme yapabilirsiniz."
            },
            "allImages[]": {
                extension: "Yalnızca resim formatında ekleme yapabilirsiniz.",
                maxsize: "Tüm resimler en fazla 20 MB boyutunda olabilir."
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

    $('#product-form').on('submit', function (event) {
        if ($('#product-form').valid() === true) {


            const addUrlRegex = new RegExp('\/Admin\/Product\/Add');
            const editUrlRegex = new RegExp('\/Admin\/Product\/Edit\/');
            const editUrlRegex2 = new RegExp('\/Admin\/Product\/Edit\/[a-z]*|[0-9]*');

            var url = window.location.pathname;
            var actionUrl = "";

            if (addUrlRegex.test(url)) {
                actionUrl = url;
            } else if (editUrlRegex.test(url) || editUrlRegex2(url)) {
                actionUrl = url;
            }
            var formData = new FormData($('#product-form')[0]);

            $.ajax({
                type: 'POST',
                url: actionUrl,
                data: formData,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        Swal.fire(
                            'Kayıt Başarılı !',
                            `${res.message}`,
                            'success'
                        )
                    }
                    else
                        Swal.fire(
                            'Kayıt Hatası !',
                            `${res.message}`,
                            'error'
                        )
                },
                error: function (err) {
                    console.log(err)
                }
            });
            return false;
        }
    });

});

// Show image preview realtime
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

// show multiple image preview realtime
function previewFiles() {
    var preview = document.querySelector('#preview');
    var files = document.querySelector('#browse').files;
    preview.innerHTML = "";
    function readAndPreview(file) {
        // Make sure `file.name` matches our extensions criteria
        if (/\.(jpe?g|png|gif)$/i.test(file.name)) {
            var reader = new FileReader();
            reader.addEventListener("load", function () {
                var image = new Image();
                image.height = 100;
                image.title = file.name;
                image.src = this.result;
                preview.appendChild(image);
            }, false);
            reader.readAsDataURL(file);
        }
    }
    if (files) {
        [].forEach.call(files, readAndPreview);
    }
}