function executeJS(code) {
    try {
        eval(code);
    } catch (e) {
        console.error("Execution of code failed.");
    }
}

function uncheckCheckboxes(checkboxIdArray) {
    for (var i = 0; i < checkboxIdArray.length; i++) {
        document.getElementById(checkboxIdArray[i]).checked = false;
    }
}

function drawField() {
    var canvas = document.getElementById("template-canvas");
    console.log(canvas);
    if (canvas != null) {
        var fieldRectangle;
        var startX = 0;
        var startY = 0;
        var x = 0;
        var y = 0;
        if (canvas.onclick == null) {
            canvas.onclick = function (e) {
                if (fieldRectangle == null) {
                    fieldRectangle = document.createElement("div");
                    fieldRectangle.classList.add("template-field");
                    canvas.appendChild(fieldRectangle);
                    startX = x;
                    startY = y;
                    fieldRectangle.style.left = x + "px";
                    fieldRectangle.style.top = y + "px";
                    canvas.appendChild(fieldRectangle);
                    console.log("Drawing started. Start X: " + startX + " start Y: " + startY);
                }
                else {
                    fieldRectangle = null;
                    console.log("Start X: " + startX + " | Start Y: " + startY + " | x: " + x + " | y: " + y);
                    console.log("Field was drawn.");
                    canvas.onclick = null;
                    canvas.onmousemove = null;
                }
            }
        }

        if (canvas.onmousemove == null) {
            canvas.onmousemove = function (e) {
                x = e.pageX + window.pageXOffset;
                y = e.pageY + window.pageYOffset;
                if (fieldRectangle != null) {
                    fieldRectangle.style.width = (x - startX) + "px";
                    fieldRectangle.style.height = (y - startY) + "px";
                    fieldRectangle.style.left = ((x - startX) < 0) ? x + "px" : startX + "px";
                    fieldRectangle.style.top = ((y - startY) < 0) ? y + "px" : startY + "px";
                }
            }
        }
    }
}