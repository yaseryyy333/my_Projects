

// Function To Change Color From Accounts
function activing(element){
    var account = document.getElementById('accounts');
    var chat = document.getElementById('chating');
    var actives = document.getElementsByClassName('to-remove-active');
    for (let index = 0; index < actives.length; index++) {
        if(actives[index].classList.contains('row-active')){
            actives[index].classList.remove('row-active');
        }
        
    }    
    element.classList.add('row-active');
    // To Show the Chating
    if(window.innerWidth > 640){
        chat.style.display = 'flex';
        account.style.display = 'none';
    }

    
}

// Function To Show The Accounting
function accounts(){
    
    var chat = document.getElementById('chating');
    var accounts = document.getElementById('accounts');
    chat.style.display = 'none';
    accounts.style.display = 'flex';

}

// Function Whene The Width Change
function widthChange(){
    var chat = document.getElementById('chating');
    var accounts = document.getElementById('accounts');
    if(window.innerWidth > 640){
        chat.style.display = 'flex';
        accounts.style.display = 'flex';
    }
    else{
        chat.style.display = 'none';
    }
}

// Function To Show The Icons Of Usrt Account
function showUserAccount(){
    var user_arrow = document.getElementById('user_arrow');
    var edit = document.getElementById('edit');
    var out = document.getElementById('out');
    if(edit.classList.contains('edit') && out.classList.contains('out')){
        edit.classList.remove('edit');
        out.classList.remove('out');
        user_arrow.classList.remove('user-click');
    }
    else{
        edit.classList.add('edit');
        out.classList.add('out');
        user_arrow.classList.add('user-click');

    }
}


// Start Chat Page 
// Function To Change between Group Page And Notification Page
function selectTopBar(element){
    var group = document.getElementById('group');
    var notification = document.getElementById('notification');
    var chatBody = document.getElementById('chat-body');
    if(element.children[2].classList.contains('active')){
        group.classList.remove('active');
        notification.classList.remove('active');
        element.children[2].classList.add('active');
    }
    else{
        group.classList.remove('active');
        notification.classList.remove('active');
        element.children[2].classList.add('active');

    }
    if(element.getAttribute('data') == 'group'){
        chatBody.classList.add('chat-body-click');
    }
    else{
        chatBody.classList.remove('chat-body-click');

    }
}

// Function To Show Chatting Page
function showGropPage(element){
    var topBar = document.getElementById('top-bar');
    var name = element.children[1];
    var groupName = document.getElementById('groub-name');
    var chattingPage = document.getElementById('chating-page');
    var chatBody = document.getElementById('chat-body');
    var topChat = document.getElementById('top-chat');
    var messageInput = document.getElementById("messageInput");

    messageInput.setAttribute("room_id", element.getAttribute("room_id"));


    chatBody.style.opacity = '0';
    chatBody.style.zIndex = '-1';
    chatBody.style.position = 'absolute';

    topBar.style.opacity = '0';
    topBar.style.zIndex = '-1';
    topBar.style.position = 'absolute';

    chattingPage.style.opacity = '1';
    chattingPage.style.zIndex = '1';
    groupName.textContent = name.textContent;

    topChat.setAttribute('onclick','hideChatingPage(this)');


}
// Function To hide Chatting Page
function hideChatingPage(){
    var topBar = document.getElementById('top-bar');
    var chattingPage = document.getElementById('chating-page');
    var chatBody = document.getElementById('chat-body');

    chatBody.style.opacity = '1';
    chatBody.style.zIndex = '1';
    chatBody.style.position = 'relative';

    topBar.style.opacity = '1';
    topBar.style.zIndex = '1';
    topBar.style.position = 'relative';

    chattingPage.style.opacity = '0';
    chattingPage.style.zIndex = '-1';
}

// Function To Show The Single Note
function showNote(element){
    var notificationBody = document.getElementById('notification-body');
    var notificationBody2 = document.getElementById('notification-body2');
    var notPage = document.getElementById('not-page');

    notPage.children[1].textContent = element.children[1].textContent;
    notPage.children[2].textContent = element.children[2].textContent;

    notPage.style.opacity = '1';
    notPage.style.zIndex = '1';
    notPage.style.position = 'relative';

    notificationBody.style.display = 'none';
    notificationBody2.style.display = 'block';

    // notificationBody.style.opacity = '0';
    // notificationBody.style.zIndex = '-1';
    // notificationBody.style.position = 'absolute';

}

