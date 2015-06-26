var perfil = {

    inicializaFormulario: function() {
        
        $('#txtDataConclusão').datepicker({ language: 'pt-BR', format: 'dd/mm/yyyy' }).inputmask('dd/mm/yyyy');
    }

};


$(document).ready(function () {

    perfil.inicializaFormulario();

});


function obterResultadoAtulizarMensagemSuccess(data) {

    if ($('#loaderModal'))
        $('#loaderModal').hide();

    $('responsiveManterTarefa').modal('hide');
    openDialogSuccess(data, 'Registro/Atualização de tarefa ou mensagem');
};

function obterResultadoAtulizarMensagemError(data) {

    if ($('#loaderModal'))
        $('#loaderModal').hide();

    $('responsiveManterTarefa').modal('hide');
    openDialogError(data, 'Erro ao tentar retistrar/atualizar');
};