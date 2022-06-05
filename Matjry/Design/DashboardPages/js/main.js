// function to display the hidden list .. 
function displayList(element){
    if(element.classList.contains('active')){
        element.classList.remove('active');
        element.children[1].classList.remove('visible');
    }
    else{
    var navItems = document.getElementsByClassName('nav-item');
    for (var i = 0; i<navItems.length ;i++){
        if(navItems[i].classList.contains('active')){
            navItems[i].classList.remove('active');
            if(i>0){
                navItems[i].children[1].classList.remove('visible');
            }
        }
    }
    element.classList.add('active');
    element.children[1].classList.add('visible');
    }
}

// function to display Mobile Navigation in small devices .. 
function showMobileNav(){
    var mobileNav = document.getElementById('mobile-navigation');
    mobileNav.style.top = '0%';
}

// function to close Mobile Navigation in Small Devices ..
function closeMobileNav(){
    var mobileNav = document.getElementById('mobile-navigation');
    mobileNav.style.top = '-100%';
}


// function to display User Links ..
function showUserLinks(){
    var userLinks = document.getElementById('userLinks');
    if(userLinks.style.display === '')
    {
        userLinks.style.display = 'block';
    }
    else{
        userLinks.style.display = '';
    }
}

// function to display hidden list in Mobile Navigation .. 
function displayLink(element)
{
    if(element.children[1].classList.contains('visible'))
    {
        element.children[1].classList.remove('visible');
        element.classList.remove('active');
    }
    else
    {
        var navLink = document.getElementsByClassName('nav-link');
        for (var i = 0; i<navLink.length ;i++){
            if(navLink[i].children[1].classList.contains('visible')){
                navLink[i].children[1].classList.remove('visible');
                navLink[i].classList.remove('active');
            }
        }
        element.children[1].classList.add('visible');
        element.classList.add('active');
    }
}

// function to add photo input in create product page .. 
function addPhoto()
{
    var myButton = document.getElementById('addPhotoBtn');
    var myPhotos = document.getElementById('photoColumn');
    var photoRow = document.getElementById('photoRow');

    if(myPhotos.children.length < 4)
    {
        var myNewPhotoInput = photoRow.cloneNode(true);
        myPhotos.appendChild(myNewPhotoInput);
        if(myPhotos.children.length === 4)
        {
            myButton.parentElement.style.display = 'none';
        }
    }
}

// function to assign supplier that exist in unconfirmed select ..
function assignToSupplier(Element)
{
    var myOption = Element;
    var unConfirmedList = document.getElementById('unConfirmed');
    var confirmedList = document.getElementById('confirmed');
    // first delete the option from unConfirmed list ..
    unConfirmedList.removeChild(Element);
    // set the onclick attribute .. 
    myOption.setAttribute('onclick','removeFromSupplier(this)');
    // append the option to the confirmed list ..
    confirmedList.appendChild(myOption);
}

// function to remove supplier from confirmed select ..
function removeFromSupplier(Element)
{
    var myOption = Element;
    var unConfirmedList = document.getElementById('unConfirmed');
    var confirmedList = document.getElementById('confirmed');
    // first delete the option from confirmed list ..
    confirmedList.removeChild(Element);
    // set the onclick attribute .. 
    myOption.setAttribute('onclick','assignToSupplier(this)');
    // append the option to the confirmed list ..
    unConfirmedList.appendChild(myOption);
}

// function to check the value of user type dropdown 
// if the user is employee , hide the address div 
// otherwise display the address div 
function displayAddress()
{
    var userType = document.getElementById('userType');
    var addressDiv = document.getElementById('addressDiv');
    if(userType.value === "موظف")
    {
        addressDiv.style.display = 'none';
    }
    else
    {
        addressDiv.style.display = 'block';
    }
}

// function to display Statistics Option in main Dashboard .. 
function displayStatistics()
{
    var myStatis = document.getElementById('st-option');
    if(myStatis.style.display === "" || myStatis.style.display === 'none')
    {
        myStatis.style.display = 'block';
    }
    else
    {
        myStatis.style.display = 'none';
    }
}

// function to display or hide the select dropdown of vat ..
function displayVatDropDown(myInput)
{
    console.log(myInput.value);
    var myDropDown = document.getElementById('vatSelect');
    if(myInput.value === "بدون ضريبة"){
        myDropDown.style.display = 'none';
    }else{
        myDropDown.style.display = 'flex';
    }
}