// Function To Hide The Single Note
function hideNote(){
    var notificationBody2 = document.getElementById('notification-body2');
    var notificationBody = document.getElementById('notification-body');
    notificationBody.style.display = 'block';
    notificationBody2.style.display = 'none';
    

}

// Function To Show THe Brach

function showBranch(){
    var arrowBranch = document.getElementById('arrow');
    var optionBranch = document.getElementById('options');
    var back = document.getElementById('back');
    var mainBody = document.getElementById('main-body');

if(!arrowBranch.classList.contains('rotate')){
    arrowBranch.classList.add('rotate');
    optionBranch.style.opacity = '1';
    optionBranch.style.position = 'relative';
    optionBranch.style.zIndex = '1';
    back.style.height = '32%';
    mainBody.style.height = '69%';
}
else{
    arrowBranch.classList.remove('rotate');
    optionBranch.style.opacity = '0';
    optionBranch.style.position = 'absolute';
    optionBranch.style.zIndex = '-1';
    back.style.height = '17%';
    mainBody.style.height = '84%';


}

    
}

// Function To Hide The Branch
function hideBranch(element){
    var nameBranch = document.getElementById('name');
    var arrowBranch = document.getElementById('arrow');
    var optionBranch = document.getElementById('options');
    var back = document.getElementById('back');
    var mainBody = document.getElementById('main-body');

    nameBranch.textContent = element.parentElement.children[0].textContent;
    arrowBranch.classList.remove('rotate');
    optionBranch.style.opacity = '0';
    optionBranch.style.position = 'absolute';
    optionBranch.style.zIndex = '-1';
    back.style.height = '17%';
    mainBody.style.height = "84%";

}

// Function To Show Input Search
function showSearchInput(){
    var options = document.getElementById('options');
    var back = document.getElementById('back');
    var bulding = document.getElementById('bulding');
    var brachSelection = document.getElementById('branch-selection');
    var search = document.getElementById('search');
    var searchInput = document.getElementById('search-input');
    var mainBody = document.getElementById('main-body');

    options.style.opacity = '0';
    options.style.position = 'absolute';
    options.style.zIndex = '-1';
    back.style.height = '17%';

    bulding.style.color = "rgb(164,221,250)";

    brachSelection.style.opacity = '0';
    brachSelection.style.position = 'absolute';
    brachSelection.style.zIndex = '-1';
    
    search.style.color = "rgb(35,169,244)";

    searchInput.style.opacity = '1';
    searchInput.style.position = 'initial';
    searchInput.style.zIndex = '1';

    mainBody.style.height = "84%";
    
}

// Function To Show The Buldeing
function showBuldeing(){
    var arrowBranch = document.getElementById('arrow');
    var options = document.getElementById('options');
    var back = document.getElementById('back');
    var bulding = document.getElementById('bulding');
    var brachSelection = document.getElementById('branch-selection');
    var search = document.getElementById('search');
    var searchInput = document.getElementById('search-input');
    var mainBody = document.getElementById('main-body');

    arrowBranch.classList.add('rotate');
    options.style.opacity = '1';
    options.style.position = 'relative';
    options.style.zIndex = '1';
    back.style.height = '32%';

        
    bulding.style.color = "rgb(35,169,244)";

    brachSelection.style.opacity = '1';
    brachSelection.style.position = 'relative';
    brachSelection.style.zIndex = '0';
    
    search.style.color = "rgb(164,221,250)";

    searchInput.style.opacity = '0';
    searchInput.style.position = 'absolute';
    searchInput.style.zIndex = '-1';

    mainBody.style.height = '69%';
}


// Function To Hide The Select Users Page
function hideSelectUsersPage(){
    var chatBody = document.getElementById('chat-body');
    var topBar = document.getElementById('top-bar');
    var selectUsersPage = document.getElementById('select-users-page');

    chatBody.style.position = "relative";
    chatBody.style.zIndex = '1';
    chatBody.style.opacity = '1';

    topBar.style.position = "relative";
    topBar.style.zIndex = '1';
    topBar.style.opacity = '1';

    selectUsersPage.style.position = "absolute";
    selectUsersPage.style.zIndex = '-1';
    selectUsersPage.style.opacity = '0';

}


function hideSelectUsersPage2(){
    var chatBody = document.getElementById('chat-body');
    var topBar = document.getElementById('top-bar');
    var selectUsersPage = document.getElementById('select-users-page');

    chatBody.style.position = "relative";
    chatBody.style.zIndex = '1';
    chatBody.style.opacity = '1';

    topBar.style.position = "relative";
    topBar.style.zIndex = '1';
    topBar.style.opacity = '1';

    selectUsersPage.style.position = "absolute";
    selectUsersPage.style.zIndex = '-1';
    selectUsersPage.style.opacity = '0';

}

