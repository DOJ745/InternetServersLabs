var textArea;
var web_socket = null;

var bstart;
var bstop;
window.onload = function() {
    if(Modernizr.websockets) {
        WriteMessage("support", "Да");
        textArea = document.getElementById("textArea");
        bstart = document.getElementById("bstart");
        bstop = document.getElementById("bstop");

        bstart.disabled = false;
        bstop.disabled = true;
    }
}

function WriteMessage(idspan, txt) {
    var span = document.getElementById(idspan);
    span.innerHTML = txt;
}

function exe_start() {
    if (web_socket == null) {
        web_socket = new WebSocket("ws://localhost:44383/Websockets.websocket");
        web_socket.onopen = function() { web_socket.send("Соеднение"); }
        web_socket.onclose = function(s) { console.log("onsclose", s); }

        web_socket.onmessage = function(evt) { textArea.innerHTML += "\n" + evt.data }

        bstart.disabled = true;
        bstop.disabled = false;
    }
}

function exe_stop() {
    web_socket.close(3001, "stopApplication");
    web_socket = null;

    bstart.disabled = false;
    bstop.disabled = true;
}