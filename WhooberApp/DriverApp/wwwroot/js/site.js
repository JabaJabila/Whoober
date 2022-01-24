// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function drawCircle(ctx, x, y, r) {
    ctx.beginPath();
    ctx.arc( x, y, r, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
}

function clearCanvas(ctx) {
    ctx.save();
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
    ctx.restore();
}