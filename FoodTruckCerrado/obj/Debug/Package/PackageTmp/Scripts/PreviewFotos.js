    $("#fileUpload").on("change", function () {
        if (typeof (FileReader) != "undefined") {

            var imageP = $("#imagem");
            imageP.empty();

            var reader = new FileReader();
            reader.onload = function (e) {
        $("<img/>", {
            "src": e.target.result,
            "class": "trumb-image"
        }).appendTo(imageP);
    }
            imageP.show();
            reader.readAsDataURL($(this)[0].files[0]);
        } else {
        alert("Este browser não suporta FileReader.");
    }
    })