// Function To show Users Page
// ???????? ??????????
function showUsersPage() {
    console.log("Yees");
    var  chatBody = document.getElementById('chat-body');
    var topBar = document.getElementById('top-bar');
    var selectUsersPage = document.getElementById('select-users-page');
    chatBody.style.position = "absolute";
    chatBody.style.zIndex = '-1';
    chatBody.style.opacity = '0';

    topBar.style.position = "absolute";
    topBar.style.zIndex = '-1';
    topBar.style.opacity = '0';

    selectUsersPage.style.position = "realtive";
    selectUsersPage.style.zIndex = '1';
    selectUsersPage.style.opacity = '1';
}

function showUsersPage2() {
    var chatBody = document.getElementById('chat-body');
    var topBar = document.getElementById('top-bar');
    var selectUsersPage = document.getElementById('select-users-page');

    chatBody.style.position = "absolute";
    chatBody.style.zIndex = '-1';
    chatBody.style.opacity = '0';

    topBar.style.position = "absolute";
    topBar.style.zIndex = '-1';
    topBar.style.opacity = '0';

    selectUsersPage.style.position = "realtive";
    selectUsersPage.style.zIndex = '1';
    selectUsersPage.style.opacity = '1';
}


// Function To Show Chatting Page
function showChatingUserPage(element){
    var selectUsersPage = document.getElementById('select-users-page');
    var name = element.children[1].children[0];
    var userName = document.getElementById('groub-name');
    var chattingPage = document.getElementById('chating-page');
    var topChat = document.getElementById('top-chat');


    selectUsersPage.style.opacity = '0';
    selectUsersPage.style.zIndex = '-1';
    selectUsersPage.style.position = 'absolute';

    chattingPage.style.opacity = '1';
    chattingPage.style.zIndex = '1';
    userName.textContent = name.textContent;

    topChat.setAttribute('onclick','hideChatingPage2()');

}


// Function To Hide Chating Page When You Come From User Page
function hideChatingPage2(){
    var chatBody = document.getElementById('chating-page');
    var selectUsersPage = document.getElementById('select-users-page');
    var topBar = document.getElementById('top-bar');
    console.log("tee");
    chatBody.style.opacity = '0';
    chatBody.style.zIndex = '-1';
    chatBody.style.position = 'absolute';

    topBar.style.opacity = '0';
    topBar.style.zIndex = '-1';
    topBar.style.position = 'absolute';

    selectUsersPage.style.opacity = '1';
    selectUsersPage.style.zIndex = '1';
    selectUsersPage.style.position = 'relative';
}

// End Chat Page








// Start Ajax Section


//Start Admin Api
function adimn_Roomes(element) {
    var mybranch = element.getAttribute("branch");
    var myroleName = element.getAttribute("roleName");
    var adminRooms = document.getElementById("adminRooms");
    var url = "../api/Room/TestRooms";

        $.ajax({
            type: "GET",
            url: url,
            data: { roleName: myroleName, branch: mybranch } ,
            contentType: "application/json",
            dataType: "json",
            success: function (success) {
                adminRooms.innerHTML = "";
                if (success.length == 0) {
                    console.log("No Rooms");
                }
                else {
                    console.log(success);
                    success.forEach(function (item) {
                        if (item.lastMSG == null) {
                            console.log("No Message");
                            adminRooms.innerHTML +=
                                ' <div roomID="' + item.roomId+'" onclick="showChatingUserPage(this);adminChat(this)" class="body-user filter">' +
                                '<div class="col-4 icon">' +
                                '<i class="fa fa-user"></i>' +
                                ' </div>' +
                                ' <div class="col-5 name">' +
                                ' <h3>' + item.userName + '</h3>' +
                                ' <p>' + "???????????? ??????????" + '</p>' +
                                ' </div>' +
                                '<div class="col-3 time">' +
                                '<p>' + theTime(new Date()) + '</p>' +
                                '<div class="state"></div>' +
                                '</div>' +
                                '</div >'
                        }
                        else {
                            adminRooms.innerHTML +=
                                ' <div roomID="' + item.roomId + '" onclick="showChatingUserPage(this);adminChat(this)" class="body-user filter">' +
                                '<div class="col-4 icon">' +
                                '<i class="fa fa-user"></i>' +
                                ' </div>' +
                                ' <div class="col-5 name">' +
                                ' <h3>' + item.userName + '</h3>' +
                                ' <p>' + item.lastMSG + '</p>' +
                                ' </div>' +
                                '<div class="col-3 time">' +
                                '<p>' + theTime(item.lastDate) + '</p>' +
                                '<div class="state"></div>' +
                                '</div>' +
                                '</div >'

                        }
                            
                    })
                }

            }
        });


}


