$(document).ready(function () {

    // region - visao geral

    $('#tabelaTarefas').dataTable();
    $('#tabelaMensagens').dataTable();

    $.ajaxSetup({ cache: false });

    // region Tarefas 

    $("#btnNovaTarefa").on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('body').modalmanager();
            $(data).load(url, '', function () {
                $(data).modal();
            });
        });
    });

    $("#btnEditarTarefa").on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('body').modalmanager();
            $(data).load(url, '', function () {
                $(data).modal();
            });
        });
    });

    $("[name=btnExcluirTarefa]").on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        openDialogConfirm('Desja confirmar a exclusão da tarefa?', 'Confirmar operação', url);
    });


    //--------------------------------------------------------

    // region Mensagens

    $("#btnNovaMensagem").on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('body').modalmanager();
            $(data).load(url, '', function () {
                $(data).modal();
            });
        });
    });

    $("#btnEditarMensagem").on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('body').modalmanager();
            $(data).load(url, '', function () {
                $(data).modal();
            });
        });
    });

    $("#btnExcluirMensagem").click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        openDialogConfirm('Desja confirmar a exclusão?', 'Confirmar operação', url);
    });

   
    function obterResultadoAtulizarMensagemSuccess(data) {

        openDialogSuccess(data, 'Atualização de dados da mensagem');
    };

    function obterResultadoAtulizarMensagemError(data) {

        openDialogError(data, 'Erro ao tentar atualizar dados');
    };

    //--------------------------------------------------------

});

// region - Perfil
function obterResultadoAtulizarPerfilSuccess(data) {

    openDialogSuccess(data, 'Atualização de dados do perfil');
};

function obterResultadoAtulizarPerfilError(data) {

    openDialogError(data, 'Erro ao tentar atualizar dados');
};

//---------------------------------------------------

// region - atualizar senha

function obterResultadoAtulizarSenhaSuccess(data) {

    openDialogSuccess(data, 'Atualização senha');
};

function obterResultadoAtulizarSenhaError(data) {

    openDialogError(data, 'Erro ao tentar atualizar senha');
};

//---------------------------------------------------


// region - atualizar foto perfil

function obterResultadoAtulizarFotoSuccess(data) {

    openDialogSuccess(data, 'Atualização de foto do perfil');
};

function obterResultadoAtulizarFotoError(data) {

    openDialogError(data, 'Erro ao tentar atualizar sua foto');
};

//---------------------------------------------------
