$(document).ready(function () {
    // Get Cart Items On Page Loaded
    getCartItems();
});

function cartItemComponent(data, index) {
    let html =
        `
    <div class="row">
        <div class="col-md-2"><img src="/img/${data[index].imageUrl}" width="100" height="100" /></div>
        <div class="col-md-9">
            <p>${data[index].name}</p>
            <p>${data[index].cartItemDto.quantity} Adet ${data[index].cartItemDto.color} </p>
            <h5> ${data[index].cartItemDto.price * data[index].cartItemDto.quantity} TL</h5>
        </div>
        <div class="col-md-1">
            <button class="btn btn-danger" onclick="removeCartItem('${data[index].cartItemDto.productId}')"><i class="fas fa-trash"></i></button>
        </div>
    </div>
    <hr />`;
    return html;
}

function getCartItems() {
    var len = 0;
    $.ajax({
        type: 'GET',
        url: "/GetCartItems",
        contentType: false,
        processData: false,
        success: function (response) {
            var data = response.data.cartItems;
            len = data.length;
            console.log(response);
            for (var i = 0; i < data.length; i++) {
                $("#cartItems").append(cartItemComponent(data, i));
            }
        }
    })
    return len;
}

removeCartItem = productId => {

    const data = {
        productId: productId
    };
    try {
        $.ajax({
            type: 'POST',
            url: `/RemoveFromCart/${productId}`,
            data: data,
            contentType: false,
            processData: false,
            success: async function (res) {
                if (res.success) {
                    await Swal.fire(
                        'Silme Başarılı !',
                        `Ürün sepetten kaldırıldı.`,
                        'success'
                    )
                    $("#cartItems").html("");
                    var len = getCartItems();
                    if (len < 1) {
                        location.reload();
                    }
                }
            },
            error: function (err) {
            }
        })
    }
    catch (ex) {
    }
    return false;
}