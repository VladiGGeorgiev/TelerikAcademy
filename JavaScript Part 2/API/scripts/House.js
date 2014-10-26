(function drawHouse() {
    var context = canvasPlus("house");
    context.lineWidth = 2;
    context.fillStyle = "#a8d";
    context.strokeStyle = "#000";

    // building
    context.drawRect("fill", 10, 130, 230, 160);
    context.drawRect("stroke", 10, 130, 230, 160);

    //door
    context.drawEllipse("stroke", 70, 240, 35, 20);
    context.drawRect("fill", 35, 240, 70, 50);
    context.drawRect("stroke", 35, 240, 70, 50);
    context.drawCircle("stroke", 60, 270, 3);
    context.drawCircle("stroke", 80, 270, 3);

    // roof
    context.drawIsosceles("fill", 125, 10, 230, 120);
    context.drawIsosceles("stroke", 125, 10, 230, 120);

    context.drawRect("fill", 170, 40, 30, 70);
    context.drawRect("stroke", 170, 40, 30, 70);
    context.drawEllipse("fill", 185, 40, 15, 5);
    context.drawEllipse("stroke", 185, 40, 15, 5);

    context.strokeStyle = "#a8d";
    context.fillStyle = "#000";
    context.strokeStyle = "#a8d";

    context.drawLine(171, 110, 199, 110);
    context.drawLine(36, 240, 104, 240);

    // windows
    context.drawRect("fill", 30, 150, 80, 50);
    context.drawRect("fill", 140, 150, 80, 50);
    context.drawRect("fill", 140, 220, 80, 50);

    // separate the window panes
    context.drawLine(70, 150, 70, 200);
    context.drawLine(180, 150, 180, 270);
    context.drawLine(30, 175, 220, 175);
    context.drawLine(140, 245, 220, 245);

    context.strokeStyle = "#000";
    context.drawLine(70, 220, 70, 290);
}());