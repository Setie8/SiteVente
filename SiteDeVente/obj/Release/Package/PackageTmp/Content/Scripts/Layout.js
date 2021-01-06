$(document).ready(function () {
    $('.btnDeconnection').click(function (event) {

        event.preventDefault();

        $.ajax({
            url: "/UserConnection/Deconnection",
            type: "POST",
            cache: false,
            async: true,
            success: function (result) {
                location.reload();
            }
        });
    });
})


function ConnectionResult(result) {
    var message;
    if (result.responseJSON.valid === false) {
        message = "Nom d'utilisateur ou mot de passe invalide !"
        CloseConfirmationConnectionModal(message);
    }
    else {
        CheckUserSession(result.responseJSON.Id)
    }
}


function RegisterResult(result) {
    var message;
    if (result.responseJSON.valid === false) {
        message = "Nom d'utilisateur ou mot de passe invalide !"
        CloseConfirmationConnectionModal(message);
    }
    else {
        CheckUserSession(result.responseJSON.Id)
    }
}


function CloseConfirmationConnectionModal(message) {
    $('#confirmationConnectionModalText').empty();
    $('#confirmationConnectionModalText').append(message);
    $('#confirmationConnectionModal').modal('show');
}

function CheckUserSession(userId) {
    $.ajax({
        url: "/ShoppingCart/CheckUserSession",
        type: "POST",
        data: { userId: userId },
        cache: false,
        async: true,
        success: function (result) {
            if (result == true) {
                location.reload();
            }
        },
        error: function (errorResult) {
        }
    });
}



