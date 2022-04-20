"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/kitchenHub").build();

connection.on("kitchenInfoUpdate", function () {

    window.location.reload("kitchen");
});

connection.start().then(function () {
    console.log("Connected");
}).catch(function (err) {
    console.error(err.toString());
});

