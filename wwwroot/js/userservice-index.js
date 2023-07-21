"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/userservice").build();
connection.start();

connection.on("IdentifyStatus", function (status) {
    switch (status) {
        case 1:
            document.getElementById("authButton").value = "InProgress";
            break;
        case 2:
            document.getElementById("authButton").value = "Success";
            break;
        case 3:
            document.getElementById("authButton").value = "Exception";
            break;
        default:
            break;
    }
    
});

document.getElementById("authButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var password = document.getElementById("passwordInput").value;
    connection.invoke("Identify", user, password).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});