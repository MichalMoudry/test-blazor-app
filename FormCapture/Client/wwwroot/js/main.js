const { createWorker } = Tesseract;

function executeJS(code) {
    try {
        eval(code);
        return true;
    } catch (e) {
        console.error("Execution of code failed.");
        return false;
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

async function recog(fields, images, lang, contentTypes) {
    //fields["height"] = fields["height"] + "px";
    //fields["width"] = fields["width"] + "px";
    //fields["xposition"] = fields["xposition"] + "px";
    //fields["yposition"] = fields["yposition"] + "px";
    const worker = createWorker();
    await worker.load();
    await worker.loadLanguage(lang);
    await worker.initialize(lang);
    var results = [];

    for (var i = 0; i < images.length; i++) {
        for (var x = 0; x < fields.length; x++) {
            const { data: { text } } = await worker.recognize("data:" + contentTypes[i] + ";base64," + images[i],
            {
                rectangle: { top: fields[x]["xposition"], left: fields[x]["yposition"], width: fields[x]["width"], height: fields[x]["height"] }
            });
            results.push(text.replace(/\s/g, "") + "/" + fields[x]["id"]);
        }
    }
    await worker.terminate();
    return results;
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