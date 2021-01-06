function ShowConfirmationModal(result) {
    $('#ConfirmationModalText').empty();
    $('#ConfirmationModalText').append(result.responseJSON.message);
    $('#ConfirmationModal').modal('show');
}

function CloseAddEquipementModal() {
    $('#addEquipementModal').modal('hide');
}

function CloseUpdateEquipementModal() {
    $('#updateEquipementModal').modal('hide');
    location.reload();
}


$(document).ready(function () {
    $('.openUpdateModalbtn').click(function () {
        $('#modal-equipementName').val($(this).attr('data-equipementName'));
        $('#modal-equipementId').val($(this).attr('data-equipementId'));
        $('#modal-equipementDescription').val($(this).attr('data-equipementDescription'));
        $('#modal-equipementPrice').val($(this).attr('data-equipementPrice'));
        $('#modal-secteurId').val($(this).attr('data-secteurId'));
        $('#modal-equipementImage').val($(this).attr('data-equipementImage'));
        $('#updateEquipementModal').modal('show');
    });
});