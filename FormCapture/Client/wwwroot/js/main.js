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