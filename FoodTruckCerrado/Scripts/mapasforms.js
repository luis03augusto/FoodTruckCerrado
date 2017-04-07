    var map;
    var mark;
    function mostraLocalizacao(posicao) {

        var latitude = posicao.coords.latitude;
        var longitude = posicao.coords.longitude;

        mostrarMapa(posicao.coords);
    }

    function mostrarMapa(coords) {

        var googleLatLong = new google.maps.LatLng(coords.latitude, coords.longitude);
        var mapaOpcao =
            {
        zoom: 15,
                center: googleLatLong,
                mapTypeId: google.maps.MapTypeId.ROAMAP
            };

        var mapDiv = document.getElementById("map");
        map = new google.maps.Map(mapDiv, mapaOpcao);

        google.maps.event.addListener(map, "click", function (event) {


            var latitude = event.latLng.lat();
            var longitude = event.latLng.lng();

            var latitudeLoc = document.getElementById("latitude");
            latitudeLoc.value = latitude;
            var longitudeLoc = document.getElementById("longitude");
            longitudeLoc.value = longitude;
            map.panTo(event.latLng);

            criarMarker(event.latLng);

        });
    }

    function criarMarker(latLng) {
        if (mark) {
        mark.setPosition(latLng);
        }
        else {
        mark = new google.maps.Marker(
            {
                position: latLng,
                map: map,
                clickable: true
            });
        }

        google.maps.event.addListener(map, 'click', function (event) {
        criarMarker(event.latLng);
    });
    };

    window.onload = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(mostraLocalizacao);
        } else {
            alert("Desculpe, Este navegado não suporta geolocalização");
        }
    };