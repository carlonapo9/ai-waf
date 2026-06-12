const connection = new signalR.HubConnectionBuilder()
    .withUrl("/wafHub")
    .build();

connection.on("ReceiveLog", function (log) {
    const table = document.getElementById("logTable");

    const row = table.insertRow(0);

    row.innerHTML = `
        <td>${log.ip}</td>
        <td>${log.path}</td>
        <td>${log.statusCode}</td>
        <td>${log.timestamp}</td>
    `;
});

connection.start();
