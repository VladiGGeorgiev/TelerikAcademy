var VechiclesJS = (function () {

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    }

    Function.prototype.extend = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var property = arguments[i];
            this.prototype[property] = parent.prototype[property];
        }

        return this;
    }

    var AfterburnerState = Object.freeze({
        "ON": 1,
        "OFF": 2,
    });

    var AmphibianMode = Object.freeze({
        "LAND": 1,
        "WATER": 2,
    });

    var SpinDirection = Object.freeze({
        "CLOCKWISE": 1,
        "COUNTER_CLOCKWISE": 2,
    });

    // Abstract class that represent propulsion unit.
    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Not implemented function. getAcceleration from PropulsionUnit.");
    }

    //Class Wheel
    function Wheel(radius) {
        this.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        var acceleration = parseInt(2 * Math.PI * this.radius);
        return acceleration;
    }

    //Class PropellingNozzles
    function PropellingNozzle(power, afterburnerSwitch) {
        this.power = power;
        this.afterburnerSwitch = afterburnerSwitch;
    }

    PropellingNozzle.inherit(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        var acceleration;
        if (this.afterburnerSwitch == AfterburnerState.ON) {
            acceleration = this.power * 2;
        } else {
            acceleration = this.power;
        }

        return acceleration;
    }

    //Class Propeller
    function Propeller(finsNumber, spinDirection) {
        this.finsNumber = finsNumber;
        this.spinDirection = spinDirection;
    }

    Propeller.inherit(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        var acceleration = this.finsNumber;

        if (this.spinDirection === SpinDirection.COUNTER_CLOCKWISE) {
            acceleration *= -1;
        }

        return acceleration;
    }

    // CLASS HIERARCHY

    function Vechicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    Vechicle.prototype.accelerate = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    };

    function LandVechicle(speed, wheels) {
        Vechicle.call(this, speed, wheels);
    }

    LandVechicle.inherit(Vechicle);

    function AirVechicle(speed, propellingNozzle) {
        Vechicle.call(this, speed, propellingNozzle);
    }

    AirVechicle.inherit(Vechicle);

    AirVechicle.prototype.setAfterburnerState = function (afterBurnerState) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                this.propulsionUnits[i].afterburnerState = afterBurnerState;
            }
        }
    }

    function WaterVechicle(speed, propellers) {
        Vechicle.call(this, speed, propellers);
    }

    WaterVechicle.inherit(Vechicle);

    WaterVechicle.prototype.setPropellersSpinDirection = function (spinDirection) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].spinDirection = spinDirection;
            }
        }
    }

    function Amphibia(speed, propeller, wheels, mode) {
        var propulsionUnits = [];
        propulsionUnits.push(propeller);

        for (var i = 0; i < wheels.length; i++) {
            propulsionUnits.push(wheels[i]);
        }

        this.mode = mode;
        Vechicle.call(this, speed, propulsionUnits);
    }

    Amphibia.inherit(Vechicle);
    Amphibia.extend(WaterVechicle, "setPropellersSpinDirection");

    Amphibia.prototype.setMode = function (mode) {
        this.mode = mode;
    }

    Amphibia.prototype.accelerate = function () {
        if (this.mode === AmphibianMode.LAND) {
            var propulsionUnitsCount = this.propulsionUnits.length;
            for (var i = 1; i < propulsionUnitsCount; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            this.speed += this.propulsionUnits[0].getAcceleration();
        }
    }

    return {
        Amphibia: Amphibia,
        AirVechicle: AirVechicle,
        LandVechicle: LandVechicle,
        WaterVechicle: WaterVechicle,
        AfterburnerState: AfterburnerState,
        SpinDirection: SpinDirection,
        AmphibiaMode: AmphibianMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller
    }
})();


