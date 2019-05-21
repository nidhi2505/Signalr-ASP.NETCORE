
var editor = document.getElementById("editor");

const connection = new signalR.HubConnectionBuilder().withUrl("/communicationhub").build();
connection.start().catch(err => console.error(err));

connection.on("RecieveMessage", (text) => {
    editor.value = text;
    editor.focus();
    editor.setSelectionRange(editor.value.length, editor.value.length);
}); 

function change() {
    connection.invoke("BroadcastMessage", editor.value).catch(err => console.error(err));
}


