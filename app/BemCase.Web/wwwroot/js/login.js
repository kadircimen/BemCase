$(document).ready(function () {
    $('#loginForm').submit(function (e) {
        e.preventDefault();
        var isChecked = $('#rememberCheck').prop('checked');

        var user = {
            Email: $('#email').val(),
            Password: $('#password').val(),
            RememberMe: isChecked
        };
        ajaxServices.post('/auth/LoginUser', user, function (response) {
            document.location.href = "/";
        }, function (error) {
            alertMessages.error(error.responseJSON.Detail);
        });
    });
});