﻿const { signalR } = require("../../../lib/microsoft-signalr/signalr");

var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:6862/auctionhub").build();
var auctionId = document.getElementById("AuctionId").value;



//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

var groupName = "auction-" + auctionId;

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    connection.invoke("AddToGroup", groupName).catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
})


