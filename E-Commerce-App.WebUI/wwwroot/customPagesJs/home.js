$(document).ready(function () {

});

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
function string_chop(str, size) {
    if (str == null) return [];
    str = String(str);
    size = ~~size;
    return size > 0 ? str.match(new RegExp('.{1,' + size + '}', 'g')) : [str];
}

function getPrice(data, index) {
    let html = ``;
    var normalPrice = (data[index].price).toFixed(0);
    if (data[index].discount != null && data[index].discount > 0) {

        var discountedPrice = (data[index].price - ((data[index].price * data[index].discount) / 100)).toFixed(2);


        html = `<p class="dress-card-para"><span class="dress-card-price">${discountedPrice + "&nbsp;₺"}</span>
                    <span class="dress-card-crossed">${normalPrice}&nbsp;₺</span><small class="dress-card-off float-right">&ensp; (% ${data[index].discount})</small>
                </p>`
    }
    else {
        html = `<p class="dress-card-para"><span class="dress-card-price">${normalPrice} &nbsp;₺ &ensp;</span></p>`;
    }
    return html;
}
function product(data, index) {
    var productName = string_chop(data[index].name, 20)[0];
    productName = productName.length >= 20 ? productName + "..." : productName;
    let html =
        `
        <div class="col-md-3 mb-5">
            <div class="dress-card shadow p-1" id="card-bg">
                <div class="dress-card-head">
                    <img class="dress-card-img-top img-fluid" src="/img/${data[index].mainImage}" alt="" id="productImage"/>
                </div>
                <div class="dress-card-body">
                    <small class="dress-card-title">${productName}</small>
                    <hr/>
                    <p class="dress-card-para"> ${getPrice(data, index)} </p>
                    <div class="row">
                        <div class="col-md-12 card-button"><a href="/product/${data[index].url}"><div class="card-button-inner">İncele </div></a></div>
                    </div>
                </div>
            </div>
        </div>
        `;
    return html;
}