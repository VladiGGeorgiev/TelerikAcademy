/// <reference path="controller.js" />
/// <reference path="dataAccess.js" />
(function () {
    var serviceRoot = "http://localhost:22954/api/";
    
    var persister = BullsAndCows.persisters.get(serviceRoot);

    var controller = BullsAndCows.controller.get(persister);
    controller.loadUI("#wrapper");
}());