function adimn_Individual_Roomes(userId) {
    //GetOrCreateIndividualRoom
    console.log(userId);
    var url = "../api/Room/GetAllIndividualRoom";
    $.ajax({
        type: "GET",
        url: url,
        data: { userId: userId },
        contentType: "application/json",
        dataType: "json",
        success: function (messages) {
            if (messages.length == 0) {
                console.log("No Messgae");
            }
        }
    })
    //string userId, string recievedId

}



//Start Admin Chat
function adminChat(element) {
    var roomID = element.getAttribute("roomID");
    var chat_messages = document.getElementById('chat_messages');
    var messageInput = document.getElementById("messageInput");
    var inputForRoomId = document.getElementById("inputForRoomId");
    inputForRoomId.setAttribute("roomID", roomID);

    messageInput.setAttribute("room_id", roomID);
    chat_messages.innerHTML = "";



    userID = parseInt(localStorage.getItem("id"));

    var url = "../api/Room/getRoomChats";
    $.ajax({
        type: "GET",
        url: url,
        data: { roomId: roomID, userId: localStorage.getItem("id") },
        contentType: "application/json",
        dataType: "json",
        success: function (messages) {
            if (messages.length == 0) {
                console.log("No Messgae");
            }
            else {
                messages.forEach(function (item) {

                    if (localStorage.getItem("id") == item.userId) {

                        chat_messages.innerHTML =
                            '<div id="chat_messages" class="col-12 my-message">' +
                            '<div class="the-message">' +
                            '<p>' + item.message + '</p>' +
                            '<div class="time">' +
                            '<p>' + theTime(item.date) + '</p>' +
                            '</div>' +
                            '</div>' +
                            '</div >' + chat_messages.innerHTML;
                    }
                    else {

                        chat_messages.innerHTML =
                            '<div class="col-12 his-message">' +
                            '<div class="the-message">' +
                            '<div class="name">' +
                            '<p>' + item.userName + '</p>' +
                            '</div>' +
                            '<p>' + item.message + '</p>' +
                            '<div class="time">' +
                            '<p>' + theTime(item.date) + '</p>' +
                            '</div>' +
                            '</div>' +
                            '</div>' + chat_messages.innerHTML;
                    }

                })
            }
        }
    });
}


//Ens Admin Chat

//End Admin Api




//Start Customer Api
function customer_Roomes(element) {
    var room_id = element.getAttribute("room_id");
    var user_id = element.getAttribute("user_id");
    var chat_messages = document.getElementById("chat_messages");
    var inputForRoomId = document.getElementById("inputForRoomId");
    inputForRoomId.setAttribute("roomID", room_id);


    chat_messages.innerHTML = "";
    console.log("Its Work");

    var url = "../api/Room/getRoomChats";
    $.ajax({
        url: url,
        method: "GET",
        data: { "roomId": room_id, "userId": user_id },
        contentType: "application/json",
        dataType: "json",
        success: function (messages) {
            if (messages.length == 0) {
                console.log("No Messgae");
            }
            else {
                messages.forEach(function (item) {
                   
                    if (localStorage.getItem("id") == item.userId) {
  
                        chat_messages.innerHTML =
                            '<div id="chat_messages" class="col-12 my-message">' +
                            '<div class="the-message">' +
                            '<p>' + item.message + '</p>' +
                            '<div class="time">' +
                            '<p>' + theTime(item.date) + '</p>' +
                            '</div>' +
                            '</div>' +
                            '</div >' + chat_messages.innerHTML;
                    }
                    else {

                        chat_messages.innerHTML =
                            '<div class="col-12 his-message">' +
                            '<div class="the-message">' +
                            '<div class="name">' +
                            '<p>' + item.userName + '</p>' +
                            '</div>' +
                            '<p>' + item.message + '</p>' +
                            '<div class="time">' +
                            '<p>' + theTime(item.date) + '</p>' +
                            '</div>' +
                            '</div>' +
                            '</div>' + chat_messages.innerHTML;
                    }
                    
                })
            }

        }
    })
}




























