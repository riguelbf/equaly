var aprovacao = function () {

    return {


    };

}();


//load
$(document).ready(function () {

});

//functions global
function obterResultadoAprovacaoDocError(data) {
    openDialogError(data, 'Erro ao tentar realizar a operação.');
};

function obterResultadoAprovacaoDocSuccess(data) {
    $('#modalManterDocumento').hide();
    openDialogSuccess(data, "Revisão de documento");
};

