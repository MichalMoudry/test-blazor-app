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