// function to add row in product table .. 
function addRow()
{
    var myTableBody = document.getElementById('table-body');
    var myTr = document.createElement('tr');

    // 1 <td> 
    var myTd1 = document.createElement('td');
    var myCheckBox = document.createElement('input');
    myCheckBox.type = "checkbox";
    myCheckBox.className = "record form-control";
    myCheckBox.style.width = 'auto';
    myTd1.appendChild(myCheckBox);
    myTr.appendChild(myTd1);
    
    // 2 <td> For Product input
    var myTd2 = document.createElement('td');
    var myProductInput = document.createElement('input');
    myProductInput.type = "text";
    myProductInput.className = "form-control";
    // var myAspAttribute =document.createAttribute('Asp-for');
    // myAspAttribute.value = ""; 
    myTd2.appendChild(myProductInput);
    myTr.appendChild(myTd2);

    // 3 <td> For Cost input
    var myTd3 = document.createElement('td');
    var myCostInput = document.createElement('input');
    myCostInput.type = "text";
    myCostInput.className = "form-control";
    // var myAspAttribute =document.createAttribute('Asp-for');
    // myAspAttribute.value = ""; 
    myTd3.appendChild(myCostInput);
    myTr.appendChild(myTd3);

    // 4 <td> For Sell Price input
    var myTd4 = document.createElement('td');
    var mySellPriceInput = document.createElement('input');
    mySellPriceInput.type = "text";
    mySellPriceInput.className = "form-control";
    // var myAspAttribute =document.createAttribute('Asp-for');
    // myAspAttribute.value = ""; 
    myTd4.appendChild(mySellPriceInput);
    myTr.appendChild(myTd4);

    // 5 <td> For Discount input
    var myTd5 = document.createElement('td');
    var myDiscountInput = document.createElement('input');
    myDiscountInput.type = "text";
    myDiscountInput.className = "discount form-control";
    var myEvent = document.createAttribute("onchange");
    myEvent.value = "totalDiscount()";
    myDiscountInput.setAttributeNode(myEvent);
    // var myAspAttribute =document.createAttribute('Asp-for');
    // myAspAttribute.value = ""; 
    myTd5.appendChild(myDiscountInput);
    myTr.appendChild(myTd5);

    // 6 <td> For Quantity input
    var myTd6 = document.createElement('td');
    var myQuantityInput = document.createElement('input');
    myQuantityInput.type = "text";
    myQuantityInput.className = "form-control";
    // var myAspAttribute =document.createAttribute('Asp-for');
    // myAspAttribute.value = ""; 
    myTd6.appendChild(myQuantityInput);
    myTr.appendChild(myTd6);

    // 7 <td> For total
    var myTd7 = document.createElement('td');
    myTd7.className = "total";
    myTd7.textContent = "0";
    myTr.appendChild(myTd7);

    // 8 <td> For total vat
    var myTd8 = document.createElement('td');
    myTd8.className = "total-vat";
    myTd8.textContent = "0";
    myTr.appendChild(myTd8);

    // 9 <td> For Quantity input
    var myTd9 = document.createElement('td');
    var myNoteInput = document.createElement('input');
    myNoteInput.type = "text";
    myNoteInput.className = "form-control";
    // var myAspAttribute =document.createAttribute('Asp-for');
    // myAspAttribute.value = ""; 
    myTd9.appendChild(myNoteInput);
    myTr.appendChild(myTd9);
    
    myTableBody.appendChild(myTr);
    total();
    totalVat();
}

// function to delete rows in product table ..
function deleteRows()
{
    var myTableBody = document.getElementById('table-body');
    var myRecord = document.getElementsByClassName('record');
    for(var i = 0 ; i<myRecord.length ;i++){
        var myCheckboxStatus = myRecord[i].checked;
        if(myCheckboxStatus === true){
            myTableBody.removeChild(myTableBody.children[i]);
        }
    }
    total();
    totalVat();
    totalDiscount();
}

// function to sum the total of invoice .. 
function total()
{
    var allTotal = document.getElementsByClassName('total');
    var totalSR =0;
    for(var i=0; i<allTotal.length ;i++){
        totalSR+=parseInt(allTotal[i].textContent);
    }
    document.getElementById('total').textContent = totalSR;
}

// function to sum the total vat of invoice .. 
function totalVat()
{
    var allTotal = document.getElementsByClassName('total-vat');
    var totalVatSR =0;
    for(var i=0; i<allTotal.length ;i++){
        totalVatSR+=parseInt(allTotal[i].textContent);
    }
    document.getElementById('total-vat').textContent = totalVatSR;
}

// function to sum the total discount of invoice .. 
function totalDiscount()
{
    var allDiscount = document.getElementsByClassName('discount');
    var totalDiscountSR =0;
    for(var i=0; i<allDiscount.length ;i++){
        totalDiscountSR+=parseInt(allDiscount[i].value);
    }
    document.getElementById('total-discount').textContent = totalDiscountSR;
}

// function to set the payment amount of invoice .. 
function setPaymentAmount(amount)
{
    document.getElementById('payment').textContent = amount.value;
}