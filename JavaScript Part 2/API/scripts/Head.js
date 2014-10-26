(function drawHead() {
    var context = canvasPlus("head");
    context.lineWidth = 3;
    context.fillStyle = "rgb(144, 202, 215)";
    context.strokeStyle = "rgb(41, 91, 102)";

    // head
    context.drawEllipse("fill", 100, 200, 80, 70);
    context.drawEllipse("stroke", 100, 200, 80, 70);

    // mouth
    context.drawEllipse("stroke", 85, 238, 30, 10, Math.PI / 18);

    // nose
    context.drawLine(85, 180, 68, 213);
    context.drawLine(68, 212, 85, 212);

    // left eye
    context.drawEllipse("stroke", 50, 180, 14, 10);

    // right eye
    context.drawEllipse("stroke", 120, 180, 14, 10);

    // change fill style for the irides
    context.fillStyle = "rgb(41, 91, 102)";

    // left iris
    context.drawEllipse("fill", 46, 180, 5, 8);

    // right iris
    context.drawEllipse("fill", 116, 180, 5, 8);

    // hat - brim
    context.fillStyle = "rgb(57, 102, 147)";
    context.strokeStyle = "rgb(37, 34, 30)";

    context.drawEllipse("fill", 100, 140, 85, 20);
    context.drawEllipse("stroke", 100, 140, 85, 20);

    // hat - cylinder base
    context.drawEllipse("stroke", 100, 135, 50, 15);

    // hat - cylinder
    context.drawRect("fill", 50, 35, 100, 100);
    context.drawRect("stroke", 50, 35, 100, 100);

    // hat - top
    context.drawEllipse("fill", 100, 35, 50, 15);
    context.drawEllipse("stroke", 100, 35, 50, 15);

    // clear line
    context.lineWidth = 4;
    context.strokeStyle = "rgb(57, 102, 147)";
    context.drawLine(52, 135, 148, 135);
}());