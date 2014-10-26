var map;
            var currentCity = 0;
            var cities = [
                { x: 42.699595, y: 23.319855, name:"Sofia" },
                { x: 55.764213, y: 37.622223, name:"Moscow" },
                { x: 51.512161, y: -0.125198, name:"London" },
                { x: 48.859068, y: 2.35239, name:"Paris" },
                { x: 52.537108, y: 13.401718, name:"Berlin" },
                { x: 52.37518, y: 4.892921, name:"Amsterdam" },
                { x: 53.550099, y: 9.991837, name:"Hamburg" },
                { x: 59.915795, y: 10.751266, name:"Oslo" },
                { x: 40.726446, y: -74.006882, name:"New York" },
                { x: 42.37072, y: -71.062546, name:"Boston" },
            ];
            var x = cities[0].x;
            var y = cities[0].y;
            var z = 10;

            function initialize() {
                var mapOptions = {
                    zoom: z,
                    center: new google.maps.LatLng(x, y),
                    mapTypeId: google.maps.MapTypeId.HYBRID //ROADMAP
                };
                map = new google.maps.Map(document.getElementById('map-canvas'),
                    mapOptions);
            }

            document.getElementById('get-previous').addEventListener('click', function () {
                if (currentCity == 0) {
                    currentCity = cities.length - 1;
                }
                else {
                    currentCity--;
                }
                goToCity();
            }, false);

            document.getElementById('get-next').addEventListener('click', function () {
                if (currentCity == cities.length - 1) {
                    currentCity = 0;
                }
                else {
                    currentCity++;
                }
                goToCity();
            }, false);

            goToCity = function () {

                x = cities[currentCity].x;
                y = cities[currentCity].y;

                if (isNaN(x) || isNaN(y) || isNaN(z)) {
                    alert("Invalid parameters. Please, enter numbers!");
                }
                else {
                    var pos = new google.maps.LatLng(x, y);
                    map.panTo(pos);
                    map.setZoom(z);
                }
            }
            google.maps.event.addDomListener(window, 'load', initialize());

            (function () {
                var container = document.getElementById("cities");
                for (var i = 0; i < cities.length; i++) {
                    var link = document.createElement("a");
                    link.id = cities[i].name;
                    link.innerHTML = cities[i].name;
                    container.appendChild(link);
                    link.addEventListener('click', function (e) {
                        for (var j = 0; j < cities.length; j++) {
                            if (cities[j].name == e.target.id) {
                                currentCity = j;
                                break;
                            }
                        }
                        goToCity();
                    }, false);

                    
                }
            })();