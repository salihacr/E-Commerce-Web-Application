$(document).ready(function () {

    // Initialize payment card
    var card = new Card({
        form: '#payment-form',
        container: '.credit-card',
        formSelectors: {
            numberInput: 'input#number',
            expiryInput: 'input#expiry',
            cvcInput: 'input#cvc',
            nameInput: 'input#name'
        },
        placeholders: {
            number: '•••• •••• •••• ••••',
            name: 'AD SOYAD',
            expiry: '••/••',
            cvc: '•••'
        }
    });

    $('#expiry').keyup(function () {
        var expiry = $("#expiry").val();
        var arr = expiry.split("/");
        $("#expiry-month").val(arr[0].trim());
        $("#expiry-year").val(arr[1].trim());
    });

    // Get cities from json file
    $.getJSON("/json/tr-iller-bolgeler.json", function (sonuc) {
        $.each(sonuc, function (index, value) {
            var row = "";
            var il = value.il.toUpperCase();
            row += '<option value="' + value.il + '">' + il + '</option>';
            $("#il").append(row);
        })
    });
    // get districts from json file after city changed
    $("#il").on("change", function () {
        var il = $(this).val();
        $("#ilce").attr("disabled", false).html("<option value=''>Seçin..</option>");
        $.getJSON("/json/tr-iller-ilceler.json", function (sonuc) {
            $.each(sonuc, function (index, value) {
                var row = "";
                if (value.il == il) {
                    var ilce = value.ilce.toUpperCase();
                    row += '<option value="' + value.ilce + '">' + ilce + '</option>';
                    $("#ilce").append(row);
                }
            });
        });
    });


    // Validate Payment Form
    const REQUIRED_INPUT_MESSAGE = "Bu alanın doldurulması zorunludur.";
    $('#payment-form').validate({
        rules: {
            "OrderDto.FirstName": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "OrderDto.LastName": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "OrderDto.Phone": {
                required: true,
                minlength: 10,
                maxlength: 10
            },
            "OrderDto.City": {
                required: true,
            },
            "OrderDto.Address": {
                required: true,
                minlength: 10,
                maxlength: 120
            },
            "CardNumber": {
                required: true,
                minlength: 16,
                maxlength: 19
            },
            "CardHolderName": {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            "expiry": {
                required: true,
            },
            "Cvc": {
                required: true,
            },
            "contract": {
                required: true,
            },
        },
        messages: {
            "OrderDto.FirstName": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "2",
                maxlength: "50"
            },
            "OrderDto.LastName": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "2",
                maxlength: "50"
            },
            "OrderDto.Phone": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "10",
                maxlength: "10"
            },
            "OrderDto.City": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "OrderDto.Address": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "10",
                maxlength: "120"
            },
            "CardNumber": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "16",
                maxlength: "19"
            },
            "CardHolderName": {
                required: REQUIRED_INPUT_MESSAGE,
                minlength: "3",
                maxlength: "20"
            },
            "expiry": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "Cvc": {
                required: REQUIRED_INPUT_MESSAGE,
            },
            "contract": {
                required: REQUIRED_INPUT_MESSAGE,
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

    // Submit Payment Form
    $('#payment-form').on('submit', function (event) {
        var formData = new FormData();
        var serializedArr = $("#payment-form").serializeArray();
        serializedArr.forEach((d) => {
            formData.append(d.name, d.value);
            console.log(d.name + " " + d.value);
        });
        if ($('#payment-form').valid() === true) {
            var formData = new FormData();
            var serializedArr = $("#payment-form").serializeArray();
            serializedArr.forEach((d) => {
                formData.append(d.name, d.value);
                console.log(d.name + " " + d.value);
            });
            $.ajax({
                type: 'POST',
                url: "/Order/Checkout",
                data: formData,
                contentType: false,
                processData: false,
                success: async function (res) {
                    if (res.success) {
                        await Swal.fire(
                            'Sipariş Başarılı !',
                            `${res.message}`,
                            'success'
                        )
                        window.location.href = "/";
                    }
                    else
                        Swal.fire(
                            'Kayıt Hatası !',
                            `${res.message}`,
                            'error'
                        )
                },
                error: function (err) {
                }
            });
            return false;
        }
        else {
            event.preventDefault();
            toastr.warning("Lütfen gerekli alanları doldurun.")
        }
    });


});

