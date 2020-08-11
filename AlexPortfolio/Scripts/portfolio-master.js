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
            url: "Account/Login",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ loginInfo: loginViewModel }),
            success: (data) => {
                var object = JSON.parse(data);
                if (object.result == "success") {
                    window.location = object.url;
                } else {
                    $.each(object.errors, function (index, value) {
                        switch (value.source) {
                            case "password":
                                $('#login-password-error').text(value.message);
                                $('#login-password').addClass('is-invalid');
                                break;
                        }
                    });
                }
            },
            error: (jqXhr, status, error) => {
                var error = "jqXhr status: " + jqXhr.status + " jqXhr status text: " + jqXhr.statusText + " | status: " + status + " | error: " + error;
                $('#error-text').text(error);
                $('#error-modal').modal('show');
            }
        });
    } else {
        $('#login-password').addClass('is-invalid');
    }
});

$('#signup-submit').on('click', () => {
    var $form = $('#signup-form');

    if ($form.get(0).checkValidity()) {

        var registerViewModel = {
            Email: $('#signup-email').val(),
            Password: $('#signup-password').val(),
            ConfirmPassword: $('#signup-confirm-password').val(),
        };

        $.ajax({
            type: "POST",
            url: "/Account/Register",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ registerInfo: registerViewModel }),
            success: (data) => {
                var object = JSON.parse(data);
                if (object.result == "success") {
                    window.location = object.url;
                } else {
                    $.each(object.errors, function (index, value) {
                        switch (value.source) {
                            case "email":
                                $('#signup-email-error').text(value.message);
                                $('#signup-email').addClass('is-invalid');
                                break;

                            case "password":
                                $('#signup-password-error').text(value.message);
                                $('#signup-password').addClass('is-invalid');
                                break;

                            case "confirmpassword":
                                $('#signup-confirm-password-error').text(value.message);
                                $('#signup-confirm-password').addClass('is-invalid');
                                break;

                            case "signin":
                                $('#signup-password-error').text(value.message);
                                $('#signup-password').addClass('is-invalid');
                                break;
                        }
                    });
                }
            },
            error: (jqXhr, status, error) => {
                var error = "jqXhr status: " + jqXhr.status + " jqXhr status text: " + jqXhr.statusText + " | status: " + status + " | error: " + error;
                $('#error-text').text(error);
                $('#error-modal').modal('show');
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

$('.signout-submit').on('click', () => {
    $.ajax({
        type: "POST",
        url: "/Account/SignOut",
        contentType: 'application/json; charset=utf-8',
        success: (data) => {
            var object = JSON.parse(data);
            if (object.result == "success") {
                window.location = object.url;
            }
        },
        error: (jqXhr, status, error) => {
            alert("jqXhr status: " + jqXhr.status + " | status: " + status + " | error: " + error);
        }
    });
});

$('.editor-collapse').on('hidden.bs.collapse', function () {
    $('#edit-link').css('display', 'inline-block');
    $('.dashboard-apply-changes').css('display', 'none');
    $('#home-greeting-input').val('');
    $('#home-intro-input').val('');
});

$('.editor-collapse').on('show.bs.collapse', function () {
    $('#home-greeting-input').val($('#home-greeting').text());
    $('#home-intro-input').val($('#home-intro').text());
});

$('.editor-collapse').on('shown.bs.collapse', function () {
    $('#edit-link').css('display', 'none');
    $('.dashboard-apply-changes').css('display', 'inline-block');
});