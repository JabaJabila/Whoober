function map(imageWidth, imageHeight) {
    pointsContainer = document.getElementById("pointsContainer");
    canvas = document.getElementById("overlay");
    canvas.width = document.body.clientWidth;
    canvas.height = document.body.clientHeight;
    renderContext = canvas.getContext("2d");

    let points = [];

    function tryPutPoint(x, y) {
        if (x < 0 || x > imageWidth || y < 0 || y > imageHeight)
            return;
        if (points.length >= 10) {
            alert("The max path length is ten points");
            return;
        }
        let pointString = Math.floor(x) + ", " + Math.floor(y);
        let pointEl = document.createElement("p");

        pointEl.innerText = pointString;
        pointEl.className = "point";
        pointsContainer.append(pointEl);

        pointEl.onclick = function (mouseEvent) {
            mouseEvent.target.remove();
            recollectPoints();
        }

        points[points.length] = [x * 1, y * 1];
        redrawCanvas();
    }

    function recollectPoints() {
        points = GetPoints();
        redrawCanvas();
    }

    function redrawCanvas() {
        renderContext.setTransform(1, 0, 0, 1, 0, 0);
        renderContext.clearRect(0, 0, renderContext.canvas.width, renderContext.canvas.height);
        let prevX;
        let prevY;
        renderContext.fillStyle = 'pink';
        renderContext.outlineColor = 'pink';
        renderContext.lineWidth = 4;
        for (let i = 0; i < points.length; i++) {
            let x = points[i][0] * scale + dx;
            let y = points[i][1] * scale + dy;
            if (prevX !== undefined) {
                renderContext.moveTo(prevX, prevY);
                renderContext.lineTo(x, y);
                renderContext.stroke();
            }
            renderContext.beginPath();
            renderContext.arc( x, y, 12, 0, 2 * Math.PI, false);
            renderContext.fill();
            renderContext.stroke();
            prevX = x;
            prevY = y;
        }
    }

    document.oncontextmenu = function(e){
        stopEvent(e);
    }

    function stopEvent(event){
        if(event.preventDefault !== undefined)
            event.preventDefault();
        if(event.stopPropagation !== undefined)
            event.stopPropagation();
    }

    let img = document.getElementById("img");

    let dx = -imageWidth/2 + img.clientWidth/2;
    let dy = 0;
    let scale = 1;
    let wheelState = 10;

    let mouseIsDown = false;
    let downX;
    let downY;

    img.style.backgroundSize = imageWidth + "px"

    canvas.addEventListener("mousewheel",onmousewheel, false);
    canvas.addEventListener("DOMMouseScroll",onDOMMouseScroll, false);

    canvas.addEventListener("mousedown",onmousedown);
    canvas.addEventListener("mouseup",onmouseup);
    canvas.addEventListener("mousemove",onmousemove);
    canvas.addEventListener("contextmenu", oncontextmenu);

    function onmousewheel(e) {
        wheel(e.detail/360, e.x, e.y);
    }

    function onDOMMouseScroll(e) {
        wheel(e.detail/3, e.x, e.y);
    }

    function wheel(size, x, y) {
        let newWheelState = wheelState - size;
        if (newWheelState > 20)
            newWheelState = 20;
        if (newWheelState < 1)
            newWheelState = 1;

        let tmpX = (-dx + x) / scale;
        let tmpY = (-dy + y) / scale;
        scale = Math.pow(newWheelState/10, 2);
        dx = x - tmpX * scale;
        dy = y - tmpY * scale;

        img.style.backgroundSize = imageWidth * scale + "px"
        img.style.backgroundPositionX = dx + "px";
        img.style.backgroundPositionY = dy + "px";
        redrawCanvas();

        wheelState = newWheelState;
    }

    function onmousedown(e) {
        mouseIsDown = true;
        downX = e.layerX - dx;
        downY = e.layerY - dy;
    }

    function onmouseup(e) {
        mouseIsDown = false;
    }

    function onmousemove(e) {
        if (mouseIsDown) {
            dx = (e.x - downX);
            dy = (e.y - downY);
            img.style.backgroundPositionX = dx + "px";
            img.style.backgroundPositionY = dy + "px";
            redrawCanvas();
        }
    }

    img.style.backgroundPositionX = dx + "px";
    img.style.backgroundPositionY = dy + "px";
    redrawCanvas();

    function oncontextmenu(e) {
        tryPutPoint((e.x - dx)/scale, (e.y - dy)/scale);
    }
}

function GetPoints() {
    let newPoints = [];
    let pointElements = pointsContainer.children;
    for (let i = 0; i < pointElements.length; i++) {
        let parts = pointElements[i].innerText.split(", ");
        newPoints[newPoints.length] = [parts[0].trim()*1, parts[1].trim()*1];
    }
    
    return newPoints;
}
