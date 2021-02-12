﻿const { createWorker } = Tesseract;
const worker = createWorker();

function executeJS(code) {
    try {
        eval(code);
    } catch (e) {
        console.error("Execution of code failed.");
    }
}

function getImageProperties(imageID) {
    var img = document.getElementById(imageID);
    return img.naturalWidth + "|" + img.naturalHeight;
}

function uncheckCheckboxes(checkboxIdArray) {
    for (var i = 0; i < checkboxIdArray.length; i++) {
        document.getElementById(checkboxIdArray[i]).checked = false;
    }
}

async function recognizeFields() {
    var fields = document.getElementsByClassName("template-field");
    var imgProperties = getImageProperties("template-preview-image");
    await worker.load();
    await worker.loadLanguage('eng');
    await worker.initialize('eng');
    console.log(fields[0].style.height + " - " + fields[0].style.width);
}

function drawField(fieldID) {
    var existingField = document.getElementById(fieldID);
    if (existingField != null) {
        console.error("Field was alredy drawn.");
        return;
    }
    var canvas = document.getElementById("template-canvas");
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
                    fieldRectangle.id = fieldID;
                    canvas.style.cursor = "crosshair";

                    startX = e.offsetX;
                    startY = e.offsetY;

                    fieldRectangle.style.top = startX + "px";
                    fieldRectangle.style.left = startY + "px";

                    canvas.appendChild(fieldRectangle);

                    //console.log("Drawing started. Start X: " + startX + " start Y: " + startY);
                }
                else {
                    fieldRectangle = null;
                    //console.log("x: " + x + " | y: " + y);
                    //console.log("Field was drawn.");
                    canvas.style.cursor = "pointer";
                    canvas.onclick = null;
                    canvas.onmousemove = null;
                }
            }
        }

        if (canvas.onmousemove == null) {
            canvas.onmousemove = function (e) {
                if (fieldRectangle != null) {
                    x = e.offsetX;
                    y = e.offsetY;
                    fieldRectangle.style.width = (x - startX) + "px";
                    fieldRectangle.style.height = (y - startY) + "px";
                    fieldRectangle.style.left = ((x - startX) < 0) ? x + "px" : startX + "px";
                    fieldRectangle.style.top = ((y - startY) < 0) ? y + "px" : startY + "px";
                }
            }
        }
    }
}