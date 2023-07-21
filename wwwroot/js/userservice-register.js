"use strict";
document.getElementById("userinfo").style.display = "none";

var connection = new signalR.HubConnectionBuilder().withUrl("/userservice").build();

connection.start();

var userid = 0;

connection.on("Registered", function (user) {
    userid = user;
    console.log(user);
    document.getElementById("userinfo").style.display = "block";
});

document.getElementById("registerButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var password = document.getElementById("passwordInput").value;
    connection.invoke("Register", user, password).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("updateInfoButton").addEventListener("click", function (event) {
    var FIO = document.getElementById("FIO").value;
    var INN = document.getElementById("INN").value;
    var Pasport = document.getElementById("Pasport").value;
    var Phone = document.getElementById("Phone").value;
    var Adress = document.getElementById("Adress").value;
    var JobTitle = document.getElementById("JobTitle").value;
    console.log(userid);
    connection.invoke("UpdateInfo", userid, FIO, INN, Pasport, Phone, Adress, Number(JobTitle)).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function hide(elements) {
    elements = elements.length ? elements : [elements];
    for (var index = 0; index < elements.length; index++) {
        elements[index].style.display = 'none';
    }
}