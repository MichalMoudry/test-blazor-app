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

function getImageProperties(imageID) {
    var img = document.getElementById(imageID);
    return img.naturalWidth + "|" + img.naturalHeight;
}

function readUploadedFilesAsText(input) {
    const temporaryFileReader = new FileReader();
    return new Promise((resolve, reject) => {
        temporaryFileReader.onerror = () => {
            temporaryFileReader.abort();
            reject(new DOMException("Problem parsing input file."));
        };
        temporaryFileReader.addEventListener("load", function () {
            var data = temporaryFileReader.result.split(',')[1];
            resolve(data);
        }, false);
        temporaryFileReader.readAsDataURL(input.files[0]);
    });
}

function getFileData(inputID) {
    return readUploadedFilesAsText(document.getElementById(inputID));
}

function drawField() {
    var canvas = document.getElementById("template-canvas");
    console.log(canvas);
    if (canvas != null) {
        var fieldRectangle;
        var startX;
        var startY;
        canvas.onclick = function (e) {
            if (fieldRectangle == null) {
                fieldRectangle = document.createElement("div");
                fieldRectangle.classList.add("template-field");
                canvas.appendChild(fieldRectangle);
                startX = e.pageX;
                startY = e.pageY;
                console.log("Drawing started. Start X: " + startX + " start Y: " + startY);
            }
            else {
                fieldRectangle = null;
                console.log("Field was drawn.");
            }
        }

        canvas.onmousemove = function (e) {

        }
    }
}