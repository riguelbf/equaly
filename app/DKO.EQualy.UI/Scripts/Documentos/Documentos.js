// carregamento da pagina 
$(document).ready(function () {
    
    $('#txtDataCriacaoFiltroInicial').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR' }).inputmask('dd/mm/yyyy');
    $('#txtDataCriacaoFiltroFinal').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR' }).inputmask('dd/mm/yyyy');
});

// -----------------------------------------------------------------------------

// documentos

function obterResultadoObterDocError(data) {

    openDialogError(data, 'Erro ao tentar buscar dados');
};

//$.ajaxSetup({ cache: false });
$("#btnNovoDocumento").on('click', function (e) {
    e.preventDefault();
    var url = $(this).attr('href');
    $.get(url, function (data) {
        $('body').modalmanager();
        $(data).load(url, '', function () {
            $(data).modal();
        });
    });
});



