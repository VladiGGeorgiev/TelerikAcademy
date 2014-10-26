(function drawBicycle() {
    var context = canvasPlus("bicycle");
    context.lineWidth = 3;
    context.fillStyle = "rgb(144, 202, 215)";
    context.strokeStyle = "rgb(57, 139, 159)";

    // rear wheel
    context.drawCircle("fill", 80, 220, 75);
    context.drawCircle("stroke", 80, 220, 75);

    // front wheel
    context.drawCircle("fill", 320, 220, 75);
    context.drawCircle("stroke", 320, 220, 75);

    // head tube
    context.drawLine(320, 220, 270, 70);

    // chain stays
    context.drawLine(80, 220, 180, 220);

    // seat stays
    context.drawLine(80, 220, 118, 110);

    // seat tube
    context.drawLine(181, 221, 100, 80);

    // top tube
    context.drawLine(118, 110, 282, 110);

    // down tube
    context.drawLine(180, 220, 282, 110);

    // seat
    context.drawLine(70, 80, 130, 80);

    // handlebars
    context.drawLine(255, 90, 285, 50);
    context.drawLine(230, 95, 255, 90);
    context.drawLine(260, 55, 285, 50);

    // chain rings
    context.drawCircle("stroke", 180, 220, 20);

    // pedals
    context.drawLine(170, 258, 175, 238);
    context.drawLine(185, 202, 190, 182);
}());