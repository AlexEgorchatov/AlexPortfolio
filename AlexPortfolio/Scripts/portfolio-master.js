$(() => {
    $('[data-toggle="tooltip"]').tooltip();
});

$("#login-button").on('click', () => {
    var $form = $('#login-form');
    //if ($form.validateForm()) {
        var loginViewModel = {
            Password: $('#password').val(),
            RememberMe: $('#remember-me').is(':checked') ? true : false,
            ReturnUrl: "/Home"
        };

        await $.ajax({
            type: "POST",
            url: "/Account/Login",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ parameters: loginViewModel }),
            success: (data) => {
                alert(data.message);
            },
            error: () => {
                alert("Failed");
            }
        });
    //}
});