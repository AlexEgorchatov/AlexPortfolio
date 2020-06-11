$(() => {
    $('[data-toggle="tooltip"]').tooltip();
});

$('.auth-modal').on('shown.bs.modal', () => {
    $('.auth-model, .show').find('.auth-input').first().trigger('focus');
});

$('.auth-modal').on('hidden.bs.modal', () => {
    $('.auth-input').removeClass('is-invalid');
    $('.auth-input').val('');
    $('.auth-input-error').text('');
    $('.auth-input:checkbox').prop('checked', false);
});

$("#login-password").keyup(() => {
    $('#login-password').removeClass('is-invalid');
    $('#login-password-error').text('Please enter the password');
});

$("#signup-email").keyup(() => {
    $('#signup-email').removeClass('is-invalid');
    $('#signup-email-error').text('Please enter the email');
});

$("#signup-password").keyup(() => {
    $('#signup-password').removeClass('is-invalid');
    $('#signup-password-error').text('Please enter the password');
});

$("#signup-confirm-password").keyup(() => {
    $('#signup-confirm-password').removeClass('is-invalid');
    $('#signup-confirm-error').text('Please confirm the password');
});

$('#login-submit').on('click', () => {
    var $form = $('#login-form');

    if ($form.get(0).checkValidity()) {

        var loginViewModel = {
            Password: $('#login-password').val(),
            RememberMe: $('#login-remember-me').is(':checked') ? true : false,
        };

        $.ajax({
            type: "POST",
            url: "/Account/Login",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ loginInfo: loginViewModel }),
            success: (data) => {
                if (data.result == "success") {
                    window.location = data.url;
                } else {
                    $('#login-password-error').text(data.message);
                    $('#login-password').addClass('is-invalid');
                }
            },
            error: (jqXhr, status, error) => {
                alert("jqXhr status: " + jqXhr.status + " | status: " + status + " | error: " + error);
            }
        });
    } else {
        $('#login-password').addClass('is-invalid');
    }
});

$('#signup-submit').on('click', () => {
    var $form = $('#signup-form');

    if ($form.get(0).checkValidity()) {

        var loginViewModel = {
            Password: $('#login-password').val(),
            RememberMe: $('#login-remember-me').is(':checked') ? true : false,
        };

        $.ajax({
            type: "POST",
            url: "/Account/Login",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ loginInfo: loginViewModel }),
            success: (data) => {
                if (data.result == "success") {
                    window.location = data.url;
                } else {
                    $('#login-password-error').text(data.message);
                    $('#login-password').addClass('is-invalid');
                }
            },
            error: (jqXhr, status, error) => {
                alert("jqXhr status: " + jqXhr.status + " | status: " + status + " | error: " + error);
            }
        });
    } else {
        if (!$('#signup-email').val()) {
            $('#signup-email').addClass('is-invalid');
        }
        if (!$('#signup-password').val()) {
            $('#signup-password').addClass('is-invalid');
        }
        if (!$('#signup-confirm-password').val()) {
            $('#signup-confirm-password').addClass('is-invalid');
        }
    }
});