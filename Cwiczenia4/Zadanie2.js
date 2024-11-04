function setupCanvas(canvas) {
    const ctx = canvas.getContext('2d');

    canvas.addEventListener('mousemove', function (event) {
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        const rect = canvas.getBoundingClientRect();
        const x = event.clientX - rect.left;
        const y = event.clientY - rect.top;

        ctx.beginPath();
        ctx.moveTo(0, 0);
        ctx.lineTo(x, y);
        ctx.moveTo(canvas.width, 0);
        ctx.lineTo(x, y);
        ctx.moveTo(0, canvas.height);
        ctx.lineTo(x, y);
        ctx.moveTo(canvas.width, canvas.height);
        ctx.lineTo(x, y);
        ctx.stroke();
    });

    canvas.addEventListener('mouseleave', function () {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    });

    function resizeCanvas() {
        canvas.width = canvas.clientWidth;
        canvas.height = canvas.clientHeight;
    }

    resizeCanvas();
    window.addEventListener('resize', resizeCanvas);
}

document.querySelectorAll('.drawingX').forEach(setupCanvas);
