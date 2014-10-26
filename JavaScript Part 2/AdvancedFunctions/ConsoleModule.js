var Console = (function () {
    function writeLine() {
        if (arguments.length == 0) {
            var noArgumentsException = new SyntaxError("You can't call method without parameters!");
            throw noArgumentsException;
        }

        var text = parseInput(arguments);

        console.log(text);
    }

    function writeError() {
        if (arguments.length == 0) {
            var noArgumentsException = new SyntaxError("You can't call method without parameters!");
            throw noArgumentsException;
        }

        var text = parseInput(arguments);

        console.log("Error: " + text);
    }

    function writeWarning() {
        if (arguments.length == 0) {
            var noArgumentsException = new SyntaxError("You can't call method without parameters!");
            throw noArgumentsException;
        }

        var text = parseInput(arguments);

        console.log("Warning: " + text);
    }

    function parseInput(arguments) {
        var text = arguments[0].toString();

        if (arguments.length == 1) {
            text = arguments[0];
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                text = text.replace("{" + i + "}", arguments[i + 1]);
            }
        }

        return text;
    }

    return {
        WriteLine: writeLine,
        WriteError: writeError,
        WriteWarning: writeWarning
    };

})();