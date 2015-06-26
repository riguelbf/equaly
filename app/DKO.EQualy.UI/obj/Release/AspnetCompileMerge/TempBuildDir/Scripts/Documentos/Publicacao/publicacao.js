var publicacao = function () {

    var tipoArmazenamento = $('#hfTipoArmazenamento').val();

    return {
        inicializaFormulario: function () {
            
            $('#txtDataPublicacao').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR' }).inputmask('dd/mm/yyyy');
            $('#txtDataValidade').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR' }).inputmask('dd/mm/yyyy');

            if (tipoArmazenamento == 2) {

                //habilito
                $("#txtLocalFisico").removeAttr('readonly');
                $("#txtNumeroCopia").removeAttr('readonly');
                $("#txtCopiaControlada").removeAttr('readonly');
                $("#txtCopiaControlada").removeAttr('disabled');

                //adiciono required
                $("#txtLocalFisico").attr('required', 'required').attr('title', 'Campo obrigatório');
                $("#txtNumeroCopia").attr('required', 'required').attr('title', 'Campo obrigatório');
                $("#txtCopiaControlada").attr('required', 'required').attr('title', 'Campo obrigatório');
            }
            
        }
    };
}();

$(document).ready(function () {

    publicacao.inicializaFormulario();
});

//functions

//functions
function obterResultadoFase5Success(data) {
    $('#modalManterDocumento').hide();
    openDialogSuccess(data, 'Publicação de documento');
};

function obterResultadoFase5Error(data) {
    openDialogError(data, 'Erro ao tentar realizar a publicação do documento');
};