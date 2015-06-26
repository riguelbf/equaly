var analiseDaCausa = function () {

    //global
    var tabela5PorQues = {};
    var tabelaSelecionados = {};
    var tabelaDisponiveis = {};
    var spanLeft = '';
    var spanRight = '';

    return {

        //load
        inicializaFormulario: function () {

            $('#txtDataConclusao').datepicker({ language: 'pt-BR', format: 'dd/mm/yyyy' }).inputmask('dd/mm/yyyy');

            //tabelas
            tabela5PorQues = $('#tabela5Porques').dataTable({
                "scrollY": "200px",
                "scrollCollapse": true,
                "paging": false
            });

            tabela5PorQues.fnSetColumnVis(0, false);
            tabela5PorQues.fnSetColumnVis(1, false);
            tabela5PorQues.fnSetColumnVis(2, false);

            tabelaSelecionados = $('#tabelaEquipeSelecionada').dataTable({ "sDom": "" });
            tabelaDisponiveis = $('#tabelaEquipeDisponivel').dataTable({ "sDom": "" });

            //botoes
            spanLeft = '<span id="btnRemoveUsuarioDisponivel" class="btn"><i class="icon-long-arrow-left"></i></span>';
            spanRight = '<span id="btnAddUsuarioDisponivel" class="btn"><i class="icon-long-arrow-right"></i></span>';

            //eventos
            analiseDaCausa.onSelecionarUsuario();
            analiseDaCausa.onDesselecionarUsuario();
            analiseDaCausa.onNovoPorQue();
            analiseDaCausa.onSalvar();
        },

        //functions
        selecionarEquipe: function (linha) {

            var usuarioSelectionado = tabelaDisponiveis.fnGetData(linha);
            tabelaSelecionados.fnAddData([spanLeft, usuarioSelectionado[0], usuarioSelectionado[1], usuarioSelectionado[2]], true);
            tabelaDisponiveis.fnDeleteRow(tabelaDisponiveis.fnGetPosition(linha), null, true);
        },

        desvincularEquipe: function (linha) {

            var usuarioSelectionado = tabelaSelecionados.fnGetData(linha);
            tabelaDisponiveis.fnAddData([usuarioSelectionado[1], usuarioSelectionado[2], usuarioSelectionado[3], spanRight], true);
            tabelaSelecionados.fnDeleteRow(tabelaSelecionados.fnGetPosition(linha), null, true);
        },

        obterEquipeSelecionada: function () {

            var EquipeEnvolvidaSelecionada = [];


            var dadosSelecionados = tabelaSelecionados.fnGetData();
            $.each(dadosSelecionados, function (index, value) {

                var EquipeEnvolvidaProjection = {
                    id: parseInt(value[1]),
                    nome: value[2],
                    nomeSetor: value[3]
                };

                EquipeEnvolvidaSelecionada.push(EquipeEnvolvidaProjection);
            });

            return EquipeEnvolvidaSelecionada;
        },

        obterCincoPorques: function () {

            var CincoPorQue = [];

            var listaCincoPorque = tabela5PorQues.fnGetData();
            $.each(listaCincoPorque, function (index, value) {

                var CincoPorQueProjection = {
                    id: parseInt(value[2]),
                    Pergunta: value[4],
                    Resposta: value[5],
                    UsuarioDestinoId: parseInt(value[1]),
                    NomeUsuarioDestino: value[6]
                };

                CincoPorQue.push(CincoPorQueProjection);
            });

            return CincoPorQue;
        },

        //events
        onNovoPorQue: function () {

            $.ajaxSetup({ cache: false });
            $("#btnNovoPorQue").on('click', function (e) {

                var equipeEnvolvidaIds = [];

                var dadosSelecionados = tabelaSelecionados.fnGetData();
                $.each(dadosSelecionados, function (index, value) {
                    equipeEnvolvidaIds.push(parseInt(value[1]));
                });

                if (dadosSelecionados.length == 0) {
                    openDialogAlert('Nenhum usuário selecionado para a equipe envolvida.', 'Novo porque');
                    return;
                }

                var url = '/EQualy/NaoConformidades/NovoCincoPorque';
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
                        openDialogError(data, 'Erro - Novo por quê');
                    },
                    complete: function () {
                        $('#loaderModal').hide();
                    }
                });
            });
        },

        onSelecionarUsuario: function () {

            $('#tabelaEquipeDisponivel').on('click', '.icon-long-arrow-right', function () {

                var linha = $(this).parents('tr:first')[0];
                analiseDaCausa.selecionarEquipe(linha);

            });
        },

        onDesselecionarUsuario: function () {

            $('#tabelaEquipeSelecionada').on('click', '.icon-long-arrow-left', function () {

                var linha = $(this).parents('tr:first')[0];
                analiseDaCausa.desvincularEquipe(linha);

            });
        },

        onSalvar: function () {

            $('#btnAjax').on('click', function () {

                var analiseDaCausaDto = {
                    CausaRaizId: $('#hfCausaRaizId').val(),
                    NaoConformidadeId: $('#hfNaoConformidadeId').val(),
                    DataConclusao: $('#txtDataConclusao').val(),
                    DefinicaoDaCausaRaiz: $('#txtDefinicaoCausa').val()
                };

                analiseDaCausaDto.EquipeEnvolvidaSelecionada = new Array();
                analiseDaCausaDto.EquipeEnvolvidaSelecionada = analiseDaCausa.obterEquipeSelecionada();

                analiseDaCausaDto.CincoPorQue = new Array();
                analiseDaCausaDto.CincoPorQue = analiseDaCausa.obterCincoPorques();

                var data = JSON.stringify({ analiseDaCausaDto: analiseDaCausaDto });

                $.ajax({
                    url: '/EQualy/NaoConformidades/RegistrarCausaRaiz',
                    type: 'POST',
                    contentType: 'application/json',
                    //dataType: "json",
                    data: data,
                    beforeSend: function () {
                        $('#loaderModal').show();
                    },
                    success: function (data, textStatus, xhr) {

                        $('#loaderModal').hide();
                        obterResultadoObterCausaRaizSuccecss(data);

                    },
                    error: function (xhr, textStatus, errorThrown) {

                        $('#loaderModal').hide();
                        obterResultadoObterCausaRaizError(errorThrown);
                    }
                });
            });
        }
    };
}();

$(document).ready(function () {

    // load
    analiseDaCausa.inicializaFormulario();

});

function obterResultadoObterCausaRaizError(data) {

    openDialogError(data, 'Erro - Cadastro/atualização de registro');
};

function obterResultadoObterCausaRaizSuccecss(data) {

    openDialogSuccess(data, 'Cadastro/atualização de registro');
};


