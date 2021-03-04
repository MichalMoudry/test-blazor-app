const { createWorker } = Tesseract;
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

async function recog(fields, imageData, lang) {
    //fields["height"] = fields["height"] + "px";
    //fields["width"] = fields["width"] + "px";
    //fields["xposition"] = fields["xposition"] + "px";
    //fields["yposition"] = fields["yposition"] + "px";
    await worker.load();
    await worker.loadLanguage(lang);
    await worker.initialize(lang);
    var results = [];

    for (var i = 0; i < fields.length; i++) {
        const { data: { text } } = await worker.recognize(document.getElementById(imageData).src,
        {
            rectangle: { top: fields[i]["xposition"], left: fields[i]["yposition"], width: fields[i]["width"], height: fields[i]["height"] }
        });
        results.push(text);
    }
    await worker.terminate();
    return results;
}

async function recognizeFields(imageID, lang) {
    var fields = document.getElementsByClassName("template-field");
    var fieldHeight;
    var fieldWidth;
    var fieldTop;
    var fieldLeft;
    var results = [];
    var imageSrc = document.getElementById(imageID).src;
    await worker.load();
    await worker.loadLanguage(lang);
    await worker.initialize(lang);
    for (var i = 0; i < fields.length; i++) {
        fieldHeight = fields[i].style.height;
        fieldHeight = fieldHeight.substring(0, fieldHeight.length - 2);
        fieldWidth = fields[i].style.width;
        fieldWidth = fieldWidth.substring(0, fieldWidth.length - 2);
        fieldTop = fields[i].style.top;
        fieldTop = fieldTop.substring(0, fieldTop.length - 2);
        fieldLeft = fields[i].style.left;
        fieldLeft = fieldLeft.substring(0, fieldLeft.length - 2);
        const { data: { text } } = await worker.recognize(imageSrc,
        {
            rectangle: { top: fieldTop, left: fieldLeft, width: fieldWidth, height: fieldHeight }
        });
        results.push(text);
    }
    console.log(results);
    await worker.terminate();
}

//Method for obtaining properies of a specific template field.
function getFieldProperties(fieldID) {
    var field = document.getElementById(fieldID);
    if (field != null) {
        return field.style.width.substring(0, field.style.width.length - 2) + "," +
            field.style.height.substring(0, field.style.height.length - 2) + "," +
            field.style.top.substring(0, field.style.top.length - 2) + "," +
            field.style.left.substring(0, field.style.left.length - 2);
    }
    else {
        return null;
    }
}

function drawField(fieldID) {
    var existingField = document.getElementById(fieldID);
    if (existingField != null) {
        existingField.remove();
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