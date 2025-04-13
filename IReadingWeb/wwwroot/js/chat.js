// chat.js
let connection;

connectSignalR();
function connectSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub", {
            //transport: signalR.HttpTransportType.WebSockets, 
            withCredentials: true
        })
        .withAutomaticReconnect()
        .build();

    connection.start()
        .then(() => console.log("Connected to SignalR"))
        .catch(err => console.error("Connection failed:", err));
}

if (connection) {
    connection.on('Disconnect', (user, message) => {
        console.log(message);
        connection.stop().then(() => {
            console.log("Đã ngắt kết nối SignalR khi logout");
        });
    });
}
function disconnect(roomName) {
    if (connection) {
        connection.invoke("ForceDisconnect",roomName);
        connection.stop();
        connection.onclose(() => {
            console.log("SignalR disconnected.");
        });
        //connection.stop().then(() => {
        //    console.log("Đã ngắt kết nối SignalR khi logout");
        //});
    }
    //href = "/Account/Logout"
}


if (connection) {
    connection.on('ReceiveMessage', (user, message) => {
        //console.log(message);
        if (user != "System") {
            let container = document.getElementById("chatMessages");
            var roomNameDiv = container.dataset.roomname;
            var userDiv = document.getElementById(user);

            if (userDiv != null) {
                var parent = userDiv.parentElement;
                if (!parent.className.includes("active")) {
                    userDiv.classList.remove("d-none");
                }          
            }

            if (user == roomNameDiv) {
                let botMsg = document.createElement("div");
                botMsg.className = "message1 bot";
                botMsg.textContent = message;
                container.appendChild(botMsg);
                container.scrollTop = container.scrollHeight;
            }



        }

    });
}


function sendMessage(roomName,message) {
    connection.invoke('SendMessageToRoom',roomName, message).catch(err => console.error(err.toString()));
}

//function logout(currentRoom) {
//    connection.invoke("LeaveRoom", currentRoom)
//        .then(() => {
//            console.log("Đã rời phòng: " + currentRoom);
//            connection.stop();

//            window.location.href = '/Account/Logout';
//        })
//        .catch(err => console.error(err.toString()));
//}



