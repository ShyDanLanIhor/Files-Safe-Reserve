window.startKeyListener = function () {
    window.addEventListener("keyup", keyUpHandler);
    window.addEventListener("keyup", keyUpHandler);
}

window.stopKeyListener = function () {
    window.removeEventListener("keyup", keyUpHandler);
    window.removeEventListener("keyup", keyUpHandler);
}

function keyUpHandler(event) {
    let shortcut = {
        key: {
            code: event.keyCode,
            value: event.key
        },
        modifiers: {
            shift: { isPressed: event.shiftKey },
            control: { isPressed: event.ctrlKey },
            meta: { isPressed: event.metaKey },
            alt: { isPressed: event.altKey }
        }
    };

    DotNet.invokeMethodAsync('FilesSafeReserve.UI', 'HandleKeyUp', shortcut);
}