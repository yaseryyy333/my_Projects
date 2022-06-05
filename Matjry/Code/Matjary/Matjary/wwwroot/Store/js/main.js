//jquery

// for cart option in topbar
$(document).click(function () {

    $(".cart-options").hide();

});

$(".cart").click(function (e) {
    $(".cart-options").toggle(); // show or hide
    e.stopPropagation(); //To prvent hide when click in document  by function above
});

//End for cart option in topbar


//for login option
$(document).click(function () {

    $(".login-options").hide();

});

$(".login").click(function (e) {
    $(".login-options").toggle(); // show or hide
    e.stopPropagation(); //To prvent hide when click in document  by function above
});
//jquery

// for category
if (document.title === 'ResultSearch - MatjaryStore') { } else {
    var heightOflist = parseInt(getComputedStyle(document.querySelector(".style-products>div>.heightOflist")).height);


    var hiddenproducts = document.querySelectorAll(".style-products>.hiddenproducts");

    var showHeightCategory = heightOflist;
    var brheight = 22;

    // for new products
    var showheightNewProduct = heightOflist;
    // for new products

    //for offers products
    var showHeightOffers = heightOflist;
    //for offers products

    //for other products
    var showHeightOther = heightOflist;
    //for other products
    if (document.querySelectorAll('.style-products').length == 0) {
    }
    else if (document.querySelectorAll('.style-products').length == 1) {
        var fullC = parseInt(getComputedStyle(document.querySelectorAll('.style-products')[0]).height);
    }
    else if (document.querySelectorAll('.style-products').length == 2) {
        var fullC = parseInt(getComputedStyle(document.querySelectorAll('.style-products')[0]).height);
        var fullH2 = parseInt(getComputedStyle(document.querySelectorAll('.style-products')[1]).height);


    } else {
        var fullC = parseInt(getComputedStyle(document.querySelectorAll('.style-products')[0]).height);
        var fullH2 = parseInt(getComputedStyle(document.querySelectorAll('.style-products')[1]).height);
        var fullH3 = parseInt(getComputedStyle(document.querySelectorAll('.style-products')[2]).height);

    }

    var fullH = parseInt(getComputedStyle(document.querySelector('.style-products')).height);



    if (document.title === 'HomePage - MatjaryStore') {

        hiddenproducts[0].style.height = 10 + heightOflist + "px";
        hiddenproducts[1].style.height = 10 + heightOflist + "px";
        hiddenproducts[2].style.height = 10 + heightOflist + "px";
    } else if (document.title === 'Category - MatjaryStore') {
        hiddenproducts[0].style.height = 10 + heightOflist + "px";
    }

    function showMore(x, showMoreButton) {


        if (showHeightCategory <= fullC) {
            showHeightCategory = heightOflist + 14 + showHeightCategory + brheight;
            hiddenproducts[x].style.height = showHeightCategory + "px";

        }
        if ((showHeightCategory + heightOflist) >= fullC) // Next Probability
        {
            showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
            showMoreButton.style.cursor = "default";
            showHeightCategory = fullC + 1;
        }


    }

    /* for category  "ShowMore" */


    // for products  "ShowMore"


    function showMoreProducct(x, showMoreButton) {
        if (x === 0) {

            if (showheightNewProduct <= fullH) {

                showheightNewProduct += heightOflist + 10 + brheight;
                hiddenproducts[x].style.height = showheightNewProduct + "px";


            }
            if ((showheightNewProduct + heightOflist) >= fullH) // Next Probability
            {
                showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
                showMoreButton.style.cursor = "default";
                showheightNewProduct = fullH + 1;
            }
        } else if (x === 1) {



            if (showHeightOffers <= fullH2) {
                showHeightOffers += heightOflist + 10 + brheight;
                hiddenproducts[x].style.height = showHeightOffers + "px";
            }
            if ((showHeightOffers + heightOflist) >= fullH2) // Next Probability
            {
                showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
                showMoreButton.style.cursor = "default";
                showHeightOffers = fullH2 + 1;
            }

        } else if (x === 2) {

            if (showHeightOther <= fullH3) {
                showHeightOther += heightOflist + 10 + brheight;
                hiddenproducts[x].style.height = showHeightOther + "px";
            }
            if ((showHeightOther + heightOflist) >= fullH3) // Next Probability
            {
                showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
                showMoreButton.style.cursor = "default";
                showHeightOther = fullH3 + 1;
            }

        }

    }
}


