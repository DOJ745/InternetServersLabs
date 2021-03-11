var textArea;
var web_sock = null;

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
    if (web_sock == null) {
        
        web_sock = new WebSocket("wss://localhost:44383/.websocket");
        web_sock.onopen = function(e) { 
            alert("[open] Соединение установлено");
            web_sock.send("connect"); 
        }
        web_sock.onmessage = function(evt) { textArea.innerHTML += "\n" + evt.data; } 
        web_sock.onclose = function(s) { console.log("onsclose", s); }

        web_sock.onerror = function(error) {
            alert(`[error] ${error.message}`);
          };
        
        bstart.disabled = true;
        bstop.disabled = false;
    }
}

function exe_stop() {
    web_sock.close(3001, "stopApplication");
    web_sock = null;

    bstart.disabled = false;
    bstop.disabled = true;
}