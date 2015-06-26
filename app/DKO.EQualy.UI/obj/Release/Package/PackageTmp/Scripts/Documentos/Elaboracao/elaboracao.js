var elaboracao = function() {

    return {

        init: function () {

            $('#btnEnviarSolicitacao').on('click', function() {
                var inputFile = $('#postedFile');
                elaboracao.validaForm(inputFile.val());
            });

            //$("#btnEnviarSolicitacao").submit(function (e) {

            //    debugger;
            //    $('#loaderModal').show();
            //    var formData = new FormData($('#frmRevisao')[0]);
            //    var formUrl = $('#frmRevisao').attr('action');//$(this).attr("action");

            //    $.ajax(
            //    {
            //        url: formUrl,
            //        type: "POST",
            //        dataType: "json",
            //        data: formData,
            //        success: function (data, textStatus, jqXHR) {
            //            e.preventDefault();
            //            openDialogSuccess('Arquivo enviado com sucesso para revisão.', 'Revisão de arquivo');
            //        },
            //        error: function (jqXHR, textStatus, errorThrown) {
            //            e.preventDefault();
            //            openDialogError(errorThrown, 'Erro de solicitação de revisão');
            //        }
            //    });

            //    $('#loaderModal').hide();
            //    //e.preventDefault(); //STOP default action
            //    //e.unbind(); //unbind. to stop multiple form submit.
            //});
        },

        validaForm: function(nomeArquivo) {
            
            if (nomeArquivo == '') {
                event.preventDefault();
                openDialogError('Selecione um arquivo!', 'Solicitação de arquivo');
                return false;
            }

            return true;
        }
    };
}();

$(document).ready(function() {

    elaboracao.init();

});

//functions
function obterResultadoFase2Success(data) {
    event.preventDefault();
    openDialogSuccess(data, 'Revisão do documento');
};

function obterResultadoFase2Error(data) {
    event.preventDefault();
    openDialogError(data, 'Erro ao tentar solicitar a revisão do documento');
};