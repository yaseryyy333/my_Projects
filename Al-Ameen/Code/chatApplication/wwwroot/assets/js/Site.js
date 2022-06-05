var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.on("ReceiveMessage", function (fromUser, message, roomId, type, time) {
    var chat_messages = document.getElementById("chat_messages");
    var inputForRoomId = document.getElementById("inputForRoomId");
    inputForRoomId = inputForRoomId.getAttribute("roomID");
    if (parseInt(inputForRoomId) == roomId) {
        chat_messages.innerHTML =
            '<div class="col-12 his-message">' +
            '<div class="the-message">' +
            '<div class="name">' +
            '<p>' + fromUser + '</p>' +
            '</div>' +
            '<p>' + message + '</p>' +
            '<div class="time">' +
            '<p>' + theTime(time) + '</p>' +
            '</div>' +
            '</div>' +
            '</div>' + chat_messages.innerHTML;
    }
});

connection.start();


function sendMessage(userId, message, roomId, type, time) {

    connection.invoke("SendMessage", userId, message, roomId,  type, time);
}