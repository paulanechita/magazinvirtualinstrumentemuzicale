$(document).ready(function () {
    $(".stergeProducatorClass").on("click", function () {
        var idOfProducator = $(this).attr('id');
        $.ajax({
            type: 'POST',
            url: '/AdminProduse/DeleteProducator?idProducator=' + idOfProducator,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#renderProducatoriPartialView').html(result);
            }
        });
    });
});