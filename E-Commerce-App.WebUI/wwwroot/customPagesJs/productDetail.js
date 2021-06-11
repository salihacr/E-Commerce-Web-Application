$(document).ready(function () {

    $('#imageGallery').lightSlider({
        gallery: true,
        item: 1,
        loop: true,
        slideMargin: 0,
        thumbItem: 9
    });

    $(".qtyminus").on("click", function () {
        var now = $(".qty").val();
        if ($.isNumeric(now)) {
            if (parseInt(now) - 1 > 0) { now--; }
            $(".qty").val(now);
        }
    })
    $(".qtyplus").on("click", function () {
        var now = $(".qty").val();
        if ($.isNumeric(now)) {
            $(".qty").val(parseInt(now) + 1);
        }
    });

    // Submit form
    $('#product-detail-form').on('submit', function (event) {

        var form = document.getElementById('product-detail-form');
        var action = form.getAttribute("action");
        var formdata = new FormData($("#product-detail-form")[0]);

        try {
            $.ajax({
                type: 'POST',
                url: action,
                data: formdata,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.success) {
                        Swal.fire(
                            'Kayıt Başarılı !',
                            `${res.message}`,
                            'success'
                        )
                    }
                },
                error: function (err) {
                }
            });
            return false;
        } catch (ex) {
            toastr.success("Ürün sepete eklenemedi.")
        }

        event.preventDefault();
        return false;
    });

});
function getChecked() {
    var colorList = document.getElementsByName('color');
    for (i in colorList) {
        if (colorList[i].checked == true) {
            return Number.parseInt(i) + 1;
        }
    }
}
setTimeout(() => {
    getChecked();
}, 1000);

var colorList = document.getElementsByName('color');
colorList[0].checked = true;