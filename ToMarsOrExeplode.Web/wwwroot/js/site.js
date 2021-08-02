// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var probe = 0;

function startProbe() {
    if (probe < 4) {
        document.getElementById("list-select-probe").innerHTML += `<option value='probe${probe}'>Probe ${probe}</option>`;
        document.getElementById("navigation-probe").innerHTML += `<img id='probe${probe}' style='left: 0; bottom: 0; transform: rotate(0);' title='Probe ${probe}' src='images/spaceship-icon-${probe}.png' />`;
        probe++;
    }
    else {
        alert("Error: only 4 probes are possible!");
    }
}

function rotateLeft() {
    if (verifyEmptyListProbe()) {
        let probe = selectedProbe();
        if (probe !== null) {
            let elem = document.getElementById(probe);
            let x = elem.style.transform.replace(/\D+/g, '');
            let val = parseInt(x, 10);
            elem.style.transform = `rotate(${-val - 90}deg)`;
        } else {
            alert("select a probe to control");
        }
    } else {
        alert("start a probe to control");
    }    
}

function rotateRight() {
    if (verifyEmptyListProbe()) {
        let probe = selectedProbe();
        if (probe !== null) {
            let elem = document.getElementById(probe);
            let x = elem.style.transform.replace(/\D+/g, '');
            let val = parseInt(x, 10);
            elem.style.transform = `rotate(${val + 90}deg)`;
        } else {
            alert("select a probe to control");
        }
    } else {
        alert("start a probe to control");
    }
}

function moveLeft() {
    if (verifyEmptyListProbe()) {
        let probe = selectedProbe();
        if (probe !== null) {        
            let elem = document.getElementById(probe);
            let val = parseInt(elem.style.left, 10);
            elem.style.left = (val + 1) + "px";
        } else {
        alert("select a probe to control");
        }
    } else {
        alert("start a probe to control");
    }
}

function moveRight() {
    if (verifyEmptyListProbe()) {
        let probe = selectedProbe();
        if (probe !== null) {
            let elem = document.getElementById(probe);
            let val = parseInt(elem.style.bottom, 10);
            elem.style.bottom = (val + 1) + "px";
        } else {
            alert("select a probe to control");
        }
    } else {
        alert("start a probe to control");
    }
}

function selectedProbe() {
    try {
        let e = document.getElementById("list-select-probe");
        return e.options[e.selectedIndex].value;
    } catch {
        return null;
    }    
}

function verifyEmptyListProbe() {
    let e = document.getElementById("list-select-probe").length;
    if (e > 0)
        return true;
    else
        return false;
}

document.addEventListener('keydown', (event) => {
    const keyName = event.key;
    if (keyName === 'ArrowRight')
        moveRight();
    else if (keyName === 'ArrowLeft')
        moveLeft();
    else if (keyName === 'ArrowUp')
        rotateLeft();
    else if (keyName === 'ArrowDown')
        rotateRight();
});