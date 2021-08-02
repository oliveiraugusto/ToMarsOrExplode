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
    let probe = selectedProbe();
    let elem = document.getElementById(probe);
    let x = elem.style.transform.replace(/\D+/g, '');
    let val = parseInt(x, 10);
    elem.style.transform = `rotate(${val - 90}deg)`;
}

function rotateRight() {
    let probe = selectedProbe();
    let elem = document.getElementById(probe);
    let x = elem.style.transform.replace(/\D+/g, '');
    let val = parseInt(x, 10);
    elem.style.transform = `rotate(${val + 90}deg)`;
}

function moveLeft() {
    let probe = selectedProbe();
    let elem = document.getElementById(probe);
    let val = parseInt(elem.style.left, 10);
    elem.style.left = (val + 1) + "px";
}

function moveRight() {
    let probe = selectedProbe();
    let elem = document.getElementById(probe);
    let val = parseInt(elem.style.bottom, 10);
    elem.style.bottom = (val + 1) + "px";
}

function selectedProbe() {
    let e = document.getElementById("list-select-probe");
    return e.options[e.selectedIndex].value;
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