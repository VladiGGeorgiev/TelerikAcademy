/// <reference path="../libs/_references.js" />

window.viewModels = (function () {
    var ViewModels = Class.create({
        init: function (dataPersister) {
            this.data = dataPersister;
        },

        getRegister: function (successCallback) {
            var self = this;
            var registerViewModel = {
                username: "",
                password: "",
                displayName: "",
                errorMessage: "",
                register: function (ev) {
                    var selfViewModel = this;
                    return self.data.user.register(
                        selfViewModel.get("username"), selfViewModel.get("displayName"), selfViewModel.get("password"))
                    .then(successCallback, function (errorData) {
                        selfViewModel.set("errorMessage", errorData.responseJSON.Message);
                        alert(selfViewModel.get("errorMessage"));
                    });
                }
            };

            return kendo.observable(registerViewModel);
        },

        getLogin: function (successCallback) {
            var self = this;
            var loginViewModel = {
                username: "",
                password: "",
                errorMessage: "",
                login: function (ev) {
                    var selfViewModel = this;
                    return self.data.user.login(
                        selfViewModel.get("username"), selfViewModel.get("password"))
                    .then(successCallback, function (errorData) {
                        selfViewModel.set("errorMessage", errorData.responseJSON.Message);
                        alert(selfViewModel.get("errorMessage"));
                    });
                }
            };

            return kendo.observable(loginViewModel);
        },

        getCars: function () {
            var carsViewModel = {
                cars: null,
                errorMessage: "",
                getCarInfo: function (id) {
                    console.log("clicked on car");
                }
            };

            return this.data.cars.getAll().then(function (cars) {
                carsViewModel.cars = cars;
                return kendo.observable(carsViewModel);
            }, function (errorData) {
                carsViewModel.errorMessage = errorData.responseJSON.Message;
                return kendo.observable(carsViewModel);
            });
        },

        getCarStores: function () {
            var carStoresModel = {
                carStores: null,
                errorMessage: ""
            };
            var self = this;

            return self._getLocation().then(function (currentLocation) {
                var latitude = currentLocation.coords.latitude;
                var longitude = currentLocation.coords.longitude;

                return self.data.carStores.getAll(latitude, longitude).then(function (carStores) {
                    carStoresModel.carStores = carStores;
                }, function (errorData) {
                    carStoresModel.errorMessage = errorData.responseJSON.Message;
                }).then(function () {
                    return kendo.observable(carStoresModel);
                });
            }, function () {
                alert("An error has occurred while getting your current location!")
            });
        },

        _getLocation: function () {
            if (navigator.geolocation) {
                var promise = new RSVP.Promise(function (resolve, reject) {
                    navigator.geolocation.getCurrentPosition(function (data) {
                        resolve(data);
                    }, function (error) {
                        reject(error);
                    });
                })

                return promise;
            } else {
                throw new Exception("Your browser does not support Geolocation!");
            }
        }
    });

    return {
        get: function (dataPersister) {
            return new ViewModels(dataPersister);
        }
    };
})();