//Function To Now The Time
function theTime(time) {
    var dbTime = moment(time);
    var thisDay = new Date();
    var currentTime = moment(thisDay);

    dbTime.set({ hour: 0, minute: 0, second: 0, millisecond: 0 });
    currentTime.set({ hour: 0, minute: 0, second: 0, millisecond: 0 });
    var isDiffrent = dbTime.diff(currentTime, 'days');

    if (isDiffrent === -1) {
        var yesterday = "??????";
        return moment(time).format("hh:mma")+" " + yesterday;
    }
    else if (isDiffrent < -1) {
        return moment(time).format("DD MM YYYY , LT");
    }
    else {
        return moment(time).format("LT");
    }

}

function theTime2(time) {
    var dbTime = moment(time);
    var thisDay = new Date();
    var currentTime = moment(thisDay);

    dbTime.set({ hour: 0, minute: 0, second: 0, millisecond: 0 });
    currentTime.set({ hour: 0, minute: 0, second: 0, millisecond: 0 });
    var isDiffrent = dbTime.diff(currentTime, 'days');

    console.log(dbTime.diff(currentTime, 'days'));
    if (isDiffrent === -1) {
        var yesterday = "??????";
        this.innerHTML = moment(time).format("hh:mma") + " " + yesterday;
    }
    else if (isDiffrent < -1) {
        this.innerHTML = moment(time).format("DD MM YYYY , LT");
    }
    else {
        this.innerHTML = moment(time).format("LT");
    }

}

//End Customer Api




// End Ajax Section



//Start Groups Api 
function group_Roomes(element){
    var room_id = element.getAttribute("room_id");
    var user_id = element.getAttribute("user_id");
    var chat_messages = document.getElementById("chat_messages");
    var messageInput = document.getElementById("messageInput");

    chat_messages.innerHTML = "";
    var inputForRoomId = document.getElementById("inputForRoomId");
    inputForRoomId.setAttribute("roomID", room_id);


    messageInput.setAttribute("room_id", element.getAttribute("room_id"));


    var url = "../api/Room/getRoomChats";
    $.ajax({
        url: url,
        method: "GET",
        data: { "roomId": room_id, "userId": user_id },
        contentType: "application/json",
        dataType: "json",
        success: function (messages) {
            if (messages.length == 0) {
                console.log("No Mwssgae");
            }
            else {
                messages.forEach(function (item) {

                    if (localStorage.getItem("id") == item.userId) {

                        chat_messages.innerHTML =
                            '<div id="chat_messages" class="col-12 my-message">' +
                            '<div class="the-message">' +
                            '<p>' + item.message + '</p>' +
                            '<div class="time">' +
                            '<p>' + theTime(item.date) + '</p>' +
                            '</div>' +
                            '</div>' +
                            '</div >' + chat_messages.innerHTML;
                    }
                    else {

                        chat_messages.innerHTML =
                            '<div class="col-12 his-message">' +
                            '<div class="the-message">' +
                            '<div class="name">' +
                            '<p>' + item.userName + '</p>' +
                            '</div>' +
                            '<p>' + item.message + '</p>' +
                            '<div class="time">' +
                            '<p>' + theTime(item.date) + '</p>' +
                            '</div>' +
                            '</div>' +
                            '</div>' + chat_messages.innerHTML;
                    }

                })
            }

        }
    })
}



//End Groups Api






















//Start Function  To Send The Message
function send(userid, thetype) {
    var messageInput = document.getElementById("messageInput");
    var roomId = messageInput.getAttribute('room_id');
    var chat_messages = document.getElementById("chat_messages");
    var time = new Date();

    var url = "../api/Chat/CreateChat";

    var data = {
        //ChatId:"",
        UserId: userid,
        RoomId: parseInt(roomId),
        Type: thetype,
        Message: messageInput.value
    }
    dataSend = JSON.stringify(data);


    $.ajax({
        url: url,
        contentType: "application/json",
        dataType: "json",
        method: "POST",
        data: dataSend,
        success: function (Resbons) {
            if (Resbons) {
                chat_messages.innerHTML =
            '<div id="chat_messages" class="col-12 my-message">' +
                '<div class="the-message">' +
                '<p>' + data.Message + '</p>' +
            '<div class="time">' +
            '<p>' + theTime(time) + '</p>' +
            '</div>' +
            '</div>' +
            '</div >' + chat_messages.innerHTML;
                messageInput.value = "";

                sendMessage(data.UserId, data.Message, data.RoomId, data.Type, time);
            }
        }
    })

}

//Start Function  To Send The Message
