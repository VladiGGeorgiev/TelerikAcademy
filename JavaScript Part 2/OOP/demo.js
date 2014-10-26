var speedUnits = " km/h";

var wheels = [
    new VechiclesJS.Wheel(8),
    new VechiclesJS.Wheel(8),
    new VechiclesJS.Wheel(8),
    new VechiclesJS.Wheel(8)
];

var propellingNozzles = [
    new VechiclesJS.PropellingNozzle(200, VechiclesJS.AfterburnerState.OFF)
];

var propellers = [
    new VechiclesJS.Propeller(5, VechiclesJS.SpinDirection.CLOCKWISE),
    new VechiclesJS.Propeller(5, VechiclesJS.SpinDirection.CLOCKWISE),
    new VechiclesJS.Propeller(5, VechiclesJS.SpinDirection.CLOCKWISE),
    new VechiclesJS.Propeller(5, VechiclesJS.SpinDirection.CLOCKWISE),
    new VechiclesJS.Propeller(5, VechiclesJS.SpinDirection.CLOCKWISE)
];

var landVehicle = new VechiclesJS.LandVechicle(50, wheels);
console.log("Land vehicle speed: " + landVehicle.speed + speedUnits);

landVehicle.accelerate();
console.log("Acceleration Land vehicle speed: " + landVehicle.speed + speedUnits);

var aircraft = new VechiclesJS.AirVechicle(100, propellingNozzles);
console.log("Aircraft speed: " + aircraft.speed + speedUnits);

aircraft.accelerate();
console.log("Aircraft speed accelerate, afterburner off: " + aircraft.speed + speedUnits);

aircraft.setAfterburnerState(VechiclesJS.AfterburnerState.ON);
aircraft.accelerate();
console.log("Aircraft speed accelerate, afterburner on: " + aircraft.speed + speedUnits);

var watercraft = new VechiclesJS.WaterVechicle(25, propellers);
console.log("Watercraft speed: " + watercraft.speed + speedUnits);

watercraft.accelerate();
console.log("Watercraft speed acceleration with propellers rotating clockwise: " + watercraft.speed + speedUnits);

watercraft.setPropellersSpinDirection(VechiclesJS.SpinDirection.COUNTER_CLOCKWISE);
watercraft.accelerate();
console.log("Watercraft speed acceleration with propellers rotating counterclockwise: " + watercraft.speed + speedUnits);

var amphibianPropellers = [
    new VechiclesJS.Propeller(4, VechiclesJS.SpinDirection.CLOCKWISE)
];

var amphibian = new VechiclesJS.Amphibia(5, amphibianPropellers, wheels, VechiclesJS.AmphibiaMode.LAND);
console.log("Amphibian speed: " + amphibian.speed + speedUnits);

amphibian.accelerate();
console.log("Amphibian speed acceleration on land: " + amphibian.speed + speedUnits);

amphibian.mode = VechiclesJS.AmphibiaMode.WATER;
amphibian.accelerate();
console.log("Amphibian speed after acceleration on water with propellers rotating clockwise: " + amphibian.speed + speedUnits);

amphibian.setPropellersSpinDirection(VechiclesJS.SpinDirection.COUNTER_CLOCKWISE);
amphibian.accelerate();
console.log("Amphibian speed after acceleration on water with propellers rotating counterclockwise: " + amphibian.speed + speedUnits);
