$(document).ready(function () {
    $('#registerForm').submit(function (e) {
        e.preventDefault();

        var user = {
            Name: $('#floatingName').val(),
            Surname: $('#floatingSurname').val(),
            Email: $('#floatingInput').val(),
            Password: $('#floatingPassword').val()
        };

        ajaxServices.post('/auth/RegisterUser', user, function (response) {
            var resp = JSON.parse(response)
            if (resp.errors && resp.errors.length > 0) {
                var errorMsgs = '';
                resp.errors.forEach(function (error) {
                    errorMsgs += error + '</br>';
                });
                alertMessages.error(errorMsgs);
            }
            else {
                alertMessages.success("Register succeed. Redirecting to login page.");
                setTimeout(function () {
                    document.location.href = "/auth/login";
                }, 2000);
            }
        }, function (error) {
            console.log(error)
        });
    });
});