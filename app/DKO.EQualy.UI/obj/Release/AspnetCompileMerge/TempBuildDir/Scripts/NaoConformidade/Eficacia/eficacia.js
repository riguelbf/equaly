var eficacia = function () {

    var rating = null;

    return {

        inicializaFormulario: function () {
           
            var pontuacaoSalva = parseInt($('#hfPontuacao').val());

            rating = $('#ratingEficacia').raty({
                score: pontuacaoSalva,
                cancel: true,
               // target: '#spanTextoPontuacao',
                numberMax: 5,
                click: function (score, evt) {

                    $('#hfPontuacao').val(score);
                    eficacia.atualizarPontuacao(score);
                }
            });

            eficacia.onSalvar();
            eficacia.atualizarPontuacao(pontuacaoSalva);
        },

        atualizarPontuacao: function (pontuacao) {
            debugger;
            if (pontuacao > 0) {
                var textoPontuacao = $(rating.find('img')[pontuacao]).attr('title');
                $('#spanTextoPontuacao').text(textoPontuacao);
                return;
            }

            $('#spanTextoPontuacao').text("");
        },

        //functions
        onSalvar: function () {

            $('#frmEficacia').submit(function () {
                debugger;
                if ($('#hfPontuacao').val() == 0) {

                    openDialogAlert('É obrigatório o preenchimento da pontuação!', 'Pontuação de eficácia');
                    return false;
                }

                return true;
            });

        }
    };
}();

$(document).ready(function () {
    eficacia.inicializaFormulario();
});

function obterResultadoEficaciaError(data) {

    openDialogError(data, 'Erro - Cadastro/atualização de registro');
};

function obterResultadoEficaciaSuccess(data) {

    openDialogSuccess(data, 'Cadastro/atualização de registro');
};