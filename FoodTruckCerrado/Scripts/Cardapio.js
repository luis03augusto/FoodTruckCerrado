function SalvarCardapio() {

var nome = $("#Nome").val();

var idFood = $("#FoodTruckId").val();

var url = "/Cadapio/Form";
    
$.ajax({
    url: url
    , type: "POST"
    , datatype: "json"
    , data: { Id: 0, Nome: nome, FoodTruckId: idFood }
    , success: function (data) {
        if (data.Resultado > 0) {
            ListarPratos(data.Resultado);
        }
    },
    error: function () {
        alert("erro!!");
    }
});

}
function ListarPratos(idCardapio) {
    
    var url = "/Prato/ListaPrato"
    $.ajax({
        url: url
        , type: "GET"
        , data: { id: idCardapio }
        , datatype: "html"
        , success: function (data) {
            var divPrato = $("#divPrato");
            divPrato.empty();
            divPrato.show();
            divPrato.html(data);
        }
    });
}

function SalvarPratos() {

    var nome = $("#NomePrato").val();
    var descricao = $("#Descricao").val();
    var preco = $("#Preco").val();
    var idCardapio = $("#IdCardapio").val();

    var url = "/Prato/Adiciona";

    $.ajax({
        url: url
        , type: "GET"
        , data: { nome: nome, descricao: descricao, preco: preco, cadapioId: idCardapio }
        , datatype: "html"
        , success: function (data) {
            if (data.Resultado > 0) {
                ListarPratos(idCardapio);
            }
        },
        error: function () {
            alert("Deu RUIM!!");
        }
    });
}