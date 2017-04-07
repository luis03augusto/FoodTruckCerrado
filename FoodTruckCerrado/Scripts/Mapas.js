    var directionsDisplay;
    var map;

    window.onload = function initMap() {
        var lati = parseFloat($("#lat").val());
        var long = parseFloat($("#long").val());
        var nome = $("#Nome").val();
        map = new google.maps.Map(document.getElementById('map'), {
        center: {lat: lati, lng: long },
            zoom: 15
        });
        var ponto = new google.maps.LatLng(lati, long);
        var marker = new google.maps.Marker({
        position: ponto,
            map: map,
            title: nome
        });
        google.maps.event.addDomListener(document.getElementById('rota'), 'click', gerarRota);
    };

    function gerarRotas(posicao) {
        var latitude = posicao.coords.latitude;
        var longitude = posicao.coords.longitude;
        geraloc(posicao.coords);
    };

    function geraloc(coords) {
            directionsDisplay = new google.maps.DirectionsRenderer();
        var directionsService = new google.maps.DirectionsService();
            var start = new google.maps.LatLng(coords.latitude, coords.longitude);
            var lati = parseFloat($("#lat").val());
            var long = parseFloat($("#long").val());
            var end = new google.maps.LatLng(lati, long);

            var request = {
            origin: start,
                destination: end,
                travelMode: google.maps.TravelMode.DRIVING
            };
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
            directionsDisplay.setMap(map);
                } else {
                     alert("Directions Request from " + start.toUrlValue(6) + " to " + end.toUrlValue(6) + " failed: " + status);
                }
            });

    };
    function gerarRota() {

            if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(gerarRotas);
        } else {
            alert("Desculpe, Este navegado não suporta geolocalização");
        }
    };
