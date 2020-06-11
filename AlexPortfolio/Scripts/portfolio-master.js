$(() => {
    $('[data-toggle="tooltip"]').tooltip();
});

$('.auth-modal').on('shown.bs.modal', () => {
    $('.auth-model, .show').find('.auth-input').first().trigger('focus');
    $('.auth-input-error').each(function() {
        $this = $(this);
        $this.text($this.next().text());
    });
});

$('.auth-modal').on('hidden.bs.modal', () => {
    $('.auth-input').removeClass('is-invalid');
    $('.auth-input').val('');
    $('.auth-input:checkbox').prop('checked', false);
});

$(".auth-input").keyup(function() {
    $this = $(this);
    $this.removeClass('is-invalid');
    $this.text($this.next().text());
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