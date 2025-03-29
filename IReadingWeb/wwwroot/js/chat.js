// chat.js
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub", {
        //transport: signalR.HttpTransportType.WebSockets, 
        withCredentials: true                         
    })
    .withAutomaticReconnect()
    .build();


connection.on('ReceiveMessage', (user, message) => {
    console.log(message);
    //const li = document.createElement('li');
    //li.textContent = `${user}: ${message}`;
    //document.getElementById('messagesList').appendChild(li);
    if (user != "Hệ thống") {
        const container = document.getElementById("chatMessages");
        const botMsg = document.createElement("div");
        botMsg.className = "message1 bot";
        botMsg.textContent = message;
        container.appendChild(botMsg);
        container.scrollTop = container.scrollHeight;
    }

});

connection.start()
    .then(() => console.log("Connected to SignalR"))
    .catch(err => console.error("Connection failed:", err));
//connection.start().catch(err => console.error(err.toString()));

//function sendMessage(message) {
//    const user = 'User';
//    //const message = document.getElementById('messageInput').value;
//    connection.invoke('SendMessage', user, message).catch(err => console.error(err.toString()));
//}

function sendMessage(roomName,message) {
    const user = 'User';
    //const message = document.getElementById('messageInput').value;
    connection.invoke('SendMessageToRoom',roomName, user, message).catch(err => console.error(err.toString()));
}

function joinRoom(roomName,user) {
    connection.invoke('JoinRoom', user, roomName).catch(err => console.error(err.toString()));
}