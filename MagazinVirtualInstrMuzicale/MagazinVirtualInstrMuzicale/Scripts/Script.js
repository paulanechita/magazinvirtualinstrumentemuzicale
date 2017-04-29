$(document).ready(function () {
    $("#categoryFilterId").on("change", function () {
        var valueOfSelection = $(this).val();
        $.ajax({
            type: 'GET',
            url: '/Home/Filtreaza?categoriiFilterParameter=' + valueOfSelection,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#renderTablePartialView').html(result);
            }
        });
    });

    $("#adaugaCategorieId").on("click", function () {
        var valueOfCategorie = $("#valueOfCateogieId").val();
        $.ajax({
            type: 'POST',
            url: '/AdminProduse/AdaugaCategorie?numeCategorie=' + valueOfCategorie,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#renderCategoriiPartialView').html(result);
            }
        });
        $("#valueOfCateogieId").val("");
    });

    $("#adaugaProducatorId").on("click", function () {
        var valueOfProducator = $("#numeProducatorId").val();
        $.ajax({
            type: 'POST',
            url: '/AdminProduse/AdaugaProducator?numeProducator=' + valueOfProducator,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#renderProducatoriPartialView').html(result);
            }
        });
        $("#numeProducatorId").val("");
    });
});