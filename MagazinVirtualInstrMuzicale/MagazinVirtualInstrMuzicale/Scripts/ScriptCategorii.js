$(document).ready(function () {
    $(".stergeCategorieClass").on("click", function () {
        debugger;
        var idOfCategorie = $(this).attr('id');
        $.ajax({
            type: 'POST',
            url: '/AdminProduse/DeleteCategorie?idCategorie=' + idOfCategorie,
            success: function (result) {
                //load returned data inside contentFrame DIV
                $('#renderCategoriiPartialView').html(result);
            }
        });
    });
});