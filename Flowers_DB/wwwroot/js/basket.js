//const addToCartBtns = document.querySelectorAll(".add-to-cart");
//$(document).ready(function () {

function addToCart(ev) {
    console.log("working");
    const productId = ev.target.getAttribute("data-id");
    fetch(`/basket/AddToBasket?productId=${productId}`)
        .then(response => response.text())
        .then(() => {
            updateBasketCount();
        });
}

function updateBasketCount() {
    fetch(`/basket/GetBasketCount`)
        .then(response => response.text())
        .then(data => {
            const basketCount = document.querySelector(".shop-cart > .rounded-circle")
            basketCount.innerHTML = data;
        });
}

updateBasketCount();

const addToCartBtns = document.querySelectorAll('.add-to-cart');
addToCartBtns.forEach(addToCartBtns => addToCartBtns.addEventListener('click', addToCart));





//    $(document).on('click', '#add-tobasket', function () {
//        var id = $(this).val();
//        console.log(id);
//        $.ajax({
//            method: "GET",
//            url: "/basket/addtobasket?id=" + id,
//            success: function () {
//                console.log(id);
//            }
//        })
//    })

//})

//function addToCart(ev) {
//    console.log("Working")
//    const productId = ev.target.getAttribute("data-id");

//    fetch(`/basket/AddToBasket?productId=${productId}`).then(response => {
//        console.log(response)
//    })

//}
//addToCartBtns.forEach(addToCartBtn => addToCartBtn.addEventListener('click', addToCart))
