$(document).ready(function() {
    
    $("[name=btnEditar]").on('click', function (e) {
        $('#loader').show();
        e.preventDefault();
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
        openDialogConfirm('Desja confirmar a exclusão do documento?', 'Confirmar operação', url);
    });

    $('#tabelaDocumentosSolicitados').dataTable();
    $('#tabelaDocumentosDisponibilizados').dataTable();
});