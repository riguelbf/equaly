
// string da div modal confirm para as grids
function getDivModalConfirm(msg, title) {
    
    var dialogConfirm = '<div id="modalConfirm" class="modal hide fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel3" aria-hidden="false" style="display: block;">';
    dialogConfirm += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button><h3 id="myModalLabel3">' + title + '</h3></div>';
    dialogConfirm += '<div class="modal-body"><p>' + msg + '</p></div>';
    dialogConfirm += '<div class="modal-footer"><button class="btn" data-dismiss="modal" aria-hidden="true"><i class="m-icon-swapleft"></i> Cancelar</button><button class="btn green" id="btnConfirmModal" data-dismiss="modal" aria-hidden="true">Sim <i class="icon-ok"></i></button></div></div>';

    return dialogConfirm;
};

//modal de mensagem de sucesso
function openDialogSuccess(msg, title) {

    if ($('#loader'))
        $('#loader').hide();

    var dialogSuccess = '<div id="modalSuccess" class="modal hide fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2" aria-hidden="false" style="display: block;">';
    dialogSuccess += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>';
    dialogSuccess += '<h3 id="myModalLabel2">' + title + '</h3></div><div class="modal-body"><p>' + msg + '</p></div>';
    dialogSuccess += '<div class="modal-footer"><button data-dismiss="modal" class="btn green">OK</button></div></div>';
    $(dialogSuccess).modal();
};

function openDialogAlert(msg, title) {

    if ($('#loader'))
        $('#loader').hide();

    var dialogSuccess = '<div id="modalAlert" class="modal hide fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2" aria-hidden="false" style="display: block;">';
    dialogSuccess += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>';
    dialogSuccess += '<h3 id="myModalLabel2">' + title + '</h3></div><div class="modal-body"><p>' + msg + '</p></div>';
    dialogSuccess += '<div class="modal-footer"><button data-dismiss="modal" class="btn yellow">OK</button></div></div>';
    $(dialogSuccess).modal();
};

//modal de mensagem de erro
function openDialogError(msg, title) {

    if ($('#loader'))
        $('#loader').hide();

    if (typeof msg == "object")
        var errorMessage = msg.responseText.substring(msg.responseText.indexOf("<title>") + 7, msg.responseText.indexOf("</title>"));
    else
        errorMessage = msg;

    var dialogError = '<div id="modalError" class="modal hide fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2" aria-hidden="false" style="display: block;">';
    dialogError += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>';
    dialogError += '<h3 id="myModalLabel2">' + title + '</h3></div><div class="modal-body"><p>' + errorMessage + '</p></div>';
    dialogError += '<div class="modal-footer"><button data-dismiss="modal" class="btn red">OK</button></div></div>';
    $(dialogError).modal();
};

//modal de confirmação de ação
function openDialogConfirm(msg, title, url) {

    if ($('#loader'))
        $('#loader').hide();

    var dialogConfirm = '<div id="modalConfirm" class="modal hide fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel3" aria-hidden="false" style="display: block;">';
    dialogConfirm += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button><h3 id="myModalLabel3">' + title + '</h3></div>';
    dialogConfirm += '<div class="modal-body"><p>' + msg + '</p></div>';

    dialogConfirm += '<div class="modal-footer"><button class="btn" data-dismiss="modal" aria-hidden="true"><i class="m-icon-swapleft"></i> Cancelar</button><button class="btn green" id="btnConfirmModal" data-dismiss="modal" aria-hidden="true">Sim <i class="icon-ok"></i></button></div></div>';

    $(dialogConfirm).modal();
    $('#btnConfirmModal').on('click', function () {
        $.ajax({
            type: "POST",
            url: url,
            success: function (data) {
                openDialogSuccess(data, title);
            },
            error: function (data) {
                openDialogError(data, 'Erro ao tentar realizar a operação');
            },
            beforeSend: function () {

            },
            complete: function () {
                //$('.loader').css({ display: "none" });
            }
        });
    });
};




