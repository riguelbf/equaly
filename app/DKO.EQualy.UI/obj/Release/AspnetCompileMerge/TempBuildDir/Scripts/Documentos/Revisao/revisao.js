var revisao = function() {

    return {


    };

}();


//load
$(document).ready(function() {
    
});

//functions global
function obterResultadoRevisaoDocError(data) {
    openDialogError(data, 'Erro ao tentar realizar a operação.');
};

function obterResultadoRevisaoDocSuccess(data) {
    $('#modalManterDocumento').hide();
    openDialogSuccess(data, "Revisão de documento");
};

