var planoDeAcao = function () {

    var tabelaPlanosDeAcao = null;

    return {

        inicializaFormulario: function () {

            tabelaPlanosDeAcao = $('#tabelaPlanoDeAcao').dataTable();
            tabelaPlanosDeAcao.fnSetColumnVis(0, false);
            tabelaPlanosDeAcao.fnSetColumnVis(1, false);
            tabelaPlanosDeAcao.fnSetColumnVis(2, false);
            tabelaPlanosDeAcao.fnSetColumnVis(6, false);
            tabelaPlanosDeAcao.fnSetColumnVis(12, false);

            //eventos
            planoDeAcao.onNovoPlanoDeAcao();
            planoDeAcao.onExcluirPlanoDeAcao();
            planoDeAcao.onEditarPlanoDeAcao();
            planoDeAcao.onSalvarPlanoDeAcao();
        },

        //events *********************************
        onNovoPlanoDeAcao: function () {

            $("#btnNovoPlanoAcao").on('click', function (e) {
                e.preventDefault();
                var equipeEnvolvidaIds = [];

                var dadosSelecionados = $("#tabelaEquipeSelecionada").dataTable().fnGetData();
                $.each(dadosSelecionados, function (index, value) {
                    equipeEnvolvidaIds.push(parseInt(value[1]));
                });

                if (dadosSelecionados.length == 0) {
                    openDialogAlert('Nenhum usuário selecionado para a equipe envolvida.', 'Novo porque');
                    return;
                }

                var url = '/EQualy/NaoConformidades/NovoPlanoAcao';
                $.ajax({
                    url: url,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify({ equipeEnvolvidaIds: equipeEnvolvidaIds }),
                    beforeSend: function () {
                        $('#loaderModal').show();
                    },
                    success: function (data, textStatus, xhr) {

                        event.preventDefault();
                        $('body').modalmanager();
                        $(data).load(url, '', function () {
                            $(data).modal();
                        });
                    },
                    error: function (xhr, textStatus, errorThrown) {

                        $('#loaderModal').hide();
                        openDialogError(data, 'Erro - Plano de ação');
                    },
                    complete: function () {
                        $('#loaderModal').hide();
                    }
                });
            });
        },

        onSalvarPlanoDeAcao : function() {
            
            $('#btnSalvarPlanoDeAcao').on('click', function () {

                var planosDeAcoes = planoDeAcao.obterPlanosDeAcoes();
                planoDeAcao.salvarPlanoDeAcao(planosDeAcoes);
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

        //functions *********************************

        excluirPlanoDeAcao: function (index) {

            if ($('#loader'))
                $('#loader').hide();

            var title = 'Exlusão de plano de ação';
            var msg = 'Confirma a exclusão do plano de ação selecionado?';

            var dialogConfirm = getDivModalConfirm(msg, title);

            $(dialogConfirm).modal();
            $('#btnConfirmModal').on('click', function () {
                tabelaPlanosDeAcao.fnDeleteRow(index, null, true);
            });
        },

        editarPlanoDeAcao: function (index) {

            var equipeEnvolvidaIds = [];

            var dadosSelecionados = $("#tabelaEquipeSelecionada").dataTable().fnGetData();
            $.each(dadosSelecionados, function (index, value) {
                equipeEnvolvidaIds.push(parseInt(value[1]));
            });

            var planoDeAcaoSelecionado = tabelaPlanosDeAcao.fnGetData(index);

            var planoDeAcaoDto = {

                Indice : planoDeAcaoSelecionado[0],
                PlanoDeAcaoId : planoDeAcaoSelecionado[1],
                UsuarioResponsavelId : planoDeAcaoSelecionado[2],
                OQue : planoDeAcaoSelecionado[3],
                PorQue : planoDeAcaoSelecionado[9],
                Quem : planoDeAcaoSelecionado[5],
                Quando : planoDeAcaoSelecionado[4],
                Onde : planoDeAcaoSelecionado[10],
                Como : planoDeAcaoSelecionado[8],
                QuantoCusta : planoDeAcaoSelecionado[11],
                Status : planoDeAcaoSelecionado[12],
                DataCadastro : new Date(),
                DataConclusao : new Date(),
                TipoDePlanoDeAcaoId: planoDeAcaoSelecionado[6],
                TipoDePlanoDeAcao : planoDeAcaoSelecionado[7]
            };

            var url = '/EQualy/NaoConformidades/EditarPlanoDeAcao';
            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ planoDeAcaoDto: planoDeAcaoDto, equipeEnvolvidaIds: equipeEnvolvidaIds }),
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

        salvarPlanoDeAcao: function (planosDeAcoes) {

            var planoDeAcaoDto = {

                NaoConformidadeId: $("#hrIdNaoConformidade").val(),
                PlanoDeAcaoProjections: planosDeAcoes
            };

            var data = JSON.stringify({ planoDeAcaoDto: planoDeAcaoDto });

            $.ajax({
                url: '/EQualy/NaoConformidades/RegistrarPlanoAcao',
                type: 'POST',
                contentType: 'application/json',
                //dataType: "json",
                data: data,
                beforeSend: function () {
                    $('#loaderModal').show();
                },
                success: function (data, textStatus, xhr) {

                    $('#loaderModal').hide();
                    obterResultadoPlanoDeAcaoSuccess(data);

                },
                error: function (xhr, textStatus, errorThrown) {

                    $('#loaderModal').hide();
                    obterResultadoPlanoDeAcaoError(errorThrown);
                }
            });

        },

        obterPlanosDeAcoes: function () {

            var planosDeAcoes = [];

            var dadosAdicionados = tabelaPlanosDeAcao.fnGetData();
            $.each(dadosAdicionados, function (index, value) {

                var planoDeAcaoDto = {

                    Indice: value[0],
                    PlanoDeAcaoId: value[1],
                    UsuarioResponsavelId: value[2],
                    OQue: value[3],
                    PorQue: value[9],
                    Quem: value[5],
                    Quando: value[4],
                    Onde: value[10],
                    Como: value[8],
                    QuantoCusta: value[11],
                    Status: value[12],
                    DataCadastro: new Date(),
                    DataConclusao: new Date(),
                    TipoDePlanoDeAcaoId: value[6],
                    TipoDePlanoDeAcao: value[7]
                };

                planosDeAcoes.push(planoDeAcaoDto);
            });

            return planosDeAcoes;
        },
    };
}();

$(document).ready(function () {

    // load

    planoDeAcao.inicializaFormulario();

    //*********************************
});

//functions *********************************
function obterResultadoPlanoDeAcaoError(data) {

    openDialogError(data, 'Erro - Plano de ação');
};

function obterResultadoPlanoDeAcaoSuccess(data) {

    openDialogSuccess(data, 'Cadastro - Plano de ação');
}

