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

    var heightOflist = parseInt(getComputedStyle(document.querySelector(".style-products>div>div")).height);
    var fullH = parseInt(getComputedStyle(document.querySelector('.style-products')).height);
    var hiddenproducts = document.querySelectorAll(".style-products>div");
    var showHeight = heightOflist;
    var brheight = 22;
    showHeight = heightOflist + 14 + showHeight + brheight;

    // for new products
    var showheightNewProduct = heightOflist;
    showheightNewProduct = heightOflist + 2 + showheightNewProduct + brheight;
    // for new products

    //for offers products
    var showHeightOffers = heightOflist;
    showHeightOffers = heightOflist + 2 + showHeightOffers + brheight;
    //for offers products

    //for other products
    var showHeightOther = heightOflist;
    showHeightOther = heightOflist + 2 + showHeightOther + brheight;
    //for other products

    if (document.title === 'Store Home Page') {
        hiddenproducts[0].style.height = 10+heightOflist + "px";
        hiddenproducts[1].style.height = 10+heightOflist + "px";
        hiddenproducts[2].style.height = 10+heightOflist + "px";
    } else if (document.title === 'Category Page') {
        hiddenproducts[0].style.height =10 + heightOflist + "px";
    }

    function showMore(x, showMoreButton) {


        if (showHeight <= fullH) {
            hiddenproducts[x].style.height = showHeight + "px";
        }
        if ((showHeight = heightOflist + 2 + showHeight + brheight) >= fullH) // Next Probability
        {
            showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
            showMoreButton.style.cursor = "default";
        }


    }

    /* for category  "ShowMore" */


    // for products  "ShowMore"


    function showMoreProducct(x, showMoreButton) {

        if (x === 0) {
            if (showheightNewProduct <= fullH) {
                hiddenproducts[x].style.height = showHeight + "px";
            }
            if ((showheightNewProduct = heightOflist + 2 + showheightNewProduct + brheight) >= fullH) // Next Probability
            {
                showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
                showMoreButton.style.cursor = "default";
            }
        } else if (x === 1) {
            if (showHeightOffers <= fullH) {
                hiddenproducts[x].style.height = showHeight + "px";
            }
            if ((showHeightOffers = heightOflist + 2 + showHeightOffers + brheight) >= fullH) // Next Probability
            {
                showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
                showMoreButton.style.cursor = "default";
            }

        } else if (x === 2) {
            if (showHeightOther <= fullH) {
                hiddenproducts[x].style.height = showHeight + "px";
            }
            if ((showHeightOther = heightOflist + 2 + showHeightOther + brheight) >= fullH) // Next Probability
            {
                showMoreButton.style.backgroundColor = "rgb(180 179 181 / 23%)";
                showMoreButton.style.cursor = "default";
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
    let cartCount = 0;
    var keepHeight=parseInt(getComputedStyle(document.querySelector('.style-products>div>div>div')).height);
    cart.innerHTML = cartCount;
    var newContent = "<span>تم بنجاح</span> ";       //just we add override =>[<span>اضف الئ السلة</span>']
    var newC2 /* To ADD [Paragraph] */ = "<p id='x'><i id='removeFromCart' onclick='removeFromCart(this)' class='far fa-times-circle'></i> <span class='tooltiptext'>تراجع عن الأضافة</span></p>";
    let oldContent = '<i class="fa fa-cart-plus"></i> <span>اضف الئ السلة</span>'; //to add it override => [<span>تم بنجاح</span> ]
    var isClicked = false; //to check if we click over add to cart

    function addToCart(self) {
        var d=self.parentElement;
        if (!self.classList.contains('true')) {
            self.setAttribute('class','true');
            // self => current div
            self.style.backgroundColor = "#45a787";
            self.style.cursor = "default"; //remover pointer
            self.style.position = "relative";
            self.innerHTML = newContent;

            if (self.parentNode.children.item(1) != "[object HTMLParagraphElement]") { //here we are checking  if Paragraph that contains [X] is exits or not
                self.parentNode.innerHTML += newC2; // if not exist we add it
            }
            cartplus();


        } else {
           // if anyone click again that return nothing
        }

       d.parentElement.style.height=keepHeight+"px";



    }


    function cartplus() {

        cartCount++;

        cart.innerHTML = cartCount.toString();
    }

    function removeFromCart(self) {
       self.parentNode.previousElementSibling.className='false';// change value that we changed in function above

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
    i.setAttribute('src',src.getAttribute('src'));
}