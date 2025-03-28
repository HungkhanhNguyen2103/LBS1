// chat.js
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub", {
        transport: signalR.HttpTransportType.WebSockets, 
        skipNegotiation: true                          
    })
    .withAutomaticReconnect()
    .build();

connection.on('ReceiveMessage', (user, message) => {
    //console.log(message);
    //const li = document.createElement('li');
    //li.textContent = `${user}: ${message}`;
    //document.getElementById('messagesList').appendChild(li);
    const container = document.getElementById("chatMessages");
    const botMsg = document.createElement("div");
    botMsg.className = "message1 bot";
    botMsg.textContent = message;
    container.appendChild(botMsg);
    container.scrollTop = container.scrollHeight;
});

connection.start().catch(err => console.error(err.toString()));

function sendMessage(message) {
    const user = 'test';
    //const message = document.getElementById('messageInput').value;
    connection.invoke('SendMessage', user, message).catch(err => console.error(err.toString()));
}
