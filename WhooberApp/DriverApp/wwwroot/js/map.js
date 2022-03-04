let mapCalls = {};
let mapValues = {};

function setOnContextMenuListener(onContextMenuListener) {
    mapCalls['onContextMenuListener'] = onContextMenuListener;
}

function setOnUpdateMapViewListener(onUpdateMapViewListener) {
    mapCalls['onUpdateMapViewListener'] = onUpdateMapViewListener;
}

function map(imageWidth, imageHeight) {
    let canvas = document.getElementById("overlay");
    canvas.width = document.body.clientWidth;
    canvas.height = document.body.clientHeight;

    document.oncontextmenu = function (e) {
        stopEvent(e);
    }

    function stopEvent(event) {
        if (event.preventDefault !== undefined)
            event.preventDefault();
        if (event.stopPropagation !== undefined)
            event.stopPropagation();
    }

    let map = document.getElementById("map");

    mapValues['dx'] = -imageWidth / 2 + map.clientWidth / 2;
    mapValues['dy'] = 0;
    mapValues['scale'] = 1;
    let wheelState = 10;

    let mouseIsDown = false;
    let downX;
    let downY;

    map.style.backgroundSize = imageWidth + "px"

    canvas.addEventListener("mousewheel", onmousewheel, false);
    canvas.addEventListener("DOMMouseScroll", onDOMMouseScroll, false);

    canvas.addEventListener("mousedown", onmousedown);
    canvas.addEventListener("mouseup", onmouseup);
    canvas.addEventListener("mousemove", onmousemove);
    canvas.addEventListener("contextmenu", oncontextmenu);

    function onmousewheel(e) {
        let deltaY = e.deltaY;
        if (deltaY === 0)
            deltaY = e.detail;
        wheel(deltaY / 100, e.x, e.y);
    }

    function onDOMMouseScroll(e) {
        wheel(e.detail / 3, e.x, e.y);
    }

    function wheel(size, x, y) {
        wheelState -= size;
        if (wheelState > 20)
            wheelState = 20;
        if (wheelState < 1)
            wheelState = 1;

        let tmpX = (-mapValues['dx'] + x) / mapValues['scale'];
        let tmpY = (-mapValues['dy'] + y) / mapValues['scale'];
        mapValues['scale'] = Math.pow(wheelState / 10, 2);
        mapValues['dx'] = x - tmpX * mapValues['scale'];
        mapValues['dy'] = y - tmpY * mapValues['scale'];

        updateMapView();
    }

    function updateMapView() {
        map.style.backgroundSize = imageWidth * mapValues['scale'] + "px"
        map.style.backgroundPositionX = mapValues['dx'] + "px";
        map.style.backgroundPositionY = mapValues['dy'] + "px";
        if (mapCalls['onUpdateMapViewListener'] !== undefined)
            mapCalls['onUpdateMapViewListener'](mapValues['dx'], mapValues['dy'], mapValues['scale']);
    }
    mapCalls['invalidate'] = updateMapView;

    function onmousedown(e) {
        if (e.buttons === 2)
            return;
        mouseIsDown = true;
        downX = e.layerX - mapValues['dx'];
        downY = e.layerY - mapValues['dy'];
        canvas.style.cursor = "grabbing"
    }

    function onmouseup(e) {
        mouseIsDown = false;
        canvas.style.cursor = "default"
    }

    function onmousemove(e) {
        if (mouseIsDown) {
            mapValues['dx'] = (e.x - downX);
            mapValues['dy'] = (e.y - downY);
            updateMapView();
        }
    }

    updateMapView();

    function oncontextmenu(e) {
        if (mapCalls['onContextMenuListener'] !== undefined)
            mapCalls['onContextMenuListener']((e.x - mapValues['dx']) / mapValues['scale'],
                (e.y - mapValues['dy']) / mapValues['scale']);
    }
}

function GetPoints() {
    let newPoints = [];
    let pointElements = pointsContainer.children;
    for (let i = 0; i < pointElements.length; i++) {
        let parts = pointElements[i].innerText.split(", ");
        newPoints[newPoints.length] = [parts[0].trim() * 1, parts[1].trim() * 1];
    }

    return newPoints;
}

function translateX(x) {
    return x * mapValues['scale'] + mapValues['dx'];
}

function translateY(y) {
    return y * mapValues['scale'] + mapValues['dy'];
}

