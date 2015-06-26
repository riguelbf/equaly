var solicitacao = function () {

    var iconOk = 'icon-ok',
        iconPlay = 'icon-play';

    return {

        initForm : function() {

            var hfFaseDocumento = $('#hfFaseDocumento').val();
            $('#listaAbas li > a').on('click', function () {

                var faseTabSelecionada = $(this).attr('href').substring(7, 8);
                if (faseTabSelecionada > hfFaseDocumento && faseTabSelecionada != 6) {
                    openDialogError('Apenas fases iniciadas podem ser visualizadas!', 'Fase do documento');
                    return false;
                }

                return true;
            });
        },

        validarFase: function (faseDocumento) {
            var codigoFase = parseInt($(faseDocumento).val()) - 2;
            var listaAbas = $('#listaAbas');
            var index = 0;
            listaAbas.children().each(function () {
                debugger;
                if (index === codigoFase +1) {

                    if($(this).find('span').html() != 'Histórico')
                        $(this).find('i').attr('class', iconPlay);
                    return false;
                    
                } else if (index > codigoFase) {
                    return false;
                }
                else {

                    $(this).find('i').attr('class', iconOk);
                }

                index++;
            });
        },

        onSubmit: function () {

            $(".btn.green").click(function () {

                if (!validaFormulario());
                    return false;
            });
        },
    };
}();


//load
$(document).ready(function() {

    solicitacao.validarFase(hfFaseDocumento);
    solicitacao.initForm();

});

//functions
function obterResultadoFase1Success(data) {
    
    $('#modalManterDocumento').hide();
    openDialogSuccess(data, 'Solicitação de documento');
};

function obterResultadoFase1Error(data) {

    openDialogError(data, 'Erro ao tentar solicitar documento');
};

//events