///////////////////////////////////////////// ADD TO CAR ///////////////////////////////////////////////////////////
// var addtocart=document.querySelectorAll('.style-products > div > div > div > div > div:last-of-type');
// for (var i=0;i<1;i++){
//     console.log( addtocart[i].classList);
//     addtocart[i].className=('false');
// }

const cart = document.querySelector('.topbar .left-content .cart > a:first-of-type > span');
var cartCount = document.getElementById("counter").innerText;
if (document.title === 'ResultSearch - MatjaryStore') {
} else {
    var keepHeight = parseInt(getComputedStyle(document.querySelector('.style-products>div>div>div')).height);
}
cart.innerHTML = cartCount;
var newContent = "<span>تم بنجاح</span> ";       //just we add override =>[<span>اضف الئ السلة</span>']
//var newC2 /* To ADD [Paragraph] */ = ;
var isClicked = false; //to check if we click over add to cart

function addToCart(self, id) {
    var d = self.parentElement;
    if (!self.classList.contains('true')) {
        self.setAttribute('class', 'true');
        // self => current div
        self.style.backgroundColor = "#45a787";
        self.style.cursor = "default"; //remover pointer
        self.style.position = "relative";
        self.innerHTML = newContent;
        if (self.parentNode.children.item(1) != "[object HTMLParagraphElement]") {
            //here we are checking  if Paragraph that contains [X] is exits or not
            self.parentNode.innerHTML += '<a id="x" data-ajax="true" data-ajax-loading="#loader" data-ajax-method="get" data-ajax-url="/Store/SessionManagment?id=' + id + '&delete=True"><i id="removeFromCart" onclick="removeFromCart(this,' + id + ')" class="far fa-times-circle"></i> <span class="tooltiptext">تراجع عن الأضافة</span></a>'; // if not exist we add it

        }
        cartplus();


    } else {
        // if anyone click again that return nothing
    }

    d.parentElement.style.height = keepHeight + "px";



}


function cartplus() {

    cartCount++;

    cart.innerHTML = cartCount.toString();
}

function removeFromCart(self, id) {
    self.parentNode.previousElementSibling.className = 'false';// change value that we changed in function above
    let oldContent = '<i class="fa fa-cart-plus"></i><a data-ajax="true" data-ajax-loading="#loader" data-ajax-method="get" data-ajax-url="/Store/SessionManagment?id=' + id + '&delete=false"> <span>اضف الئ السلة</span></a>'; //to add it override => [<span>تم بنجاح</span> ]

    if (cartCount !== 0) {
        cartCount--;
    }
    cart.innerHTML = cartCount.toString(); //To print the count in topbar into cart
    //////
    //self => is [removeFromCart], parentNode=>is [P =paragraph] ,previousElementSibling => is [div that contains normal display of any product like "add to cart"]
    self.parentNode.previousElementSibling.style.backgroundColor = 'rgb(141 93 167)';//here we return old background
    self.parentNode.previousElementSibling.style.cursor = "pointer";
    //////
    self.parentNode.previousElementSibling.innerHTML = oldContent; // here we return old content
    self.parentNode.parentNode.children.item(1).remove(); //here we remove P =paragraph To delete [X]


}

function getImage(src) {
    var i = document.getElementById("big-img");
    i.setAttribute('src', src.getAttribute('src'));
}



function ChangeQTY(self, Cost, index) {
    var to = document.getElementById("total-" + index);
    var r = (self.value) * Cost;

    to.innerText = r.toString();


}

function h(self) {
    const cart = document.querySelector('.topbar .left-content .cart > a:first-of-type > span');
    var cartCount = document.getElementById("counter").innerText;

    self.parentNode.parentNode.style.display = "none";
    if (cartCount !== 0) {
        cartCount--;

    }
    cart.innerHTML = cartCount.toString();

}
