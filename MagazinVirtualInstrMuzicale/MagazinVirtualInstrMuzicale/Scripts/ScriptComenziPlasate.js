$(document).ready(function () {
    $(".comandaExpediataId").on("click", function () {
        var idComanda = $(this).attr("id");
        $.ajax({
            type: 'GET',
            url: '/AdminProduse/ExpediazaComanda?idComanda=' + idComanda,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#reloadContentComenziPlasateId').html(result);

            }
        });
    });

    $(".stergeComandaId").on("click", function () {
        var idComanda = $(this).attr("id");
        $.ajax({
            type: 'GET',
            url: '/AdminProduse/StergeComanda?idComanda=' + idComanda,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#reloadContentComenziPlasateId').html(result);

            }
        });
    });
});