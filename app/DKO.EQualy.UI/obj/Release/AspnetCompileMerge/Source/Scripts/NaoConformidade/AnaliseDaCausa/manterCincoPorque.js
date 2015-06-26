
var manterCincoPorque = function () {

    var tabela5PorQues = $('#tabela5Porques').dataTable({
        "sScrollY": "100px",
        "bPaginate": false,
        "bDestroy": true
    });

    return {

        //functions
        inicializaFormulario: function () {

            manterCincoPorque.onAdicionarPorQue();
            manterCincoPorque.onExcluirPorQue();
            manterCincoPorque.onEditarPorQue();
        },

        adicionaEventosGrid: function () {

            manterCincoPorque.onExcluirPorQue();
            manterCincoPorque.onEditarPorQue();
        },

        excluirPorque: function (index) {

            if ($('#loader'))
                $('#loader').hide();

            var title = 'Exlusão de por quê';
            var msg = 'Confirma a exclusão do por quê selecionado?';

            var dialogConfirm = getDivModalConfirm(msg, title);

            $(dialogConfirm).modal();
            $('#btnConfirmModal').on('click', function () {
                
                tabela5PorQues.fnDeleteRow(index, null, true);
            });
        },

        editarPorque: function (linha) {

            var porqueSelecionado = tabela5PorQues.fnGetData(linha);

            var cincoPorQueProjection = {
                Indice : porqueSelecionado[0],
                UsuarioDestinoId: porqueSelecionado[1],
                Id: porqueSelecionado[2],
                Pergunta: porqueSelecionado[4],
                Resposta: porqueSelecionado[5],
                NomeUsuarioDestino: porqueSelecionado[6],
            };

            var url = '/EQualy/NaoConformidades/EditarPorque';
            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ cincoPorQueProjection: cincoPorQueProjection }),
                beforeSend: function () {
                    $('#loaderModal').show();
                },
                success: function (data, textStatus, xhr) {

                    $('#loaderModal').hide();
                    event.preventDefault();
                    $('body').modalmanager();
                    $(data).load(url, '', function () {
                        $(data).modal();
                    });
                },
                error: function (xhr, textStatus, errorThrown) {

                    $('#loaderModal').hide();
                    obterResultadoObterCausaRaizError(errorThrown);
                }
            });
        },

        //events
        onExcluirPorQue: function () {

            $.ajaxSetup({ cache: false });
            $("[name=btnExcluirPorQue]").on('click', function (e) {
                var linha = $(this).parents('tr:first')[0];
                manterCincoPorque.excluirPorque(linha._DT_RowIndex);
            }); 
        },

        onEditarPorQue: function () {

            $.ajaxSetup({ cache: false });
            $("[name=btnEditarPorque]").on('click', function (e) {
                var linha = $(this).parents('tr:first')[0];
                manterCincoPorque.editarPorque(linha);
            });
        },

        onAdicionarPorQue: function () {

            $("#btnAdicionarPorQue").on('click', function (e) {

                if ($('#selUsuario').val() == 0 || $('#txtPergunta').val() == '') {
                    openDialogAlert('Usuário de destino e Pergunta são campos obrigatórios', 'Novo por quê');
                    return;
                }

                var porQue = [];
                var indice = $('#hfIndice').val();

                if (indice > 0) {

                    tabela5PorQues.fnDeleteRow(indice - 1, null, true);
                }

                porQue = [

                    tabela5PorQues.fnGetData().length + 1,
                    $('#selUsuario').val(),
                    $('#hfId').val(),
                    'Por quê',
                    $('#txtPergunta').val(),
                    $('#txtResposta').val(),
                    $("#selUsuario option:selected").text(),
                    '<button type="button" name="btnEditarPorque" class="btn icn-only" title="Editar o por quê selecionado"><i class="icon-edit"></i></button>' + ' ' +
                    '<button type="button" name="btnExcluirPorQue" class="btn red icn-only"  title="Excluir o por quê selecionado"><i class="icon-trash"></i></button>'
                ];

                tabela5PorQues.fnAddData(porQue);
                tabela5PorQues.fnSetColumnVis(0, false);
                tabela5PorQues.fnSetColumnVis(1, false);
                tabela5PorQues.fnSetColumnVis(2, false);

                manterCincoPorque.adicionaEventosGrid();
                $('#modalManterCincoPorque').modal('hide');
            });
        },
    };
}();

$(document).ready(function () {

    manterCincoPorque.inicializaFormulario();
});

