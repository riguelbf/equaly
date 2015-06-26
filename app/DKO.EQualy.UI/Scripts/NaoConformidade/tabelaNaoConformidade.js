$(document).ready(function () {

    $("[name=btnEditar]").on('click', function (e) {
        e.preventDefault();
        $('#loader').show();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('body').modalmanager();
            $(data).load(url, '', function () {
                $('#loader').hide();
                $(data).modal();
            });
        });
    });

    $("[name=btnExcluir]").on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        openDialogConfirm('Deseja confirmar a exclusão da não conformidade?', 'Confirmar operação', url);
    });

    $('#tabelaNaoConformidade').dataTable();
});