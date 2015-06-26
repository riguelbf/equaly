var naoConformidade = function () {

    return {
        inicializar: function () {

            $('#txtDataInicial').datepicker({ language: 'pt-BR', format: 'dd/mm/yyyy' }).inputmask('dd/mm/yyyy');
            $('#txtDataFinal').datepicker({ language: 'pt-BR', format: 'dd/mm/yyyy' }).inputmask('dd/mm/yyyy');

            naoConformidade.inicializaEventos();
        },

        inicializaEventos : function() {

            naoConformidade.onNovaRnc();
        },

        onNovaRnc : function() {
            
            $("#btnNovaRNC").on('click', function (e) {
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
        }
    };

}();

$(document).ready(function () {

    naoConformidade.inicializar();
});

//**  functions genrais *******************************
function obterResultadoObterRncError(data) {

    openDialogError(data, 'Erro ao tentar realizar consulta');
}
