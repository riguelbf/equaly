var reclamativa = function() {

    return{
        
        inicializaFormulario: function () {

            $('#txtDataCriacao').datepicker({ language: 'pt-BR', format: 'dd/mm/yyyy' }).inputmask('dd/mm/yyyy');
            $('#txtTelefone').inputmask('(99) 99999-9999');
        },

        inicializaEventos: function() {
            
        }
    };
}();   

$(document).ready(function () {

    reclamativa.inicializaFormulario();
});

//functions
function obterResultadoRegReclamativaError(data) {

    openDialogError(data, 'Erro ao tentar salvar o registro');
}

function obterResultadoRegReclamativaSuccess(data) {

    openDialogSuccess(data, 'Registro de reclamativa');
}
