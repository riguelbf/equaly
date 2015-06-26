var manterPlanoAcao = function () {

    var tabelaPlanoDeacao = null;

    return {
        inicializaFormulario: function () {

            tabelaPlanoDeacao = $("#tabelaPlanoDeAcao").dataTable();
            $('#txtQuando').datepicker({ language: 'pt-BR', format: 'dd/mm/yyyy' }).inputmask('dd/mm/yyyy');

            $("#txtQuantoCusta").inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 1,
                autoGroup: true,
                prefix: 'R$'
            });

            manterPlanoAcao.inicializaEventos();
        },

        inicializaEventos : function() {

            manterPlanoAcao.onAdicionarPlanoDeAcao();
        },

        adicionaEventosGrid : function() {

            manterPlanoAcao.onExcluirPlanoDeAcao();
            manterPlanoAcao.onEditarPlanoDeAcao();
        },

        //events
        onAdicionarPlanoDeAcao: function () {

            $("#btnAdicionarPlanoDeAcao").on('click', function (e) {

                var planoDeAcao = [];
                var indice = $('#hfIndice').val();

                if (indice > 0) {

                    tabelaPlanoDeacao.fnDeleteRow(indice - 1, null, true);
                }

                planoDeAcao = [

                    tabelaPlanoDeacao.fnGetData().length + 1,
                    $('#hfId').val(),
                    $("#selectQuem").val(),
                    $("#txtOque").val(),
                    $("#txtQuando").val(),
                    $("#selectQuem option:selected").text(),
                    $("#selectTipoDePlano").val(),
                    $("#selectTipoDePlano option:selected").text(),
                    $("#txtComo").val(),
                    $("#txtPorQue").val(),
                    $("#txtOnde").val(),
                    $("#txtQuantoCusta").val(),
                    $("#selectStatus").val(),
                    $("#selectStatus option:selected").text(),
                    '<button type="button" name="btnEditarPlanoDeAcao" class="btn icn-only" title="Editar o plano de ação selecionado"><i class="icon-edit"></i></button>' + ' ' +
                    '<button type="button" name="btnExcluirPlanoDeAcao" class="btn red icn-only"  title="Excluir o plano de ação selecionado"><i class="icon-trash"></i></button>'
                ];

                tabelaPlanoDeacao.fnAddData(planoDeAcao);
                tabelaPlanoDeacao.fnSetColumnVis(0, false);
                tabelaPlanoDeacao.fnSetColumnVis(1, false);
                tabelaPlanoDeacao.fnSetColumnVis(2, false);
                tabelaPlanoDeacao.fnSetColumnVis(6, false);
                tabelaPlanoDeacao.fnSetColumnVis(12, false);

                manterPlanoAcao.adicionaEventosGrid();
                $('#modalManterPlanoDeAcao').modal('hide');
            });
        },

        onExcluirPlanoDeAcao: function () {

            $.ajaxSetup({ cache: false });
            $("[name=btnExcluirPlanoDeAcao]").on('click', function (e) {
                var linha = $(this).parents('tr:first')[0];
                planoDeAcao.excluirPlanoDeAcao(linha._DT_RowIndex);
            });
        },

        onEditarPlanoDeAcao: function () {

            $.ajaxSetup({ cache: false });
            $("[name=btnEditarPlanoDeAcao]").on('click', function (e) {
                var linha = $(this).parents('tr:first')[0];
                planoDeAcao.editarPlanoDeAcao(linha._DT_RowIndex);
            });
        },
        
    };
}();


$(document).ready(function () {

    // load
    manterPlanoAcao.inicializaFormulario();
});

//functions
$.ajaxSetup({ cache: false });
function obterResultadoRegPlanAcaoError(data) {
    document.querySelector("#loader").hide();
    openDialogError(data, 'Erro ao tentar adicionar um registro');
}

function obterResultadoRegPlanAcaoSuccess(data) {
    document.querySelector("#loader").hide();
    openDialogSuccess(data, 'Registro de plano de ação');
}