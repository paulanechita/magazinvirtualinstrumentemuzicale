$(document).ready(function () {
    $(".categoryFilterClass").on("click", function (e) {
        var valueOfSelection = $(this).attr("id");
        $.ajax({
            type: 'GET',
            url: '/Home/Filtreaza?categoriiFilterParameter=' + valueOfSelection,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#renderTablePartialView').html(result);
            }
        });
        e.preventDefault();
    });

    $(".adaugaInCosClass").on("click", function () {
        debugger;
        var idOfProdus = $(this).attr("id");
        $.ajax({
            type: 'POST',
            url: '/Home/AdaugaProdusInCos?idProdus=' + idOfProdus,
            success: function (result) {
                window.location.reload();
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

    $("#cautaButtonId").on("click", function () {
        var searchTerm = $("#searchTrimId").val();
        $.ajax({
            type: 'GET',
            url: '/AdminProduse/Search?searchTerm=' + searchTerm,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#reloadContentComenziPlasateId').html(result);
            }
        });
        $("#searchTrimId").val("");
    });

});